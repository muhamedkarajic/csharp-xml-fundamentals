using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Caching.Samples
{
  public static class XmlSerializerHelper
  {
    #region Serialize Method
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
    #endregion

    #region Deserialize Method
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
    #endregion

    #region GetAs Method
    public static T GetAs<T>(this XElement elem, T defaultValue = default(T))
    {
      T ret = defaultValue;

      if (elem != null && !string.IsNullOrEmpty(elem.Value)) {
        // Cast to Return Data Type
        // NOTE: ChangeType can not cast to a Nullable type
        ret = (T)Convert.ChangeType(elem.Value, typeof(T));
      }

      return ret;
    }
    #endregion

    #region GetMaxValue Method
    public static T GetMaxValue<T>(this XElement elem, string elemName, string parentNodeName)
    {
      // Get the largest node value
      T maxValue =
        (from node in elem.Elements(parentNodeName)
         select node.Element(elemName).GetAs<T>(default(T))).Max();

      return maxValue;
    }
    #endregion

    #region GetCount Method
    public static int GetCount(this XElement elem, string parentNodeName)
    {
      // Get total rows in XML file
      int count = (from node in elem.Elements(parentNodeName)
                   select node).Count();

      return count;
    }
    #endregion
  }
}