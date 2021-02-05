using System;
using System.Collections.Generic;
using System.Text;
using MetadataExtractor;

namespace PhotoOrganizer
{
    class MyMetaDataCapture
    {

        //var directories = ImageMetadataReader.ReadMetadata(FI.FullName);
        //// select only EXIF tag
        //var subIfdDirectory = directories.OfType<ExifSubIfdDirectory>();


        //foreach (var directory in subIfdDirectory)
        //{
        //    var dateTime = directory?.GetDescription(ExifDirectoryBase.TagDateTimeOriginal);

        //    if (dateTime != null)
        //    {
        //        string s = dateTime.ToString();
        //        string[] ss = s.Split(':');
        //        Console.WriteLine($"Moving {FI.Name} to {ss[0]}-{ss[1]}");


        //        MyDirectory.CreateDirectory(mainPath + "\\SortedByYear" + "\\" + ss[0] + "\\" + ss[1]);
        //        //File.Copy(FI.FullName, mainPath + "\\SortedByYear" + "\\" + ss[0] + "\\" + ss[1]+"\\"+FI.Name);
        //        File.Move(FI.FullName, mainPath + "\\SortedByYear" + "\\" + ss[0] + "\\" + ss[1] + "\\" + FI.Name);




        //    }

        //}
    }
}
