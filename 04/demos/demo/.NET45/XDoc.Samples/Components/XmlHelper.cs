using System;
using System.Linq;
using System.Xml.Linq;

namespace XDoc.Samples
{
  public static class XmlHelper
  {
    #region GetAs Methods
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

    public static T GetAs<T>(this XAttribute attr, T defaultValue = default(T))
    {
      T ret = defaultValue;

      if (attr != null && !string.IsNullOrEmpty(attr.Value)) {
        // Cast to Return Data Type 
        // NOTE: ChangeType can not cast to a Nullable type
        ret = (T)Convert.ChangeType(attr.Value, typeof(T));
      }

      return ret;
    }
    #endregion

    #region NextId
    public static int NextId(this XElement elem, string attrName, string parentNodeName)
    {
      // Get The last id
      var MaxID = (from node in elem.Elements(parentNodeName)
                   select node.Attribute(attrName).GetAs<int>()).Max();

      return MaxID + 1;
    }
    #endregion

    #region Count Method
    public static int Count(this XElement elem, string parentNodeName)
    {
      // Get The last Date Updated
      int count = (from node in elem.Elements(parentNodeName)
                   select node).Count();

      return count;
    }
    #endregion
  }
}
