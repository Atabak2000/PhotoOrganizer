using System;
using MetadataExtractor;
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

            string mainPath = @"E:\Music";
            //string mainPath = SDirectory.GetCurrentDirectory();


            // Take a snapshot of the file system.  
            DirectoryInfo dir = new DirectoryInfo(mainPath);

            // This method assumes that the application has discovery permissions  
            // for all folders under the specified path.  
            IEnumerable<FileInfo> fileList = dir.GetFiles("*.*",SearchOption.AllDirectories);

            // fileList.Where(); /////////////////////////////////////////////////////////

            //Create the query  
            //IEnumerable<FileInfo> fileQuery =
            //    from file in fileList
            //    where file.Extension == ".JPG"
            //    select file;

            ////Execute the query. This might write out a lot of files!  
            //foreach (FileInfo fi in fileQuery)
            //{
            //    Console.WriteLine(fi.FullName);
            //}






            //var directories = ImageMetadataReader.ReadMetadata(path);
            //foreach (var directory in directories)
            //    foreach (var tag in directory.Tags)
            //        Console.WriteLine($"{directory.Name} - {tag.Name} = {tag.Description}");
        }
        
    }

}
