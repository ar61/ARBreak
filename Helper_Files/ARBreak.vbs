Dim objFSO, objShell
Set objFSO = CreateObject("Scripting.FileSystemObject")
Set objShell = CreateObject("WScript.Shell")
Const minsToSecs = 60
Const writeFileIntervalSecs = 60

Sub WriteToFile(num)
	Dim objFile
	Set objFile = objFSO.CreateTextFile("ARBreak_.txt", True)
	mins = CInt (num/60 )
	objFile.Write mins & " minutes left" & vbCrlf
	objFile.Close
End Sub

Sub BreakLoop(breakInterval)
	timeLeftSecs = breakInterval
	prevTimeLeftSecs = breakInterval
	WriteToFile(timeLeftSecs)
	Do
		timeLeftSecs = timeLeftSecs - 1
		WScript.Sleep (1000)
		
		diffSecs = prevTimeLeftSecs - timeLeftSecs
		If diffSecs >= writeFileIntervalSecs Then
			prevTimeLeftSecs = timeLeftSecs
			WriteToFile(timeLeftSecs)
		End If
	Loop Until timeLeftSecs <= 0
	retVal = objShell.Popup ("Its time for a Break! Ready to get back to Work?",300,"Break!",vbQuestion+vbYesNo)
	If retVal = 6 Then
		BreakLoop(breakInterval*minsToSecs)
	Else
		WScript.Quit (-2)
	End If
End Sub

Sub Main()
	breakInterval = InputBox ("Input a Break time Interval(in minutes):","ARBreak")
	If breakInterval = "" Then
		WScript.Quit (-3)
	End If
	res = CInt( breakInterval )
	If res <= 0 Then
		WScript.Quit (-1)
	End If
	
	BreakLoop(breakInterval*minsToSecs)
End Sub

Main()