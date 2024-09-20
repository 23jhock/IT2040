namespace RandomMusicPlaylist;
using System.Collections.Generic;
using System.IO;

class Program
{
    /*
    This program will contain a file of songs. Then, it will prompt the user to give a number 1-10.
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
        List<string> songPlaylist = new List<string>(); 
        Random rd = new Random();

        songPlaylist = LoadSongs(songPlaylist);

        Console.WriteLine("Random Music Playlist\n---------------------");

        //For testing: 
        //songPlaylist.ForEach(Console.WriteLine);
        
        while(doProgram){

            //Calls GetSongNum and generates it
            songNum = GetSongNum();

            //Creates a title section for a new playlist
            Console.WriteLine($"\nPlaylist {playlistCounter}");
            
            //Calls GetRandomPlaylist and generates it
            List<string> randomPlaylist = GetRandomPlaylist(songPlaylist, songNum);

            //Calls SavePlaylist to save the generated random playlist
            SavePlaylist(randomPlaylist);

            //Reads out the playlist
            for(int i = 0; i < songNum; i++){
                Console.Write($"Song {i+1}: ");
                Console.WriteLine(randomPlaylist[i]);
            }

            Console.WriteLine("\nPlaylist saved to playlist.csv.");

            //Increments for every playlist made
            playlistCounter++;

            //Prompts the user if they want to run the program again, if not y, exits
            Console.WriteLine("\nDo you want to run the program again? (y/n)\n");
            string runResponse = Console.ReadLine()!;
            if(runResponse != "y"){
                doProgram = false;
            }
        }
    }

    //Prompts the user for the number of songs in a playlist
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

    //Loads the songs into the list from the file
    static List<string> LoadSongs(List<string> songPlaylist){
        //Stores the path to the file
        string filePath = "songs.csv";

        //Create streamreader object\
        using(StreamReader fileReader = new StreamReader(filePath)){
            //Read lines from file
            while(!fileReader.EndOfStream){
                string songDataLine = fileReader.ReadLine()!;

                //Testing
                //Console.WriteLine(songDataLine);

                //Split song and artist name
                string[] songData = songDataLine.Split(",");

                //Get values from the song data
                //Trim because some of the spacing was inconsistent, just add a space when you add it to the list
                string songName = songData[0].Trim();
                string songArtist = songData[1].Trim();

                songPlaylist.Add($"{songName}: {songArtist}");
            }
            
        }
        return songPlaylist;
    }

    //Randomly picks and returns a playlist numbered of your choosing
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

    //This program saves the randomized playlist to a file called playlist.csv
    static void SavePlaylist(List<string> songPlaylist){
        //Create a streamwriter object
        using(StreamWriter fileWriter = new StreamWriter("playlist.csv")){
            //For each iteration through the list, write the song into the file
            foreach(string song in songPlaylist){
                fileWriter.WriteLine(song);
            }
        }
    }
}

/*
REFERENCES:
https://www.geeksforgeeks.org/c-sharp-list-class/ 
https://www.tutorialspoint.com/Random-Numbers-in-Chash
https://umsystem.instructure.com/courses/252101/pages/programming-toolbox
Videos from Random Music Playlist - Version 2 module page
My previous programs
In class work
*/