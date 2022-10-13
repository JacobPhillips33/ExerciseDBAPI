using ExerciseDBAPI;
using Newtonsoft.Json.Linq;

var response = Methods.AllExercises();

Console.WriteLine("There are 1327 exercises to choose from.");
Console.Write("Please enter a number to see the corresponding exercise: ");
var parsable = int.TryParse(Console.ReadLine(), out int exerciseNumber);
Console.WriteLine();

while (!parsable || exerciseNumber > 1327 || exerciseNumber < 1)
{
    Console.Write("Invalid entry. Please enter a valid number between 1 and 1327: ");
    parsable = int.TryParse(Console.ReadLine(), out exerciseNumber);
    Console.WriteLine();
}

var answer = Methods.SpecificExercise(response, exerciseNumber);

Console.WriteLine("******************************************************************");
Console.WriteLine($"                  EXERCISE {exerciseNumber}");
Console.WriteLine("******************************************************************");

Console.WriteLine($"Exercise Name:      {answer.Name.ToUpper()}");
Console.WriteLine($"Body Part:          {answer.BodyPart.ToUpper()}");
Console.WriteLine($"Target Muscle:      {answer.Target.ToUpper()}");
Console.WriteLine($"Equipment Needed:   {answer.Equipment.ToUpper()}");
Console.WriteLine($"GIF URL:            {answer.GifUrl}");
Console.WriteLine();
Console.WriteLine("******************************************************************");













