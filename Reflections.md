
###Reflections

####Rest
Det jag använde mig av i controllern = automapper, Interface för FilmStudioService

Skapade först en dependency injection, sedan en constructor och la in det jag behövde i parametrarna.

I min FilmStudioController på min getfilmstudiobyid skapade jag först två variabler. En role och en token. Jag använde mig sedan av det i en if sats för att validera att det går att hämta ett id på filmstudio för admin. Försöker man komma åt det som vanlig användare blir man nekad.
Andra if satsen kollar rollen och är rollen admin så loopas det igenom filmStudioAdminDton som är kopplad till automapper.

I min andra method getallfilmstudios använde jag mig av Authorize här med som gör så inte vem som helst kan komma åt studiosarna. Utan bara inloggade, users och admin.
Tillämpade samma logik som första methoden

Authenticate kollar så namn och lösenord är korrekt och Register methoden registrerar ny användare och håller koll på så man inte skriver samma namn på flera konton man skapar.

FilmControllern har samma logik som FilmStudio. Bara att här har jag lagt till flera Http requests. I mina GET requests har jag en method för getAllFilms som hämtar alla filmer. Och beroende på om det är admin eller ej visar den fram informationen för respektive användare. Och en method för getFilmById som hämtar specifikt en film man letar efter med rätt id.

I min Post request skapade jag createFilm method och en frombody där jag la in createfilmdto objektet. I den loopas det en if sats för att kolla ifall filmen man skapar existerar eller ej. 

I min Http request Patch skapade jag en method för att updatera filmer. Använde mig av Authorize för att sätta vem som får ändra. Använde även här frombody och en UpdateFilmDto.
Skapade en if för badrequest, skapade en variabel där jag la in min Film automapper.

I min Delete är som det står. En method för att radera saker. 

Så min layout fungerar såhär. Jag skapar först models, Skapar sedan repositorys för modellerna jag skapat, interface till repositorysen. Skapar sedan instans för film, filmstudio, user och filmcopies, skapar sedan services som jag använder dependency injection och skapar en constructor för repository så det blir till ett. Och skapar sedan DTos som jag kopplar ihop till controllern. 

###Implementation

I Models class library : FilmStudio classen ärver från IFilmStudio. Samma med RegisterFilmStudio och IRegisterFilmStudio. Film och IFilm likaså. 
I DataAccess class library så ärver UserRepository IUserRepository. FilmStudioRepository med IFilmStudioRepository etc... varav dom är kopplade till varsin instans i databasen med respektive namn. 

I service så kör jag en dependency injection och en constructor på respektive servicar. UserService ärver från IUserService och sedan lägger jag in en dependency injection till IUserRepository och döper den till repository. Samma på alla i service beroende på vad det är om det är user eller filmstudio eller film. Sedan skapar jag dtos och det är här jag tar fram vad användaren ska se. Så classerna ärver från interfacen här med som med allt innan och sedan kopplas det ihop till automappern i respektive listor och sen läggs dom in i controllern. 

###Säkerhet

På säkerhetsfronten så har jag använt mig av JWT Tokens och Authorizations samt lagt till roller där admin och användarna urskiljer sig vad man kan få fram. I Data mappen så skapade jag en AppSettings.cs där jag la in en secret token som även är kopplat till appsettings.json.


