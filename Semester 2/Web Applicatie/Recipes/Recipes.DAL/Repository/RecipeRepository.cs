using System.Data.SqlClient;
using Recipes.Logic.Interfaces;
using Recipes.Logic.Models;

namespace Recipes.DAL.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly string _connectionString;

        public RecipeRepository()
        {
            _connectionString = "Server=mssqlstud.fhict.local;Database=dbi538222;Integrated Security=False;User Id=dbi538222;Password=KCR3ank4eba_her-exb;MultipleActiveResultSets=true";
        }

        public List<RecipeModel> GetAllRecipes()
        {
            List<RecipeModel> recipes = [];

            using (SqlConnection connection = new(_connectionString))
            {
                string query = "SELECT * FROM recipes";

                using SqlCommand command = new(query, connection);
                connection.Open();

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
                        UserId = Convert.ToInt32(reader["user_id"])
                    };
                    recipes.Add(recipe);
                }
            }
            return recipes;
        }

        public RecipeModel UpdateRecipe(int id, string? title, string? description, int time, string? type, string? img)
        {
            using SqlConnection connection = new(_connectionString);
            string query = "UPDATE recipes SET title = @Title, description = @Description, time = @Time, type = @Type, img = @Img WHERE id = @Id";

            using SqlCommand command = new(query, connection);
            connection.Open();

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

        public RecipeModel? GetRecipeById(int id)
        {
            using SqlConnection connection = new(_connectionString);
            string query = "SELECT * FROM recipes WHERE id = @Id";

            using SqlCommand command = new(query, connection);
            connection.Open();

            command.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = command.ExecuteReader();
            if (reader != null && reader.Read())
            {
                RecipeModel  recipe = new()
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Title = reader["title"].ToString(),
                    Description = reader["description"].ToString(),
                    Time = Convert.ToInt32(reader["time"]),
                    Type = reader["type"].ToString(),
                    Img = reader["img"].ToString(),
                    UserId = Convert.ToInt32(reader["user_id"])
                };

                return recipe;
            }
            return null;
        }

        public RecipeModel? CreateRecipe(string title, string description, int time, string type, string img)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                string query = "INSERT INTO recipes (title, description, time, type, img, user_id) VALUES (@Title, @Description, @Time, @Type, @Img, 1)";

                using SqlCommand command = new(query, connection);
                connection.Open();

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
                Console.WriteLine("There was an error while trying to create a new recipe " + ex);
                return null;
            } 
        }

        public void DeleteRecipe(int id)
        {
            try
            {
                using SqlConnection connection = new(_connectionString);
                string query = "DELETE FROM recipes WHERE id = @Id";

                using SqlCommand command = new(query, connection);
                connection.Open();

                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error while trying to delete the recipe: " + ex);
            }
        }

    }
}
