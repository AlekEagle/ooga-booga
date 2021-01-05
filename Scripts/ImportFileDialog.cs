using Godot;
using System;

public class ImportFileDialog : Godot.FileDialog
{
  // Declare member variables here. Examples:
  // private int a = 2;
  // private string b = "text";

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {

  }

  private void _ShowDialog()
  {
    CurrentDir = OS.GetSystemDir(OS.SystemDir.Documents);
    Popup_();
  }
}
