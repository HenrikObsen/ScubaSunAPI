using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;


    public class FileTools
    {

        public string CreateFile(string filePath)
        {
            StreamWriter sw = File.CreateText(filePath);
            sw.Close();
            return "Filen er oprettet";
        }

        public string DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return "Filen er nu slettet!";
            }
            else
            {
                return "Filen ( " + filePath + " ) findes ikke i mappen!!!";
            }

        }

        public void WritToFile(string path, string text)
        {

            StreamWriter sw = new StreamWriter(path);

            sw.Write(text + "\n");
            sw.WriteLine("/* Opdateret: " + DateTime.Now + " */\n");
            sw.Close();
        }

        public string ReadFromFile(string path)
        {
            StreamReader sr = File.OpenText(path);
            string input = sr.ReadToEnd();
            sr.Close();

            return input;
        }

        public FileInfo[] GetAllFiles(string path)
        {
            DirectoryInfo myDirectory = new DirectoryInfo(path);
            FileInfo[] files = myDirectory.GetFiles();

            return files;
        }

        public string UploadFile(HttpPostedFileBase fil, string outputPath)
        {
            string fileName = Path.GetFileName(fil.FileName);

            fileName.Replace(" ", "_");
            fileName.Replace("æ", "ae");
            fileName.Replace("ø", "oe");
            fileName.Replace("å", "aa");

            fil.SaveAs(outputPath + fileName);

            return outputPath + fileName;

        }

        public string ReSizeImage(string imagePath, string imagePathTo, int newWidth)
        {
            System.Drawing.Image bm = System.Drawing.Image.FromFile(imagePath);

            int newHeight = (bm.Height * newWidth) / bm.Width;

            Bitmap resized = new Bitmap(newWidth, newHeight);

            Graphics g = Graphics.FromImage(resized);

            g.DrawImage(bm, new Rectangle(0, 0, resized.Width, resized.Height), 0, 0, bm.Width, bm.Height, GraphicsUnit.Pixel);

            g.Dispose();
            bm.Dispose();
            string fileName = Path.GetFileName(imagePath);

            resized.Save(imagePathTo + fileName, ImageFormat.Jpeg);

            return imagePathTo;
        }




    }
