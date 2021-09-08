using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Caching.Samples.Sample03
{
  public class DetectChangesViewModel : ViewModelBase
  {
    #region Constructor
    public DetectChangesViewModel()
    {
      CreateXmlFileName(CUSTOMER_XML_FILE);
    }
    #endregion

    private const string CUSTOMER_XML_FILE = "Customers.xml";
    private const string LAST_DATE_NAME = "ModifiedDate";
    private const string PARENT_NODE = "Customer";

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
      GetData(LAST_DATE_NAME, PARENT_NODE);
    }
    #endregion

    #region GetLocalInfo Method
    public void GetLocalInfo()
    {
      GetLocalInfo(LAST_DATE_NAME, PARENT_NODE);
    }
    #endregion

    #region GetFromServer Method
    public override void GetFromServer()
    {
      AdventureWorksLTDbContext db = null;

      try {
        using (db = new AdventureWorksLTDbContext()) {
          Customers = new ObservableCollection<Customer>(db.Customers);
        }

        ResultText += "Read from Customers table on SQL Server" + Environment.NewLine;
      }
      catch (Exception ex) {
        ResultText = ex.ToString();
      }
    }
    #endregion

    #region GetServerInfo Method
    public override void GetServerInfo()
    {
      DateTime ret = DateTime.MinValue;
      AdventureWorksLTDbContext db = null;

      ServerMaxDate = DateTime.MinValue;
      ServerTotalRows = -1;

      try {
        using (db = new AdventureWorksLTDbContext()) {
          // Get maximum date in ModifiedDate field
          ServerMaxDate = db.Customers.OrderByDescending(c => c.ModifiedDate)
            .Select(c => c.ModifiedDate).FirstOrDefault();
          // Get total rows in the Customer table on the server
          ServerTotalRows = db.Customers.Count();

          ResultText += "Server Max Date: " + ServerMaxDate.ToString() + Environment.NewLine;
          ResultText += "Server Total Rows: " + ServerTotalRows.ToString() + Environment.NewLine;
        }
      }
      catch (Exception ex) {
        ResultText = ex.ToString();
      }
    }
    #endregion

    #region StoreToLocalFile Method
    public override void StoreToLocalFile()
    {
      string xml;

      // Serialize Collection
      xml = Customers.Serialize<ObservableCollection<Customer>>();

      // Write XML to local file
      WriteXmlFile(xml);

      if (string.IsNullOrEmpty(LastErrorMessage)) {
        ResultText += "Stored Customers in File: '" + Path.GetFileName(XmlFileName) + "'" + Environment.NewLine;
      }
      else {
        ResultText = LastErrorMessage;
      }
    }
    #endregion

    #region GetFromXmlFile Method
    public override void GetFromXmlFile()
    {
      string xml;

      // Clear properties
      Customers = new ObservableCollection<Customer>();

      // Read from local XML file
      xml = ReadXmlFile();
      if (!string.IsNullOrEmpty(xml)) {
        // Deserialize customers
        Customers = Customers.Deserialize<ObservableCollection<Customer>>(xml);

        // Display Results
        ResultText += "Read from Local XML File: '" + Path.GetFileName(XmlFileName) + "'." + Environment.NewLine;
      }
      else {
        // Get data from server
        GetFromServer();
      }
    }
    #endregion
  }
}
