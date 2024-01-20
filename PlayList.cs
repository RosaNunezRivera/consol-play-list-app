using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace consol_play_list_app
{
    /// <summary>
    /// Include all the method for the player music application
    /// </summary>
    internal class PlayListMethods
    {
        /// <summary>
        /// OptionsPlayList() method that receive a string variable and convert to a integer 
        /// Use a switch case to call each method to the options:
        ///  (1) Add a song to your playlist
        ///  (2) Play the next song in your playlist
        ///  (3) Skip the next song
        ///  (4) Rewind one song
        ///  (5) Exit 
        /// </summary>
        public void OptionsPlayList()
        {
            try
            {
                //Declare variables
                int option;
                string optionString;
                bool isValidInt = false;

                //Creating SD to ListSongs operations
                Queue<string> playList = new Queue<string>();

                //Creating SD to rewing a song 
                Stack<string> rewingPlayList = new Stack<string>();
                
                //Do-while to be in a loop while option is not exit
                do
                {
                    do
                    {
                        Console.WriteLine("Music Player Application");

                        Console.WriteLine("Options:");
                        Console.WriteLine("========================================");
                        Console.WriteLine("(1) Add a song to your playlist");
                        Console.WriteLine("(2) Play the next song in your playlist");
                        Console.WriteLine("(3) Skip the next song");
                        Console.WriteLine("(4) Rewind one song");
                        Console.WriteLine("(5) Exit");

                        //Gettint the string enter by the user and parse if is a integer 
                        Console.Write("\nEnter an option (1-5): ");
                        optionString = Console.ReadLine();

                        //Set the caracter enter by the user without whitespace
                        optionString = optionString.Trim();

                        // Get a string and using a int.TryParse() method to get a boolean value to validate a valid int input
                        isValidInt = int.TryParse(optionString, out option);

                        if (!isValidInt)
                        {
                            Console.WriteLine("Only numbers are valid, please enter numbers 1-5\n");
                        }
                        else if (option <= 0 || option > 5)
                        {
                            Console.WriteLine("Please, enter numbers 1-5\n");
                        }

                    } while (!isValidInt || option <= 0 || option > 5);

                    //Evaluating each value of the option enter by the user
                    switch (option)
                    {
                        case 1:
                            AddASong(playList);
                            break;
                        case 2:
                            PlayNextSong(playList, rewingPlayList);
                            break;
                        case 3:
                            SkipTheNextSong(playList, rewingPlayList);
                            break;
                        case 4:
                            RewingASong(playList, rewingPlayList);
                            break;
                        case 5:
                            Exit(playList);
                            break;
                        default:
                            break;
                    }
                } while (option != 5);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ocurred! " + ex.Message);
            }
        }
        public void AddASong(Queue<string> playList) 
        {
            try
            {
                //Declaring variables 
                string nameSong;
                bool isNameSongValid = false;
              
                //Allow to the user to enter a song validating if is a string
                do
                {
                    Console.WriteLine("\n(1) Add a song to your playlist");
                    Console.WriteLine("---------------------------------------- ");
                    Console.Write("Enter a name song: ");
                    nameSong = Console.ReadLine().Trim();

                    //Ckecking if the song enter by the user is valid 
                    if (!string.IsNullOrEmpty(nameSong))
                    {
                        isNameSongValid = true;
                        //Adding the song to the play list
                        playList.Enqueue(nameSong);
                      
                        Console.WriteLine($"\n{nameSong} added to your playlist.");
                        Console.WriteLine($"Next song: {playList.Peek()}\n");
                    }
                    else
                    {
                        Console.Write("\nPlease, enter a song name");
                    }
                } while (!isNameSongValid);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ocurred! " + ex.Message);
            }
        }

        /// <summary>
        /// Method to play a song and show the next song in the play list
        /// Add the playing song in stack structure called to use in rewingSong method
        /// </summary>
        /// <param name="playList"></param>
        public void PlayNextSong(Queue<string> playList, Stack<string> rewingPlayList)
        {
            Console.WriteLine("\n(2) Play the next song in your playlist");
            Console.WriteLine("---------------------------------------- ");

            try 
            {

                if (playList.Count != 0)
                {
                    //Declaring a variable to store the playing song and remove it
                    string actualSong = playList.Dequeue();

                    //Printing the playing song and the next song
                    Console.WriteLine($"\nNow is playing {actualSong}.");

                    //Add the playing song in stack SD to use in rewingSong Method
                    rewingPlayList.Push(actualSong);

                    //Prinring next songs in the play list
                    PrintNextSongs(playList);
                }
                else
                {
                    Console.WriteLine("There is no song to play\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ocurred! " + ex.Message);
            }
        }

        /// <summary>
        /// Method to allow skip a song cheking before if the SD is not empty. 
        /// anfter store actualSong taking and removing this value from playList 
        /// </summary>
        /// <param name="playList"></param>
        /// <param name="rewingPlayList"></param>
        public void SkipTheNextSong(Queue<string> playList, Stack<string> rewingPlayList) 
        {
            Console.WriteLine("\n(3) Skip the next song");
            Console.WriteLine("----------------------- ");

            try 
            {

                //Validating if the play list has songs to play
                if (playList.Count > 0)
                {
                    //Declaring a variable to store the skiped song and remove it
                    string skipSong = playList.Dequeue();

                    //Printing the skiped song 
                    Console.WriteLine($"\nThe skiped song is {skipSong}.");

                    //Printring next songs in the play list
                    PrintNextSongs(playList);
                }
                else
                {
                    Console.WriteLine("There is not more songs to play\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ocurred! " + ex.Message);
            }
        }

        /// <summary>
        /// Method that allows user rewing a song. First the method check if the 
        /// SD is not empty. Then, store in a string variable the song 
        /// taking the top element without removing from  rewingPlayList. Finally, 
        /// print the next songs interating the playList SD type queue.
        /// </summary>
        /// <param name="playList"></param>
        /// <param name="rewingPlayList"></param>
        public void RewingASong(Queue<string> playList, Stack<string> rewingPlayList) 
        {
            Console.WriteLine("\n(4) Rewind one song");
            Console.WriteLine("----------------------- ");

            try 
            {
                if (rewingPlayList.Count > 0)
                {
                    //Getting the song to rewing from stack SD 
                    string previousSong = rewingPlayList.Peek();
                    Console.WriteLine($"Now rewinding the song: {previousSong}");
                }
                else
                {
                    Console.WriteLine("There is no one song played yet.\n");
                }
                //Prinring next songs in the play list
                PrintNextSongs(playList);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ocurred! " + ex.Message);
            }
        }

        //Method Exit - to execute when the user is getting of the application
        //Clear the play list and show a message to the user 
        public void Exit(Queue<string> playList) 
        {
            playList.Clear();
        }

        /// <summary>
        /// Method to print the next songs doing an interate in the SD 
        /// playList type Queue.
        /// </summary>
        /// <param name="playList"></param>
        public void PrintNextSongs(Queue<string> playList)
        {
            try 
            {
                if (playList.Count > 0)
                {
                    foreach (var nextSong in playList)
                    {
                        Console.WriteLine($"Next song: {nextSong}");
                    }
                }
                else
                {
                    Console.WriteLine("\nThere are no more songs to play");
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ocurred! " + ex.Message);
            }
        }
    }
}
       
        


