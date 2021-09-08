using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializeXML.Samples.Sample06
{
  public class SerializeSampleViewModel : CommonBase
  {
    #region Constructor
    public SerializeSampleViewModel()
    {
      CreateXmlFileName(CUSTOMER_XML_FILE);
    }
    #endregion

    private const string CUSTOMER_XML_FILE = "Customers.bin";

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
      // Clear properties
      ResultText = string.Empty;
      
      // Does directory exist?
      if (!Directory.Exists(Path.GetDirectoryName(XmlFileName))) {
        Directory.CreateDirectory(Path.GetDirectoryName(XmlFileName));
      }
      // Delete old file
      if (File.Exists(XmlFileName)) {
        File.Delete(XmlFileName);
      }

      using (FileStream stream = new FileStream(XmlFileName, FileMode.Create)) {
        BinaryFormatter formatter = new BinaryFormatter();

        formatter.Serialize(stream, Entity);

        stream.Close();
      }

      ResultText = "Stored Customer in File: '" + XmlFileName + "'";
      RaisePropertyChanged("ResultText");      
    }
    #endregion

    #region Deserialize Method
    public void Deserialize()
    {
      // Clear properties
      ResultText = string.Empty;
      Entity = new Customer();

      if (File.Exists(XmlFileName)) {
        using (FileStream fs = new FileStream(XmlFileName, FileMode.Open)) {
          BinaryFormatter formatter = new BinaryFormatter();

          Entity = (Customer)formatter.Deserialize(fs);
        }

        // Display Results
        ResultText = "The private value is: '" + Entity.GetPrivateValue() + "'.";
        RaisePropertyChanged("ResultText");
        RaisePropertyChanged("Entity");
      }
    }
    #endregion
  }
}
