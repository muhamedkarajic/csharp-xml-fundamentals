using System.Windows;
using System.Windows.Controls;

namespace Caching.Samples.Sample01
{
  public partial class ReadAndStoreControl : UserControl
  {
    public ReadAndStoreControl()
    {
      InitializeComponent();

      // Connect to instance of the view model created by the XAML
      _viewModel = (ReadAndStoreViewModel)this.Resources["viewModel"];
    }

    private ReadAndStoreViewModel _viewModel;

    private void GetDataButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.GetData();
    }
  }
}
