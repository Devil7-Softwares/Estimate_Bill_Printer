Public Class Receiver
    Sub New(ByVal ID As Integer, ByVal Name As String, ByVal Address As String, ByVal State As String, ByVal StateCode As String, ByVal GSTIN As String)
        Me.ID = ID
        Me.Name = Name
        Me.Address = Address
        Me.GSTIN = GSTIN
        Me.State = State
        Me.StateCode = StateCode
    End Sub
    Property ID As Integer
    Property Name As String = ""
    Property Address As String = ""
    Property State As String = ""
    Property StateCode As String = ""
    Property GSTIN As String = ""
    Public Overrides Function ToString() As String
        Return Me.Name
    End Function
End Class