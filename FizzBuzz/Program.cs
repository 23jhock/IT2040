using System.Globalization;

namespace IT2040;

class Program
{
    static void Main(string[] args)
    {
        //Fizz BUzz from 0-100
        //If number is divisible by 3, output Fizz
        //If number is divisible by 5, output Buzz
        //If number is divisible by 3 and 5, output FizzBuzz

        //Ask a user for the stop value

        //Write a for loop to loop from 0 to 100
        for(int number = 0; number <= stopValue; number++){
            if((number % 3 == 0) && (number % 5 == 0)){
                Console.WriteLine("FizzBuzz");
            }
            else if(number % 3 == 0){
                Console.WriteLine("Fizz");
            }
            else if(number % 5 == 0){
                Console.WriteLine("Buzz");
            }
            else if(number == 0){
                Console.WriteLine("Fizz");
            }
            else{
                Console.WriteLine(number);
            }
        }

        //Function to get and return a stop value
        //No input, outputs an int
        static int getStopValue(){
            //Prompts the user to enter a value
            Console.WriteLine("Enter the stop value: ");
            string stringNumber = Console.ReadLine();

            //Converts the number to an int
            
            //Returns int
        }
    }
}
