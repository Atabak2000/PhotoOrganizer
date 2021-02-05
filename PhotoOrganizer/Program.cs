using System;
using System.IO;
using MyDirectory = System.IO.Directory;
using System.Collections.Generic;
using System.Linq;

namespace PhotoOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // not used in this code but can be used in query
            //List<string> formats = new List<string>();
            //formats.Add(".jpg");
            //formats.Add(".JPG");
            //formats.Add(".jpeg");
            //formats.Add(".JPEG");
            //formats.Add(".CR2");
            //formats.Add(".png");
            //formats.Add(".PNG");
            //formats.Add(".heif");
            //formats.Add(".HEIF");

            try
            {
                
                // get  Path to search
                string mainPath = MyDirectory.GetCurrentDirectory();
                // delete local app folder
                mainPath = MyDirectory.GetParent(mainPath).ToString();

                // Take a snapshot of the file system.
                DirectoryInfo dir = new DirectoryInfo(mainPath);

                // This method assumes that the application has discovery permissions  
                // for all folders under the specified path.  
                IEnumerable<FileInfo> fileList = dir.GetFiles("*.*", SearchOption.AllDirectories);

                // Query for selected files
                IEnumerable<FileInfo> selectedFiles =
                    from file in fileList
                    where file.Extension == ".jpg" || file.Extension == ".JPG" || file.Extension == ".jpeg"
                    || file.Extension == ".JPEG" || file.Extension == ".CR2" || file.Extension == ".png"
                    || file.Extension == ".PNG" || file.Extension == ".heif" || file.Extension == ".HEIF"
                    || file.Extension == ".mp4" || file.Extension == ".MP4" || file.Extension == ".mov"
                    || file.Extension == ".MOV" || file.Extension == ".gif" || file.Extension == ".GIF"
                    select file;
                
                // CMD interface
                Console.WriteLine($"Main Folder is: {mainPath} \n");
                Console.WriteLine($"{selectedFiles.Count()} is founded. \n Continue (y/n)?");
                var answerkey = Console.ReadKey();Console.WriteLine("");
                if (answerkey.KeyChar=='n') { Environment.Exit(0); }


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
