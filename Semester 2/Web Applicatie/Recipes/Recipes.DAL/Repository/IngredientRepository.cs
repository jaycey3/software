using Recipes.DAL.Connection;
using Recipes.Logic.Models;
using System.Data.SqlClient;
using Recipes.Logic.Interfaces;

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
                        Energy = Convert.ToInt32(reader["energy"]),
                        Protein = Convert.ToDecimal(reader["protein"]),
                        Carbohydrates = Convert.ToDecimal(reader["carbohydrates"]),
                        Sugar = Convert.ToDecimal(reader["sugar"]),
                        Fat = Convert.ToDecimal(reader["fat"]),
                        SaturatedFat = Convert.ToDecimal(reader["saturated_fat"]),
                        Salt = Convert.ToDecimal(reader["salt"]),
                        Fibers = Convert.ToDecimal(reader["fibers"])
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

        public IngredientModel? UpdateIngredient(int id, string? title, int energy, decimal protein, decimal carbohydrates, decimal sugar, decimal fat, decimal saturatedfat, decimal salt, decimal fibers)
        {
            try
            {
                dataAccess.OpenConnection();
                string query = "UPDATE recipes SET title = @Title, energy = @Energy, protein = @Protein, carbohydrates = @Carbohydrates, sugar = @Sugar, fat = @Fat, saturated_fat = @SaturatedFat, salt = @Salt, fibers = @Fibers WHERE id = @Id";

                using SqlCommand command = new(query, dataAccess.Connection);

                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Energy", energy);
                command.Parameters.AddWithValue("@Protein", protein);
                command.Parameters.AddWithValue("@Carbohydrates", carbohydrates);
                command.Parameters.AddWithValue("@Sugar", sugar);
                command.Parameters.AddWithValue("@Fat", fat);
                command.Parameters.AddWithValue("@SaturatedFat", saturatedfat);
                command.Parameters.AddWithValue("@Salt", salt);
                command.Parameters.AddWithValue("@Fibers", fibers);

                command.ExecuteReader();

                IngredientModel updatedIngredient = new()
                {
                    Id = id,
                    Title = title,
                    Energy = energy,
                    Protein = protein,
                    Carbohydrates = carbohydrates,
                    Sugar = sugar,
                    Fat = fat,
                    SaturatedFat = saturatedfat,
                    Salt = salt,
                    Fibers = fibers,
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
                        Energy = Convert.ToInt32(reader["energy"]),
                        Protein = Convert.ToDecimal(reader["protein"]),
                        Carbohydrates = Convert.ToDecimal(reader["carbohydrates"]),
                        Sugar = Convert.ToDecimal(reader["sugar"]),
                        Fat = Convert.ToDecimal(reader["fat"]),
                        SaturatedFat = Convert.ToDecimal(reader["saturated_fat"]),
                        Salt = Convert.ToDecimal(reader["salt"]),
                        Fibers = Convert.ToDecimal(reader["fibers"])
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

        public IngredientModel? CreateIngredient(string? title, int energy, decimal protein, decimal carbohydrates, decimal sugar, decimal fat, decimal saturatedfat, decimal salt, decimal fibers)
        {
            try
            {
                dataAccess.OpenConnection();
                string query = "INSERT INTO recipes (title, description, time, type, img, user_id) VALUES (@Title, @Description, @Time, @Type, @Img, 1)";

                using SqlCommand command = new(query, dataAccess.Connection);

                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Energy", energy);
                command.Parameters.AddWithValue("@Protein", protein);
                command.Parameters.AddWithValue("@Carbohydrates", carbohydrates);
                command.Parameters.AddWithValue("@Sugar", sugar);
                command.Parameters.AddWithValue("@Fat", fat);
                command.Parameters.AddWithValue("@SaturatedFat", saturatedfat);
                command.Parameters.AddWithValue("@Salt", salt);
                command.Parameters.AddWithValue("@Fibers", fibers);

                command.ExecuteNonQuery();

                IngredientModel createdIngredient = new()
                {
                    Title = title,
                    Energy = energy,
                    Protein = protein,
                    Carbohydrates = carbohydrates,
                    Sugar = sugar,
                    Fat = fat,
                    SaturatedFat = saturatedfat,
                    Salt = salt,
                    Fibers = fibers,
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
