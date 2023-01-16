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
                    Pixel[h, w].Color = Color.White;
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
            if (x.Height == y.Height && x.Width == y.Width) 
            {
                for (int h = 0; h < x.Height; h++)
                {
                    for (int w = 0; w < x.Width; w++)
                    {
                        if (x.Pixel[h, w] != y.Pixel[h, w])
                            return false;  
                    }
                }
                return true;
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
            int count = 0;
            int occurrences = 0;

            for (int line = 0; line < x.Height; line++)
            {
                for (int column = 0; column < x.Width; column++) // Varre A matrix da imagem X
                {
                    if (x.Pixel[line, column] == y.Pixel[0, 0]) // Se encontrar o inicio da matriz da imagem Y inicia varredura da mesma
                    {
                        int yLine = 0;//1//1
                        int yColumn = 1;//0//1
                        while (yLine < y.Height)//Colocar pra procurar uma matriz dentro de outra
                        {
                            while (yColumn < y.Width)
                            {
                                if (y.Pixel[yLine, yColumn] == x.Pixel[line + yLine, column + yColumn])
                                {
                                    count++;
                                    yColumn++;
                                }
                                else
                                {
                                    yColumn = y.Width;
                                    yLine = y.Height;
                                    count = 0;
                                }
                            }
                            yLine++;
                            yColumn = 0;
                        }
                        if (count == (y.Height * y.Width) - 1)
                        {
                            occurrences++;
                            count = 0;
                        }
                    }
                }
            }
            return (occurrences > 0);
        }
    }
}
