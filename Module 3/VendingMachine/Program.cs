namespace VendingMachine;

class Program
{
    /*
    This program will allow the user to input certain numbers representing certain coins.
    It will not allow you to input anything other than 1, 5, 10, and 25.
    Once you get your inputted total to 50, the program will stop allowing you to input.
    Finally, if there is any excess past 50, it will return the excess amount.
    */
    static void Main(string[] args)
    {
        //GetChange is for ending the main loop once it is <= 0, isInteger is to validate inputs are proper
        bool getChange = false, isInteger = true;
        //Due always starts at 50, and goes down as input goes up.
        int due = 50, input = 0;
        Console.WriteLine("Vending Machine\n---------------");
        //Loop will end when due is <= 0
        while(getChange == false){
            Console.WriteLine($"Amount due: {due}\nInsert Coin:"); 
            //Tries to convert input to integer, and will reprompt if it doesn't work
            try{
                input = Convert.ToInt32(Console.ReadLine()!); 
                isInteger = true;
            }
            catch(Exception){
                Console.WriteLine("Improper input, must be an integer.");
                isInteger = false;
            }
            //Loop will start if the catch above isn't triggered
            while(isInteger == true){
                switch(input){
                    case 1:
                        due = due - 1;
                        break;
                    case 5:
                        due = due - 5;
                        break;
                    case 10:
                        due = due - 10;
                        break;
                    case 25:
                        due = due - 25;
                        break;
                    default:
                        //If not a coin value input, informs of error and reprompts
                        Console.WriteLine("Improper input, must be 1, 5, 10, or 25.");
                        break;
                }
                break;
            }
            //Checks if due is <=0, if so exits the above loop and return change owed
            if(due <= 0){
                getChange = true;
                //If change is owed, just multiply it by -1 to make it positive and return the number
                if(due < 0){
                    due = due * -1;
                }
                Console.WriteLine($"Change owed: {due}");
            }

        }
    }
    /*
    public static bool tryInteger(int input){
        try{
            input = Convert.ToInt32(Console.ReadLine()!); 
            return true;
        }
        catch(Exception){
            Console.WriteLine("Improper input, must be an integer.");
            return false;
        }
    }
    */
}
