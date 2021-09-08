using System.IO;
using System.Xml.Serialization;

namespace SerializeXML.Samples.Sample01
{
  public class SerializeSampleViewModel : CommonBase
  {
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

      // Create XML Serializer
      var serializer = new XmlSerializer(typeof(Customer));
      // Write to string
      using (var sw = new StringWriter()) {
        serializer.Serialize(sw, Entity);
        ResultText = sw.ToString();
      }

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
      
      // Create XML Serializer
      var serializer = new XmlSerializer(typeof(Customer));
      // Read from File
      using (var tw = new FileStream(XmlFileName, FileMode.Open)) {
        Entity = (Customer)serializer.Deserialize(tw);
        tw.Close();
      }

      // Clear result text
      ResultText = string.Empty;
    }
    #endregion
  }
}
