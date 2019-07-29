%%%%% >Scheduler GUI - Philipp Würfel< %%%%%

#### Für Benutzung ###

Dateien aus dem Ordner SchedulerPlugIn_DLL in den PlugIn-Ordner von DMXControl ablegen
(Bspw.: C:\Program Files (x86)\DMXControl3\GUI\Plugins)

### Für Entwicklung ###

1. DMX Control 3 installieren (getestete Version: v3.1.3)

# In Visual Studio

(Für Installation im x86-Ordner von Windows muss Visual Studio mit Administratorrechten gestartet werden 
und DMXControl darf nicht geöffnet sein)

2. Projekt "SchedulerPlugin" -> Eigenschaften -> Buildereignisse -> Postbuildereignis überprüfen 
und Pfad bei abweichender DMXControl-Installation ändern
Musterbeispiel: copy "$(ProjectDir)$(OutDir)\SchedulerPlugin.dll"  "C:\Program Files (x86)\DMXControl3\GUI\Plugins"
Postbuildereignisse müssen für folgende Klassenbibliotheken hinzugefügt werden:
	- SchedulerPlugin.dll (opt.: + SchedulerPlugin.pdb) 
	- SchedulerCommunicator.dll (opt.: + SchedulerCommunicator.pdb)
	- SchedulerAppointment.dll (opt.: + SchedulerAppointment.pdb)
	- SchedulerLogFileWriter.dll (opt.: + SchedulerLogFileWriter.pdb)
	- SchedulerTimer.dll" (opt.: + SchedulerTimer.pdb)

3. Unter Eigenschaften -> Verweispfade: Von "SchedulerPlugin" Verweispfad zum GUI-Ordner überprüfen/setzen
(Bsp.: "C:\Program Files (x86)\DMXControl3\GUI")

4. In den Projektmappen "SchedulerPlugin" folgende Verweise (aus GUI-Ordner, wie im Verweispfad) hinzufügen oder deren Pfad aktualisieren:
	- LumosGUILIB.dll
	- LumosGUI.exe
	- WeifenLuo.WinFormsUI.Docking.dll
	- LumosLIB.dll
	
	- SchedulerAppointment.dll
	- SchedulerCommunicator.dll
	- SchedulerLogFileWriter.dll
	- SchedulerTimer.dll

5. Projektmappe "SchedulerPlugin" als Startprojekt festlegen

6. In SchedulerPlugin Unter Eigenschaften -> Debuggen -> "Externes Programm starten" mit Pfad zur "LumosGUI.exe" von DMX-Control
Musterbeispiel: C:\Program Files (x86)\DMXControl3\GUI\LumosGUI.exe

--> In dieser Variante kann DMXControl in Visual Studio debuggt werden, zusätzlich werden die notwendigen dll's in den Plugins Ordner von DMXControl kopiert (weswegen Ausführung als Administator notwendig ist). Auf das PlugIn kann danach auch außerhalb von VisualStudio in DMXControl zugegriffen werden.

# In DMX-Control

Für die Aktivierung des PlugIns in DMXControl:
	a) Reiter Settings -> Plugin Management : Haken bei Scheduler Plugin setzen
	b) Reiter Windows -> DMX Scheduler : anklicken, fenster öffnet sich (manchmal im oberen, oder unteren Bereich von DMXControl, in diesem Fall entsprechend "hochziehen"


Mögliche Fehlerbehebungen:

- Bei Laufzeitproblemen unter Properties bei Build das Plattformziel auf x86 setzen
- Wenn Funktionen/Buttons in DMX Control nicht funktionieren: 
Projekt DMXControlScheduler als Startprojekt festlegen und starten, 
danach in dessen Debug-Ordner gehen und alle fehlenden Dll's und .pdb-Dateien 
(außer DMXControlScheduler.dll, *pdb) in den DMXControl/GUI/Plugins Ordner kopieren
