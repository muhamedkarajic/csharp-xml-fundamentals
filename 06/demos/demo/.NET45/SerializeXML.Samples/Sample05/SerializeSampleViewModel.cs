using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace SerializeXML.Samples.Sample05
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
      // Clear properties
      ResultText = string.Empty;

      // Create Memory Stream and Serializer
      using (MemoryStream ms = new MemoryStream()) {
        // NOTE: Add System.Runtime.Serialization.dll to your project
        DataContractSerializer serializer = new DataContractSerializer(typeof(Customer));
        // Serialize CustomerList class into Memory Stream
        serializer.WriteObject(ms, Entity);

        // Does directory exist?
        if (!Directory.Exists(Path.GetDirectoryName(XmlFileName))) {
          Directory.CreateDirectory(Path.GetDirectoryName(XmlFileName));
        }
        // Delete old file
        if (File.Exists(XmlFileName)) {
          File.Delete(XmlFileName);
        }

        // Reset memory stream to beginning before writing
        ms.Seek(0, SeekOrigin.Begin);
        // Write memory stream
        using (FileStream fs = new FileStream(XmlFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite)) {
          ms.CopyTo(fs);
        }
      }

      ResultText = "Stored Customer in File: '" + XmlFileName + "'";
    }
    #endregion

    #region Deserialize Method
    public void Deserialize()
    {      
      // Clear properties
      ResultText = string.Empty;
      Entity = new Customer();

      if (File.Exists(XmlFileName)) {
        // NOTE: Add System.Runtime.Serialization.dll to your project
        DataContractSerializer serializer = new DataContractSerializer(typeof(Customer));
        // Read from memory stream
        using (MemoryStream ms = new MemoryStream()) {
          using (FileStream fs = new FileStream(XmlFileName, FileMode.Open, FileAccess.Read)) {
            fs.CopyTo(ms);
          }
          // Reset memory stream to beginning before reading
          ms.Seek(0, SeekOrigin.Begin);
          // Deserialize to Customer List
          Entity = (Customer)serializer.ReadObject(ms);

          // Display Results
          ResultText = "Read from File: '" + XmlFileName + "' and converted to Customer";
        }
      }
    }
    #endregion
  }
}
