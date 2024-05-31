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
                        UserName = reader["first_name"].ToString(),
                        Steps = GetStepsByRecipeId(id),
                        Ingredients = GetRecipeIngredients(id)
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
                string query = "INSERT INTO recipes (title, description, time, type, img, user_id) VALUES (@Title, @Description, @Time, @Type, @Img, 1); SELECT SCOPE_IDENTITY();";

                using SqlCommand command = new(query, dataAccess.Connection);

                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@Time", time);
                command.Parameters.AddWithValue("@Type", type);
                command.Parameters.AddWithValue("@Img", img);

                int insertedId = Convert.ToInt32(command.ExecuteScalar());

                RecipeModel recipe = new()
                {
                    Id = insertedId,
                    Title = title,
                    Description = description,
                    Time = time,
                    Type = type,
                    Img = img,
                };

                return recipe;
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

        private List<StepModel>? GetStepsByRecipeId(int recipeId)
        {
            List<StepModel> steps = [];
            try
            {
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
                    steps.Add(step);
                }
                return steps;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private List<RecipeIngredientModel>? GetRecipeIngredients(int recipeId)
        {
            List<RecipeIngredientModel> ingredients = [];
            try
            {
                string query = "SELECT ri.recipe_id, ri.ingredient_id, ri.quantity, ri.unit, i.title " +
                               "FROM recipe_ingredients ri " +
                               "JOIN ingredients i ON ri.ingredient_id = i.id " +
                               "WHERE ri.recipe_id = @RecipeId";

                using SqlCommand command = new(query, dataAccess.Connection);

                command.Parameters.AddWithValue("@RecipeId", recipeId);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    RecipeIngredientModel ingredient = new()
                    {
                        RecipeId = Convert.ToInt32(reader["recipe_id"]),
                        IngredientId = Convert.ToInt32(reader["ingredient_id"]),
                        Quantity = Convert.ToDecimal(reader["quantity"]),
                        Unit = reader["unit"].ToString(),
                        Title = reader["title"].ToString()
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
        }
    }
}
