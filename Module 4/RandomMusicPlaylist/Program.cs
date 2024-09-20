namespace RandomMusicPlaylist;
using System.Collections.Generic;

class Program
{
    /*
    This program will provide a list of 10 songs. Then, it will prompt the user to give a number 1-10.
    Then, it will to check and make sure the input is valid.
    It will create another list that contains the inputted amount of songs, in a randomized fashion.
    This list will be printed to the console.
    The program will end if it is not inputted to run again.
    */
    static void Main(string[] args)
    {
        //Setting up variables
        bool doProgram = true;
        int songNum = 0, playlistCounter = 1;
        List<string> songPlaylist = new List<string>(10); 
        Random rd = new Random();

        //Setting up the beginning list, and adding all songs.
        Console.WriteLine("Random Music Playlist\n---------------------");
        songPlaylist.Add("Stairway to Heaven: Led Zepplin");
        songPlaylist.Add("if i was a ghost: Endie");
        songPlaylist.Add("Duvet: Boa");
        songPlaylist.Add("dumb party: Internet Girl");
        songPlaylist.Add("Join the Club: Tilly Louise");
        songPlaylist.Add("Ventura Highway: America");
        songPlaylist.Add("astrid: Glaive");
        songPlaylist.Add("riddle: midwxst");
        songPlaylist.Add("Metamodernity: Vansire");
        songPlaylist.Add("through the light: dracodraco");

        //For testing: 
        //songList.ForEach(Console.WriteLine);
        
        while(doProgram){

            //Calls GetSongNum and generates it
            songNum = GetSongNum();

            //Creates a title section for a new playlist
            Console.WriteLine($"\nPlaylist {playlistCounter}");
            
            //Calls GetRandomPlaylist and generates it
            List<string> randomPlaylist = GetRandomPlaylist(songPlaylist, songNum);

            //Reads out the playlist
            for(int i = 0; i < songNum; i++){
                Console.Write($"Song {i+1}: ");
                Console.WriteLine(randomPlaylist[i]);
            }

            //Increments for every playlist made
            playlistCounter++;

            //Prompts the user if they want to run the program again, if not y, exits
            Console.WriteLine("\nDo you want to run the program again? (y/n)");
            string runResponse = Console.ReadLine()!;
            if(runResponse != "y"){
                doProgram = false;
            }
        }
    }

    static int GetSongNum(){
        int songNum = 0;
        bool isInteger = false;
        //Prompting the user how many songs should be played
        Console.WriteLine("Enter the number of songs to play(1-10): ");


        while(!isInteger){
            //Checks to see if the input can be parsed, if not, skip the next loop and reprompt as a result
            try{
                string input = Console.ReadLine()!; 
                //Checks to see if can be converted into an int and if its between 1-10.
                if(int.TryParse(input, out songNum) && songNum >= 1 && songNum <= 10){
                    isInteger = true;
                }
                else{
                    Console.WriteLine("Improper input, must be a number between 1 and 10.");
                }
            }
            catch(Exception){
                Console.WriteLine("Improper input, must be a number between 1 and 10.");
            }
        }

        return songNum;
    }

    static List<string> GetRandomPlaylist(List<string> songPlaylist, int songNum){
        //Creates a new randomized playlist with a capacity of the input value
        List<string> randomPlaylist = new List<string>(songNum);
        //Creates a new list that is copied over from the starting playlist.
        //This is to ensure we don't give 2 of the same songs into the random playlist.
        List<string> availableSongs = new List<string>(songPlaylist);

        Random rd = new Random();
        for(int i = 0; i < songNum; i++){
            //Creates a random number to choose the songs for the playlist and adds it to the list as requested
            int randNum = rd.Next(0, availableSongs.Count);
            randomPlaylist.Add(availableSongs[randNum]);
            //Removes the song from the currently available songs list
            availableSongs.RemoveAt(randNum);
        }

        return randomPlaylist;
    }
}

/*
REFERENCES:
https://www.geeksforgeeks.org/c-sharp-list-class/ 
https://www.tutorialspoint.com/Random-Numbers-in-Chash
https://umsystem.instructure.com/courses/252101/pages/programming-toolbox
My previous programs
In class work
*/