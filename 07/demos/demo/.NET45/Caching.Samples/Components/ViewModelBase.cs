using System;
using System.IO;
using System.Xml.Linq;

namespace Caching.Samples
{
  public abstract class ViewModelBase : CommonBase
  {
    #region Properties
    private bool _IsFromLocal;
    private DateTime _LocalMaxDate;
    private DateTime _ServerMaxDate;
    private int _LocalTotalRows;
    private int _ServerTotalRows;

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
    public virtual void GetData(string elemName, string parentNodeName)
    {
      ResultText = string.Empty;

      // Get local XML file info
      GetLocalInfo(elemName, parentNodeName);
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
    public virtual void GetLocalInfo(string elemName, string parentNodeName)
    {
      XElement xelem;

      LocalMaxDate = DateTime.MinValue;
      LocalTotalRows = -1;

      if (File.Exists(XmlFileName)) {
        try {
          xelem = XElement.Parse(File.ReadAllText(XmlFileName));
          // Get largest ModifiedDate in local XML file
          LocalMaxDate = xelem.GetMaxValue<DateTime>(elemName, parentNodeName);
          // Get total rows in local XML file
          LocalTotalRows = xelem.GetCount(parentNodeName);

          ResultText += "Local Max Date: " + LocalMaxDate.ToString() + Environment.NewLine;
          ResultText += "Local Total Rows: " + LocalTotalRows.ToString() + Environment.NewLine;
        }
        catch (Exception ex) {
          ResultText = ex.ToString();
        }
      }
    }
    #endregion

    #region Abstract GetFromServer Method
    public abstract void GetFromServer();
    #endregion

    #region Abstract GetServerInfo Method
    public abstract void GetServerInfo();
    #endregion

    #region Abstract StoreToLocalFile Method
    public abstract void StoreToLocalFile();
    #endregion

    #region Abstract GetFromXmlFile Method
    public abstract void GetFromXmlFile();   
    #endregion
  }
}
