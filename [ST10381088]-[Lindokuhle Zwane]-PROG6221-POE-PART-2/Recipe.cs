using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeManager
{
    // Class representing a recipe
    public class Recipe
    {
        private List<Ingredient> Ingredients { get; set; }
        private List<RecipeStep> Steps { get; set; }
        public string Name { get; }

        // Delegate declaration
        public delegate void CaloriesExceededHandler(Recipe recipe);

        // Event to which the handler will be attached
        public event CaloriesExceededHandler CaloriesExceeded;

        // Constructor to initialize the recipe with a name and attach the delegate
        public Recipe(string name, CaloriesExceededHandler handler)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<RecipeStep>();
            CaloriesExceeded += handler; // Attach the handler to the event
        }

        // Method to add an ingredient to the recipe
        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        // Method to add a step to the recipe
        public void AddStep(RecipeStep step)
        {
            Steps.Add(step);
        }

        // Method to calculate the total calories of the recipe
        public double CalculateTotalCalories()
        {
            return Ingredients.Sum(ingredient => ingredient.Calories * ingredient.Quantity);
        }

        // Method to check if calories exceed 300 and invoke the delegate if they do
        public void CheckCalories()
        {
            double totalCalories = CalculateTotalCalories();
            if (totalCalories > 300)
            {
                CaloriesExceeded?.Invoke(this); // Invoke the delegate if it's not null
            }
        }

        // Method to display recipe details
        public void DisplayDetails()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"- {ingredient}");
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Steps:");
            int stepNumber = 1;
            foreach (var step in Steps)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"{stepNumber++}. {step}");
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Total Calories: {CalculateTotalCalories()}");
        }
    }
}