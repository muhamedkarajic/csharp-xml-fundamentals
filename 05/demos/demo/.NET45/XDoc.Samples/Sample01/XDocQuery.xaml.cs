using System.Windows;
using System.Windows.Controls;

namespace XDoc.Samples.Sample01
{
  public partial class XDocQuery : UserControl
  {
    public XDocQuery()
    {
      InitializeComponent();

      // Connect to instance of the view model created by the XAML
      _viewModel = (XDocQueryViewModel)this.Resources["viewModel"];
    }

    // View model class
    private XDocQueryViewModel _viewModel = null;

    private void XDocAllNodesButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.XDocGetAll();
    }

    private void XDocFindElementButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.XDocFindByElement();
    }

    private void XDocFindByAttributeButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.XDocFindByAttribute();
    }

    private void XElemAllNodesButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.XElemGetAll();
    }

    private void XElemFindElementButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.XElemFindByElement();
    }

    private void XElemFindByAttributeButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.XElemFindByAttribute();
    }
  
    private void XElemReadConfigButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.ReadConfig();
    }
  }
}
