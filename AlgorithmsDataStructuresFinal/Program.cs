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

sandwichIngredients = sandwichIngredients.ToDictionary(k => k.Key.ToUpper(), k => k.Value);

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
    return calories;
}


bool appRun = true;

    bool validUserInput = false;
    int minCalories = 0;
    int maxCalories = 0;




while (!validUserInput)
{
    Console.Write($"Enter the minimum number of calories you would like in your sandwich: \n>");
    string MinCaloriesinput = Console.ReadLine().Trim();

    if (IsNumeric(MinCaloriesinput))
    {
        minCalories = Convert.ToInt32(MinCaloriesinput);
        if (minCalories > sandwichIngredients["BREAD"] * 2)
        {
            validUserInput = true;
        } else
        {
            Console.WriteLine("The calorie you enter is too low. Please enter another number.");
            validUserInput = false;
        }
    } 
};

validUserInput = false;

while (!validUserInput)
{
    Console.Write($"Enter the maximum number of calories you would like in your sandwich: \n>");
    string MaxCaloriesinput = Console.ReadLine().Trim();

    if (IsNumeric(MaxCaloriesinput))
    {
        maxCalories = Convert.ToInt32(MaxCaloriesinput);
        if (maxCalories > minCalories)
        {
            validUserInput = true;
        }
        else
        {
            Console.WriteLine("maxCalories must greater than minCalories, Please try again.");
            validUserInput = false;
        }
    }
};

string excludeIngredient = "";
List<string> excludeIngredientsList = new List<string>();

bool containsBread = true;
while (containsBread)
{
    Console.WriteLine("Do you want to exclude any ingredients? (If not, just press enter to skip.)");
    excludeIngredient = Console.ReadLine().ToUpper().Trim();
    List<string> excludeIngredients = excludeIngredient.Split(',').ToList();

    foreach (string exclude in excludeIngredients)
    {
        excludeIngredient = exclude.Trim();
        Console.WriteLine(excludeIngredient);
    }
    containsBread = false;
    if (!string.IsNullOrEmpty(excludeIngredient))
    {
        if (excludeIngredients.Contains("BREAD"))
        {
            Console.WriteLine("Sandwiches must include bread.");
            containsBread = true;
        }
        foreach (string exclude in excludeIngredients)
        {
            bool validExcludeIngredient = sandwichIngredients.ContainsKey(exclude);
            if (validExcludeIngredient)
            {
                excludeIngredientsList.Add(exclude);
            }
        }

    }
    else
    {
        Console.WriteLine("No excluded ingredients.");
    }
};

foreach (string exclude in excludeIngredientsList)
{
    Console.WriteLine("需要被移出去的list" + exclude);
}


Console.WriteLine("\nMaking your sandwich\n");
List<string> sandwich = new List<string>();
int breadCalories = sandwichIngredients["BREAD"];
int currentCalories = breadCalories * 2;
excludeIngredientsList.Add("BREAD");
// https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.where?view=net-6.0
sandwichIngredients = sandwichIngredients.Where(k => !excludeIngredientsList.Contains(k.Key)).ToDictionary(k => k.Key, k => k.Value);
// https://learn.microsoft.com/en-us/dotnet/api/system.random?view=net-6.0
Random random = new Random();
bool cannotBeAdd = false;
string lastIngredient = "";
while (currentCalories <= maxCalories && sandwichIngredients.Count > 0 && !cannotBeAdd)
{
    // https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.elementat?view=net-6.0
    string randomIngredient = sandwichIngredients.Keys.ElementAt(random.Next(sandwichIngredients.Count));
    int ingredientCalories = sandwichIngredients[randomIngredient];
    if (currentCalories + ingredientCalories <= maxCalories && randomIngredient != lastIngredient)
    {
        sandwich.Add(randomIngredient);
        lastIngredient = randomIngredient;
        currentCalories += ingredientCalories;
    }
    cannotBeAdd = sandwichIngredients.Values.All(num => num > maxCalories - currentCalories);
}
while (currentCalories < minCalories && sandwich.Count > 0)
{
    string removedIngredient = sandwich.Last();
    int removedIngredientCalories = sandwichIngredients[removedIngredient];
    sandwich.Remove(removedIngredient);
    currentCalories -= removedIngredientCalories;
}
if (sandwich.Count == 0)
{
    Console.WriteLine("It's not possible to create a sandwich within the given calorie range.");
}
else
{
    int totalCalories = sandwich.Sum(ingredient => sandwichIngredients[ingredient]) + breadCalories * 2;
    Console.WriteLine($"Adding bread (66 calories)");
    foreach (string str in sandwich)
    {
        Console.WriteLine($"Adding {str.ToLower()} ({sandwichIngredients[str]} calories)");
    }
    Console.WriteLine($"Adding bread (66 calories)");
    Console.WriteLine($"Your sandwich, with {totalCalories} calories, is ready. Enjoy!");
}