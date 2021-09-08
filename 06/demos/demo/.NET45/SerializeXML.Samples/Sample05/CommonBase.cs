using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace SerializeXML.Samples.Sample05
{
  /// <summary>
  /// This class implements the INotifyPropertyChanged Event Procedure
  /// </summary>
  [DataContract()]
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
    public void ReadXmlFile()
    {
      ResultText = string.Empty;

      if (!string.IsNullOrEmpty(XmlFileName)) {
        if (File.Exists(XmlFileName)) {
          ResultText = File.ReadAllText(XmlFileName, Encoding.Unicode);
        }
        else {
          ResultText = "File: '" + XmlFileName + "' does not exist.";
        }
      }
    }
    #endregion

    #region WriteXmlFile Method
    public void WriteXmlFile(string xml)
    {
      // Does directory exist?
      if (!Directory.Exists(Path.GetDirectoryName(XmlFileName))) {
        Directory.CreateDirectory(Path.GetDirectoryName(XmlFileName));
      }
      // Delete old file
      if (File.Exists(XmlFileName)) {
        File.Delete(XmlFileName);
      }

      File.AppendAllText(XmlFileName, xml, Encoding.Unicode);
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
