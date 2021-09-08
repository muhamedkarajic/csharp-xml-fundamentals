using System.Windows;
using System.Windows.Controls;

namespace XDoc.Samples.Sample02
{
  public partial class XDocAggregate : UserControl
  {
    public XDocAggregate()
    {
      InitializeComponent();

      // Connect to instance of the view model created by the XAML
      _viewModel = (XDocAggregateViewModel)this.Resources["viewModel"];
    }

    // View model class
    private XDocAggregateViewModel _viewModel = null;


    private void CountButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.Count();
    }

    private void SumButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.Sum();
    }

    private void MinButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.Minimum();
    }

    private void MaxButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.Maximum();
    }

    private void AverageButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.Average();
    }
  }
}
