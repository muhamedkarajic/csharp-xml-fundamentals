using System.Windows;
using System.Windows.Controls;

namespace SerializeXML.Samples.Sample01
{
  public partial class SerializeSampleControl : UserControl
  {
    public SerializeSampleControl()
    {
      InitializeComponent();

      // Connect to instance of the view model created by the XAML
      _viewModel = (SerializeSampleViewModel)this.Resources["viewModel"];

      _viewModel.Entity = new Customer {
        CustomerID = 1,
        FirstName = "Bruce",
        LastName = "Jones",
        CompanyName = "Beach Computer Consulting"
      };
    }

    private SerializeSampleViewModel _viewModel;

    private void SerializeCustomerButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.Serialize();
    }

    private void DeserializeCustomerButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.Deserialize();
    }

    private void ReadFileButton_Click(object sender, RoutedEventArgs e)
    {
      _viewModel.ReadXmlFile();      
    }
  }
}
