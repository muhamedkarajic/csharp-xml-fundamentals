using System;
using System.Windows;
using System.Windows.Controls;

namespace Caching.Samples
{
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
      MenuItem mnu = (MenuItem)sender;
      string cmd = string.Empty;

      // The Tag property contains a command 
      // or the name of a user control to load
      if (mnu.Tag != null) {
        cmd = mnu.Tag.ToString();
        if (cmd.Contains(".")) {
          // Display a user control
          LoadUserControl(cmd);
        }
        else {
          // Process special commands
          ProcessMenuCommands(cmd);
        }
      }
    }

    private void LoadUserControl(string controlName)
    {
      Type ucType = null;
      UserControl uc = null;

      // Create a Type from controlName parameter
      ucType = Type.GetType(controlName);
      if (ucType == null) {
        MessageBox.Show("The Control: " + controlName
                         + " does not exist.");
      }
      else {
        // Close current user control in content area
        CloseUserControl();

        // Create an instance of this control
        uc = (UserControl)Activator.CreateInstance(ucType);
        if (uc != null) {
          // Display control in content area
          DisplayUserControl(uc);
        }
      }
    }

    private void ProcessMenuCommands(string command)
    {
      switch (command.ToLower()) {
        case "exit":
          this.Close();
          break;

        default:
          break;
      }
    }


    private void CloseUserControl()
    {
      // Remove current user control
      contentArea.Children.Clear();
    }

    public void DisplayUserControl(UserControl uc)
    {
      // Add new user control to content area
      contentArea.Children.Add(uc);
    }
  }
}
