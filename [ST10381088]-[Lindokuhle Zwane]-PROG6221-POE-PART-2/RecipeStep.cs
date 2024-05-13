using System;

namespace RecipeManager
{
    // Class representing a recipe step
    public class RecipeStep
    {
        public string Description { get; set; }

        // Constructor to initialize the step with a description
        public RecipeStep(string description)
        {
            Description = description;
        }

        // Override ToString method to return the description of the step
        public override string ToString()
        {
            return Description;
        }
    }
}
