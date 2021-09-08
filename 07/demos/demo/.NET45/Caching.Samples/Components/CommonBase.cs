using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Caching.Samples
{
  /// <summary>
  /// This class implements the INotifyPropertyChanged Event Procedure
  /// </summary>
  public class CommonBase : INotifyPropertyChanged
  {
    #region Constructor
    public CommonBase()
    {
      // Create Xml File Name
      CreateXmlFileName();
    }
    #endregion

    #region Properties
    private string _ResultText;
    private string _XMLFileName;
    private string _LastErrorMessage;

    [XmlIgnore]
    public string ResultText
    {
      get { return _ResultText; }
      set {
        _ResultText = value;
        RaisePropertyChanged("ResultText");
      }
    }

    [XmlIgnore]
    public string XmlFileName
    {
      get { return _XMLFileName; }
      set {
        _XMLFileName = value;
        RaisePropertyChanged("XMLFileName");
      }
    }

    [XmlIgnore]
    public string LastErrorMessage
    {
      get { return _LastErrorMessage; }
      set {
        _LastErrorMessage = value;
        RaisePropertyChanged("LastErrorMessage");
      }
    }
    #endregion

    #region CreateXmlFileName Method
    public void CreateXmlFileName()
    {
      CreateXmlFileName("Cached.xml");
    }

    public void CreateXmlFileName(string fileName)
    {
      XmlFileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" + AppDomain.CurrentDomain.FriendlyName + @"\" + fileName;
    }
    #endregion

    #region ReadXmlFile Method
    public string ReadXmlFile()
    {
      string ret = string.Empty;

      LastErrorMessage = string.Empty;
      try {
        if (!string.IsNullOrEmpty(XmlFileName)) {
          if (File.Exists(XmlFileName)) {
            ret = File.ReadAllText(XmlFileName, Encoding.Unicode);
          }
          else {
            LastErrorMessage = "File: '" + XmlFileName + "' does not exist.";
          }
        }
      }
      catch (Exception ex) {
        LastErrorMessage = ex.ToString();
      }

      return ret;
    }
    #endregion

    #region WriteXmlFile Method
    public void WriteXmlFile(string xml)
    {
      LastErrorMessage = string.Empty;
      try {
        // Does directory exist?
        if (!Directory.Exists(Path.GetDirectoryName(XmlFileName))) {
          Directory.CreateDirectory(Path.GetDirectoryName(XmlFileName));
        }
        // Delete old file
        if (File.Exists(XmlFileName)) {
          File.Delete(XmlFileName);
        }

        // Write XML to local file
        File.AppendAllText(XmlFileName, xml, Encoding.Unicode);
      }
      catch (Exception ex) {
        LastErrorMessage = ex.ToString();
      }
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
