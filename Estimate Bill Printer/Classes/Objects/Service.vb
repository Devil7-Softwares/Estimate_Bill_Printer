Public Class Service
    Sub New(ByVal ID As Integer, ByVal ServiceName As String, ByVal Fees As String)
        Me.ID = ID
        Me.ServiceName = ServiceName
        Me.Fees = Fees
    End Sub
    Property ID As Integer
    Property ServiceName As String
    Property Fees As String
End Class