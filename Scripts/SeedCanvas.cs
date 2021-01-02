using Godot;
using System;

namespace OogaBooga
{
  public class SeedCanvas : Godot.TextureRect
  {
    public override void _GuiInput(InputEvent @event)
    {
      if (@event is InputEventMouseMotion motion)
      {
        _OnMouseMove(new Vector2((int)((motion.Position.x / RectSize.x) * 128), (int)((motion.Position.y / RectSize.y) * 128)));
      }
      else if (@event is InputEventMouseButton button)
      {
        _OnMouseClick(new Vector2((int)((button.Position.x / RectSize.x) * 128), (int)((button.Position.y / RectSize.y) * 128)), button.ButtonMask);
      }
    }

    public virtual void _OnMouseMove(Vector2 loc) { }

    public virtual void _OnMouseClick(Vector2 loc, int Button) { }
  }
}