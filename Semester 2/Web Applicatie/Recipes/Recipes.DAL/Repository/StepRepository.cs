using Recipes.DAL.Connection;
using Recipes.Logic.Interfaces;
using Recipes.Logic.Models;
using System.Data.SqlClient;

namespace Recipes.DAL.Repository
{
    public class StepRepository : IStepRepository
    {
        private readonly DataAccess dataAccess;

        public StepRepository()
        {
            dataAccess = new();
        }

        public List<StepModel>? GetAllSteps(int recipeId)
        {
            List<StepModel> method = [];
            try
            {
                dataAccess.OpenConnection();
                string query = "SELECT * FROM steps WHERE recipe_id = @RecipeId";

                using SqlCommand command = new(query, dataAccess.Connection);
                command.Parameters.AddWithValue("@RecipeId", recipeId);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    StepModel step = new()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Order = Convert.ToInt32(reader["order"]),
                        Description = reader["description"].ToString(),
                        RecipeId = Convert.ToInt32(reader["recipe_id"])
                    };
                    method.Add(step);
                }
                return method;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                dataAccess.CloseConnection();
            }
        }

        public StepModel? UpdateStep(int id, int order, string? description)
        {
            try
            {
                dataAccess.OpenConnection();
                string query = "UPDATE steps SET order = @Order, description = @Description WHERE id = @Id";

                using SqlCommand command = new(query, dataAccess.Connection);

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Order", order);
                command.Parameters.AddWithValue("@Description", description);

                command.ExecuteReader();

                StepModel updatedStep = new()
                {
                    Id = id,
                    Order = order,
                    Description = description,
                };

                return updatedStep;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                dataAccess.CloseConnection();
            }
        }

        public StepModel? CreateStep(int order, string description, int recipeId)
        {
            try
            {
                dataAccess.OpenConnection();
                string query = "INSERT INTO recipes (order, description, recipe_id) VALUES (@Order, @Description, @RecipeId)";

                using SqlCommand command = new(query, dataAccess.Connection);

                command.Parameters.AddWithValue("@Order", order);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@RecipeId", recipeId);

                command.ExecuteNonQuery();

                StepModel createdStep = new()
                {
                    Order = order,
                    Description = description,
                    RecipeId = recipeId
                };
                return createdStep;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                dataAccess.CloseConnection();
            }
        }

        public void DeleteStep(int id)
        {
            try
            {
                dataAccess.OpenConnection();
                string query = "DELETE FROM steps WHERE id = @Id";

                using SqlCommand command = new(query, dataAccess.Connection);

                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error while trying to delete the recipe: " + ex);
            }
            finally
            {
                dataAccess.CloseConnection();
            }
        }

    }
}
