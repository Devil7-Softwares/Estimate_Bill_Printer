Public Class PrintData
    Property Sender As Sender
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
    Property SerialNumber As String = ""
    Property EstimateDate As Date
    Property Receiver As Receiver
    Property Services As New List(Of Service)
End Class
