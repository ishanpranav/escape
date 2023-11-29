setlocal enabledelayedexpansion
echo off
if not exist Program_Files\ (
	mkdir Program_Files\
)
set v=v15.1.16.0
if not exist Program_Files\Data (
	(
		echo %v%
		echo /new
		echo USER
		echo 100
		echo 0
		echo 0
		echo 0
		echo 0
		echo 0
	)>Program_Files\Data
)
title Haunted Castle
:/start
color fc
cls
if exist Program_Files\music\music.vbs (
	start Program_Files\music\music.vbs
)
if exist Program_Files\external\theme.cmd (
	call Program_Files\external\theme.cmd
)
echo ^|^|    ^|^|    ^|^|^|^|^|^|^|^|    ^|^|    ^|^|    ^|^|^|   ^|^|    ^|^|^|^|^|^|^|^|    ^|^|^|^|^|^|^|^|    ^|^|^|^|^|^|
echo ^|^|    ^|^|    ^|^|    ^|^|    ^|^|    ^|^|    ^|^|^|^|  ^|^|       ^|^|       ^|^|          ^|^|   ^|^|
echo ^|^|^|^|^|^|^|^|    ^|^|^|^|^|^|^|^|    ^|^|    ^|^|    ^|^| ^|^| ^|^|       ^|^|       ^|^|^|^|^|^|^|^|    ^|^|   ^|^|
echo ^|^|    ^|^|    ^|^|    ^|^|    ^|^|    ^|^|    ^|^|  ^|^|^|^|       ^|^|       ^|^|          ^|^|   ^|^|
echo ^|^|    ^|^|    ^|^|    ^|^|    ^|^|^|^|^|^|^|^|    ^|^|   ^|^|^|       ^|^|       ^|^|^|^|^|^|^|^|    ^|^|^|^|^|^|
echo.
echo.
echo.
echo ^|^|^|^|^|^|^|^|    ^|^|^|^|^|^|^|^|    ^|^|^|^|^|^|^|^|    ^|^|^|^|^|^|^|^|    ^|^|          ^|^|^|^|^|^|^|^|
echo ^|^|          ^|^|    ^|^|    ^|^|             ^|^|       ^|^|          ^|^|
echo ^|^|          ^|^|^|^|^|^|^|^|    ^|^|^|^|^|^|^|^|       ^|^|       ^|^|          ^|^|^|^|^|^|^|^|
echo ^|^|          ^|^|    ^|^|          ^|^|       ^|^|       ^|^|          ^|^|
echo ^|^|^|^|^|^|^|^|    ^|^|    ^|^|    ^|^|^|^|^|^|^|^|       ^|^|       ^|^|^|^|^|^|^|^|    ^|^|^|^|^|^|^|^|
echo.
echo Haunted Castle. %v%
echo Copyright 2014 Ishan Pranav.
echo.
pause>nul
cls
rem echo Loading
rem timeout /t 1 /nobreak>nul
rem cls
rem echo Loading.
rem timeout /t 1 /nobreak>nul
rem cls
rem echo Loading..
rem timeout /t 1 /nobreak>nul
rem cls
rem echo Loading...
rem timeout /t 1 /nobreak>nul
rem cls
rem echo Loading
rem timeout /t 1 /nobreak>nul
rem cls
rem echo Loading.
rem timeout /t 1 /nobreak>nul
rem cls
rem echo Loading..
rem timeout /t 1 /nobreak>nul
rem cls
rem echo Loading...
rem timeout /t 1 /nobreak>nul
color f0
cls
echo You have some options.
echo.
echo PRESS 1^> CONTINUE GAME
echo PRESS 2^> NEW GAME
echo PRESS 3^> MULTIPLAYER CHAT
echo PRESS 4^> VIEW HI-SCORES
(
	set /p version=
	set /p path=
	set /p name=
	set /p gold=
	set /p ghost1=
	set /p ghost2=
	set /p ghost3=
	set /p puzzle1=
	set /p ghost4=
)<Program_Files\Data
if not %version% equ %v% (
	echo PRESS 5^> FINISH UPDATING
	if not exist Program_Files\music (			
		mkdir Program_Files\music\
	)
	echo.>Program_Files\music\temp.vbs
	echo MsgBox "Now that you have updated Haunted Castle, choose option 5 in the start menu to finish updating.", 48, "Finish Updating">>Program_Files\music\temp.vbs
	start Program_Files\music\temp.vbs
)
echo.
set option=1
set /p option=What do you want to do? ^>
echo.
if not defined option (
	echo Make up your mind
	pause>nul
	goto /start
)
if %option% equ 2 (
	goto /new
)
if %option% equ 3 (
	if not exist Program_Files\chat.cmd (
		echo OH DEAR! The chat room has not yet been downloaded.
		pause>nul
		goto /start
	)
	call Program_Files\chat.cmd
	cls
	pause>nul
	goto /start
)
if %option% equ 4 (
	cls
	echo HI-SCORES
	echo.
	if not exist Program_Files\scores (
		echo No HI-SCORES have been recorded so far. :(
		pause>nul
		goto /start
	)
	type Program_Files\scores
	pause>nul
	goto /start
)
if %option% equ 5 (
	set path=/new
	set name=USER
	set gold=100
	set ghost1=0
	set ghost2=0
	set ghost3=0
	set puzzle1=0
	set ghost4=0
	(
		set /p version=
		set /p path=
		set /p name=
		set /p gold=
		set /p ghost1=
		set /p ghost2=
		set /p ghost3=
		set /p puzzle1=
		set /p ghost4=
	)<Program_Files\Data
	if not %version% equ %v% (
		(
			echo %v%
			echo %path%
			echo %name%
			echo %gold%
			echo %ghost1%
			echo %ghost2%
			echo %ghost3%
			echo %puzzle1%
			echo %ghost4%
		)>Program_Files\Data
	)
	(
		date /t
		time /t
		echo UPDATED FROM %version% TO %v%
		echo.
		echo WHAT'S NEW?
		echo.
		echo   - Added Creepy Carl, the 5th ghost.
		echo   - Added External Programs (help.txt for more)
		echo   - Added Music Extentions (help.txt for more)
		echo. 
	)>>Program_Files\update.log
	cls
	echo UPDATE.LOG
	echo.
	type Program_Files\update.log
	pause>nul
)
if not exist Program_Files\Data (
	echo OH DEAR! Your game has been erased.
	pause>nul
	goto /start
)
(
	set /p version=
	set /p path=
	set /p name=
	set /p gold=
	set /p ghost1=
	set /p ghost2=
	set /p ghost3=
	set /p puzzle1=
	set /p ghost4=
)<Program_Files\Data
cls
echo You have some options.
echo.
echo PRESS 1^> PLAY GAME
echo PRESS 2^> VIEW PLAYER STATS
echo PRESS 3^> VISIT SHOP
echo.
set option=
set /p option=What do you want to do? ^>
echo.
if %option% equ 1 (
	color f0
	cls
	date /t>>Program_Files\tries
	goto %path%
)
if %option% equ 2 (
	(
		set /p version=
		set /p path=
		set /p name=
		set /p gold=
		set /p ghost1=
		set /p ghost2=
		set /p ghost3=
		set /p puzzle1=
		set /p ghost4=
	)<Program_Files\Data
	cls
	echo PLAYER STATS
	echo.
	if exist Program_Files\tries (
		echo %name%'s ATTEMPTS
		echo.
		date /t
		type Program_Files\tries
		pause>nul
		echo.
	)
	if %ghost1% equ 1 (
		echo HORRIFYING HENRY
		echo.
		echo TYPE: Scary
		echo ATTACK: Scare ^| Mega-Scare
		echo.
		echo Scary type ghosts live in places where they think they can cause the most
		echo mischeif. They love to do despicable things such as rip up books and
		echo put worms in people's beds.
		echo.
		set option=
		set /p option=Feed? (Y/N) ^>
		if %option% equ Y (
			set gh=h
			goto /feed
		)
		if %option% equ y (
			set gh=h
			goto /feed
		)
		pause>nul
		echo.
	)
	if %ghost2% equ 1 (
		echo FRIGHTENING FERDINAND
		echo.
		echo TYPE: Fighter
		echo ATTACK: Lightning Shield ^| Ghost Punch
		echo.
		echo Fighter type ghosts are extremely hard to catch and escape very easily. They
		echo don't like helping out, but are competitive and will do anything to win a
		echo battle.
		echo.
		set option=
		set /p option=Feed? (Y/N) ^>
		if %option% equ Y (
			set gh=f
			goto /feed
		)
		if %option% equ y (
			set gh=f
			goto /feed
		)
		pause>nul
		echo.
	)
	if %ghost3% equ 1 (
		echo SCARY SARAH
		echo.
		echo TYPE: Scary
		echo ATTACK: Scare ^| Mega Scare
		echo.
		echo Scary type ghosts live in places where they think they can cause the most
		echo mischeif. They love to do despicable things such as rip up books and
		echo put worms in people's beds.
		echo.
		set option=
		set /p option=Feed? (Y/N) ^>
		if %option% equ Y (
			set gh=s
			goto /feed
		)
		if %option% equ y (
			set gh=s
			goto /feed
		)
		pause>nul
		echo.
	)
	if %ghost4% equ 1 (
		echo CREEPY CARL
		echo.
		echo TYPE: Scary
		echo ATTACK: Scare ^| Mega-Scare
		echo.
		echo Scary type ghosts live in places where they think they can cause the most
		echo mischeif. They love to do despicable things such as rip up books and
		echo put worms in people's beds.
		echo.
		set option=
		set /p option=Feed? (Y/N) ^>
		if %option% equ Y (
			set gh=c
			goto /feed
		)
		if %option% equ y (
			set gh=c
			goto /feed
		)
		pause>nul
		echo.
	)
	pause>nul
	goto /start
)
if %option% equ 3 (
	goto /shop
)
:/new
color f0
set ghost1=0
set ghost2=0
set ghost3=0
set puzzle1=0
set ghost4=0
del Program_Files\tries
(
	echo %v%
	echo /new
	echo USER
	echo %gold%
	echo %ghost1%
	echo %ghost2%
	echo %ghost3%
	echo %puzzle1%
	echo %ghost4%
)>Program_Files\Data
cls
echo USER ^| LEVEL 1 ^| $%gold% ^|
echo.
echo Fill out the following fields.
echo.
set /p name=What is your name? ^>
echo.
set option=
set /p option=Log on to a server? (Y/N) ^>
echo.
if %option% equ y (
	goto /logon
)
if %option% equ Y (
	goto /logon
)
if %option% equ n (
	goto /new/noserver
)
if %option% equ N (
	goto /new/noserver
)
if not defined option (
	goto /new/noserver
)
goto /new/noserver
:/logon
set name=USER
set path=/new
if exist Program_Files\Data (
	(
		set /p version=
		set /p path=
		set /p name=
		set /p gold=
		set /p ghost1=
		set /p ghost2=
		set /p ghost3=
		set /p puzzle1=
		set /p ghost4=
	)<Program_Files\Data
)
color f0
cls
echo Fill out the following fields.
echo.
set /p server=Server Name ^>
echo.
if not exist "Program_Files\multiplayer\%server%\chat" (
	echo OH DEAR! The multiplayer server "%server%" does not exist.
	pause>nul
	goto /new/noserver
)
(
	echo %name% SHARED A SAVE FILE AT "\Shared Data\%server%"
	echo.
)>>"Program_Files\multiplayer\%server%\chat"
echo Connecting to server...
pause>nul
if exist Program_Files\Data (
	mkdir "Shared Data\"
	(
		echo %v%
		echo %path%
		echo %name%
		echo %gold%
		echo %ghost1%
		echo %ghost2%
		echo %ghost3%
		echo %puzzle1%
		echo %ghost4%
	)>"Shared Data\%server%"
)
goto /new/noserver
:/new/noserver
cls
echo %name% ^| LEVEL 1 ^| $%gold% ^|
echo.
echo You find yourself in a dark room, with furniture that's covered in cobwebs and
echo dust.
echo.
pause>nul
echo It's too dark to see...
echo.
pause>nul
goto /new/q
:/new/q
(
	echo %v%
	echo /new/q
	echo %name%
	echo %gold%
	echo %ghost1%
	echo %ghost2%
	echo %ghost3%
	echo %puzzle1%
	echo %ghost4%
)>Program_Files\Data
echo You have some options.
echo.
echo PRESS 1^> LIGHT A TORCH
echo PRESS 2^> TURN ON THE LIGHTS
echo.
set option=
set /p option=What do you want to do? ^>
echo.
if not defined option (
	echo Make up your mind
	pause>nul
	cls
	goto /new/q
)
if %option% equ 1 (
	echo The torch provides enough light to see.
	pause>nul
	goto /new/ii
)
echo You got electrocuted. :(
pause>nul
goto /die
:/new/ii
(
	echo %v%
	echo /new/ii
	echo %name%
	echo %gold%
	echo %ghost1%
	echo %ghost2%
	echo %ghost3%
	echo %puzzle1%
	echo %ghost4%
)>Program_Files\Data
cls
echo %name% ^| LEVEL 1 ^| $%gold% ^|
echo.
echo You continue exploring when you see a dark hallway. There are two rooms: one
echo leads to the library, and the other leads to the kitchen.
echo.
pause>nul
goto /new/ii/q
:/new/ii/q
(
	echo %v%
	echo /new/ii/q
	echo %name%
	echo %gold%
	echo %ghost1%
	echo %ghost2%
	echo %ghost3%
	echo %puzzle1%
	echo %ghost4%
)>Program_Files\Data
echo You have some options.
echo.
echo PRESS 1^> EXPLORE THE LIBRARY
echo PRESS 2^> EXPLORE THE KITCHEN
echo.
set option=
set /p option=What do you want to do? ^>
echo.
if not defined option (
	echo Make up your mind
	pause>nul
	cls
	goto /new/ii/q
)
if %option% equ 2 (
	echo You walk through the kitchen doorway.
	pause>nul
	goto /new/kitchen
)
echo The door is locked. :(
echo.
pause>nul
echo You turn around to go to the kitchen, but an angry ghost is blocking your path.
pause>nul
goto /new/ii/q2
:/new/ii/q2
(
	echo %v%
	echo /new/ii/q2
	echo %name%
	echo %gold%
	echo %ghost1%
	echo %ghost2%
	echo %ghost3%
	echo %puzzle1%
	echo %ghost4%
)>Program_Files\Data
cls
echo %name% ^| LEVEL 1 ^| $%gold% ^|
echo.
echo You have some options.
echo.
echo PRESS 1^> CATCH THE GHOST
echo PRESS 2^> RUN
echo.
set option=
set /p option=What do you want to do? ^>
echo.
if not defined option (
	echo Make up your mind
	pause>nul
	goto /new/ii/q2
)
if %option% equ 1 (
	set hp=100
	set monhp=100
	set shieldlimit=1
	set speciallimit=2
	goto /ghost1
)
echo You tried to run away, but the ghost caught up to you!
pause>nul
goto /die
:/ghost1
color fc
cls
if %hp% leq 0 (
	goto /die
)
if %monhp% leq 0 (
	echo You caught HORRIFYING HENRY, a SCARY type ghost!
	echo To view his BIO, visit the PLAYER STATS page in the player menu.
	set ghost1=1
	pause>nul
	set /a gold=%gold%+200
	color f0
	echo.
	echo You decide to leave the library and explore the kitchen.
	pause>nul
	goto /new/kitchen
)
echo %name% ^| LEVEL 1 ^| $%gold% ^|
echo.
echo + %hp%
echo.
echo It's your turn.
echo.
echo You have some options.
echo.
echo PRESS 1^> ZAP
echo PRESS 2^> TRAP
echo PRESS 3^> SHIELD (%shieldlimit%/1)
echo PRESS 4^> VAPORIZE (%speciallimit%/2)
echo.
set option=
set /p option=What do you want to do? ^>
echo.
if not defined option (
	echo Make up your mind
	pause>nul
	goto /ghost1
)
if %option% equ 1 (
	echo You use ZAP against HORRIFYING HENRY!
	pause>nul
	set /a monhp=%monhp%-%Random% %%15-7%
	goto /ghost1/ii
)
if %option% equ 2 (
	if not %monhp% leq 25 (
		echo HORRIFYING HENRY breaks out of the TRAP!
		pause>nul
		goto /ghost1/ii
	)
	echo You caught HORRIFYING HENRY, a SCARY type ghost!
	echo To view his BIO, visit the PLAYER STATS page in the player menu.
	set ghost1=1
	pause>nul
	set /a gold=gold+100
	color f0
	echo.
	echo You decide to leave the library and explore the kitchen.
	pause>nul
	goto /new/kitchen
)
if %option% equ 3 (
	if %shieldlimit% leq 0 (
		echo You try SHIELD but it fails.
		pause>nul
		goto /ghost1
	)
	set /a hp=%hp%+%Random% %%18-5%
	set /a shieldlimit=%shieldlimit%-1
	echo You use SHIELD and recover + %hp%.
	pause>nul
	goto /ghost1
)
if %option% equ 4 (
	if %speciallimit% leq 0 (
		echo You try VAPORIZE but it misses.
		pause>nul
		goto /ghost1
	)
	set /a monhp=%monhp%-%Random% %%25-3%
	set /a speciallimit=%speciallimit%-1
	echo You used VAPORIZE against HORRIFYING HENRY!
	pause>nul
	goto /ghost1/ii
)
:/ghost1/ii
cls
echo HORRIFYING HENRY ^| SCARY TYPE ^| $500 ^|
echo.
echo + %monhp%
echo.
echo HORRIFYING HENRY's turn.
echo.
if %monhp% leq 15 (
	echo HORRIFYING HENRY uses MEGA-SCARE!
	pause>nul
	set /a hp=%hp%-%Random% %%25-3%
	goto /ghost1
)
echo HORRIFYING HENRY uses SCARE!
pause>nul
set /a hp=%hp%-%Random% %%18-5%
goto /ghost1
:/new/kitchen
(
	echo %v%
	echo /new/kitchen
	echo %gold%
	echo %ghost1%
	echo %ghost2%
	echo %ghost3%
	echo %puzzle1%
	echo %ghost4%
)>Program_Files\Data
cls
echo %name% ^| LEVEL 1 ^| $%gold% ^|
echo.
echo The kitchen counter is covered in junk: soda cans, candy wrappers, and all sorts of other garbage.
echo.
pause>nul
echo There is a key hanging from a hook.
echo.
pause>nul
echo You pick it up.
echo.
pause>nul
goto /new/kitchen/q
:/new/kitchen/q
(
	echo %v%
	echo /new/kitchen/q
	echo %name%
	echo %gold%
	echo %ghost1%
	echo %ghost2%
	echo %ghost3%
	echo %puzzle1%
	echo %ghost4%
)>Program_Files\Data
echo You have some options.
echo.
echo PRESS 1^> COOK SOMETHING
echo PRESS 2^> WASH YOUR HANDS
echo PRESS 3^> CONTINUE TO THE LIBRARY
echo.
set option=
set /p option=What do you want to do? ^>
echo.
if not defined option (
	echo Make up your mind
	pause>nul
	cls
	goto /new/kitchen/q
)
if %option% equ 3 (
	echo You decide to explore the library to see if the key fits.
	pause>nul
	goto /new/library
)
if %option% equ 2 (
	echo You flooded the castle. :(
	pause>nul
	goto /die
)
echo You started a fire. :(
pause>nul
goto /die
:/new/library
(
	echo %v%
	echo new/library
	echo %name%
	echo %gold%
	echo %ghost1%
	echo %ghost2%
	echo %ghost3%
	echo %puzzle1%
	echo %ghost4%
)>Program_Files\Data
cls
echo %name% ^| LEVEL 1 ^| $%gold% ^|
echo.
echo The key fits!
echo.
pause>nul
echo The bookshelf has a large collection of spellbooks.
echo.
pause>nul
echo You decide to read one and test your magic skills.
echo.
pause>nul
goto /new/library/q
:/new/library/q
(
	echo %v%
	echo /new/library/q
	echo %name%
	echo %gold%
	echo %ghost1%
	echo %ghost2%
	echo %ghost3%
	echo %puzzle1%
	echo %ghost4%
)>Program_Files\Data
echo You have some options.
echo.
echo PRESS 1^> READ FLAME ^& DESTRUCTION
echo PRESS 2^> READ ALL ABOUT SPAIN
echo PRESS 3^> READ BOB JOE's DIARY
echo.
set option=
set /p option=What do you want to do? ^>
echo.
if %option% equ 1 (
	echo You started a fire with your spells. :(
	pause>nul
	goto /die
)
if %option% equ 2 (
	echo You woke up FRIGHTENING FERDINAND!
	pause>nul
	set hp=100
	set monhp=100
	set shieldlimit=1
	set speciallimit=2
	goto /ghost2
)
echo You die of boredom. :(
pause>nul
goto /die
:/ghost2
color fc
cls
if %hp% leq 0 (
	goto /die
)
if %monhp% leq 0 (
	echo You caught FRIGHTENING FERDINAND, a FIGHTER type ghost!
	echo To view his BIO, visit the PLAYER STATS page in the player menu.
	set ghost2=1
	pause>nul
	set /a gold=%gold%+200
	color f0
	goto /new/iii
)
echo %name% ^| LEVEL 1 ^| $%gold% ^|
echo.
echo + %hp%
echo.
echo Your turn.
echo.
echo You have some options.
echo.
echo PRESS 1^> ZAP
echo PRESS 2^> TRAP
echo PRESS 3^> SHIELD (%shieldlimit%/1)
echo PRESS 4^> VAPORIZE (%speciallimit%/2)
echo.
set /p option=What do you want to do? ^>
echo.
if %option% equ 1 (
	echo You use ZAP against FRIGHTENING FERDINAND!
	pause>nul
	set /a monhp=%monhp%-%Random% %%15-7%
	goto /ghost2/ii
)
if %option% equ 2 (
	if not %monhp% leq 25 (
		echo FRIGHTENING FERDINAND breaks out of the TRAP!
		pause>nul
		goto /ghost2/ii
	)
	echo You caught FRIGHTENING FERDINAND, a FIGHTER type ghost!
	echo To view his BIO, visit the PLAYER STATS page in the player menu.
	set ghost2=1
	pause>nul
	set /a gold=%gold%+100
	color f0
	goto /new/iii
)
if %option% equ 3 (
	if %shieldlimit% leq 0 (
		echo You try SHIELD but it fails.
		pause>nul
		goto /ghost2
	)
	set /a hp=%hp%+%Random% %%18-5%
	set /a shieldlimit=%shieldlimit%-1
	echo You use SHIELD and recover %hp% HP.
	pause>nul
	goto /ghost2
)
if %option% equ 4 (
	if %speciallimit% leq 0 (
		echo You try VAPORIZE but it misses.
		pause>nul
		goto /ghost2
	)
	set /a monhp=%monhp%-%Random% %%25-3%
	set /a speciallimit=%speciallimit%-1
	echo You used VAPORIZE against FRIGHTENING FERDINAND!
	pause>nul
	goto /ghost2/ii
)
:/ghost2/ii
cls
echo FRIGHTENING FERDINAND ^| FIGHTER TYPE ^| $500 ^|
echo.
echo + %monhp%
echo.
echo FRIGHTENING FERDINAND's turn.
echo.
if %monhp% leq 15 (
	echo FRIGHTENING FERDINAND uses LIGHTNING SHIELD!
	pause>nul
	set /a hp=%hp%-%Random% %%25-3%
	set /a monhp=%monhp%+%Random% %%25-3%
	goto /ghost2
)
echo FRIGHTENING FERDINAND uses GHOST PUNCH!
pause>nul
set /a hp=%hp%-%Random% %%18-5%
goto /ghost2
:/new/iii
(
	echo %v%
	echo new/iii
	echo %name%
	echo %gold%
	echo %ghost1%
	echo %ghost2%
	echo %ghost3%
	echo %puzzle1%
	echo %ghost4%
)>Program_Files\Data
color f0
cls
echo You leave the library and explore further.
echo.
pause>nul
echo You found the stairs!
echo.
pause>nul
echo PRESS 1^> GO UPSTAIRS
echo PRESS 2^> STAY DOWNSTAIRS
echo.
set /p option=What do you want to do? ^>
echo.
if %option% equ 1 (
	echo You go upstairs, but the door is locked. :(
	pause>nul
	goto /puzzle1
)
echo You turn around to go downstairs when you see a ghost.
echo.
pause>nul
set hp=100
set monhp=100
set shieldlimit=1
set speciallimit=2
goto /ghost3
:/ghost3
color fc
cls
if %hp% leq 0 (
	goto /die
)
if %monhp% leq 0 (
	echo You caught SCARY SARAH, a SCARY type ghost!
	echo To view her BIO, visit the PLAYER STATS page in the player menu.
	set ghost3=1
	pause>nul
	set /a gold=%gold%+200
	color f0
	echo.
	echo You decide to walk upstairs because there's nothing more to see.
	pause>nul
	cls
	echo You go upstairs, but the door is locked. :(
	pause>nul
	goto /puzzle1 
)
echo %name% ^| LEVEL 1 ^| $%gold% ^| SCARY ^|
echo.
echo + %hp%
echo.
echo Your turn.
echo.
echo You have some options.
echo.
echo PRESS 1^> ZAP
echo PRESS 2^> TRAP
echo PRESS 3^> SHIELD (%shieldlimit%/1)
echo PRESS 4^> VAPORIZE (%speciallimit%/2)
echo.
set /p option=What do you want to do? ^>
echo.
if %option% equ 1 (
	echo You use ZAP against SCARY SARAH!
	pause>nul
	set /a monhp=%monhp%-%Random% %%15-7%
	goto /ghost3/ii
)
if %option% equ 2 (
	if not %monhp% leq 25 (
		echo SCARY SARAH breaks out of the TRAP!
		pause>nul
		goto /ghost3/ii
	)
	echo You caught SCARY SARAH, a SCARY type ghost!
	echo To view her BIO, visit the PLAYER STATS page in the player menu.
	set ghost3=1
	pause>nul
	set /a gold=%gold%+100
	color f0
	echo.
	echo You decide to walk upstairs because there's nothing more to see.
	pause>nul
	cls
	echo You go upstairs, but the door is locked. :(
	pause>nul
	goto /puzzle1
)
if %option% equ 3 (
	if %shieldlimit% leq 0 (
		echo You try SHIELD but it fails.
		pause>nul
		goto /ghost3
	)
	set /a hp=%hp%+%Random% %%18-5%
	set /a shieldlimit=%shieldlimit%-1
	echo You use SHIELD and recover %hp% HP.
	pause>nul
	goto /ghost3
)
if %option% equ 4 (
	if %speciallimit% leq 0 (
		echo You try VAPORIZE but it misses.
		pause>nul
		goto /ghost3
	)
	set /a monhp=%monhp%-%Random% %%25-3%
	set /a speciallimit=%speciallimit%-1
	echo You used VAPORIZE against SCARY SARAH!
	pause>nul
	goto /ghost3/ii
)
:/ghost3/ii
cls
echo SCARY SARAH ^| LEVEL 50 ^| $500 ^|
echo.
echo + %monhp%
echo.
echo SCARY SARAH's turn.
echo.
if %monhp% leq 15 (
	echo SCARY SARAH uses MEGA-SCARE!
	pause>nul
	set /a hp=%hp%-%Random% %%25-3%
	goto /ghost3
)
echo SCARY SARAH uses SCARE!
pause>nul
set /a hp=%hp%-%Random% %%18-5%
goto /ghost3
:/puzzle1
color f0
cls
echo To unlock the door solve the following riddle. 
echo.
echo PLEASE TURN ON VOLUME TO LISTEN TO THE RIDDLE
pause>nul
mkdir Program_Files\music\
echo.>Program_Files\music\temp.vbs
echo Set sound = CreateObject("SAPI.spVoice")>>Program_Files\music\temp.vbs
echo sound.Speak "What can hold water even if it has a hole in it?">>Program_Files\music\temp.vbs
cls
start Program_Files\music\temp.vbs
echo.
echo ANSWER: A [_][_][_][_][_][_]
echo.
set /p answer=Riddle Answer (ALL LOWERCASE) ^>
echo.
if %answer% equ sponge (
	echo Hooray! The door swung open.
	echo.
	echo ANSWER: A [S][P][O][N][G][E]
	echo.
	set puzzle1=1
	set /a gold=%gold%+100
	pause>nul
	goto /upstairs
)
echo OH DEAR! The door is still locked and an angry ghost sneaks up behind you.
pause>nul
goto /puzzle1/q
:/puzzle1/q
(
	echo %v%
	echo /puzzle1/q
	echo %name%
	echo %gold%
	echo %ghost1%
	echo %ghost2%
	echo %ghost3%
	echo %puzzle1%
	echo %ghost4%
)>Program_Files\Data
cls
echo %name% ^| LEVEL 1 ^| $%gold% ^|
echo.
echo You have some options.
echo.
echo PRESS 1^> CATCH THE GHOST
echo PRESS 2^> RUN
echo.
set option=
set /p option=What do you want to do? ^>
echo.
if not defined option (
	echo Make up your mind
	pause>nul
	cls
	goto /puzzle1/q
)
if %option% equ 1 (
	set hp=100
	set monhp=100
	set shieldlimit=1
	set speciallimit=2
	set moninvis=0
	goto /useless1
)
echo You tried to run away, but the ghost caught up to you!
pause>nul
goto /die
:/useless1
color fc
cls
if %hp% leq 0 (
	goto /die
)
if %monhp% leq 0 (
	echo You caught ESCAPING ELLIS, an ELUSIVE type ghost!
	echo To view her BIO, visit the PLAYER STATS page in the player menu.
	pause>nul
	color f0
	echo.
	echo ESCAPING ELLIS broke out of her trap and caught up to you while you were trying to run away.
	echo.
	pause>nul
	goto /die
)
echo %name% ^| LEVEL 1 ^| $%gold% ^|
echo.
echo + %hp%
echo.
echo It's your turn.
echo.
echo You have some options.
echo.
echo PRESS 1^> ZAP
echo PRESS 2^> TRAP
echo PRESS 3^> SHIELD (%shieldlimit%/1)
echo PRESS 4^> VAPORIZE (%speciallimit%/2)
echo.
set option=
set /p option=What do you want to do? ^>
echo.
if not defined option (
	echo Make up your mind
	pause>nul
	goto /useless1
)
if %option% equ 1 (
	echo You use ZAP against ESCAPING ELLIS!
	if %moninvis% gtr 0 (
		echo.
		echo Your attack is weak because ESCAPING ELLIS is %moninvis% percent INVISIBLE!
		set /p monhp=%monhp%+%moninvis%
	)
	pause>nul
	set /a monhp=%monhp%-%Random% %%15-7%
	goto /useless1/ii
)
if %option% equ 2 (
	if not %monhp% leq 25 (
		echo ESCAPING ELLIS breaks out of the TRAP!
		pause>nul
		goto /useless1/ii
	)
	echo You caught ESCAPING ELLIS, an ELUSIVE type ghost!
	echo To view her BIO, visit the PLAYER STATS page in the player menu.
	pause>nul
	color f0
	echo.
	echo ESCAPING ELLIS broke out of her trap and caught up to you while you were trying to run away.
	echo.
	pause>nul
	goto /die
)
if %option% equ 3 (
	if %shieldlimit% leq 0 (
		echo You try SHIELD but it fails.
		pause>nul
		goto /useless1
	)
	set /a hp=%hp%+%Random% %%18-5%
	set /a shieldlimit=%shieldlimit%-1
	echo You use SHIELD and recover + %hp%.
	pause>nul
	goto /useless1
)
if %option% equ 4 (
	if %speciallimit% leq 0 (
		echo You try VAPORIZE but it misses.
		pause>nul
		goto /useless1
	)
	set /a monhp=%monhp%-%Random% %%25-3%
	set /a speciallimit=%speciallimit%-1
	echo You used VAPORIZE against ESCAPING ELLIS!
	if %moninvis% gtr 0 (
		echo.
		echo Your attack is weak because ESCAPING ELLIS is %moninvis% PERCENT INVISIBLE!
		set /p monhp=%monhp%+%moninvis%
	)
	pause>nul
	goto /useless1/ii
)
:/useless1/ii
cls
echo ESCAPING ELLIS ^| MYSTERIOUS TYPE ^| $500 ^|
echo.
echo + %monhp%
set /a moninvis=%moninvis%+%Random% %%15-1% >nul
echo.
echo ESCAPING ELLIS's turn.
echo.
echo ESCAPING ELLIS uses INVISIBILITY and becomes %moninvis% percent INVISIBLE!
pause>nul
goto /useless1
:/upstairs
(
	echo %v%
	echo /upstairs
	echo %name%
	echo %gold%
	echo %ghost1%
	echo %ghost2%
	echo %ghost3%
	echo %puzzle1%
	echo %ghost4%
)>Program_Files\Data
cls
echo %name% ^| LEVEL 1 ^| $%gold% ^|
echo.
echo You find yourself in a bedroom. The bed isn't made, as if somebody had been
echo sleeping in it. The rest of the room is neat and tidy.
pause>nul
echo.
echo A lamp is already lit, and a book lays open on the nightstand. It looks as if
echo somebody had been reading just a second ago.
pause>nul
echo.
echo Loud footsteps can be heard from another room.
pause>nul
goto /upstairs/q
:/upstairs/q
(
	echo %v%
	echo /upstairs/q
	echo %name%
	echo %gold%
	echo %ghost1%
	echo %ghost2%
	echo %ghost3%
	echo %puzzle1%
	echo %ghost4%
)>Program_Files\Data
echo You have some options.
echo.
echo PRESS 1^> HIDE IN THE CLOSET
echo PRESS 2^> HIDE UNDER THE DRESSER
echo.
set option=
set /p option=What do you want to do? ^>
echo.
if not defined option (
	echo Make up your mind
	pause>nul
	goto /upstairs/q
)
if %option% equ 1 (
	goto /upstairs/hide
)
echo You duck under a dresser, when a giant man-eating spider appears. :(
pause>nul
goto /die
:/upstairs/hide
(
	echo %v%
	echo /upstairs/hide
	echo %name%
	echo %gold%
	echo %ghost1%
	echo %ghost2%
	echo %ghost3%
	echo %puzzle1%
	echo %ghost4%
)>Program_Files\Data
echo A ghost appears while you're in the closet.
pause>nul
goto /upstairs/hide/q2
:/upstairs/hide/q2
(
	echo %v%
	echo /upstairs/hide/q2
	echo %name%
	echo %gold%
	echo %ghost1%
	echo %ghost2%
	echo %ghost3%
	echo %puzzle1%
	echo %ghost4%
)>Program_Files\Data
cls
echo %name% ^| LEVEL 1 ^| $%gold% ^|
echo.
echo You have some options.
echo.
echo PRESS 1^> CATCH THE GHOST
echo PRESS 2^> RUN
echo.
set option=
set /p option=What do you want to do? ^>
echo.
if not defined option (
	echo Make up your mind
	pause>nul
	goto /upstairs/hide/q2
)
if %option% equ 1 (
	set hp=100
	set monhp=100
	set shieldlimit=1
	set speciallimit=2
	goto /ghost4
)
echo You tried to run away, but the ghost caught up to you!
pause>nul
goto /die
:/ghost4
color fc
cls
if %hp% leq 0 (
	goto /die
)
if %monhp% leq 0 (
	echo You caught CREEPY CARL, a SCARY type ghost!
	echo To view his BIO, visit the PLAYER STATS page in the player menu.
	set ghost4=1
	pause>nul
	set /a gold=%gold%+200
	color f0
	echo.
	echo You look out a hole in the closet door and see an old man walking into the room.
	pause>nul
	goto /upstairs/ii
)
echo %name% ^| LEVEL 1 ^| $%gold% ^|
echo.
echo + %hp%
echo.
echo It's your turn.
echo.
echo You have some options.
echo.
echo PRESS 1^> ZAP
echo PRESS 2^> TRAP
echo PRESS 3^> SHIELD (%shieldlimit%/1)
echo PRESS 4^> VAPORIZE (%speciallimit%/2)
echo.
set option=
set /p option=What do you want to do? ^>
echo.
if not defined option (
	echo Make up your mind
	pause>nul
	goto /ghost4
)
if %option% equ 1 (
	echo You use ZAP against CREEPY CARL!
	pause>nul
	set /a monhp=%monhp%-%Random% %%15-7%
	goto /ghost4/ii
)
if %option% equ 2 (
	if not %monhp% leq 25 (
		echo CREEPY CARL breaks out of the TRAP!
		pause>nul
		goto /ghost4/ii
	)
	echo You caught CREEPY CARL, a SCARY type ghost!
	echo To view his BIO, visit the PLAYER STATS page in the player menu.
	set ghost4=1
	pause>nul
	set /a gold=%gold%+100
	color f0
	echo.
	echo You look out a hole in the closet door and see an old man walking into the room.
	pause>nul
	goto /upstairs/ii
)
if %option% equ 3 (
	if %shieldlimit% leq 0 (
		echo You try SHIELD but it fails.
		pause>nul
		goto /ghost4
	)
	set /a hp=%hp%+%Random% %%18-5%
	set /a shieldlimit=%shieldlimit%-1
	echo You use SHIELD and recover + %hp%.
	pause>nul
	goto /ghost4
)
if %option% equ 4 (
	if %speciallimit% leq 0 (
		echo You try VAPORIZE but it misses.
		pause>nul
		goto /ghost4
	)
	set /a monhp=%monhp%-%Random% %%25-3%
	set /a speciallimit=%speciallimit%-1
	echo You used VAPRORIZE against CREEPY CARL!
	pause>nul
	goto /ghost4/ii
)
:/ghost4/ii
cls
echo CREEPY CARL ^| SCARY TYPE ^| $500 ^|
echo.
echo + %monhp%
echo.
echo CREEPY CARL's turn.
echo.
if %monhp% leq 15 (
	echo CREEPY CARL uses MEGA-SCARE!
	pause>nul
	set /a hp=%hp%-%Random% %%25-3%
	goto /ghost4
)
echo CREEPY CARL uses SCARE!
pause>nul
set /a hp=%hp%-%Random% %%18-5%
goto /ghost4
:/win
color fc
cls
if exist Program_Files\music\music.vbs (
	start Program_Files\music\music.vbs
)
if exist Program_Files\external\theme.cmd (
	call Program_Files\external\theme.cmd
)
echo ^|^|    ^|^|    ^|^|^|^|^|^|^|^|    ^|^|    ^|^|        ^|^|    ^|^|    ^|^|    ^|^|^|   ^|^|    ^|^|  
echo  ^|^|  ^|^|     ^|^|    ^|^|    ^|^|    ^|^|        ^|^|    ^|^|    ^|^|    ^|^|^|^|  ^|^|    ^|^|
echo    ^|^|       ^|^|    ^|^|    ^|^|    ^|^|        ^|^| ^|^| ^|^|    ^|^|    ^|^| ^|^| ^|^|    ^|^|
echo    ^|^|       ^|^|    ^|^|    ^|^|    ^|^|        ^|^| ^|^| ^|^|    ^|^|    ^|^|  ^|^|^|^|        
echo    ^|^|       ^|^|^|^|^|^|^|^|    ^|^|^|^|^|^|^|^|        ^|^|^|^|^|^|^|^|    ^|^|    ^|^|   ^|^|^|    ^|^|
echo.
echo You win. :)
echo.
pause>nul
set option=
set /p option=Do you want to be on the HI-SCORES list? (Y/N) ^>
echo.
if not defined option (
	echo Make up your mind
	pause>nul
	goto /win
)
if %option% equ Y (
	goto /win/ii
)
if %option% equ y (
	goto /win/ii
)
if %option% equ N (
	goto /start
)
goto /start
:/win/ii
(
	echo %v%
	echo /new
	echo USER
	echo 100
	echo 0
	echo 0
	echo 0
	echo 0
	echo 0
)>Program_Files\Data
echo %name% ^| LEVEL 1 ^| $%gold% ^|>Program_Files\scores
goto /start
:/shop
set jellybeans=0
set supertrap=0
set cake=0
set hat=0
set shoes=0
(
	set /p version=
	set /p path=
	set /p name=
	set /p gold=
	set /p ghost1=
	set /p ghost2=
	set /p ghost3=
	set /p puzzle1=
	set /p ghost4=
)<Program_Files\Data
(
	set /p jellybeans=
	set /p supertrap=
	set /p cake=
	set /p hat=
	set /p shoes=
)<Program_Files\character
cls
echo THE SHOP
echo.
echo Welcome to THE SHOP! Here you can buy all kinds of items to help you catch
echo ghosts.
echo.
echo AVAILABLE ITEMS
echo.
echo PRESS 1^> JELLY BEANS
echo PRESS 2^> SUPER-TRAP
echo PRESS 3^> CHOCOLATE CAKE
echo PRESS 4^> HAT
echo PRESS 5^> SHOES
echo PRESS 6^> EXIT SHOP
echo.
set option=
set /p option=What do you want to buy? ^>
echo.
if not defined option (
	echo Make up your mind
	pause>nul
	goto /shop
)
if %option% equ 1 (
	echo JELLY BEANS ($%gold%/900)
	echo.
	echo Ghosts are allergic to JELLY BEANS, so all you have to do is feed GAZZOT these
	echo beans, and he'll be too sick to attack!
	echo.
	set option=
	set /p option=Buy JELLY BEANS for $900? (Y/N) ^>
	echo.
	if %option% equ Y (
		if %gold% leq 900 (
			echo OH DEAR! You have $%gold% out of $900.
			pause>nul
			goto /shop
		)
		set jellybeans=1
		(
			echo %jellybeans%
			echo %supertrap%
			echo %cake%
			echo %hat%
			echo %shoes%
		)>Program_Files\character
	)
	if %option% equ y (
		if %gold% leq 900 (
			echo OH DEAR! You only have $%gold% out of $900.
			pause>nul
			goto /shop
		)
		set jellybeans=1
		(
			echo %jellybeans%
			echo %supertrap%
			echo %cake%
			echo %hat%
			echo %shoes%
		)>Program_Files\character
	)
	goto /shop
)
if %option% equ 2 (
	echo SUPER-TRAP ($%gold%/1350)
	echo.
	echo The SUPER-TRAP will trap ghosts faster than a TRAP, and is more likely to trap
	echo the ghost. NOTE: The SUPER-TRAP is specially designed for GAZZOT, and may not
	echo trap any other ghost.
	echo.
	set option=
	set /p option=Buy SUPER-TRAP for $1350? (Y/N) ^>
	echo.
	if %option% equ Y (
		if %gold% leq 1350 (
			echo OH DEAR! You only have $%gold% out of $1350.
			pause>nul
			goto /shop
		)
		set supertrap=1
		(
			echo %jellybeans%
			echo %supertrap%
			echo %cake%
			echo %hat%
			echo %shoes%
		)>Program_Files\character
	)
	if %option% equ y (
		if %gold% leq 1350 (
			echo OH DEAR! You only have $%gold% out of $1350.
			pause>nul
			goto /shop
		)
		set supertrap=1
		(
			echo %jellybeans%
			echo %supertrap%
			echo %cake%
			echo %hat%
			echo %shoes%
		)>Program_Files\character
	)
)
if %option% equ 3 (
	echo CHOCOLATE CAKE ($%gold%/150)
	echo.
	echo Ghosts love CHOCOLATE CAKE! Feed them a slice and watch them grow!
	echo.
	set option=
	set /p option=Buy CHOCOLATE CAKE for $150? (Y/N) ^>
	echo.
	if %option% equ Y (
		if %gold% leq 150 (
			echo OH DEAR! You only have $%gold% out of $150.
			pause>nul
			goto /shop
		)
		set cake=1
		(
			echo %jellybeans%
			echo %supertrap%
			echo %cake%
			echo %hat%
			echo %shoes%
		)>Program_Files\character
	)
	if %option% equ y (
		if %gold% leq 150 (
			echo OH DEAR! You only have $%gold% out of $150.
			pause>nul
			goto /shop
		)
		set cake=1
		(
			echo %jellybeans%
			echo %supertap%
			echo %cake%
			echo %hat%
			echo %shoes%
		)>Program_Files\character
	)
)
goto /start
:/feed
(
	set /p version=
	set /p path=
	set /p name=
	set /p gold=
	set /p ghost1=
	set /p ghost2=
	set /p ghost3=
	set /p puzzle1=
	set /p ghost4=
)<Program_Files\Data
(
	set /p jellybeans=
	set /p supertrap=
	set /p cake=
	set /p hat=
	set /p shoes=
)<Program_Files\character
cls
if %gh% equ h (
	set ghl=HORRIFYING HENRY
)
if %gh% equ f (
	set ghl=FRIGHTENING FERDINAND
)
if %gh% equ s (
	set ghl=SCARY SARAH
)
if %gh% equ c (
	set ghl=CREEPY CARL
)
echo FEED %ghl%
echo Use the food listed below to feed %gh1%.
echo.
if %cake% equ 1 (
	echo * Feed CHOCOLATE CAKE (-cake)
)
if %ghost1% equ 1 (
	if not %gh% equ h (
		echo * Feed HORRIFYING HENRY (-h)
	)
)
if %ghost2% equ 1 (
	if not %gh% equ f (
		echo * Feed FRIGHTENING FERDINAND (-f)
	)
)
if %ghost3% equ 1 (
	if not %gh% equ s (
		echo * Feed SCARY SARAH (-s)
	)
)
if %ghost4% equ 1 (
	if not %gh% equ c (
		echo * Feed CREEPY CARL (-c)
	)
)
echo * Exit (-exit)
echo.
set option=
set /p option=OPTION ^>
if not defined option (
	goto /feed
)
if "%option%" equ "-cake" (
	echo You feed CAKE to %ghl% and boost to:
	echo.
	echo Health: 250
	echo Small Attack: 37
	echo Large Attack: 51
	set boost_%gh%=1
	pause>nul
	goto /start
)
if %option% equ "-h" (
	echo You feed HORRIFYING HENRY to %ghl% and boost to:
	echo.
	echo Health: 250
	echo Small Attack: 37
	echo Large Attack: 51
	set boost_%gh%=1
	set gold=%gold%-100
	pause>nul
	goto /start
)
if %option% equ "-f" (
	echo You feed FRIGHTENING FERDINAND to %ghl% and boost to:
	echo.
	echo Health: 250
	echo Small Attack: 37
	echo Large Attack: 51
	set boost_%gh1%=1
	set gold=%gold%-100
	pause>nul
	goto /start
)
if %option% equ "-s" (
	echo You feed SCARY SARAH to %ghl% and boost to:
	echo.
	echo Health: 250
	echo Small Attack: 37
	echo Large Attack: 51
	set boost_%gh1%=1
	set gold=%gold%-100
	pause>nul
	goto /start
)
if %option% equ "-c" (
	echo You feed CREEPY CARL to %ghl% and boost to:
	echo.
	echo Health: 250
	echo Small Attack: 37
	echo Large Attack: 51
	set boost_%gh1%=1
	set gold=%gold%-100
	pause>nul
	goto /start
)
:/die
color fc
(
	echo %v%
	echo /new
	echo USER
	echo 100
	echo 0
	echo 0
	echo 0
	echo 0
	echo 0
)>Program_Files\Data
del Program_Files\tries
cls
if exist Program_Files\music\music.vbs (
	start Program_Files\music\music.vbs
)
if exist Program_Files\external\theme.cmd (
	call Program_Files\external\theme.cmd
)
echo ^|^|    ^|^|    ^|^|^|^|^|^|^|^|    ^|^|    ^|^|        ^|^|^|^|^|^|       ^|^|    ^|^|^|^|^|^|^|^|    ^|^|  
echo  ^|^|  ^|^|     ^|^|    ^|^|    ^|^|    ^|^|        ^|^|   ^|^|      ^|^|    ^|^|          ^|^|
echo    ^|^|       ^|^|    ^|^|    ^|^|    ^|^|        ^|^|   ^|^|      ^|^|    ^|^|^|^|^|^|^|^|    ^|^|
echo    ^|^|       ^|^|    ^|^|    ^|^|    ^|^|        ^|^|   ^|^|      ^|^|    ^|^|          
echo    ^|^|       ^|^|^|^|^|^|^|^|    ^|^|^|^|^|^|^|^|        ^|^|^|^|^|^|       ^|^|    ^|^|^|^|^|^|^|^|    ^|^|
echo.
echo You die. :(
pause>nul
goto /start