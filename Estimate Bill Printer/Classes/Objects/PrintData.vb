Public Class PrintData
    ReadOnly Property HasGSTIN As Boolean
        Get
            Return Sender.GSTIN.Trim <> ""
        End Get
    End Property
    ReadOnly Property Fees As Integer
        Get
            Try
                Dim amt As Integer = 0
                For Each i As Service In Services
                    amt += i.Fees
                Next
                Return amt
            Catch ex As Exception
                Return 0
            End Try
        End Get
    End Property

    Property ID As String
    Property Sender As Sender
    Property SerialNumber As String = ""
    Property EstimateDate As Date
    Property Receiver As Receiver
    Property Services As New List(Of Service)

    Sub New(ByVal ID As String, ByVal Sender As Sender, ByVal SerialNumber As String, ByVal EstimateDate As Date, ByVal Receiver As Receiver, ByVal Services As List(Of Service))
        Me.ID = ID
        Me.Sender = Sender
        Me.SerialNumber = SerialNumber
        Me.EstimateDate = EstimateDate
        Me.Receiver = Receiver
        Me.Services = Services
    End Sub
End Class
