namespace CharDemo;

class Program
{
    static void Main(string[] args)
    {
        string className = "IT*2040";
        char character = 't';

        //is the second character in the class name a letter
        char secondLetter = className[1];
        bool isLetter = Char.IsLetter(secondLetter);
        Console.WriteLine($"It is {isLetter} that {secondLetter} is a letter.");

        //is the third character in the class name a letter
        char thirdLetter = className[2];
        isLetter = Char.IsLetter(thirdLetter);
        Console.WriteLine($"It is {isLetter} that {thirdLetter} is a letter.");

        //is the third character in the class name a letter
        bool isDigit = Char.IsDigit(thirdLetter);
        Console.WriteLine($"It is {isDigit} that {thirdLetter} is a digit.");

        //is the third character in the class name a letter or digit
        bool isLetterOrDigit = Char.IsLetterOrDigit(thirdLetter);
        Console.WriteLine($"It is {isLetterOrDigit} that {thirdLetter} is a letter or a digit.");

        //bool meetsRequirements = Char.IsLetterOrDigit(className);

        //use our funtion to determine if non alphnumeric characters ar in the classname
        bool isValid = IsValidName(className);

        if(isValid){
            Console.WriteLine("Class name only contains alphanumeric characters");
        }else{
            Console.WriteLine("Class name contains non-alphanumeric characters");
        }


    }

    //Function to dertermine valid characters
    //Input: (string) class name
    //Output: bool: true if all characters alphanumeric. False if not
    static bool IsValidName(string cName){
        //determine if all charcters are alphanumeric
        foreach(char letter in cName){
            if(!Char.IsLetterOrDigit(letter)){
                return false;
            }
        }

        return true;

    }
}
