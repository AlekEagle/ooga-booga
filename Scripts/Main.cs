using Godot;
using System;

public class Main : Control
{
  public TextureRect thing;

  public Image otherThing;
  public RandomNumberGenerator rng = new RandomNumberGenerator();

  public override void _Ready()
  {
    thing = GetNode<TextureRect>("TextureRect");
    otherThing = new Image();
    otherThing.Create(128, 128, false, Image.Format.Rgb8);
    otherThing.Lock();

    for (int x = 0; x < 128; x++)
    {
      for (int y = 0; y < 128; y++)
      {
        rng.Randomize();
        float r = rng.Randf(), g = rng.Randf(), b = rng.Randf();
        otherThing.SetPixel(x, y, new Color(r, g, b));
      }
    }

    ImageTexture a = new ImageTexture();
    a.CreateFromImage(otherThing);

    thing.Texture = a;
    a.Flags = 0;
  }

  private void ChangeLabel(float a)
  {
    GetNode<Label>("Label3").Text = a.ToString();
  }
}
