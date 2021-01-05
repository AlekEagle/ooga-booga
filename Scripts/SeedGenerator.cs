using Godot;
using System;

public class SeedGenerator
{
    RandomNumberGenerator rng = new RandomNumberGenerator();

    public Image CreateRandomImageSeed()
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

    public Image CreateImageFromSeed(uint seed)
    {
        Image img = new Image();
        img.Create(128, 128, false, Image.Format.Rgb8);
        img.Lock();
        for(int x = 0; x < 128; x++)
        {
            for(int y = 0; y < 128; y++)
            {

            }
        }
        return img;
    }

    public uint GetSeedFromImage(Image img)
    {
        img.Lock();
        uint seed = 0;

        byte[] imgData = img.GetData();

        for(int x = 0; x < 128; x++)
        {
            for(int y = 0; y < 128; y++)
            {
                seed += (uint)imgData[0 + (y * x)] + (uint)imgData[1 + (y * x)] + (uint)imgData[2 + (y * x)];
            }
        }

        return seed;
    }
}