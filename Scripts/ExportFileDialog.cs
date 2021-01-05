using Godot;
using System;

public class ExportFileDialog : FileDialog
{

  public override void _Ready()
  {

  }

  private void _ShowDialog()
  {
    CurrentDir = OS.GetSystemDir(OS.SystemDir.Documents);
    CurrentFile = "Seed_" + OS.GetUnixTime() + ".png";
    Popup_();
  }
}
