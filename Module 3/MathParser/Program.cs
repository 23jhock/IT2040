namespace MathParser;

class Program
{
    static void Main(string[] args)
    {
        /*
        Prompt the user to enter an equation in the form A operator B (A * B)
        Operators can be +, -, *, /.
        Valid input: 4 + 3, invalid: 4+3, 4+ 3, 4 + 3 + 2
        */
        int number1 = 0, number2 = 0;
        string mathOperator = "";

        //Prompt the user to enter the equation
        Console.WriteLine("Enter the equation: ");

        //Get user input and assign a variable
        string equation = Console.ReadLine()!;

        //Parse the equation to get the number and the operator and validate format
        string[] equationParts = equation.Split(" ");
        if(equationParts.Length != 3){
            Console.WriteLine("Error: Incorrect format.\nExiting program.");
            Environment.Exit(0);
        }
        //Validate input: make sure A and B are numbers. Make sure the operator is [+, - , *, /]
        try{
            number1 = int.Parse(equationParts[0]);
            number2 = int.Parse(equationParts[2]);
        }
        catch(Exception){
            Console.WriteLine("Error: Must be enter numbers in the equation.\nExiting program.");
            Environment.Exit(0);
        }
        
        mathOperator = equationParts[1];
        switch(mathOperator){
            case "+":
                Console.WriteLine($"Answer: {number1 + number2}");
                break;
            case "-":
                Console.WriteLine($"Answer: {number1 - number2}");
                break;s
            case "*":
                Console.WriteLine($"Answer: {number1 * number2}");
                break;
            case "/":
                //handle divide  by 0 error check
                if(number2 == 0){
                    Console.WriteLine("Error: Cannot divide by 0.\nExiting program");
                    Environment.Exit(0);
                }
                Console.WriteLine($"Answer: {(float)number1 / (float)number2}");
                break;
            default:
                Console.WriteLine($"Error: {mathOperator} is not a valid operator.\nExiting program.");
                Environment.Exit(0);
                break;
        }
        //End the program if user input is invalid
    }
}
