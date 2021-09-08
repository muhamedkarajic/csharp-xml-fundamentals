using System;

namespace SerializeXML.Samples.Sample03
{
  public class SalesHeader : CommonBase
  {
    private int _SalesOrderID;
    private DateTime _OrderDate;
    private string _SalesOrderNumber;
    private double _TotalDue;

    public int SalesOrderID
    {
      get { return _SalesOrderID; }
      set {
        _SalesOrderID = value;
        RaisePropertyChanged("SalesOrderID");
      }
    }
    
    public DateTime OrderDate
    {
      get { return _OrderDate; }
      set {
        _OrderDate = value;
        RaisePropertyChanged("OrderDate");
      }
    }

    public string SalesOrderNumber
    {
      get { return _SalesOrderNumber; }
      set {
        _SalesOrderNumber = value;
        RaisePropertyChanged("SalesOrderNumber");
      }
    }

    public double TotalDue
    {
      get { return _TotalDue; }
      set {
        _TotalDue = value;
        RaisePropertyChanged("TotalDue");
      }
    }
  }
}
