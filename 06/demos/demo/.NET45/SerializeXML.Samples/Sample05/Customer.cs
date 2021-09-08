using System.Runtime.Serialization;

namespace SerializeXML.Samples.Sample05
{
  [DataContract(Name = "Customer", Namespace = "http://www.netinc.com")]
  public class Customer : CommonBase
  {
    private int _CustomerID;
    private string _FirstName;
    private string _LastName;
    private string _CompanyName;

    [DataMember]
    public int CustomerID
    {
      get { return _CustomerID; }
      set {
        _CustomerID = value;
        RaisePropertyChanged("CustomerID");
      }
    }

    [DataMember]
    public string FirstName
    {
      get { return _FirstName; }
      set {
        _FirstName = value;
        RaisePropertyChanged("FirstName");
      }
    }

    [DataMember]
    public string LastName
    {
      get { return _LastName; }
      set {
        _LastName = value;
        RaisePropertyChanged("LastName");
      }
    }

    [DataMember]
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
