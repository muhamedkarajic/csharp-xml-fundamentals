namespace SerializeXML.Samples.Sample03
{
  public class SerializeSampleViewModel : CommonBase
  {
    #region Constructor
    public SerializeSampleViewModel()
    {
      CreateXmlFileName(CUSTOMER_XML_FILE);
    }
    #endregion

    private const string CUSTOMER_XML_FILE = "Customers.xml";

    #region Properties
    private Customer _Entity;

    public Customer Entity
    {
      get { return _Entity; }
      set {
        _Entity = value;
        RaisePropertyChanged("Entity");
      }
    }
    #endregion

    #region Serialize Method
    public void Serialize()
    {
      ResultText = string.Empty;

      // Serialize to String
      ResultText = Entity.Serialize<Customer>();

      // Write to file
      WriteXmlFile(ResultText);

      // Clear customer fields
      Entity = new Customer();
    }
    #endregion

    #region Deserialize Method
    public void Deserialize()
    {
      Entity = new Customer();

      // Deserialize
      Entity = Entity.Deserialize<Customer>(ResultText);

      // Clear result text
      ResultText = string.Empty;
    }
    #endregion
  }
}
