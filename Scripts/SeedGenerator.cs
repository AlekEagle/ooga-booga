using Godot;
using System;

public class SeedGenerator : Control
{
  public TextureRect textRect;
  public RandomNumberGenerator rng = new RandomNumberGenerator();
  public Seed seedGen = new Seed();
  Image image = new Image();
  public uint seed = 0;

  public override void _Ready()
  {
    image = seedGen.GetRandomImageSeed();

    textRect = GetNode<TextureRect>("TextureRect");

    ImageTexture imgText = new ImageTexture();
    imgText.CreateFromImage(image);

    textRect.Texture = imgText;
    imgText.Flags = 0;
  }

  private void ChangeLabel(float a)
  {
    GetNode<Label>("Label3").Text = a.ToString();
  }

  private void _ImportSeed(String seedPath)
  {
    ImageTexture imageTexture = new ImageTexture();
    Image img = new Image();
    img.Load(seedPath);
    imageTexture.CreateFromImage(img);
    textRect.Texture = imageTexture;
    imageTexture.Flags = 0;

    GD.Print(seedGen.GetSeedFromImage(img));
  }

  private void _ExportSeed(String seedPath)
  {
    image = new Image();
    image.CreateFromData(128, 128, false, Image.Format.Rgb8, textRect.Texture.GetData().GetData());
    image.SavePng(seedPath);

    GD.Print(seedGen.GetSeedFromImage(image));
  }
}
