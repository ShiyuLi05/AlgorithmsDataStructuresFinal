Dictionary<string, int> sandwichIngredients  = new Dictionary<string, int>
{
  { "Bread", 66 },

  { "Ham", 72 },
  { "Bologna", 57 },
  { "Chicken", 17 },
  { "Corned Beef", 53 },
  { "Salami", 40 },

  { "Cheese, American", 104 },
  { "Cheese, Cheddar", 113 },
  { "Cheese, Havarti", 105 },

  { "Mayonnaise", 94 },
  { "Mustard", 10 },
  { "Butter", 102 },
  { "Garlic Aioli", 100 },
  { "Sriracha", 15 },
  { "Dressing, Ranch", 73 },
  { "Dressing, 1000 Island", 59 },

  { "Lettuce", 5 },
  { "Tomato", 4 },
  { "Cucumber", 4 },
  { "Banana Pepper", 10 },
  { "Green Pepper", 3 },
  { "Red Onion", 6 },
  { "Spinach", 7 },
  { "Avocado", 64 }
};

Console.WriteLine("Welcome to SandwichShop.");

// function valid input is number or not 
static bool IsNumeric(string value)
{
    return value.All(char.IsNumber);
}

static int isInputValid(bool isValid, string MinOrMax, int calories)
{
    while (!isValid)
    {
        Console.Write($"Enter the {MinOrMax} number of calories you would like in your sandwich: \n>");
        string input = Console.ReadLine();

        if (IsNumeric(input))
        {
            calories = Convert.ToInt32(input);
            isValid = true;
        }
    };
    isValid = false;
    //Console.WriteLine(calories);
    return calories;
}

bool appRun = true;

    bool validUserInput = false;
    int minCalories = 0;
    int maxCalories = 0;
    int itemCalories = 0;
    string userIngrediensInput = "";




while (appRun)
{
    /*while (!validUserInput)
    {
        Console.Write("Enter the minimum number of calories you would like in your sandwich: \n>");
        string userMinCaloriesInput = Console.ReadLine();

        if (IsNumeric(userMinCaloriesInput))
        {
            minCalories = Convert.ToInt32(userMinCaloriesInput);
            validUserInput = true;
        }
    };
    validUserInput = false;
    Console.WriteLine(minCalories);*/




    minCalories = isInputValid(validUserInput, "minimum", minCalories);
    maxCalories = isInputValid(validUserInput, "maximum", maxCalories);

    /*while (!validUserInput)
    {
        Console.Write("Enter the maximum number of calories you would like in your sandwich: \n>");
        string userMaxCaloriesInput = Console.ReadLine();

        if (IsNumeric(userMaxCaloriesInput))
        {
            maxCalories = Convert.ToInt32(userMaxCaloriesInput);
            validUserInput = true;
        }
    };
    validUserInput = false;
    Console.WriteLine(maxCalories);*/

    Console.WriteLine(minCalories + " " + maxCalories);

    if (minCalories < maxCalories)
    {
        if (minCalories >= 132)
        {
            validUserInput = true;
        }
        else
        {
            Console.WriteLine("MinCalory at least is 132, Please enter another number.");
        }
    }
    else
    {
        Console.WriteLine("maxCalories must greater than minCalories, Please try again.");
    }





}