Imports System.Runtime.InteropServices

Module Module1

    <StructLayoutAttribute(LayoutKind.Sequential)> _
    Private Structure SYSTIME

        Public Year As Short

        Public Month As Short

        Public DayOfWeek As Short

        Public Day As Short

        Public Hour As Short

        Public Minutes As Short

        Public Seconds As Short

        Public Milliseconds As Short
    End Structure


    Private Declare Function SetLocalTime Lib "kernel32.dll" (ByRef time As SYSTIME) As Boolean
    Sub Main()
        Dim s = New SYSTIME()
        s.Year = CShort(DateTime.Now.Year)
        s.Month = CShort(DateTime.Now.Month)
        s.DayOfWeek = CShort(DateTime.Now.DayOfWeek)
        s.Day = CShort(DateTime.Now.Day)
        s.Hour = 20
        s.Minutes = 0
        s.Seconds = 0
        s.Milliseconds = 0

        SetLocalTime(s)
    End Sub

End Module
