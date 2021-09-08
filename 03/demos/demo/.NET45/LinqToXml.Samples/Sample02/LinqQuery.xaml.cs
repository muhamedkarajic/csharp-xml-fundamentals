using System.Windows;
using System.Windows.Controls;

namespace LinqToXml.Samples.Sample02
{
  public partial class LinqQuery : UserControl
  {
    public LinqQuery()
    {
      InitializeComponent();

      // Connect to instance of the view model created by the XAML
      _viewModel = (LinqQueryViewModel)this.Resources["viewModel"];
    }

    // View model class
    private LinqQueryViewModel _viewModel = null;

    private void AllNodesButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.GetAll();
    }

    private void SingleNodeButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.SingleNode();
    }

    private void WhereButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.WhereClause();
    }

    private void WhereAttributeButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.WhereClauseUsingAttribute();
    }

    private void OrderByButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.OrderBy();
    }

    private void JoinButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.Join();
    }

    private void ReadConfigButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.ReadConfig();
    }

    private void LoadClassesButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.LoadClasses();
    }
  }
}
