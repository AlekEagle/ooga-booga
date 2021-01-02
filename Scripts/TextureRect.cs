using Godot;
using System;

public class TextureRect : OogaBooga.SeedCanvas
{

  private int MouseButton = 0;
  public override void _OnMouseMove(Vector2 loc)
  {
    Draw(loc);
  }

  public override void _OnMouseClick(Vector2 loc, int button)
  {
    MouseButton = button;
    Draw(loc);
  }

  private void Draw(Vector2 loc)
  {
    if (MouseButton == 1)
    {
      Slider slider = GetParent<Control>().GetNode<Slider>("HSlider");
      Image thing = new Image();
      thing.CreateFromData(128, 128, false, Image.Format.Rgb8, Texture.GetData().GetData());
      thing.Lock();

      for (int x = 0; x < slider.Value; x++)
      {
        for (int y = 0; y < slider.Value; y++)
        {
          thing.SetPixelv(loc + new Vector2(x, y), GetParent<Control>().GetNode<ColorPickerButton>("ColorPickerButton").Color);
        }
      }
      ImageTexture a = new ImageTexture();
      a.CreateFromImage(thing);
      Texture = a;
      a.Flags = 0;
    }
  }
}