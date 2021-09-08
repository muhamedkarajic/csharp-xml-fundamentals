using System.Windows;
using System.Windows.Controls;

namespace Caching.Samples.Sample02
{
  public partial class DetectChangesControl : UserControl
  {
    public DetectChangesControl()
    {
      InitializeComponent();

      // Connect to instance of the view model created by the XAML
      _viewModel = (DetectChangesViewModel)this.Resources["viewModel"];
    }

    private DetectChangesViewModel _viewModel;

    private void GetButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.GetData();
    }
  }
}
