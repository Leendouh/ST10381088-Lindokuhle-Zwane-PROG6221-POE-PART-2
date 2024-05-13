using System;


namespace RecipeManager
{
    // Class representing an ingredient in a recipe
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }
        public string Unit { get; set; } 

        // Constructor to initialize the ingredient with name, quantity, calories, and food group
        public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        // Override ToString method to return a formatted string representation of the ingredient
        public override string ToString()
        {
            return $"{Quantity} {Unit} of {Name} ({Calories} calories)";
        }
    }
}