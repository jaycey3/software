using Recipes.DAL.Connection;
using Recipes.Logic.Models;
using System.Data.SqlClient;
using Recipes.Logic.Interfaces;
using System.Data;

namespace Recipes.DAL.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly DataAccess dataAccess;

        public IngredientRepository()
        {
            dataAccess = new();
        }

        public List<IngredientModel>? GetAllIngredients()
        {
            List<IngredientModel> ingredients = [];
            try
            {
                dataAccess.OpenConnection();
                string query = "SELECT * FROM ingredients";

                using SqlCommand command = new(query, dataAccess.Connection);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IngredientModel ingredient = new()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Title = reader["title"].ToString(),
                        Type = reader["type"].ToString()
                    };
                    ingredients.Add(ingredient);
                }
                return ingredients;
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

        public IngredientModel? UpdateIngredient(int id, string? title, string? type)
        {
            try
            {
                dataAccess.OpenConnection();
                string query = "UPDATE ingredients SET title = @Title, type = @Type WHERE id = @Id";

                using SqlCommand command = new(query, dataAccess.Connection);

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Type", type);

                command.ExecuteReader();

                IngredientModel updatedIngredient = new()
                {
                    Id = id,
                    Title = title,
                    Type = type
                };

                return updatedIngredient;
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

        public IngredientModel? GetIngredientById(int id)
        {
            try
            {
                dataAccess.OpenConnection();
                string query = "SELECT * from ingredients WHERE id = @Id";

                using SqlCommand command = new(query, dataAccess.Connection);

                command.Parameters.AddWithValue("@Id", id);

                using SqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.Read())
                {
                    IngredientModel ingredient = new()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Title = reader["title"].ToString(),
                        Type = reader["type"].ToString()
                    };
                    return ingredient;
                }
                return null;

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

        public IngredientModel? CreateIngredient(string? title, string? type)
        {
            try
            {
                dataAccess.OpenConnection();
                string query = "INSERT INTO ingredients (title, type) VALUES (@Title, @Type)";

                using SqlCommand command = new(query, dataAccess.Connection);

                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Type", type);

                command.ExecuteNonQuery();

                IngredientModel createdIngredient = new()
                {
                    Title = title,
                    Type = type
                };

                return createdIngredient;

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

        public void DeleteIngredient(int id)
        {
            try
            {
                dataAccess.OpenConnection();
                string query = "DELETE FROM ingredients WHERE id = @Id";

                using SqlCommand command = new(query, dataAccess.Connection);

                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                dataAccess.CloseConnection();
            }
        }

    }
}
