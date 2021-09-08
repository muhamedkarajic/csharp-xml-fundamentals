using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XDoc.Samples.Sample01
{
  public class XDocQueryViewModel : CommonBase
  {
    #region XDocGetAll Method
    public void XDocGetAll()
    {
      StringBuilder sb = new StringBuilder(1024);
      XDocument doc = 
            XDocument.Load(AppSettings.Instance.CustomersFile);

      // Get All Customers
      IEnumerable<XElement> customers = 
            doc.XPathSelectElements("/Customers/Customer");

      // Iterate over elements
      foreach (XElement cust in customers) {
        sb.AppendLine(cust.Element("CompanyName").Value);
      }

      ResultText = sb.ToString();
    }
    #endregion

    #region XDocFindByElement Method
    public void XDocFindByElement()
    {
      XDocument doc = 
            XDocument.Load(AppSettings.Instance.CustomersFile);

      // Find by Element
      XElement customer = 
        doc.XPathSelectElement("/Customers/Customer[CustomerID='2']");

      if (customer != null) {
        ResultText = customer.Element("CompanyName").Value;
      }
      else {
        ResultText = "Not Found";
      }
    }
    #endregion

    #region XDocFindByAttribute Method
    public void XDocFindByAttribute()
    {
      XDocument doc = 
            XDocument.Load(AppSettings.Instance.CustomersAttributesFile);

      // Find by Attribute
      XElement customer = 
       doc.XPathSelectElement("/Customers/Customer[@CustomerID='2']");

      if (customer != null) {
        ResultText = customer.Attribute("CompanyName").Value;
      }
      else {
        ResultText = "Not Found";
      }
    }
    #endregion

    #region XElemGetAll Method
    public void XElemGetAll()
    {
      StringBuilder sb = new StringBuilder(1024);
      XElement doc = 
            XElement.Load(AppSettings.Instance.CustomersFile);

      // Get All Customers
      IEnumerable<XElement> customers = 
            doc.XPathSelectElements("/Customer");

      // Iterate over elements
      foreach (XElement cust in customers) {
        sb.AppendLine(cust.Element("CompanyName").Value);
      }

      ResultText = sb.ToString();
    }
    #endregion

    #region XElemFindByElement Method
    public void XElemFindByElement()
    {
      XElement doc = 
            XElement.Load(AppSettings.Instance.CustomersFile);

      // Find by Element
      XElement customer = 
            doc.XPathSelectElement("/Customer[CustomerID='2']");

      if (customer != null) {
        ResultText = customer.Element("CompanyName").Value;
      }
      else {
        ResultText = "Not Found";
      }
    }
    #endregion

    #region XElemFindByAttribute Method
    public void XElemFindByAttribute()
    {
      XElement doc = 
            XElement.Load(AppSettings.Instance.CustomersAttributesFile);

      // Find by Attribute
      XElement customer =
            doc.XPathSelectElement("/Customer[@CustomerID='2']");

      if (customer != null) {
        ResultText = customer.Attribute("CompanyName").Value;
      }
      else {
        ResultText = "Not Found";
      }
    }
    #endregion
    
    #region ReadConfig Method
    public void ReadConfig()
    {
      StringBuilder sb = new StringBuilder(1024);
      XElement doc = 
            XElement.Load(
               AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

      // Find XmlFile element
      IEnumerable<XElement> settings = 
            doc.XPathSelectElements("/appSettings/add");

      if (settings != null) {
        foreach (var setting in settings) {
          sb.Append("key: '");
          sb.Append(setting.Attribute("key").Value);
          sb.Append("' - value: '");
          sb.Append(setting.Attribute("value").Value);
          sb.Append("'" + Environment.NewLine);
        }

        ResultText = sb.ToString();
      }
      else {
        ResultText = "Not Found";
      }
    }
    #endregion
  }
}
