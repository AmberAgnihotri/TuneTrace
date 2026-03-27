Proces 1e sprint:

Database (SSMS):
Ik heb eerst een database aangemaakt met tabellen gebaseerd op mijn Ontwerp Document. De tabellen zijn Artist, Song, Album, Gebruiker, Beoordeling. De koppeltabel AlbumArtist is er omdat, een Album meerdere Artists kan bevatten en een Artist kan bij meerdere Albums horen. Daarna heb ik testdata ingevoegd voor Artist (The Beatles, Taylor Swift en Kendrick Lamar) en Albums (Abbey Road, Midnights en Mr.Morale) en Song (Come together, Something, Lavender-Haze, Anti-Hero, N95 en Die Hard). 

Visual Studio Projectstructuur:
Ik hebben een ASP.NET MVC project gemaakt.
In Models beschrijf ik de structuur van de data in C# met classes. Ik heb Album.cs, Artist.cs, Beoordeling.cs, Gebruiker.cs en Song.cs aangemaakt. Elke klasse heeft properties zoals ID, Titel, etc, die overeenkomen met de kolommen in de database.
In de Repositories map heb ik alle database-communicatie gezet. Ik heb vijf bestanden aangemaakt: AlbumRepository.cs, ArtistRepository.cs, SongRepository.cs, BeoordelingRepository.cs en ZoekRepository.cs. In elk bestand heb ik methodes geschreven, hierin staat ophalen, toevoegen, verwijderen en filteren van data.
De repository zorgt ervoor dat data uit de database wordt omgezet naar models die in de applicatie gebruikt worden.
In de Controllers heb ik de logica van de applicatie gezet per requirement een controller. Ik roep hier de repositories aan, verwerk de data en stuur het naar de View. In Vieuws Index.cshtml wordt de data visueel weergegeven. 

FR-01: Als gebruiker wil ik dat er een overzicht te zien is met content die muziekitems aan toont.
B-01.01: Alleen de belangrijkste informatie van elk muziekitem (titel en artiest, top nummers van album) wordt weergegeven.
B-01.02: Het overzicht moet korte toplijsten bevatten over populaire artiesten, trending nummers en albums.

FR-02: Als gebruiker wil ik nummers een rating en review kunnen geven.
K-02.01: Een gebruiker mag maar een actieve rating per nummer of album hebben.
B-02.01: Ratings mogen alleen van 1 tot 10 sterren zijn.
B-02.02: Huidige ratings en reviews moeten eerst verwijderd worden voordat de gebruiker een nieuwe voor hetzelfde nummer of album kan plaatsen.
	
Fr-03: Als gebruiker wil ik naar nummers, albums en artiesten kunnen zoeken op de website.
K-03.01: De zoekfunctie moet fouttolerant zijn, zodat kleine typefouten nog steeds relevante resultaten opleveren.
B-03.01: De zoekopdracht moet minimaal 2 tekens bevatten om iets te vinden.
B-03.02: Het systeem zoekt alleen in nummers, artiesten en albums die in de database staan.
B-03.03: Het systeem geeft de laatste 5 recente opgezochte nummers, artiesten en albums weer van de gebruiker die in de database staan.

