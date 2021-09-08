using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Caching.Samples.Sample01
{
  public class ReadAndStoreViewModel : CommonBase
  {
    #region Constructor
    public ReadAndStoreViewModel()
    {
      CreateXmlFileName(CUSTOMER_XML_FILE);
    }
    #endregion

    private const string CUSTOMER_XML_FILE = "Customers.xml";

    #region Properties
    private ObservableCollection<Customer> _Customers;

    public ObservableCollection<Customer> Customers
    {
      get { return _Customers; }
      set {
        _Customers = value;
        RaisePropertyChanged("Customers");
      }
    }
    #endregion

    #region GetData Method
    public void GetData()
    {
      string xml;

      // Clear properties
      ResultText = string.Empty;
      Customers = new ObservableCollection<Customer>();

      // Attempt to read local XML file
      xml = ReadXmlFile();
      // Check to see if we got any data
      if (!string.IsNullOrEmpty(xml)) {
        // Deserialize customers from XML
        Customers = 
          Customers.Deserialize<ObservableCollection<Customer>>(xml);

        // Display Results
        ResultText = "Read from XML File: '" + Path.GetFileName(XmlFileName) + "'.";
      }
      else {
        // Get data from server
        GetFromServer();

        // Serialize Collection
        xml = Customers.Serialize<ObservableCollection<Customer>>();

        // Write XML to local file
        WriteXmlFile(xml);

        ResultText = "Read from Server and Stored in File: '" + Path.GetFileName(XmlFileName) + "'";
      }
    }
    #endregion

    #region GetFromServer Method
    public void GetFromServer()
    {
      AdventureWorksLTDbContext db = null;

      try {
        using (db = new AdventureWorksLTDbContext()) {
          Customers = new ObservableCollection<Customer>(db.Customers);
        }
      }
      catch (Exception ex) {
        ResultText = ex.ToString();
      }
    }
    #endregion
  }
}
