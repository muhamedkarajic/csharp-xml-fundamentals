using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Caching.Samples.Sample02
{
  public class DetectChangesViewModel : CommonBase
  {
    #region Constructor
    public DetectChangesViewModel()
    {
      CreateXmlFileName(CUSTOMER_XML_FILE);
    }
    #endregion

    private const string CUSTOMER_XML_FILE = "Customers.xml";

    #region Properties
    private ObservableCollection<Customer> _Customers;
    private bool _IsFromLocal;
    private DateTime _LocalMaxDate;
    private DateTime _ServerMaxDate;
    private int _LocalTotalRows;
    private int _ServerTotalRows;

    public ObservableCollection<Customer> Customers
    {
      get { return _Customers; }
      set {
        _Customers = value;
        RaisePropertyChanged("Customers");
      }
    }

    public bool IsFromLocal
    {
      get { return _IsFromLocal; }
      set {
        _IsFromLocal = value;
        RaisePropertyChanged("IsFromLocal");
      }
    }

    /// <summary>
    /// Get/Set LocalMaxDate
    /// </summary>
    public DateTime LocalMaxDate
    {
      get { return _LocalMaxDate; }
      set {
        _LocalMaxDate = value;
        RaisePropertyChanged("LocalMaxDate");
      }
    }

    /// <summary>
    /// Get/Set ServerMaxDate
    /// </summary>
    public DateTime ServerMaxDate
    {
      get { return _ServerMaxDate; }
      set {
        _ServerMaxDate = value;
        RaisePropertyChanged("ServerMaxDate");
      }
    }

    /// <summary>
    /// Get/Set LocalTotalRows
    /// </summary>
    public int LocalTotalRows
    {
      get { return _LocalTotalRows; }
      set {
        _LocalTotalRows = value;
        RaisePropertyChanged("LocalTotalRows");
      }
    }

    /// <summary>
    /// Get/Set ServerTotalRows
    /// </summary>
    public int ServerTotalRows
    {
      get { return _ServerTotalRows; }
      set {
        _ServerTotalRows = value;
        RaisePropertyChanged("ServerTotalRows");
      }
    }
    #endregion

    #region GetData Method
    public void GetData()
    {
      // Clear properties
      ResultText = string.Empty;
      Customers = new ObservableCollection<Customer>();

      // Get local XML file info
      GetLocalInfo();
      // Get server info
      GetServerInfo();
      // Check if server date is greater than local date 
      // and total rows are not the same
      if (LocalMaxDate < ServerMaxDate || 
          LocalTotalRows != ServerTotalRows) {
        // Get info from server
        GetFromServer();
        // Store XML data to local file
        StoreToLocalFile();
        IsFromLocal = false;
      }
      else {
        // Get info from local file
        GetFromXmlFile();
        IsFromLocal = true;
      }

      ResultText += "Is From Local: " + IsFromLocal.ToString() + Environment.NewLine;
    }
    #endregion

    #region GetLocalInfo Method
    public void GetLocalInfo()
    {
      XElement xelem;

      LocalMaxDate = DateTime.MinValue;
      LocalTotalRows = -1;

      if (File.Exists(XmlFileName)) {
        try {
          xelem = XElement.Parse(File.ReadAllText(XmlFileName));
          // Get largest ModifiedDate in local XML file
          LocalMaxDate = xelem.GetMaxValue<DateTime>("ModifiedDate", "Customer");
          // Get total rows in local XML file
          LocalTotalRows = xelem.GetCount("Customer");

          ResultText += "Local Max Date: " + LocalMaxDate.ToString() + Environment.NewLine;
          ResultText += "Local Total Rows: " + LocalTotalRows.ToString() + Environment.NewLine;
        }
        catch (Exception ex) {
          ResultText = ex.ToString();
        }
      }
    }
    #endregion

    #region GetServerInfo Method
    public void GetServerInfo()
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
    public void StoreToLocalFile()
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

    #region GetFromServer Method
    public void GetFromServer()
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

    #region GetFromXmlFile Method
    public void GetFromXmlFile()
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
