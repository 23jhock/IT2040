namespace ObjectPosition;

class Program
{
    static void Main(string[] args)
    {
        //Declare variables
        float initialPosition, initialVelocity, acceleration, elapsedTime;
        double finalPosition = 0;
        bool doCalculation = true;

        Console.WriteLine("This program calculates an object's final position.");

        while(doCalculation){
            //Prompt the user to enter initial position
            initialPosition = GetFloatInput("Enter the object's initial position: ", false);

            //Prompt the user to enter initial velocity
            initialVelocity = GetFloatInput("Enter the object's initial velocity: ", false);

            //Prompt the user to enter acceleration
            acceleration = GetFloatInput("Enter the object's acceleration: ", false);

            //Prompt the user to enter elapsed time
            elapsedTime = GetFloatInput("Enter the time elapsed: ", true);

            //Calculate the final position using the user input values
            //ip + iv * et + 1/2 at^2 (intial position, initial velocity, elapsed time, acceleration, time)
            finalPosition = initialPosition + initialVelocity * elapsedTime + 0.5 * acceleration * Math.Pow(elapsedTime, 2);

            //Print the result to console
            Console.WriteLine($"Final Position: {finalPosition:N2}");

            //Ask user if they want to run it again
            Console.WriteLine("Do you want to perform another calculation? (y/n)");
            string anotherCalculation = Console.ReadLine()!;

            //If yes, run program again, if no, end program
            if(anotherCalculation != "y"){
                doCalculation = false;
            }
        }   
    }

    /*
    Function to get float input from user
    Input: prompt
    Output: number (float)
    */
    static float GetFloatInput(string prompt, bool mustBePositive){
        float userInput = 0;
            while(true){
                Console.WriteLine("\n" + prompt);
                //Validate and recieve the input, reprompt if the input is invalid
                try{
                    userInput = float.Parse(Console.ReadLine()!);
                    if(userInput < 0 && mustBePositive){
                        Console.WriteLine("Error: Elapsed time must be greater than 0.");
                        continue;
                    }
                    break;
                }
                catch(Exception error){
                    Console.WriteLine("The value you entered is invalid. Only numerical values allowed.");
                    //Gets and prints the error
                    Console.WriteLine($"Error: {error.GetType().Name}");
                }
            }
        
        return userInput;
    }
}
