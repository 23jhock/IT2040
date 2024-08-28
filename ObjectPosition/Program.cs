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
            while(true){
                Console.WriteLine("Enter the object's initial position:");

                //Validate and recieve the input, reprompt if the input is invalid
                try{
                    initialPosition = float.Parse(Console.ReadLine());
                    break;
                }
                catch(Exception error){
                    Console.WriteLine("The value you entered is invalid. Only numerical values allowed.");
                    //Gets and prints the error
                    Console.WriteLine($"Error: {error.GetType().Name}");
                }
            }

            //Prompt the user to enter initial velocity
            while(true){
                Console.WriteLine("Enter the object's initial velocity:");

                //Validate and recieve the input, reprompt if the input is invalid
                try{
                    initialVelocity = float.Parse(Console.ReadLine());
                    break;
                }
                catch(Exception error){
                    Console.WriteLine("The value you entered is invalid. Only numerical values allowed.");
                    //Gets and prints the error
                    Console.WriteLine($"Error: {error.GetType().Name}");
                }
            }

            //Prompt the user to enter acceleration
            while(true){
                Console.WriteLine("Enter the object's acceleration:");

                //Validate and recieve the input, reprompt if the input is invalid
                try{
                    acceleration = float.Parse(Console.ReadLine());
                    break;
                }
                catch(Exception error){
                    Console.WriteLine("The value you entered is invalid. Only numerical values allowed.");
                    //Gets and prints the error
                    Console.WriteLine($"Error: {error.GetType().Name}");
                }
            }

            //Prompt the user to enter elapsed time
            while(true){
                Console.WriteLine("Enter the elapsed time:");

                //Validate and recieve the input, reprompt if the input is invalid
                try{
                    elapsedTime = float.Parse(Console.ReadLine());
                    break;
                }
                catch(Exception error){
                    Console.WriteLine("The value you entered is invalid. Only numerical values allowed.");
                    //Gets and prints the error
                    Console.WriteLine($"Error: {error.GetType().Name}");
                }
            }

            //Calculate the final position using the user input values
            //ip + iv * et + 1/2 at^2 (intial position, initial velocity, elapsed time, acceleration, time)

            //Print the result to console

            //Ask user if they want to run it again
            Console.WriteLine("Do you want to perform another calculation?");
            string anotherCalculation = Console.ReadLine();

            //If yes, run program again, if no, end program
            if(anotherCalculation != "y"){
                doCalculation = false;
            }
        }

        
    }
}
