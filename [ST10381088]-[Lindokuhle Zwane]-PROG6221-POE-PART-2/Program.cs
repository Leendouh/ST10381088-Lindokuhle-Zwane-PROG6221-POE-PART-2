using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeManager
{
    // Main program class
    public class Program
    {
        // List to store all recipes
        private List<Recipe> recipes = new List<Recipe>();

        // Food groups
        private readonly List<string> foodGroups = new List<string> { "Grains", "Vegetables", "Fruits", "Proteins", "Dairy", "Fats", "Water" };

        // Method to start the program
        public void Start()
        {
            Console.WriteLine("++++++++++ RECIPE MANAGER ++++++++++");
            bool running = true;
            while (running)
            {
                // Display menu options
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Choose an option:");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("1. Enter a new recipe");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("3. Exit");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");

                // Get user choice
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        EnterRecipe();
                        break;
                    case "2":
                        DisplayAllRecipes();
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
                // Prompt the user to press any key to display the menu again
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Press any key to display the menu again...");
                Console.ReadKey(true);
            }
        }

        // Method to allow user to enter a new recipe
        private void EnterRecipe()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Enter details for the new recipe:");

            // Get recipe name
            Console.WriteLine("-------------------------------------");
            Console.Write("Enter recipe name: ");
            string name = Console.ReadLine();

            // Create new recipe
            Recipe recipe = new Recipe(name, RecipeCaloriesExceededHandler);

            // Get number of ingredients
            Console.WriteLine("-------------------------------------");
            int ingredientCount = GetPositiveIntegerInput("Enter the number of ingredients: ");

            // Enter ingredients
            for (int i = 0; i < ingredientCount; i++)
            {
                // Get ingredient details
                Console.WriteLine("-------------------------------------");
                Console.Write($"Enter name of ingredient {i + 1}: ");
                string ingredientName = Console.ReadLine();

                double quantity = GetPositiveDoubleInput($"Enter quantity of {ingredientName} (NB. A double): ");

                Console.WriteLine("-------------------------------------");
                Console.Write($"Enter unit of measurement for {ingredientName} (e.g. Tablespoon): ");
                string unit = Console.ReadLine();

                double calories = GetPositiveDoubleInput($"Enter calories per unit of {ingredientName}: ");

                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Select food group:");
                for (int j = 0; j < foodGroups.Count; j++)
                {
                    Console.WriteLine($"{j + 1}. {foodGroups[j]}");
                }
                int selectedFoodGroupIndex = GetFoodGroupSelection();

                // Create and add ingredient to recipe
                Ingredient ingredient = new Ingredient(ingredientName, quantity, unit, calories, foodGroups[selectedFoodGroupIndex - 1]);
                recipe.AddIngredient(ingredient);
            }

            // Get number of steps
            Console.WriteLine("-------------------------------------");
            int stepCount = GetPositiveIntegerInput("Enter the number of steps: ");

            // Enter steps
            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine("-------------------------------------");
                Console.Write($"Enter step {i + 1} description: ");
                string description = Console.ReadLine();
                RecipeStep step = new RecipeStep(description);
                recipe.AddStep(step);
            }

            // Add recipe to list and check calories
            recipes.Add(recipe);
            recipe.CheckCalories();
        }

        // Method to display all recipes
        private void DisplayAllRecipes()
        {
            // Check if recipes exist
            if (recipes.Count == 0)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("No recipes available.");
                return;
            }

            // Sort recipes alphabetically by name
            recipes.Sort((r1, r2) => string.Compare(r1.Name, r2.Name, StringComparison.Ordinal));

            // Display all recipes
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Recipes:");

            int index = 1;
            foreach (var recipe in recipes)
            {
                Console.WriteLine($"{index++}. {recipe.Name}");
            }

            // Get user choice to display recipe details
            Console.WriteLine("-------------------------------------");
            Console.Write("Enter the number of the recipe to display details: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= recipes.Count)
            {
                recipes[choice - 1].DisplayDetails();
            }
            else
            {
                Console.WriteLine("-------------------------------------");
                Console.Write("Invalid input.");
            }
        }

        // Method to handle recipe calories exceeding 300
        private void RecipeCaloriesExceededHandler(Recipe recipe)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"WARNING: {recipe.Name} exceeds 300 calories.");
        }

        // Helper method to get a positive integer input with a limited number of attempts
        private int GetPositiveIntegerInput(string message)
        {
            int attempts = 4;
            int value;
            do
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out value) && value > 0)
                {
                    return value;
                }
                attempts--;
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"Invalid input. Please enter a positive integer. {attempts} Attempts left: ");
                Console.WriteLine("-------------------------------------");
            } while (attempts > 0);
            // If all attempts fail, terminate the program or handle the situation accordingly
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Maximum number of attempts reached. Exiting program.");
            Environment.Exit(0);
            return 0; // This line is not reachable, added for compilation
        }

        // Helper method to get a positive double input
        private double GetPositiveDoubleInput(string message)
        {
            double value;
            do
            {
                Console.WriteLine("-------------------------------------");
                Console.Write(message);
            } while (!double.TryParse(Console.ReadLine(), out value) || value <= 0);
            return value;
        }

        // Helper method to select food group
        private int GetFoodGroupSelection()
        {
            int selectedGroup;
            while (!int.TryParse(Console.ReadLine(), out selectedGroup) || selectedGroup < 1 || selectedGroup > foodGroups.Count)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Invalid input. Please select a valid food group number.");
                Console.WriteLine("-------------------------------------");
            }
            return selectedGroup;
        }

        // Main method
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }
    }

}
