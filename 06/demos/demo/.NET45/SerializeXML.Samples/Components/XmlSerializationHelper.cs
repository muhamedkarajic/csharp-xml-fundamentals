using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace SerializeXML.Samples
{
  public static class XmlSerializerHelper
  {
    public static string Serialize<T>(this T value)
    {
      string ret = string.Empty;

      if (value != null) {
        // Create XML Serializer
        var serializer = new XmlSerializer(typeof(T));
        // Write to string
        using (var sw = new StringWriter()) {
          serializer.Serialize(sw, value);
          ret = sw.ToString();
        }
      }

      return ret;
    }

    public static T Deserialize<T>(this T value, string xml)
    {
      T ret = default(T);

      if (!string.IsNullOrEmpty(xml)) {
        // Create XML Serializer
        var serializer = new XmlSerializer(typeof(T));
        // Convert from string to object
        using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(xml))) {
          ms.Position = 0;
          ret = (T)serializer.Deserialize(ms);         
        }
      }

      return ret;
    }
  }
}