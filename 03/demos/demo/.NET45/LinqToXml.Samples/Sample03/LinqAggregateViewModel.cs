using System.Linq;
using System.Xml.Linq;

namespace LinqToXml.Samples.Sample03
{
  public class LinqAggregateViewModel : CommonBase
  {
    #region Count Method
    public void Count()
    {
      XElement doc =
            XElement.Load(AppSettings.Instance.SalesOrderDetailsFile);

      int value = doc.Elements("OrderDetail").Count();

      ResultText = value.ToString();
    }
    #endregion

    #region Sum Method
    public void Sum()
    {
      XElement doc = XElement.Load(AppSettings.Instance.SalesOrderDetailsFile);

      decimal value =
        (from order in doc.Elements("OrderDetail")
         select order.Element("LineTotal").GetAs<decimal>()).Sum();

      ResultText = value.ToString("c");
    }
    #endregion

    #region Minimum Method   
    public void Minimum()
    {
      XElement doc = XElement.Load(AppSettings.Instance.SalesOrderDetailsFile);

      decimal value =
        (from order in doc.Elements("OrderDetail")
         select order.Element("LineTotal").GetAs<decimal>()).Min();

      ResultText = value.ToString("c");
    }
    #endregion

    #region Maximum Method
    public void Maximum()
    {
      XElement doc = XElement.Load(AppSettings.Instance.SalesOrderDetailsFile);

      decimal value =
        (from order in doc.Elements("OrderDetail")
         select order.Element("LineTotal").GetAs<decimal>()).Max();

      ResultText = value.ToString("c");
    }
    #endregion

    #region Average Method
    public void Average()
    {
      XElement doc = XElement.Load(AppSettings.Instance.SalesOrderDetailsFile);

      decimal value =
        (from order in doc.Elements("OrderDetail")
         select order.Element("LineTotal").GetAs<decimal>()).Average();

      ResultText = value.ToString("c");
    }
    #endregion
  }
}
