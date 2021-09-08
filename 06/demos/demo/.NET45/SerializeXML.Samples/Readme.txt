Sample 01
-------------------------
Simplest sample of serialization

Sample 02
-------------------------
Using Attributes to control serialization

Sample 03
-------------------------
Nested objects
Using the [XmlArray] attribute

Sample 04
-------------------------
Serialization sample using extension methods

Sample 05
-------------------------
Using the DataContractSerializer

Sample 06
-------------------------
Using the BinaryFormatter
Must mark Customer and CommonBase classes as Serializable
  Not as flexible
  Can't implement INotifyPropertyChanged
Will store and restore private variables


XmlSerializer
https://docs.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlserializer?view=netframework-4.7.2

BinaryFormatter
https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.formatters.binary.binaryformatter?view=netframework-4.7.2

DataContractSerialize
https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.datacontractserializer?view=netframework-4.7.2


The Serialize method converts the public fields and read/write properties of an object into XML. 
It does not convert methods, indexers, private fields, or read-only properties. 
To serialize all an object's fields and properties, both public and private, use the BinaryFormatter.
