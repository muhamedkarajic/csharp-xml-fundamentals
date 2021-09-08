using System.Xml.Linq;

namespace LinqToXml.Samples.Sample01
{
  public class LinqLoadViewModel : CommonBase
  { 
    #region LoadUsingXDocument Method
    public void LoadUsingXDocument()
    {
      XDocument doc = 
            XDocument.Load(AppSettings.Instance.CustomersFile);

      ResultText = doc.FirstNode.ToString();
    }
    #endregion

    #region LoadUsingXElement Method
    public void LoadUsingXElement()
    {
      XElement doc = 
            XElement.Load(AppSettings.Instance.CustomersFile);
    
      ResultText = doc.FirstNode.ToString();
    }
    #endregion
  }
}
