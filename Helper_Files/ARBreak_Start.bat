C:\WINDOWS\SysWOW64\cscript.exe /nologo "ARBreak.vbs"
echo %errorlevel%

IF %errorlevel%==-3 (
	msg * "You have Quit ARBreak!"
) ELSE (
	IF %errorlevel%==-2 (
		msg * "You have Quit ARBreak!"
	) ELSE (
		IF %errorlevel%==-1 ( 
			msg * "You have Quit ARBreak!"
		)
	)
)