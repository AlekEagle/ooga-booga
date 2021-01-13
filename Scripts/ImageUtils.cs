using Godot;
using System;
namespace ImageUtils
{

  public class ImagePixels
  {
    public int width;
    public int height;
    public Color[,] pixels;

    public ImagePixels(int w = 0, int h = 0, Color[,] pixels = null)
    {
      width = w;
      height = h;
      pixels = new Color[width, height];
    }

    public ImagePixels(Image img)
    {
      width = img.GetWidth();
      height = img.GetHeight();

      byte[] rawImg = img.GetData();
      int pixelCount = rawImg.Length / 3;
      pixels = new Color[width, height];


      for (int byteInd = 0; byteInd < rawImg.Length; byteInd += 3)
      {
        pixels[(int)((byteInd / 3) / width), (int)((byteInd / 3) % height)] = new Color(rawImg[byteInd], rawImg[byteInd + 1], rawImg[byteInd + 2], 1);
      }
    }

    public Image ToImage()
    {
      Image img = new Image();

      int byteCount = pixels.Length * 3;
      byte[] data = new byte[byteCount];

      for (int byteInd = 0; byteInd < byteCount; byteInd += 3)
      {
        data[byteInd] = (byte)(255 - pixels[(int)((byteInd / 3) / width), (int)((byteInd / 3) % height)].r8);
        data[byteInd + 1] = (byte)(255 - pixels[(int)((byteInd / 3) / width), (int)((byteInd / 3) % height)].g8);
        data[byteInd + 2] = (byte)(255 - pixels[(int)((byteInd / 3) / width), (int)((byteInd / 3) % height)].b8);
      }

      img.CreateFromData(width, height, false, Image.Format.Rgb8, data);
      return img;
    }
  }
}