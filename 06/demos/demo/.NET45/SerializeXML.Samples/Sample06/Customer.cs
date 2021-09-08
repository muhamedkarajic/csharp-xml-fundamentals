using System;

namespace SerializeXML.Samples.Sample06
{
  [Serializable]
  public class Customer
  {
    private string APrivateValue = "A Private Variable";

    public void ChangePrivateString(string value)
    {
      APrivateValue = value;
    }
    public string GetPrivateValue()
    {
      return APrivateValue;
    }

    public string ResultText { get; set; }
    public string XMLFileName { get; set; }
    public int CustomerID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CompanyName { get; set; }
  }
}
