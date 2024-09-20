namespace MenuOrder;
using System.Collections.Generic;

class Program
{
    /*
    Implement a program that enables a user to place an order, 
    Prompting them for items, one per line, until the user types the word "end"0
    After each inputted item, display the total cost of all items inputted thus far, 
    prefixed with a dollar sign ($) and formatted to two decimal places.  
    Ignore any input that isn’t an item. You should create the menu as a dictionary.
    */

    static void Main(string[] args)
    {
        //Declares the menu dictionary and adds items
        Dictionary<string, float> menu = new Dictionary<string, float>();
        menu.Add("Baja Taco", 4.00f);
        menu.Add("Burrito", 7.50f);
        menu.Add("Bowl", 8.50f);
        menu.Add("Nachos", 11.00f);
        menu.Add("Quesadilla", 8.50f);
        menu.Add("Super Burrito", 8.50f);
        menu.Add("Super Quesadilla", 9.50f);
        menu.Add("Taco", 3.00f);
        menu.Add("Tortilla Salad", 8.00f);

        bool doProgram = true;
        string end = "end";
        float totalPrice = 0.00f;

        while(doProgram){
            //Collects the information and validates it
            string menuRequest = GetMenuRequest(menu);

            //Checks if the input was "end" in a non case-sensitive way, and ends the program
            if(menuRequest.ToLower() == end){
                doProgram = false;
                continue;
            }
            
            //Grabs the price of the input item from the dictionary
            float currentPrice = menu[menuRequest];
            //Adds the price to the total
            totalPrice += currentPrice;

            //Prints total and loops
            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }

    //Adapted function from my RandomMusicPlaylist program
    static string GetMenuRequest(Dictionary<string, float> menu)
    {
        string menuRequest = "", end = "end";
        bool isValid = false;

        while(!isValid){
            try{
                //Prompts user to enter an item
                Console.WriteLine("\nItem:");

                menuRequest = Console.ReadLine()!; 
                //Checks to see if the input is in the dictionary
                if(menu.ContainsKey(menuRequest)){
                    isValid = true;
                }
                else{
                    if(menuRequest.ToLower() == end){
                        Console.WriteLine("Ending program.");
                        return menuRequest;
                    }
                    Console.WriteLine($"{menuRequest} is not found on the menu.");
                }
            }
            //Not necessary for this program, but good to have for future programs
            catch(Exception error){
                Console.WriteLine($"An error occurred: {error}.");
            }
        }

        return menuRequest;
    }
}

/*
Resources:
https://www.c-sharpcorner.com/UploadFile/mahesh/compare-strings-in-C-Sharp/
https://dotnetteach.com/blog/csharp-dictionary-get-value-by-key
https://www.w3schools.com/cs/cs_exceptions.php
GetMenuRequest function adapted from my RandomMusicPlaylist from Module 4
*/