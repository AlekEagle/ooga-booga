using Godot;
using System;

public class Main : Control
{
  public TextureRect textRect;

  public Image image;
  public RandomNumberGenerator rng = new RandomNumberGenerator();

  public uint seed = 0;

  public override void _Ready()
  {
    textRect = GetNode<TextureRect>("TextureRect");
    image = new Image();
    image.Create(128, 128, false, Image.Format.Rgb8);
    image.Lock();

    for (int x = 0; x < 128; x++)
    {
      for (int y = 0; y < 128; y++)
      {
        rng.Randomize();
        float r = rng.Randf(), g = rng.Randf(), b = rng.Randf();
        image.SetPixel(x, y, new Color(r, g, b));
        seed += (uint)new Color(r, g, b).ToRgba32() - 255;
      }
    }

    ImageTexture a = new ImageTexture();
    a.CreateFromImage(image);

    textRect.Texture = a;
    a.Flags = 0;
    GD.Print(seed);
  }

  private void ChangeLabel(float a)
  {
    GetNode<Label>("Label3").Text = a.ToString();
  }

  private void _ImportSeed(String seedPath)
  {
    ImageTexture a = new ImageTexture();
    Image b = new Image();
    b.Load(seedPath);
    a.CreateFromImage(b);
    textRect.Texture = a;
    a.Flags = 0;
  }

  private void _ExportSeed(String seedPath)
  {
    image = new Image();
    image.CreateFromData(128, 128, false, Image.Format.Rgb8, textRect.Texture.GetData().GetData());
    image.SavePng(seedPath);
  }
}
