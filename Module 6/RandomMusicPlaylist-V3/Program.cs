namespace RandomMusicPlaylist;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        //Setting up variables
        bool doProgram = true;
        int songNum = 0, playlistCounter = 1;
        string playlistName = "", directoryPath = "";
        List<string> songPlaylist = new List<string>(); 
        Random rd = new Random();

        //Loads the list with songs from the file
        songPlaylist = LoadSongs(songPlaylist);

        Console.WriteLine("Random Music Playlist\n---------------------");
        
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

            int choice = GetSaveQuitOption();

            //If it is one or two, prompts user to add a name for the file
            if(choice == 1 || choice == 2){
                playlistName = GetPlaylistName();
                directoryPath = "playlists";
                Directory.CreateDirectory(directoryPath);
            }

            //Determines what to do with the program and if to save
            switch(choice){
                case 1:
                    SavePlaylist(randomPlaylist, Path.Combine(directoryPath, playlistName));
                    Console.WriteLine($"Playlist saved as {playlistName}, reprompting.");
                    break;
                case 2:
                    SavePlaylist(randomPlaylist, Path.Combine(directoryPath, playlistName));
                    Console.WriteLine($"Playlist saved as {playlistName}, exiting program.");
                    doProgram = false;
                    break;
                case 3:
                    Console.WriteLine("Playlist not saved, reprompting.");
                    break;
                case 4:
                    Console.WriteLine("Playlist not saved, exiting program.");
                    doProgram = false;
                    break;
                default:
                    break;
            }
        }
    }

    //Prompts the user to get the name of the playlist
    static string GetPlaylistName(){
        string playlistName = "";
        bool validName = false;

        //Prompts the user for a valid playlist name, will loop if invalid and reprompt
        while(!validName){
            Console.WriteLine("Enter a name for your playlist file:");
            playlistName = Console.ReadLine()!;

            //If the name is empty, tell the user and let the loop run again
            if(playlistName == ""){
                Console.WriteLine("Improper input, please input a name.");
            }
            //If the playlist name doesn't end with .txt, append it to the end and exit the loop
            else{
                if(!playlistName.EndsWith(".txt")){
                    playlistName += ".txt";
                }
                validName = true;
            }
        }

        return playlistName;
    }

    //Prompts the user to determine what they want to do with the generated playlist
    static int GetSaveQuitOption(){
        Console.WriteLine("\nChoose one of the following options:\n------------------------------------");
        Console.WriteLine("1. Save Playlist & Continue");
        Console.WriteLine("2. Save Playlist & Quit");
        Console.WriteLine("3. DON'T Save Playlist & Continue");
        Console.WriteLine("4. DON'T Save Playlist & Quit");

        int choice = 0;
        bool validChoice = false;

        //Tries to read the input, loops and reprompts if improper input
        while(!validChoice){
            //Tries to check if the input is an int, and if so, checks if it lands between 1-4
            try{
                choice = int.Parse(Console.ReadLine()!);
                if(choice >= 1 && choice <= 4){
                    validChoice = true;
                }
                else{
                    //If not 1-4, reprompt
                    Console.WriteLine("Improper input, please input a number between 1-4.");
                }
            }
            //If not an int alltogether, reprompt
            catch (Exception){
                Console.WriteLine("Improper input, please input a number.");
            }
        }

        return choice;
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
    static void SavePlaylist(List<string> songPlaylist, string filePath){
        //Create a streamwriter object
        using(StreamWriter fileWriter = new StreamWriter(filePath)){
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