using System.Reflection;
using System.Runtime.InteropServices;
using Rhino.PlugIns;

// Plug-in Description Attributes - all of these are optional.
// These will show in Rhino's option dialog, in the tab Plug-ins.
[assembly: PlugInDescription(DescriptionType.Address, "3670 Woodland Park Avenue North\r\nSeattle, WA 98103")]
[assembly: PlugInDescription(DescriptionType.Country, "United States")]
[assembly: PlugInDescription(DescriptionType.Email, "devsupport@mcneel.com")]
[assembly: PlugInDescription(DescriptionType.Phone, "206-545-6877")]
[assembly: PlugInDescription(DescriptionType.Fax, "206-545-7321")]
[assembly: PlugInDescription(DescriptionType.Organization, "Robert McNeel & Associates")]
[assembly: PlugInDescription(DescriptionType.UpdateUrl, "https://github.com/mcneel/rhino-developer-samples")]
[assembly: PlugInDescription(DescriptionType.WebSite, "http://www.rhino3d.com/")]
[assembly: PlugInDescription(DescriptionType.Icon, "SampleCsDockBar.Resources.SampleCsDockBar-utility.ico")]

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("SampleCsDockBar")] // Plug-In title is extracted from this
[assembly: AssemblyDescription("RhinoCommon Sample - SampleCsDockBar")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Robert McNeel & Associates")]
[assembly: AssemblyProduct("SampleCsDockBar")]
[assembly: AssemblyCopyright("Copyright © 2017, Robert McNeel & Associates")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("9c84103d-7c1b-4685-8763-129503fee6b6")] // This will also be the Guid of the Rhino plug-in

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]

[assembly: AssemblyVersion("6.0.0.0")]
[assembly: AssemblyFileVersion("6.0.0.0")]

// Make compatible with Rhino Installer Engine
[assembly: AssemblyInformationalVersion("2")]
