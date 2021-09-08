using System.Windows;
using System.Windows.Controls;

namespace XDoc.Samples.Sample04
{
  public partial class XDocWrite : UserControl
  {
    public XDocWrite()
    {
      InitializeComponent();

      // Connect to instance of the view model created by the XAML
      _viewModel = (XDocWriteViewModel)this.Resources["viewModel"];
    }

    // View model class
    private XDocWriteViewModel _viewModel = null;

    private void XDocSaveButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.XDocSave();
    }

    private void XmlWriterSaveButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.XmlWriterSave();
    }

    private void XmlWriterFormattingButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.XmlWriterFormattingSave();
    }

    private void DataSetButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.DataSetSave();
    }

    private void ReadXmlFileButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.ReadXmlFile();
    }

    private void ReadXsdFileButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.ReadXsdFile();
    }
  }
}
