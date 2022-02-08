# Filmstudion

Obs!! Har bara skapat apiet och inget klientgränsnitt!

### Instruktioner
Öppna mappen Filmstudion och högerklicka sedan på Filmstudion.Server för att få fram git. Kör  dotnet ef database update och sedan en dotnet run. OM den öppas i code. I Visual studio är det bara att klicka på solution filen.
När apiet är igång så finns det tre kategorier att välja mellan. Film, FilmStudio och User. APIet körs på .net5 och alla nuget packages är antingen 5.0.13 eller 
senaste versionen beroende på nuget.


###Film: 

GET /api/Film, klicka på try out och sedan execute så tar den fram alla filmer. 

POST skapar en film. (Obs, du måste vara admin). Ändra i strängen när du trycker på try out "title, filmcopies, amount" och låt de andra vara som det är. 

GET /api/Film/{filmId} hämtar en specifik film beroende på id. Tryck på try out och sedan skriv in idet. (funkar för både gäster och inloggade).

PATCH ändrar en specifik film. Ändrar namn och id på filmen. Hur man gör. Logga in som admin, Skriv in i fältet id siffran som filmen har och ändra sedan i strängen till ett annat namn. kör en clear o get /api/film och executa igen så kommer du se den valda idet att namnet är ändrat!

DELETE raderar en specifik film genom att skriva in idet på filmen man vill ta bort.

###FilmStudio: 

GET /api(FilmStudio/{filmStudioId}) hämtar filmstudios baserat på vald id.

GET /api/FilmStudio hämtar alla filmstudios som är registrerade.

POST /api/FilmStudio/authenticate autentiserar användaren. Om det är admin eller ej och generar ut en token man kan logga in med.

POST /api/FilmStudio/register registrerar en användare. Filmstudio eller admin.

###USER

GET /api/user Hämtar alla admins

POST /api/User/authenticate kollar om det är admin eller ej. byt ut strängarna från username och password till det som skapats så generar den en admin token.

POST /api/User/register registrerar en ny admin. Fyll i namn och lösenord.

Nedanför det finns en spalt för Schemas. Där står det också instruktioner om hur apiet ska gå till för att fungera.
När du registrerat dig och fått ut din admin token så klickar du på övre hörnet på knappen där det står "Authorize" skriv sedan Bearer "apiKEY/ token" och sen är det bara köra!


###N-Tier architecture
Jag valde att använda mig utan N-Tier när jag organiserade min kod. Models > DataAccess > Business > Server. 

Models är en class library och i den så la jag in alla databasmodeller som behövdes.
DataAccess är även den en class library och där jag la in alla filer som hade något att göra med databasen. Den används till all direkt databaskoppling.
Business är även den en class library som sköter all business logik. 
Server är själva apiet. 

