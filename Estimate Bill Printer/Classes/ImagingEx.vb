Imports System.IO
Imports System.Text
Imports System.Collections
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Module ImagingEx
    Public Heading As New StringType With {.Font = New Font("Cambria", 15, FontStyle.Bold), .StringFromat = New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}}
    Public Bold As New StringType With {.Font = New Font("Calibri", 12, FontStyle.Bold), .StringFromat = New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}}
    Public Body As New StringType With {.Font = New Font("Calibri", 12), .StringFromat = New StringFormat}

    Public Function SetOpacity(ByVal image As Image, ByVal opacity As Decimal) As Image
        Dim colorMatrix = New ColorMatrix()
        colorMatrix.Matrix33 = opacity
        Dim imageAttributes = New ImageAttributes()
        imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.[Default], ColorAdjustType.Bitmap)
        Dim output = New Bitmap(image.Width, image.Height)
        Using gfx = Graphics.FromImage(output)
            gfx.SmoothingMode = SmoothingMode.AntiAlias
            gfx.DrawImage(image, New Rectangle(0, 0, image.Width, image.Height), 0, 0, image.Width, image.Height, _
             GraphicsUnit.Pixel, imageAttributes)
        End Using
        Return output
    End Function
    Sub PrintWatermark(ByVal g As Graphics, ByVal Angle As Integer, ByVal Text As String, ByVal Font As Font, ByVal Color As Color, ByVal Transparency As Integer, ByVal Location As Point)
        g.TranslateTransform(Location.X, Location.Y)
        g.RotateTransform(Angle)
        g.DrawString(Text, Font, _
                     New SolidBrush(Color.FromArgb(Transparency, Color)), 0, 0)
    End Sub
    Function MeasureString(ByVal g As Graphics, ByVal Font As Font) As Size
        Return g.MeasureString("TEST", Font).ToSize
    End Function
End Module
Public Class StringType
    Property Font As Font
    Property StringFromat As StringFormat
End Class
