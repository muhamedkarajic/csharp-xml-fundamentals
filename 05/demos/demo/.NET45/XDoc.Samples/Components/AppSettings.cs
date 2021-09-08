using System;

namespace XDoc.Samples
{
  /// <summary>
  /// This class holds global data for this application
  /// </summary>
  public class AppSettings : CommonBase
  {
    #region Constructor
    public AppSettings()
    {
      Init();
    }
    #endregion

    #region Instance Property
    private static AppSettings _Instance;

    public static AppSettings Instance
    {
      get {
        if (_Instance == null) {
          _Instance = new AppSettings();
        }

        return _Instance;
      }
      set { _Instance = value; }
    }
    #endregion

    #region Private Properties
    private int _InfoMessageTimeout;
    private string _CustomersFile;
    private string _CustomersAttributesFile;
    private string _CustomersAndSalesFile;
    private string _SalesOrderHeadersFile;
    private string _SalesOrderDetailsFile;
    #endregion

    #region Public Properties
    public int InfoMessageTimeout
    {
      get { return _InfoMessageTimeout; }
      set {
        _InfoMessageTimeout = value;
        RaisePropertyChanged("InfoMessageTimeout");
      }
    }

    /// <summary>
    /// Get/Set CustomersFile
    /// </summary>
    public string CustomersFile
    {
      get { return _CustomersFile; }
      set {
        _CustomersFile = value;
        RaisePropertyChanged("CustomersFile");
      }
    }

    /// <summary>
    /// Get/Set CustomersAttributesFile
    /// </summary>
    public string CustomersAttributesFile
    {
      get { return _CustomersAttributesFile; }
      set {
        _CustomersAttributesFile = value;
        RaisePropertyChanged("CustomersAttributesFile");
      }
    }

    /// <summary>
    /// Get/Set CustomersAndSalesFile
    /// </summary>
    public string CustomersAndSalesFile
    {
      get { return _CustomersAndSalesFile; }
      set {
        _CustomersAndSalesFile = value;
        RaisePropertyChanged("CustomersAndSalesFile");
      }
    }

    /// <summary>
    /// Get/Set SalesOrderHeadersFile
    /// </summary>
    public string SalesOrderHeadersFile
    {
      get { return _SalesOrderHeadersFile; }
      set {
        _SalesOrderHeadersFile = value;
        RaisePropertyChanged("SalesOrderHeadersFile");
      }
    }

    /// <summary>
    /// Get/Set SalesOrderDetailsFile
    /// </summary>
    public string SalesOrderDetailsFile
    {
      get { return _SalesOrderDetailsFile; }
      set {
        _SalesOrderDetailsFile = value;
        RaisePropertyChanged("SalesOrderDetailsFile");
      }
    }
    #endregion

    #region Init Method
    public void Init()
    {
      string path = GetCurrentDirectory();
      CustomersFile = path + @"\Xml\Customers.xml";
      CustomersAttributesFile = path + @"\Xml\Customers_Attributes.xml";
      CustomersAndSalesFile = path + @"\Xml\CustomersAndSales.xml";
      SalesOrderHeadersFile = path + @"\Xml\SalesOrderHeaders.xml";
      SalesOrderDetailsFile = path + @"\Xml\SalesOrderDetails.xml";
    }
    #endregion

    #region GetCurrentDirectory Method
    public string GetCurrentDirectory()
    {
      string file;

      file = AppDomain.CurrentDomain.BaseDirectory;
      if (file.IndexOf(@"\bin") > 0) {
        file = file.Substring(0, file.LastIndexOf(@"\bin"));
      }

      return file;
    }
    #endregion
  }
}
