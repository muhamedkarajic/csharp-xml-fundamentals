using System.Xml.Serialization;

namespace SerializeXML.Samples.Sample02
{
  [XmlRoot("CustomerClass", Namespace = "http://www.netinc.com")]
  public class Customer : CommonBase
  {
    private int _CustomerID;
    private string _FirstName;
    private string _LastName;
    private string _CompanyName;

    [XmlAttribute("CustId")]
    public int CustomerID
    {
      get { return _CustomerID; }
      set {
        _CustomerID = value;
        RaisePropertyChanged("CustomerID");
      }
    }

    [XmlElement("FName")]
    public string FirstName
    {
      get { return _FirstName; }
      set {
        _FirstName = value;
        RaisePropertyChanged("FirstName");
      }
    }

    public string LastName
    {
      get { return _LastName; }
      set {
        _LastName = value;
        RaisePropertyChanged("LastName");
      }
    }

    public string CompanyName
    {
      get { return _CompanyName; }
      set {
        _CompanyName = value;
        RaisePropertyChanged("CompanyName");
      }
    }
  }
}
