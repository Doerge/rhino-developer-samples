Imports Rhino.Input

Partial Class Examples
  Public Shared Function TransformBrep(doc As Rhino.RhinoDoc) As Rhino.Commands.Result
    Dim rhobj As Rhino.DocObjects.ObjRef = Nothing
    Dim rc = RhinoGet.GetOneObject("Select brep", True, Rhino.DocObjects.ObjectType.Brep, rhobj)
    If rc <> Rhino.Commands.Result.Success Then
      Return rc
    End If

    ' Simple translation transformation
    Dim xform = Rhino.Geometry.Transform.Translation(18, -18, 25)
    doc.Objects.Transform(rhobj, xform, True)
    doc.Views.Redraw()
    Return Rhino.Commands.Result.Success
  End Function
End Class
