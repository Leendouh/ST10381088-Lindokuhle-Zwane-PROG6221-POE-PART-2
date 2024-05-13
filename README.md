# [ST10381088]-[Lindokuhle Zwane]-PROG6221-PART-2
**Recipe Manager Application:**
- Command-line application written in C# for managing recipes.
- Allows users to enter new recipes, display all recipes, and calculate total calories.

**Steps for viewing the project:**
1. Open the **[ST10381088]-[Lindokuhle Zwane]-PROG6221-PART-2** file.
2. Contains 4 C# classes for different aspects of the Recipe Manager.
3. **Program.cs** contains the main method executed when running the application.
4. Running the application presents options for Recipe Manager.
5. Options include entering a new recipe, displaying all recipes, or exiting.
6. **Enter a New Recipe:**
   - Prompted to enter the recipe name.
   - Asked for the number of ingredients.
   - For each ingredient:
     - Enter name, quantity, unit, calories, and food group.
   - Enter the number of steps and description for each.
   - Application summarizes the recipe with total calories.
7. **Display Recipe:**
   - View details of currently entered recipe, including ingredients and steps.
   - If no recipe is entered, prompt to add one.
8. Unit tests for calorie calculation in **RecipeManager.Tests** project.
9. To run tests:
   - Navigate to **RecipeManager.Tests** directory.
   - Run tests with `dotnet test`.
10. **Exit Application:** Option to exit when done managing recipes.
11. **Installation:**
    - Clone repository or download source code.
    - Open solution in preferred C# IDE (e.g., Visual Studio).
    - Build solution to compile.
    - Run application from IDE or execute compiled binary.
12. **Contributing:**
    - Contributions welcome! Open issues or submit pull requests for improvements or new features.
