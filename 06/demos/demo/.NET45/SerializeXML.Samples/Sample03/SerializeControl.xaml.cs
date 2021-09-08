using System;
using System.Windows;
using System.Windows.Controls;

namespace SerializeXML.Samples.Sample03
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
      // Add customer sales
      _viewModel.Entity.CustomerSales.Add(new SalesHeader { SalesOrderID = 71915, OrderDate = Convert.ToDateTime("2018-12-03"), SalesOrderNumber = "SO71915", TotalDue = 2361.64 });
      _viewModel.Entity.CustomerSales.Add(new SalesHeader { SalesOrderID = 71938, OrderDate = Convert.ToDateTime("2019-01-04"), SalesOrderNumber = "SO71938", TotalDue = 3598.32 });
      _viewModel.Entity.CustomerSales.Add(new SalesHeader { SalesOrderID = 71783, OrderDate = Convert.ToDateTime("2019-02-02"), SalesOrderNumber = "SO72003", TotalDue = 1311.79 });
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
