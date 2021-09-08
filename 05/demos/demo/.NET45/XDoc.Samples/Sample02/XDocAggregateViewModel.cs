using System;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XDoc.Samples.Sample02
{
  public class XDocAggregateViewModel : CommonBase
  {
    #region Count Method
    public void Count()
    {
      XElement doc =
            XElement.Load(AppSettings.Instance.SalesOrderDetailsFile);
      XPathNavigator nav = doc.CreateNavigator();

      double value = (double)nav.Evaluate("count(//OrderDetail)");

      ResultText = value.ToString();
    }
    #endregion




    #region Sum Method
    public void Sum()
    {
      XElement doc =
            XElement.Load(AppSettings.Instance.SalesOrderDetailsFile);
      XPathNavigator nav = doc.CreateNavigator();

      double value = (double)nav.Evaluate("sum(//OrderDetail/LineTotal)");

      ResultText = value.ToString("c");
    }
    #endregion



    #region Average Method
    public void Average()
    {
      string query = string.Empty;
      XElement doc =
            XElement.Load(AppSettings.Instance.SalesOrderDetailsFile);
      XPathNavigator nav = doc.CreateNavigator();

      query = "  sum(//OrderDetail/LineTotal)";
      query += " div ";
      query += " count(//OrderDetail)";

      double value = (double)nav.Evaluate(query);

      ResultText = value.ToString("c");
    }
    #endregion


    #region Minimum Method   
    public void Minimum()
    {
      string query = string.Empty;
      XElement doc = XElement.Load(AppSettings.Instance.SalesOrderDetailsFile);

      query = "//OrderDetail/LineTotal[";
      query += "     not(. >=../preceding-sibling::OrderDetail/LineTotal)";
      query += " and not(. >=../following-sibling::OrderDetail/LineTotal)]";

      XElement minValue = doc.XPathSelectElement(query);

      if (minValue != null) {
        ResultText = Convert.ToDouble(minValue.Value).ToString("c");
      }
    }
    #endregion

    #region Maximum Method
    public void Maximum()
    {
      string query = string.Empty;
      XElement doc = XElement.Load(AppSettings.Instance.SalesOrderDetailsFile);

      query = "//OrderDetail/LineTotal[";
      query += "     not(. <=../preceding-sibling::OrderDetail/LineTotal)";
      query += " and not(. <=../following-sibling::OrderDetail/LineTotal)]";
      XElement maxValue = doc.XPathSelectElement(query);

      if (maxValue != null) {
        ResultText = Convert.ToDouble(maxValue.Value).ToString("c");
      }
    }
    #endregion
  }
}
