
# register

De volgende commando's zijn vereist voor registratie:

    • register.gebruikersnaam

    • registreer.wachtwoord

    • registreren.verzenden

Als u eerst "register.username {your_name}" typt, zorg er dan voor dat u uw naam samen schrijft, omdat alleen het eerste woord als naam wordt gekozen.

Daarna geldt hetzelfde voor je wachtwoord, maar typ je naam niet in, maar kies een sterk wachtwoord. Dus "register.password {your_password}".

Zodra dit is gebeurd, typt u register.submit. En je komt dan direct in het Dashboard terecht.



# Goto

Gebruik de goto om naar verschillende pagina's te gaan. Zoals "ga naar mediaplayer.panel". 

Dit brengt u bijvoorbeeld naar het mediaspelerpaneel. Bovenaan staan ​​alle opties vermeld.


# LOGIN
Dezelfde logica voor het registreren werkt ook met login.
"login.gebruikersnaam {uw_gebruikersnaam}"
"login.wachtwoord {uw_wachtwoord}"
en na het invoeren van dit type "login.submit"



# mediaplayer
1 mediaplayer.play
Een liedje spelen. Dit moet worden gedaan door het commando met een song_id te typen. Dus "mediaplayer.play {song_id}". Hiermee kunt u een nummer afspelen.

2 mediaplayer.remove
Om een ​​nummer te verwijderen, typ je mediaplayer.remove met de ID van het nummer dat je wilt verwijderen. Dus "mediaplayer.remove {song_id}".

3 mediaplayer.add
Om een ​​nummer aan je wachtrij toe te voegen, typ je mediaplayer.add en de song_id van het nummer dat je wilt toevoegen. Dus "mediaplayer.add {song_id}"

4 mediaplayer.pause
Typ mediaplayer.pause om een ​​nummer te stoppen. Hiermee wordt het nummer niet verder gespeeld en kun je rustig een kopje koffie pakken zonder iets van een nummer te missen. Dus met “mediaplayer.pause”.

5 mediaplayer.next
Met mediaplayer.next sla je het huidige nummer over en speel je het volgende nummer af.
Dus met “mediaplayer.next” ga je naar het volgende nummer.

# SONGS
1 songs.all
Met songs.all kun je alle nummers met bijbehorende id's bekijken als je dit nodig hebt.

Dus met “songs.all” kun je alle nummers bekijken.

2 song.current
Typ song.current om het huidige nummer te zien. Dit toont het huidige nummer dat wordt afgespeeld. Typ dus "song.current" om het nummer te zien dat momenteel wordt afgespeeld.

3 song.like
Als je een nummer leuk vindt, kun je het opslaan met "song.like {song_id}". Het nummer wordt tussen je favoriete nummers geplaatst.

4 song.dislike
Als je een nummer niet zo leuk vindt, kun je het uit het nummer verwijderen met "song.dislike {song_id}". Hiermee wordt het nummer tussen je favoriete nummers verwijderd.

5 song.make
Het aanmaken van een nieuw nummer kan door “song.make {title} {duration in seconds} {genre}”



# playlist
1 playlist.view-id
Om een ​​specifieke afspeellijst te bekijken, typt u "playlist.view-id {playlist_id}" met de bijbehorende afspeellijst-id.

2 playlist.play
Typ "playlist.play {playlist_id}" om een ​​afspeellijst af te spelen. Hierdoor wordt de afspeellijst afgespeeld.

3 playlist.add
Typ "playlist.add {song_id} {playlist_id}" om een ​​nummer aan een afspeellijst toe te voegen. Hierdoor wordt een nummer aan de afspeellijst toegevoegd. Let op, dit is alleen voor de eigenaar van een afspeellijst.

4 playlist.make
Typ "playlist.make {title_song}" met de titel van de nieuwe afspeellijst om een ​​nieuwe afspeellijst te maken.

5 playlist.remove
Om een ​​nummer uit de afspeellijst te verwijderen, typt u 'playlist.remove {song_id}'. Hiermee wordt het nummer uit de afspeellijst verwijderd.



# Album
1 album.view-id
Om een ​​specifieke album te bekijken, typt u "album .view-id {album_id}" met de bijbehorende album-id.

2 album.play
Typ "album .play {album_id}" om een ​​album af te spelen. Hierdoor wordt de album afgespeeld.

3 album.add
Typ "album .add {song_id} {album_id}" om een ​​nummer aan een album toe te voegen. Hierdoor wordt een nummer aan de album toegevoegd. Let op, dit is alleen voor de eigenaar van een album.

4 album.make
Typ "album .make {title_song}" met de titel van de nieuwe album om een ​​nieuwe album te maken.

5 album.remove
Om een ​​nummer uit de album te verwijderen, typt u 'album .remove {song_id}'. Hiermee wordt het nummer uit de album verwijderd.



# friends
1 friends.add
Gebruik het commando "friends.add {user_id}" om een ​​vriend toe te voegen. Hier kun je een vriend aan je lijst toevoegen.

2 friends.remove
Gebruik het commando "friends.remove{user_id}" om een ​​vriend te verwijderen. Hier kun je een vriend van je lijst verwijderen.

3 friends.profile
Als je een profiel van een vriend wilt zien, gebruik dan "friends.profile {user_id}". Hier krijg je een overzicht van je vriendenprofiel



# Overig
1 Exit
Gebruik hem niet!

2 Logout
Om uit te loggen van je huidig account type “logout”. Dit werkt alleen waarneer je ingelogt staat.

# USER STORIES

Als gebruiker wil ik muziek kunnen opslaan Zodat ik dit later terug kan vinden

Als gebruiker wil ik muziek kunnen afspelen Zodat ik dit kan luisteren

Als gebruiker wil ik een nummer kunnen aanmaken en uploaden Zodat anderen hierna kunnen luisteren

Als gebruiker wil ik mijn nummer op pause kunnen zetten Zodat ik koffie kan halen

Als gebruiker wil ik een eigen account hebben Zodat ik niet op andermans account hoeft te zitten.

Als gebruiker wil ik kunnen uitloggen Zodat niet iedereen op mijn account komt.

Als artiest wil ik een album kunnen maken met zelfgemaakte nummers Zodat anderen dit kunnen luisteren.


# NIET GELUKT:
Als gebruiker wil ik songs kunnen terugzien wat er is gespeeld Zodat ik weet welk nummer er leuk was.
