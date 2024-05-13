using NUnit.Framework;
using RecipeManager;

namespace RecipeManager.Tests
{
    [TestFixture]
    public class IngredientTests
    {
        [Test]
        public void TestCalculateTotalCalories_WithDifferentIngredients()
        {
            // Arrange
            var recipe = new Recipe("TestRecipe", null); // Using null for CaloriesExceededHandler as it's not needed for this test
            recipe.AddIngredient(new Ingredient("Ingredient1", 100, "grams", 50, "Grains")); // 100 grams of Ingredient1 with 50 calories per gram
            recipe.AddIngredient(new Ingredient("Ingredient2", 200, "ml", 30, "Fruits"));    // 200 milliliters of Ingredient2 with 30 calories per milliliter

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(100 * 50 + 200 * 30, totalCalories); // Total calories should be sum of (quantity * calorie value) for each ingredient
        }

        [Test]
        public void TestCalculateTotalCalories_WithEmptyIngredientsList()
        {
            // Arrange
            var recipe = new Recipe("TestRecipe", null); // Using null for CaloriesExceededHandler as it's not needed for this test

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(0, totalCalories); // Total calories should be 0 when there are no ingredients
        }

        // Add more test methods to cover other scenarios mentioned above
    }
}