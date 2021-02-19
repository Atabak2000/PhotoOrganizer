using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MyDirectory = System.IO.Directory;

namespace PhotoOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {

            
            List<string> formats = new MyFileType().getAllFormats();
            try
            {


                // get  Path to search
                string mainPath = MyDirectory.GetCurrentDirectory();
                mainPath = @"C:\Users\Atabak\Desktop\Dani_Milad_Sagi_me_Glore";

                // Get parent folder of the app
                //mainPath = MyDirectory.GetParent(mainPath).ToString();

                // show current folder
                Console.WriteLine($"Detected Path is: \n {mainPath} \n \n");

                // asking conformation of the path
                Console.WriteLine("For choosing new path presss \"N\"");

                // setting new entered Path as main path
                var pathConf = Console.ReadKey(); Console.WriteLine(""); 
                if (pathConf.KeyChar == 'N' || pathConf.KeyChar == 'n')
                {
                    // asking new path
                    Console.WriteLine($"For new path enter the full path of folder (or drag&drop it) here and press enter.\n \n");
                    // a loop for getting valid path
                    do
                    {

                        string newPathUnValid = Console.ReadLine();
                        // Validating Path
                        if (MyDirectory.Exists(newPathUnValid))
                        {
                            mainPath = newPathUnValid;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Error in finding path: \n {newPathUnValid}");
                            Console.WriteLine("For new path press \"N\" OR for continue with the default folder press \"C\".");
                            var ans = Console.ReadKey();
                            if (ans.KeyChar == 'C' || ans.KeyChar == 'c') break;
                        }
                    } while (true);
                }




                // Take a snapshot of the file system.
                DirectoryInfo dir = new DirectoryInfo(mainPath);

                // This method assumes that the application has discovery permissions  
                // for all folders under the specified path.  
                IEnumerable<FileInfo> fileList = dir.GetFiles("*.*", SearchOption.AllDirectories);

                // Query for selected files
                IEnumerable<FileInfo> selectedFiles =
                    from file in fileList
                    where
                    // file.Extension == ".jpg" || file.Extension == ".JPG" || file.Extension == ".jpeg"
                    // || file.Extension == ".JPEG" || file.Extension == ".CR2" || file.Extension == ".png"
                    // || file.Extension == ".PNG" || file.Extension == ".heif" || file.Extension == ".HEIF"
                    // || file.Extension == ".mp4" || file.Extension == ".MP4" || file.Extension == ".mov"
                    // || file.Extension == ".MOV" || file.Extension == ".gif" || file.Extension == ".GIF" ||
                    formats.Exists(x => x == file.Extension)

                    select file;

                // CMD interface
                Console.WriteLine($"Main Folder is: {mainPath} \n");
                Console.WriteLine($"{selectedFiles.Count()} is founded. \n Continue (Y/N)?");
                var answerkey = Console.ReadKey(); Console.WriteLine("");
                if (answerkey.KeyChar.ToString().ToUpper() == "N") { Environment.Exit(0); }


                // selected folders looped to search
                foreach (FileInfo FI in selectedFiles)
                {
                    if (File.GetLastWriteTime(FI.FullName) != null)
                    {
                        // file creation date
                        DateTime time = File.GetLastWriteTime(FI.FullName);
                        // make folders if not already there
                        MyDirectory.CreateDirectory(mainPath + "\\SortedByYear" + "\\" + time.Year.ToString() + "\\" + time.Month.ToString());
                        // move files to new folder (can use copy here too)
                        File.Move(FI.FullName, mainPath + "\\SortedByYear" + "\\" + time.Year.ToString() + "\\" + time.Month.ToString() + "\\" + FI.Name);
                        // CMD progress data showing
                        Console.WriteLine($"Moving {FI.Name} to {time.Year}-{time.Month}");
                    }
                }
                // Final CMD interface
                Console.WriteLine($"Path was : {mainPath}");
                Console.WriteLine("Press any key to exit ...");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error eccured:");
                Console.WriteLine(e.ToString());
                Console.ReadKey();
            }



        }

    }

}
