%%%%% >Scheduler GUI - Philipp Würfel< %%%%%

1. DMX Control 3 installieren (getestete Version: v3.1.3)


In Visual Studio:

2. Projekt "SchedulerPlugin" -> Properties -> Buildereignisse -> Postbuildereignis überprüfen 
und Pfad bei abweichender DMXControl-Installation ändern
Musterbeispiel: copy "$(ProjectDir)$(OutDir)\SchedulerPlugin.dll"  "C:\Program Files (x86)\DMXControl3\GUI\Plugins"
Postbuildereignisse müssen für folgende Klassenbibliotheken hinzugefügt werden:
	- SchedulerPlugin.dll (opt.: + SchedulerPlugin.pdb) 
	- SchedulerCommunicator.dll (opt.: + SchedulerCommunicator.pdb)
	- SchedulerAppointment.dll (opt.: + SchedulerAppointment.pdb)
	- SchedulerLogFileWriter.dll (opt.: + SchedulerLogFileWriter.pdb)
	- SchedulerTimer.dll" (opt.: + SchedulerTimer.pdb)
	
(Für Installation im x86-Ordner von Windows muss Visual Studio mit Administratorrechten gestartet werden 
und DMXControl darf nicht geöffnet sein)

3. Unter Properties von "SchedulerPlugin" Verweispfad zum GUI Ordner überprüfen/setzen
(Bsp.: "C:\Program Files (x86)\DMXControl3\GUI")

4. In den Projektmappen "SchedulerPlugin" und "DMXControlScheduler" folgende Verweise (aus GUI-Ordner, wie im Verweispfad) hinzufügen oder deren Pfad aktualisieren:
	- LumosGUILIB.dll
	- LumosGUI.exe
	- WeifenLuo.WinFormsUI.Docking.dll
	- LumosLIB.dll

5. Projektmappe "SchedulerPlugin" als Startprojekt festlegen

6. Unter Properties -> Debuggen -> "Externes Programm starten" mit Pfad zur "LumosGUI.exe" von DMX-Control
Musterbeispiel: C:\Program Files (x86)\DMXControl3\GUI\LumosGUI.exe

--> In dieser Variante kann DMXControl in Visual Studio debuggt werden, zusätzlich werden die notwendigen dll's in den Plugins Ordner von DMXControl kopiert. Auf das PlugIn kann danach auch außerhalb von VisualStudio in DMXControl zugegriffen werden.

Für die Aktivierung des PlugIns in DMXControl:
	a) Reiter Settings -> Plugin Management : Haken bei Scheduler Plugin setzen
	b) Reiter Windows -> Scheduler Plug In : anklicken, fenster öffnet sich (manchmal im oberen, oder unteren Bereich von DMXControl, in diesem Fall entsprechend "hochziehen"


Mögliche Fehlerbehebungen:

- Bei Laufzeitproblemen unter Properties bei Build das Plattformziel auf x86 setzen
- Wenn Funktionen/Buttons in DMX Control nicht funktionieren: 
Projekt DMXControlScheduler als Startprojekt festlegen und starten, 
danach in dessen Debug-Ordner gehen und alle fehlenden Dll's und .pdb-Dateien 
(außer DMXControlScheduler.dll, *pdb) in den DMXControl/GUI/Plugins Ordner kopieren

7. Die Lauffähigkeit vom Communicator kann nur mit DMX Control 3 und vorhandenen Cuelist in DMX überprüft werden. Folgende Verweise hinzufügen. 
        - LumosGUILIB.dll
	- LumosGUI.exe
        - LumosLIB.dll
