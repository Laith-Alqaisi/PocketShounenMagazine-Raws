using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DycreptMagazinePages
{
    public partial class Form1 : Form
    {
        public string SearchPath;
        public string SavePath;

        public int PageNumber;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchPath = textBox1.Text;
            SavePath = textBox2.Text;

            var images = Directory.EnumerateFiles($@"{SearchPath}", "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg"));
            
            foreach (var image in images)
            {
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
                        Bitmap partBitmap = bitmap.Clone(new Rectangle(Xoffset, Yoffset, gridBoxWidth, gridBoxHeight), bitmap.PixelFormat);

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
                            graphics.DrawImage(imageParts[x + y * 4], new Rectangle(Xoffset, Yoffset, gridBoxWidth, gridBoxHeight));

                            Xoffset += gridBoxWidth;
                        }

                        Yoffset += gridBoxHeight;
                    }
                }
                
                //Save the bitmap to a new image
                PageNumber++;
                newBitmap.Save($@"{SavePath}\{PageNumber}.png");
            }
        }
    }
}
