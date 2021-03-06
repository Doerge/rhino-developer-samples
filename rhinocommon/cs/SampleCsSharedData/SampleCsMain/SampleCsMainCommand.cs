using Rhino;
using Rhino.Commands;
using Rhino.Input;
using Rhino.Input.Custom;
using SampleCsCommon;

namespace SampleCsMain
{
  [System.Runtime.InteropServices.Guid("10541129-e175-4152-9204-4edf724fa942")]
  public class SampleCsMainCommand : Command
  {
    /// <summary>
    /// Public constructor.
    /// </summary>
    public SampleCsMainCommand()
    {
    }

    /// <summary>
    /// Returns the English command name.
    /// </summary>
    public override string EnglishName
    {
      get { return "SampleCsMain"; }
    }

    /// <summary>
    /// Called by Rhino when the user wants to run the command.
    /// </summary>
    protected override Result RunCommand(RhinoDoc doc, RunMode mode)
    {
      GetOption go = new GetOption();
      go.SetCommandPrompt("Select command option");
      int add_index = go.AddOption("Add");
      int delete_index = go.AddOption("Delete");
      int list_index = go.AddOption("List");

      go.Get();
      if (go.CommandResult() !=Result.Success)
        return go.CommandResult();

      CommandLineOption option = go.Option();
      if (null == option)
        return Result.Failure;

      int index = option.Index;
      if (index == add_index)
      {
        string str = string.Empty;
        Result rc = RhinoGet.GetString("String to add", false, ref str);
        if (rc == Result.Success)
          SampleCsStringTableHelpers.Add(str);
      }
      else if (index == delete_index)
      {
        string str = string.Empty;
        Result rc = RhinoGet.GetString("String to delete", false, ref str);
        if (rc == Result.Success)
          SampleCsStringTableHelpers.Remove(str);
      }
      else if (index == list_index)
      {
        int count = SampleCsStringTableHelpers.Count();
        if (0 == count)
          RhinoApp.WriteLine("0 string items to list.");
        else
        {
          for (int i = 0; i < count; i++)
            RhinoApp.WriteLine(SampleCsStringTableHelpers.GetAt(i));
        }
      }

      return Result.Success;
    }
  }
}
