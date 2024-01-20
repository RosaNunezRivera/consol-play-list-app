using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consol_play_list_app
{
    /// <summary>
    /// Program to performace a consol music player application.
    /// The applicacion allows add songs, play a song, skip and rewing
    /// a song. 
    /// It is using queue to the store the songs of the play list and 
    /// stack to store the song that are been played to rewing again
    /// In the main program call the method OptionsPlayList() which show
    /// all the options and allows user enter a value to call the method for
    /// each opcion 
    /// </summary>
    /// <param name="args"></param>
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //New object - Creating an instance of the class 
                PlayListMethods playListObject = new PlayListMethods();

                //Show options of Car Application after to set the capacity
                playListObject.OptionsPlayList();

                Console.WriteLine("\nThanks for use this Music Player Application!");
                Console.WriteLine("\nPress any key for exit...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAn error ocurred! Detail: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\nProgram completed"); 
            }
        }
    }
}

