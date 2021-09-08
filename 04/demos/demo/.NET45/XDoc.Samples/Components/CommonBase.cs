using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace XDoc.Samples
{
  /// <summary>
  /// This class implements the INotifyPropertyChanged Event Procedure
  /// </summary>
  public class CommonBase : INotifyPropertyChanged
  {
    #region Constructor
    public CommonBase()
    {
      XmlFileName = Directory.GetCurrentDirectory() + @"\XmlOutput.xml";
      XsdFileName = Directory.GetCurrentDirectory() + @"\XmlOutput.xsd";
    }
    #endregion

    #region Properties
    private string _ResultText;

    [XmlIgnore]
    public string ResultText
    {
      get { return _ResultText; }
      set {
        _ResultText = value;
        RaisePropertyChanged("ResultText");
      }
    }

    private string _XmlFileName;

    [XmlIgnore]
    public string XmlFileName
    {
      get { return _XmlFileName; }
      set {
        _XmlFileName = value;
        RaisePropertyChanged("XmlFileName");
      }
    }
    
    private string _XsdFileName;

    [XmlIgnore]
    public string XsdFileName
    {
      get { return _XsdFileName; }
      set {
        _XsdFileName = value;
        RaisePropertyChanged("XsdFileName");
      }
    }
    #endregion

    #region ReadXmlFile Method
    public void ReadXmlFile()
    {
      ResultText = string.Empty;

      ResultText = ReadFile(XmlFileName);
    }
    #endregion

    #region ReadXsdFile Method
    public void ReadXsdFile()
    {
      ResultText = string.Empty;

      ResultText = ReadFile(XsdFileName);
    }
    #endregion

    #region ReadFile Method
    protected virtual string ReadFile(string fileName)
    {
      string ret = string.Empty;

      if (!string.IsNullOrEmpty(fileName)) {
        if (File.Exists(fileName)) {
          ret = File.ReadAllText(fileName, Encoding.Unicode);
        }
        else {
          ret = "File: '" + fileName + "' does not exist.";
        }
      }

      return ret;
    }
    #endregion

    #region INotifyPropertyChanged
    /// <summary>
    /// The PropertyChanged Event to raise to any UI object
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// The PropertyChanged Event to raise to any UI object
    /// The event is only invoked if data binding is used
    /// </summary>
    /// <param name="propertyName">The property name that is changing</param>
    protected void RaisePropertyChanged(string propertyName)
    {
      // Grab a handler
      PropertyChangedEventHandler handler = this.PropertyChanged;
      // Only raise event if handler is connected
      if (handler != null) {
        PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);

        // Raise the PropertyChanged event.
        handler(this, args);
      }
    }
    #endregion
  }
}
