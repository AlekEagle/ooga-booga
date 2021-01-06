using Godot;
using System;

public class SeedGenerator
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

    public Image GetImageFromSeed(uint seed)
    {
        Image img = new Image();
        img.Create(128, 128, false, Image.Format.Rgb8);
        img.Lock();

        byte[] imgData = new byte[128 * 128];
        /*
        Array.Reverse(imgData);

        for(int i = 0; i < imgData.Length; i++)
        {
            imgData[i] = BitConverter.GetBytes(seed)[i];
        }
        */
        img.CreateFromData(128, 128, false, Image.Format.Rgb8, imgData);

        return img;
    }

    public uint GetSeedFromImage(Image img)
    {
        img.Lock();
        uint seed = 0;

        byte[] imgData = img.GetData();

        for(int i = 0; i < imgData.Length; i++)
        {
            seed += (uint)imgData[i];
        }

        return seed;
    }
}