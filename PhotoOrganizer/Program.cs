using System;
using MetadataExtractor;
using System.IO;
using MyDirectory = System.IO.Directory;
using System.Collections.Generic;
using System.Linq;
using MetadataExtractor.Formats.Exif;

namespace PhotoOrganizer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(SDirectory.GetCurrentDirectory());
            
            List<string> formats = new List<string>();
            formats.Add(".jpg");
            formats.Add(".JPG");
            formats.Add(".jpeg");
            formats.Add(".JPEG");
            formats.Add(".CR2");
            formats.Add(".png");
            formats.Add(".PNG");
            formats.Add(".heif");
            formats.Add(".HEIF");

            try
            {

                //string mainPath = @"C:\Users\Atabak\Desktop";
                string mainPath = MyDirectory.GetCurrentDirectory();
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

                Console.WriteLine($"Main Folder is: {mainPath} \n");
                Console.WriteLine($"{selectedFiles.Count()} is founded. \n Continue (y/n)?");
                var answerkey = Console.ReadKey();Console.WriteLine("");
                if (answerkey.KeyChar=='n') { Environment.Exit(0); }


                //foreach(var s in selectedFiles) Console.WriteLine(s.FullName);
                foreach (FileInfo FI in selectedFiles)
                {
                    if (File.GetLastWriteTime(FI.FullName) != null)
                    {
                        DateTime time = File.GetLastWriteTime(FI.FullName);
                        MyDirectory.CreateDirectory(mainPath + "\\SortedByYear" + "\\" + time.Year.ToString() + "\\" + time.Month.ToString());
                        File.Move(FI.FullName, mainPath + "\\SortedByYear" + "\\" + time.Year.ToString() + "\\" + time.Month.ToString() + "\\" + FI.Name);
                        Console.WriteLine($"Moving {FI.Name} to {time.Year}-{time.Month}");
                    }


                }
                Console.WriteLine($"path was : {mainPath}");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadKey();
            }

            
            
        }
        
    }

}
