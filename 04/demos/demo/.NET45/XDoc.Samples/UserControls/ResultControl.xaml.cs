using System.Windows;
using System.Windows.Controls;

namespace XDoc.Samples.UserControls
{
  public partial class ResultControl : UserControl
  {
    public ResultControl()
    {
      InitializeComponent();
    }

    private CommonBase _viewModel = null;

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
      _viewModel = (CommonBase)this.DataContext;
    }
  }
}
