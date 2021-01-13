using Godot;
using System;

public class Seed
{
  RandomNumberGenerator rng = new RandomNumberGenerator();

  public Image GetRandomImageSeed()
  {
    Image img = new Image();
    img.Create(128, 128, false, Image.Format.Rgb8);
    img.Lock();

    for (int x = 0; x < 128; x++)
    {
      for (int y = 0; y < 128; y++)
      {
        rng.Randomize();
        float r = rng.Randf(), g = rng.Randf(), b = rng.Randf();
        img.SetPixel(x, y, new Color(r, g, b));
      }
    }
    return img;
  }

  public ulong GetSeedFromImage(Image img)
  {
    img.Lock();
    ulong seed = 0;

    byte[] imgData = img.GetData();

    seed += imgData[0];

    for (int i = 1; i < imgData.Length; i++)
    {
      seed += (ulong)imgData[i] + 1;
    }

    seed *= (ulong)imgData[imgData.Length / 2] + 1;

    return seed;
  }
}