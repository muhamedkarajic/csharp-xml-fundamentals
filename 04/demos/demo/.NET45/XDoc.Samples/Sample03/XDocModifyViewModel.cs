using System.Xml.Linq;
using System.Xml.XPath;

namespace XDoc.Samples.Sample03
{
  public class XDocModifyViewModel : CommonBase
  {
    #region BuildEmptyXMLDocument Method
    public void BuildEmptyXMLDocument()
    {
      XDocument doc =
        new XDocument(
          new XDeclaration("1.0", "utf-8", "yes"),
          new XComment("Customer Information"),
          new XElement("Customers"));

      ResultText = doc.ToString();
    }
    #endregion

    #region BuildXmlDocument Method
    public void BuildXmlDocument()
    {
      XDocument doc =
        new XDocument(
          new XDeclaration("1.0", "utf-8", "yes"),
          new XComment("Customer Information"),
          new XElement("Customers",
            new XElement("Customer",
            new XElement("CustomerID", "1"),
            new XElement("FirstName", "Bruce"),
            new XElement("LastName", "Jones"),
            new XElement("CompanyName", "Beach Computer Services")
            )
          )
        );

      ResultText = doc.ToString();
    }
    #endregion
    
    #region CreateXmlString Method
    public string CreateXmlString()
    {
      return @"<Customers>
                <Customer>
                  <CustomerID>1</CustomerID>
                  <Title>Mr.</Title>
                  <FirstName>Orlando</FirstName>
                  <MiddleName>N.</MiddleName>
                  <LastName>Gee</LastName>
                  <CompanyName>A Bike Store</CompanyName>
                  <SalesPerson>adventure-works\pamela0</SalesPerson>
                  <EmailAddress>orlando0@adventure-works.com</EmailAddress>
                  <Phone>245-555-0173</Phone>
                </Customer>
                <Customer>
                  <CustomerID>2</CustomerID>
                  <Title>Mr.</Title>
                  <FirstName>Keith</FirstName>
                  <MiddleName>asdf</MiddleName>
                  <LastName>Harris</LastName>
                  <CompanyName>Progressive Sports</CompanyName>
                  <SalesPerson>adventure-works\david8</SalesPerson>
                  <EmailAddress>keith0@adventure-works.com</EmailAddress>
                  <Phone>170-555-0127</Phone>
                </Customer>
            </Customers>";
    }
    #endregion

    #region LoadString Method
    public void LoadString()
    {
      string xml = CreateXmlString();

      // Create XML Document
      XDocument doc = XDocument.Parse(xml);

      ResultText = doc.ToString();
    }
    #endregion

    #region Add Method
    public void Add()
    {
      string xml = CreateXmlString();

      // Create XML Document
      XDocument doc = XDocument.Parse(xml);

      // Create a new XElement object to add
      XElement customer =
          new XElement("Customer",
            new XElement("CustomerID", "1001"),
            new XElement("Title", "Mr."),
            new XElement("FirstName", "Bruce"),
            new XElement("MiddleName", ""),
            new XElement("LastName", "Jones"),
            new XElement("CompanyName", "Beach Computer Consulting"),
            new XElement("SalesPerson", @"netinc\pshaffer"),
            new XElement("Email", "pshaffer@netinc.com"),
            new XElement("Phone", "714-999-9999")
          );

      // Add the new XElement object to the root
      doc.Root.Add(customer);

      ResultText = doc.ToString();
    }
    #endregion

    #region Update Method
    public void Update()
    {
      string xml = CreateXmlString();

      // Create XML Document
      XDocument doc = XDocument.Parse(xml);

      // Select element to edit
      XElement customer = doc.XPathSelectElement("/Customers/Customer[CustomerID='2']"); ;

      // Modify some of the node values
      customer.Element("FirstName").Value = "John";
      customer.Element("LastName").Value = "Kuhn";

      ResultText = customer.ToString();
    }
    #endregion

    #region Delete Method
    public void Delete()
    {
      string xml = CreateXmlString();

      // Create XML Document
      XDocument doc = XDocument.Parse(xml);

      // Find a specific customer
      XElement customer = doc.XPathSelectElement("/Customers/Customer[CustomerID='2']");

      if (customer != null) {
        customer.Remove();
      }

      ResultText = doc.ToString();
    }
    #endregion
  }
}
