﻿using Recipes.DAL.Connection;
using Recipes.Logic.Interfaces;
using Recipes.Logic.Models;
using System.Data.SqlClient;

namespace Recipes.DAL.Repository
{
    public class RecipeIngredientRepository : IRecipeIngredientRepository
    {
        private readonly DataAccess dataAccess;

        public RecipeIngredientRepository()
        {
            dataAccess = new();
        }
        public List<RecipeIngredientModel>? GetAllIngredients(int recipeId)
        {
            List<RecipeIngredientModel> ingredients = [];
            try
            {
                dataAccess.OpenConnection();
                string query = "SELECT * FROM recipe_ingredients WHERE recipe_id = @RecipeId";

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
                        Unit = reader["unit"].ToString()
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

        public RecipeIngredientModel? UpdateIngredient(int recipeId, int oldIngredientId, int newIngredientId, decimal? quantity, string? unit)
        {
            try
            {
                dataAccess.OpenConnection();
                string query = "UPDATE recipe_ingredients SET ingredient_id = @NewIngredientId, quantity = @Quantity, unit = @Unit WHERE recipe_id = @RecipeId AND ingredient_id = @OldIngredientId";

                using SqlCommand command = new(query, dataAccess.Connection);

                command.Parameters.AddWithValue("@RecipeId", recipeId);
                command.Parameters.AddWithValue("@OldIngredientId", oldIngredientId);
                command.Parameters.AddWithValue("@NewIngredientId", newIngredientId);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@Unit", unit);

                command.ExecuteReader();

                RecipeIngredientModel updatedIngredient = new()
                {
                    RecipeId = recipeId,
                    NewIngredientId = newIngredientId,
                    Quantity = quantity,
                    Unit = unit
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

        public RecipeIngredientModel? AddIngredient(int recipeId, int ingredientId, decimal? quantity, string? unit)
        {
            try
            {
                dataAccess.OpenConnection();
                string query = "INSERT INTO recipe_ingredients (recipe_id, ingredient_id, quantity, unit) VALUES(@RecipeId, @IngredientId, @Quantity, @Unit)";

                using SqlCommand command = new(query, dataAccess.Connection);

                command.Parameters.AddWithValue("@RecipeId", recipeId);
                command.Parameters.AddWithValue("@IngredientId", ingredientId);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@Unit", unit);

                command.ExecuteNonQuery();

                RecipeIngredientModel addedIngredient = new()
                {
                    RecipeId = recipeId,
                    IngredientId = ingredientId,
                    Quantity = quantity,
                    Unit = unit
                };

                return addedIngredient;

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

        public void RemoveIngredient(int recipeId, int ingredientId)
        {
            try
            {
                dataAccess.OpenConnection();
                string query = "DELETE FROM recipe_ingredients WHERE recipe_id = @RecipeId AND ingredient_id = @IngredientId";

                using SqlCommand command = new(query, dataAccess.Connection);

                command.Parameters.AddWithValue("@RecipeId", recipeId);
                command.Parameters.AddWithValue("@IngredientId", ingredientId);

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

        public void DeleteRecipeIngredients(int recipeId)
        {
            try
            {
                dataAccess.OpenConnection();
                string query = "DELETE FROM recipe_ingredients WHERE recipe_id = @RecipeId";

                using SqlCommand command = new(query, dataAccess.Connection);

                command.Parameters.AddWithValue("@RecipeId", recipeId);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error while trying to delete ingredients: " + ex);
            }
            finally
            {
                dataAccess.CloseConnection();
            }
        }
    }
}
