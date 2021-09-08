using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Text;
using System.IO;

namespace XDoc.Samples.Sample04
{
  public class XDocWriteViewModel : CommonBase
  {
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

    #region XDocSave Method
    public void XDocSave()
    {
      string xml = CreateXmlString();

      // Create XML Document
      XDocument doc = XDocument.Parse(xml);

      // Save to disk
      doc.Save(XmlFileName);

      // Disable Formatting
      //doc.Save(XmlFileName, SaveOptions.DisableFormatting);

      ResultText = doc.ToString();
    }
    #endregion

    #region XmlWriterSave Method
    public void XmlWriterSave()
    {
      // Create the XML Writer
      using (XmlWriter writer = XmlWriter.Create(XmlFileName)) {
        // Write a Start Element (Root)
        writer.WriteStartElement("Customers");

        // Write a Start Element (Parent)
        writer.WriteStartElement("Customer");
        // Write an Attribute
        writer.WriteAttributeString("CustomerID", "999");

        // Write a Start Element (Child)
        writer.WriteStartElement("Title");
        // Write the value
        writer.WriteString("Mr.");
        // Write the End Element
        writer.WriteEndElement();

        // Write a Start Element (Child)
        writer.WriteStartElement("FirstName");
        // Write the value
        writer.WriteString("Bruce");
        // Write the End Element
        writer.WriteEndElement();

        // Write a Start Element (Child)
        writer.WriteStartElement("LastName");
        // Write the value
        writer.WriteString("Jones");
        // Write the End Element
        writer.WriteEndElement();

        // Write a Start Element (Child)
        writer.WriteStartElement("CompanyName");
        // Write the value
        writer.WriteString("Beach Computer Consulting");
        // Write the End Element
        writer.WriteEndElement();

        // Write the End Element (Parent)
        writer.WriteEndElement();
        // Write the End Element (Root)
        writer.WriteEndElement();
        // Close the Writer
        writer.Close();
      }

      // Display XML File Contents
      ReadXmlFile();
    }
    #endregion

    #region XmlWriterFormattingSave Method
    public void XmlWriterFormattingSave()
    {
      XmlWriterSettings settings = new XmlWriterSettings {
        // Set the Format Options
        Encoding = Encoding.Unicode,
        Indent = true
      };

      // Create the XML Writer
      using (XmlWriter writer = XmlWriter.Create(XmlFileName, settings)) {
        // Write a Start Element (Root)
        writer.WriteStartElement("Customers");

        // Write a Start Element (Parent)
        writer.WriteStartElement("Customer");
        // Write an Attribute
        writer.WriteAttributeString("CustomerID", "999");
       
        // Write a Start Element (Child)
        writer.WriteStartElement("Title");
        // Write the value
        writer.WriteString("Mr.");
        // Write the End Element
        writer.WriteEndElement();

        // Write a Start Element (Child)
        writer.WriteStartElement("FirstName");
        // Write the value
        writer.WriteString("Bruce");
        // Write the End Element
        writer.WriteEndElement();

        // Write a Start Element (Child)
        writer.WriteStartElement("LastName");
        // Write the value
        writer.WriteString("Jones");
        // Write the End Element
        writer.WriteEndElement();

        // Write a Start Element (Child)
        writer.WriteStartElement("CompanyName");
        // Write the value
        writer.WriteString("Beach Computer Consulting");
        // Write the End Element
        writer.WriteEndElement();

        // Write the End Element (Parent)
        writer.WriteEndElement();
        // Write the End Element (Root)
        writer.WriteEndElement();
        // Close the Writer
        writer.Close();
      }

      // Display XML File Contents
      ReadXmlFile();
    }
    #endregion

    #region DataSetSave Method
    public void DataSetSave()
    {
      string sql = "SELECT TOP 10 CustomerID, Title, FirstName, LastName, CompanyName FROM SalesLT.Customer";
      string cs = "Server=Localhost;Database=AdventureWorksLT;Trusted_Connection=Yes";
      
      using(SqlDataAdapter da = new SqlDataAdapter(sql, cs)) {
        using (DataSet ds = new DataSet("Customers")) {
          da.Fill(ds, "Customer" );
          // Use a StreamWriter to write in Unicode
          using (StreamWriter xmlWriter = new StreamWriter(XmlFileName, false, Encoding.Unicode)) {
            // Write XML File
            ds.WriteXml(xmlWriter);
          }
          
          using (StreamWriter xsdWriter = new StreamWriter(XsdFileName, false, Encoding.Unicode)) {
            // Write XSD File
            ds.WriteXmlSchema(xsdWriter);
          }
        }
      }
      
      // Display XSD File Contents
      ReadXsdFile();
    }
    #endregion
  }
}
