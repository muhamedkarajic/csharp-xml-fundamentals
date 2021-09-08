using System.Windows;
using System.Windows.Controls;

namespace LinqToXml.Samples.Sample01
{
  public partial class LinqLoad : UserControl
  {
    public LinqLoad()
    {
      InitializeComponent();

      // Connect to instance of the view model created by the XAML
      _viewModel = (LinqLoadViewModel)this.Resources["viewModel"];
    }

    // View model class
    private LinqLoadViewModel _viewModel = null;

    private void LoadUsingXDocumentButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.LoadUsingXDocument();
    }

    private void LoadUsingXElementButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.LoadUsingXElement();
    }
  }
}
