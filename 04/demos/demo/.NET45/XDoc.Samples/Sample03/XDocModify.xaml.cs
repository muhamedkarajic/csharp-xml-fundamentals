using System.Windows;
using System.Windows.Controls;

namespace XDoc.Samples.Sample03
{
  public partial class XDocModify : UserControl
  {
    public XDocModify()
    {
      InitializeComponent();

      // Connect to instance of the view model created by the XAML
      _viewModel = (XDocModifyViewModel)this.Resources["viewModel"];
    }

    // View model class
    private XDocModifyViewModel _viewModel = null;

    private void BuildEmptyXmlButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.BuildEmptyXMLDocument();
    }

    private void BuildXmlButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.BuildXmlDocument();
    }
    
    private void LoadStringButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.LoadString();
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.Add();
    }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.Update();
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.Delete();
    }
  }
}
