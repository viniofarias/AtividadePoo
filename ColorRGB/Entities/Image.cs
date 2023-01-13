using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RGB.Entities
{
    public class Image
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public Pixel[,] Pixel { get; set; }
        public Image(int height, int width)
        {
            Height = height;
            Width = width;
            Pixel = new Pixel[Height, Width];
            for (int h=0; h < Height; h++)
            {
                for(int w=0; w < Width; w++)
                {
                    Pixel[h, w].Color = new Color().White;
                }
            }
        }
        public void ChangeColorPixel(Pixel pixel, int height, int width)
        {
            Pixel[height,width] = pixel;
        }
        public void ChangeColorPixel(int height, int width, Color color )
        {
            Pixel[height, width].Color = color;
        }
        public bool CompareImages(Image x, Image y)
        {
            bool compare = false;
            if (x.Height == y.Height && x.Width == y.Width) 
            {
                for (int h = 0; h < x.Height; h++)
                {
                    for (int w = 0; w < x.Width; w++)
                    {
                        compare = (x.Pixel[h,w] == y.Pixel[h,w])? compare=true : compare=false; break;
                    }
                }
                return compare;
            }
            else
            {
                return false;
            }
            
        }
        public void EquivalentGrayToImage(Image x)
        {
            for (int h = 0; h < x.Height; h++)
            {
                for (int w = 0; w < x.Width; w++)
                {
                    x.Pixel[h, w].Color = Color.EquivalentGray(x.Pixel[h, w].Color);
                }
            }
        }
        public bool ImageInsideImage(Image x, Image y)
        {
            for (int h = 0; h < x.Height; h++)
            {
                for (int w = 0; w < x.Width; w++)
                {
                    if (x.Pixel[h,w] == y.Pixel[0, 0])
                    {
                        int yh = 0;
                        while (yh<y.Height)//Colocar pra procurar uma matriz dentro de outra
                        {
                            for (int yw = 0; yw < y.Width; yw++)
                            {
                                if (x.Pixel[h, w] == y.Pixel[h, yw]) continue;
                                else break;
                            }
                        }
                    }
                }
            }
        }
    }
}
