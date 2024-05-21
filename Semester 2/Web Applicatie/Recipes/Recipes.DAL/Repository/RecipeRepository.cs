using System.Data.SqlClient;
using Recipes.DAL.Connection;
using Recipes.Logic.Interfaces;
using Recipes.Logic.Models;

namespace Recipes.DAL.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly DataAccess dataAccess;

        public RecipeRepository()
        {
            dataAccess = new();
        }

        public List<RecipeModel>? GetAllRecipes()
        {
            List<RecipeModel> recipes = [];
            try
            {
                dataAccess.OpenConnection();
                string query = "SELECT r.id, r.title, r.description, r.time, r.type, r.img, r.user_id, u.first_name " +
                "FROM recipes r " +
                "JOIN users u ON r.user_id = u.id";

                using SqlCommand command = new(query, dataAccess.Connection);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    RecipeModel recipe = new()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Title = reader["title"].ToString(),
                        Description = reader["description"].ToString(),
                        Time = Convert.ToInt32(reader["time"]),
                        Type = reader["type"].ToString(),
                        Img = reader["img"].ToString(),
                        UserId = Convert.ToInt32(reader["user_id"]),
                        UserName = reader["first_name"].ToString()
                    };
                    recipes.Add(recipe);
                }
                return recipes;
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

        public RecipeModel? UpdateRecipe(int id, string? title, string? description, int time, string? type, string? img)
        {
            try
            {
                dataAccess.OpenConnection();
                string query = "UPDATE recipes SET title = @Title, description = @Description, time = @Time, type = @Type, img = @Img WHERE id = @Id";

                using SqlCommand command = new(query, dataAccess.Connection);

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@Time", time);
                command.Parameters.AddWithValue("@Type", type);
                command.Parameters.AddWithValue("@Img", img);

                command.ExecuteReader();

                RecipeModel updatedRecipe = new()
                {
                    Id = id,
                    Title = title,
                    Description = description,
                    Time = time,
                    Type = type,
                    Img = img,
                };

                return updatedRecipe;
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

        public RecipeModel? GetRecipeById(int id)
        {
            try
            {
                dataAccess.OpenConnection();
                string query = "SELECT r.id, r.title, r.description, r.time, r.type, r.img, r.user_id, u.first_name " +
                "FROM recipes r " +
                "JOIN users u ON r.user_id = u.id " +
                "WHERE r.id = @Id";

                using SqlCommand command = new(query, dataAccess.Connection);

                command.Parameters.AddWithValue("@Id", id);

                using SqlDataReader reader = command.ExecuteReader();
                if (reader != null && reader.Read())
                {
                    RecipeModel recipe = new()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Title = reader["title"].ToString(),
                        Description = reader["description"].ToString(),
                        Time = Convert.ToInt32(reader["time"]),
                        Type = reader["type"].ToString(),
                        Img = reader["img"].ToString(),
                        UserId = Convert.ToInt32(reader["user_id"]),
                        UserName = reader["first_name"].ToString()
                    };

                    return recipe;
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

        public RecipeModel? CreateRecipe(string title, string description, int time, string type, string img)
        {
            try
            {
                dataAccess.OpenConnection();
                string query = "INSERT INTO recipes (title, description, time, type, img, user_id) VALUES (@Title, @Description, @Time, @Type, @Img, 1)";

                using SqlCommand command = new(query, dataAccess.Connection);

                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@Time", time);
                command.Parameters.AddWithValue("@Type", type);
                command.Parameters.AddWithValue("@Img", img);

                command.ExecuteNonQuery();

                RecipeModel createdRecipe = new()
                {
                    Title = title,
                    Description = description,
                    Time = time,
                    Type = type,
                    Img = img,
                };

                return createdRecipe;

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

        public void DeleteRecipe(int id)
        {
            try
            {
                dataAccess.OpenConnection();
                string query = "DELETE FROM recipes WHERE id = @Id";

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
