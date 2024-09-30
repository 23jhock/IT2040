namespace LiscencePlate;

class Program
{
    static void Main(string[] args)
    {
        string userInput = getUserInput();

        bool isValid = validityChecker(userInput);

        getResult(userInput, isValid);
    }

    static string getUserInput()
    {
        string userInput = "";
        bool isValid = false;

        while(!isValid){

            //Prompts user to enter an item
            Console.WriteLine("Enter Plate:");

            userInput = Console.ReadLine()!; 

            //If it isn't just nothing, continues on with the program
            if(userInput != ""){
                isValid = true;
            }
            else{
                //If nothing is inputted, reprompts.
                Console.WriteLine("ERROR: Must enter a plate.");
            }
        }

        return userInput;
    }

    static bool validityChecker(string userInput){
        bool firstNum = true;
        
        //Checks if the input is between 2 and 6 characters
        if(userInput.Length < 2 || userInput.Length > 6){
            return false;
        }

        //Checks if the input has 2 letters at the start
        for(int i = 0; i < 2; i++){
            if(char.IsDigit(userInput[i])){
                return false;
            }
        }
        
        //Loops through the characters of the string
        for(int i = 0; i < userInput.Length; i++){

            //If this is the first number encountered and 0, go through if statement
            if(firstNum == true && char.IsDigit(userInput[i])){

                //Starts a separate incrementing process that checks if any letters are present after a number
                for(int j = i; j < userInput.Length; j++){
                    //If there is a letter after the number, return false
                    if(char.IsLetter(userInput[j])){
                        return false;
                    }
                }
                //If the first number is 0, return false
                if(userInput[i] == '0'){
                    return false;
                }
                firstNum = false;
            }

            //If the character is not a letter or digit, return false
            if(!char.IsLetterOrDigit(userInput[i])){
                return false;
            }
        }

        //Returns true if all the checks are passed
        return true;
    }

    static void getResult(string userInput, bool isValid){
        if(isValid){
            Console.WriteLine($"{userInput} is a valid license plate.");
        }
        else{
            Console.WriteLine($"{userInput} is NOT a valid license plate.");
        }
    }
}
