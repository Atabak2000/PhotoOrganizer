using System.Collections.Generic;

namespace PhotoOrganizer
{
    class MyFileType
    {
        public MyFileType()
        { 

        }

        public List<string> photoFormats = new List<string>() { ".jpg", ".JPG", ".jpeg", ".JPEG", ".png", ".PNG", ".heif", ".HEIF" };
        public List<string> rawFormats = new List<string>() { ".CR2", ".NEF" };
        public List<string> videoFormats = new List<string>() { ".MOV", ".mov", ".gif", ".GIF", ".MP4", ".mp4" };

        public List<string> getAllFormats()
        {
            List<string> allFormats=new List<string>();
            allFormats.AddRange(photoFormats);
            allFormats.AddRange(rawFormats);
            allFormats.AddRange(videoFormats);
            return allFormats;
        }
        
        public List<string> getPhotoFormats()
        {
            return photoFormats;
        }
    }
}

