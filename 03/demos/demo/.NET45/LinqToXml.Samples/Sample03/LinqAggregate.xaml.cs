using System.Windows;
using System.Windows.Controls;

namespace LinqToXml.Samples.Sample03
{
  public partial class LinqAggregate : UserControl
  {
    public LinqAggregate()
    {
      InitializeComponent();

      // Connect to instance of the view model created by the XAML
      _viewModel = (LinqAggregateViewModel)this.Resources["viewModel"];
    }

    // View model class
    private LinqAggregateViewModel _viewModel = null;

    private void CountButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.Count();
    }

    private void SumButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.Sum();
    }

    private void MinimumButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.Minimum();
    }

    private void MaximumButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.Maximum();
    }

    private void AverageButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.Average();
    }
  }
}
