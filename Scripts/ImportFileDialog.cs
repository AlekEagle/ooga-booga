using Godot;
using System;

public class ImportFileDialog : Godot.FileDialog
{
  private void _ShowDialog()
  {
    CurrentDir = OS.GetSystemDir(OS.SystemDir.Documents);
    Popup_();
  }
}
