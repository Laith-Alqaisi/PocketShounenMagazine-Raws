using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DycreptMagazinePages
{
    public partial class Form1 : Form
    {
        public string SearchPath;
        public string SavePath;

        public Form1()
        {
            InitializeComponent();
        }

        //PocketShounen
        private void button1_Click(object sender, EventArgs e)
        {
            SearchPath = SearchPathTextBox.Text;
            SavePath = SavePathTextBox.Text;

            var images = Directory.EnumerateFiles($@"{SearchPath}", "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".jfif") || s.EndsWith(".jpeg"));

            foreach (var image in images)
            {
                FileInfo imageFileInfo = new FileInfo(image);
                List<Bitmap> imageParts = new List<Bitmap>();
                Bitmap bitmap = new Bitmap(image);

                var gridBoxWidth = bitmap.Width / 4;
                var gridBoxHeight = bitmap.Height / 4;

                var Xoffset = 0;
                int Yoffset;

                //Read the image parts
                for (int x = 0; x < 4; x++)
                {
                    Yoffset = 0;
                    for (int y = 0; y < 4; y++)
                    {
                        Bitmap partBitmap = bitmap.Clone(new RectangleF(Xoffset, Yoffset, gridBoxWidth, gridBoxHeight), bitmap.PixelFormat);

                        imageParts.Add(partBitmap);

                        Yoffset += gridBoxHeight;
                    }

                    Xoffset += gridBoxWidth;
                }

                //Reorder and draw the image parts
                Bitmap newBitmap = new Bitmap(bitmap.Width, bitmap.Height);

                Yoffset = 0;

                using (var graphics = Graphics.FromImage(newBitmap))
                {
                    for (int y = 0; y < 4; y++)
                    {
                        Xoffset = 0;
                        for (int x = 0; x < 4; x++)
                        {
                            graphics.DrawImage(imageParts[x + y * 4], new RectangleF(Xoffset, Yoffset, gridBoxWidth, gridBoxHeight));

                            Xoffset += gridBoxWidth;
                        }

                        Yoffset += gridBoxHeight;
                    }
                }

                //Save the bitmap to a new image
                newBitmap.Save($@"{SavePath}\{imageFileInfo.Name}.png");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchPath = SearchPathTextBox.Text;

            var files = Directory.EnumerateFiles($@"{SearchPath}");

            int charIndex = 65; //ASCII code, 65 = A, 66 = B,...., 90 = Z.
            int index = 0;
            
            foreach (var file in files)
            {
                FileInfo myFileInfo = new FileInfo(file);
                
                File.Move(file, SearchPath + $@"\{(char)charIndex}{index}" + ".png");
                
                index++;
                if (index > 99)
                {
                    charIndex++;
                    index = 0;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int StartingPageNumber = int.Parse(SPNumberTextBox.Text);
            int EndingPageNumber = int.Parse(EPNumberTextBox.Text);

            string DocString = $"{StartingPageNumber}-{EndingPageNumber} ({EndingPageNumber - StartingPageNumber + 1}pages)\n\n";
            
            for (int i = StartingPageNumber; i <= EndingPageNumber; i++)
            {
                DocString += $"Page {i}: \n\n";
            }
            
            Clipboard.SetText(DocString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //ComicDays, igorquintaes
        private void button4_Click(object sender, EventArgs e)
        {
            SearchPath = SearchPathTextBox.Text;
            SavePath = SavePathTextBox.Text;

            var images = Directory.EnumerateFiles($@"{SearchPath}", "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".jfif") || s.EndsWith(".jpeg"));

            foreach(var image in images)
            {
                FileInfo imageFileInfo = new FileInfo(image);
                List<Bitmap> imageParts = new List<Bitmap>();
                Bitmap bitmap = new Bitmap(image);
                Bitmap newBitmap = new Bitmap(bitmap.Width, bitmap.Height);

                var gridBoxWidth = (int)Math.Floor((double)(bitmap.Width / 32)) * 8;
                var gridBoxHeight = (int)Math.Floor((double)(bitmap.Height / 32)) * 8;

                //Read, reorder and draw the image parts
                for (var x = 0; x + gridBoxWidth <= bitmap.Width; x += gridBoxWidth)
                {
                    for (var y = (x / gridBoxWidth) * gridBoxHeight + gridBoxHeight;  y + gridBoxHeight <= bitmap.Height; y += gridBoxHeight)
                    {
                        var rectOldPosition = new Rectangle(x, y, gridBoxWidth, gridBoxHeight);
                        var partBitmapOldPosition = bitmap.Clone(rectOldPosition, PixelFormat.DontCare);

                        var newPositionX = (y / gridBoxHeight) * gridBoxWidth;
                        var newPositionY = (x / gridBoxWidth) * gridBoxHeight;
                        var rectNewPosition = new Rectangle(newPositionX, newPositionY, gridBoxWidth, gridBoxHeight);
                        var partBitmapNewPosition = bitmap.Clone(rectNewPosition, PixelFormat.DontCare);

                        var graphics = Graphics.FromImage(newBitmap);

                        graphics.DrawImage(partBitmapNewPosition, new Point(x, y));
                        graphics.DrawImage(partBitmapOldPosition, new Point(newPositionX, newPositionY));
                    }
                }

                //Fill up the missing middle parts, credits to igorquintaes for this.
                for (var middleLine = 0; middleLine < 4; middleLine++)
                {
                    var middleLineX = middleLine * gridBoxWidth;
                    var middleLineY = middleLine * gridBoxHeight;
                    var rectMiddleLine = new Rectangle(middleLineX, middleLineY, gridBoxWidth, gridBoxHeight);
                    var ImageMiddleLine = bitmap.Clone(rectMiddleLine, PixelFormat.DontCare);

                    var graphics = Graphics.FromImage(newBitmap);
                    graphics.DrawImage(ImageMiddleLine, new Point(middleLineX, middleLineY));
                }

                //Save the bitmap to a new image
                newBitmap.Save($@"{SavePath}\{imageFileInfo.Name}.png");
            }
        }
    }
}