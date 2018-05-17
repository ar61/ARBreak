'Global Vars
Set ObjFSO = CreateObject("Scripting.FileSystemObject")
Set objShell = WScript.CreateObject( "WScript.Shell" )
Dim popupRet
Dim breakInterval
Const minToSecs = 60
Const popupTimeOutSecs = 0
Dim outFile

Function CurrProcessId
    Dim oShell, sCmd, oWMI, oChldPrcs, oCols, lOut
    lOut = 0
    Set oShell  = CreateObject("WScript.Shell")
    Set oWMI    = GetObject(_
        "winmgmts:{impersonationLevel=impersonate}!\\.\root\cimv2")
    sCmd = "/K " & Left(CreateObject("Scriptlet.TypeLib").Guid, 38)
    oShell.Run "%comspec% " & sCmd, 0
    WScript.Sleep 100 'For healthier skin, get some sleep
    Set oChldPrcs = oWMI.ExecQuery(_
        "Select * From Win32_Process Where CommandLine Like '%" & sCmd & "'",,32)
    For Each oCols In oChldPrcs
        lOut = oCols.ParentProcessId 'get parent
        oCols.Terminate 'process terminated
        Exit For
    Next
    CurrProcessId = lOut
End Function

Sub Write(num)
	Set objFile = objFSO.CreateTextFile(outFile,True)
	' Dont need seconds accuracy, just want to know Minutes left
	val = CInt( num/60 )
	objFile.Write val & vbCrLf
	ObjFile.Close
End Sub

Sub DeleteDataFile()
	If objFSO.FileExists(outFile) Then
		objFSO.DeleteFile outFile
	End If
End Sub

Function BreakLoop(breakInterval)
	timeLeftSecs = breakInterval
	prevTimeLeftSecs = timeLeftSecs
	Write(timeLeftSecs)
	Do
		timeLeftSecs = timeLeftSecs - 1 
		WScript.Sleep(1000)
		' Write to File every minute
		timeDiffSecs = prevTimeLeftSecs - timeLeftSecs
		If timeDiffSecs >= 60 Then
			Write(timeLeftSecs)
			prevTimeLeftSecs = timeLeftSecs
		End If
		If timeLeftSecs = 0 Then			
			Write(timeLeftSecs)
		End If
	Loop While (timeLeftSecs > 0)
	BreakLoop = -1
End Function

Sub Main()
	Set objNet = CreateObject("WScript.Network")
	outFile="C:\Users\" & objNet.UserName & "\AppData\Local\Temp\ARBreak_data_" & CurrProcessId & ".txt"
	Write(0)
	breakInterval = WScript.Arguments(0)
	retVal = BreakLoop(breakInterval*minToSecs)
	DeleteDataFile()
	WScript.Quit(retVal)
End Sub

Main()
