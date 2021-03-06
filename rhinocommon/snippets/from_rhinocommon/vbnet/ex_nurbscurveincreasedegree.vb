Imports Rhino
Imports Rhino.Commands
Imports Rhino.Input
Imports Rhino.DocObjects

Namespace examples_vb
  Public Class NurbsCurveIncreaseDegreeCommand
    Inherits Command
    Public Overrides ReadOnly Property EnglishName() As String
      Get
        Return "vbNurbsCrvIncreaseDegree"
      End Get
    End Property

    Protected Overrides Function RunCommand(doc As RhinoDoc, mode As RunMode) As Result
      Dim obj_ref As ObjRef
      Dim rc = RhinoGet.GetOneObject("Select curve", False, ObjectType.Curve, obj_ref)
      If rc <> Result.Success Then
        Return rc
      End If
      If obj_ref Is Nothing Then
        Return Result.Failure
      End If
      Dim curve = obj_ref.Curve()
      If curve Is Nothing Then
        Return Result.Failure
      End If
      Dim nurbs_curve = curve.ToNurbsCurve()

      Dim new_degree As Integer = -1
      rc = RhinoGet.GetInteger(String.Format("New degree <{0}...11>", nurbs_curve.Degree), True, new_degree, nurbs_curve.Degree, 11)
      If rc <> Result.Success Then
        Return rc
      End If

      rc = Result.Failure
      If nurbs_curve.IncreaseDegree(new_degree) Then
        If doc.Objects.Replace(obj_ref.ObjectId, nurbs_curve) Then
          rc = Result.Success
        End If
      End If

      RhinoApp.WriteLine("Result: {0}", rc.ToString())
      doc.Views.Redraw()
      Return rc
    End Function
  End Class
End Namespace