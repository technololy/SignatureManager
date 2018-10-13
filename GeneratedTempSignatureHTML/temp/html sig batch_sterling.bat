
    
mkdir "%APPDATA%\Microsoft\Signatures"

	echo y| copy "sterlinglogo3.png" "%APPDATA%\Microsoft\Signatures"

echo y| copy "sterling_sig.htm" "%APPDATA%\Microsoft\Signatures"

If exist "%APPDATA%\Microsoft\Signatures\sterling_sig.htm" 
del "%APPDATA%\Microsoft\Signatures\sterling_sig.htm"

echo y| copy "sterling_sig.htm" "%APPDATA%\Microsoft\Signatures"
