namespace MealTime;

class Program
{
    /*
    This program will prompt the user for an input in the format [xx:xx].
    It will hand off the string, [time], to the [convertTime] program.
    Finally, it will evaluate the result of [convertTime] and print out the appropriate-time message.
    */
    static void Main(string[] args)
    {
        Console.WriteLine("What time is it?");
        string time = Console.ReadLine()!;
        //Passes inputed [time] to be converted and assigned to [convertedTime]
        float convertedTime = convertTime(time);
        /* Line below for testing
        Console.WriteLine($"Converted time = {convertedTime}");
        */
        if(convertedTime >= 7.0f && convertedTime <= 8.0f){
            Console.WriteLine("Breakfast time!");
        }
        else if(convertedTime >= 12.0f && convertedTime <= 13.0f){
            Console.WriteLine("Lunch time!");
        }
        else if(convertedTime >= 18.0f && convertedTime <= 19.0f){
            Console.WriteLine("Dinner time!");
        }
        else{
            Console.WriteLine("Not time to eat!");
        }
    }

    /*
    This program will accept the user input [time].
    It will then split the [hour] and [minutes] into two variables.
    Then, it will convert the [minutes] into a decimal, [minutesConverted].
    Finally, it will add them together and return the float, [combinedTime].
    */
    
    public static float convertTime(string time){
        string[] timeParts = time.Split(":");
        //Taking the split string and parsing it to two different variables
        float hour = float.Parse(timeParts[0]);
        float minutes = float.Parse(timeParts[1]);
        //Converting minutes to a decimal
        float minutesConverted = minutes / 60f;
        //Computing final time and returning
        float combinedTime = hour + minutesConverted;
        return combinedTime;
    }

}
