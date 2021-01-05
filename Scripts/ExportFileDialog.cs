using Godot;
using System;

public class ExportFileDialog : FileDialog
{
  private void _ShowDialog()
  {
    CurrentDir = OS.GetSystemDir(OS.SystemDir.Documents);
    CurrentFile = "Seed_" + OS.GetUnixTime() + ".png";
    Popup_();
  }
}
