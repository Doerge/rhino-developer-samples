using System.Collections.Generic;
using Rhino;
using Rhino.UI;

namespace SampleCsEto
{
  public class SampleCsEtoPlugIn : Rhino.PlugIns.PlugIn
  {
	public DisplayConduit displayConduit;
    public SampleCsEtoPlugIn()
    {
      Instance = this;
	    displayConduit = new DisplayConduit() { Enabled = true };
    }

    public static SampleCsEtoPlugIn Instance
    {
      get;
      private set;
    }

    protected override void DocumentPropertiesDialogPages(RhinoDoc doc, List<OptionsDialogPage> pages)
    {
      var page = new Views.SampleCsEtoOptionsPage();
      pages.Add(page);
    }

    protected override void OptionsDialogPages(List<OptionsDialogPage> pages)
    {
      var page = new Views.SampleCsEtoOptionsPage();
      pages.Add(page);
    }

    protected override void ObjectPropertiesPages(ObjectPropertiesPageCollection collection)
    {
      var page = new Views.SampleCsEtoPropertiesPage();
      collection.Add(page);
    }
  }
}