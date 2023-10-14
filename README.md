# Individuellt projekt Oskar Johansson

Grundläggande innehåll:
Detta program är en enkel konsolapplikation som ska likna en bankomat. Den innehåller funktioner för att logga in, visa konton och saldo, överföra pengar och ta ut pengar från olika konton. Den använder statiska arrayer för att lagra informationen om användare, pinkoder och kontosaldon. Användaren kan logga in och utföra olika bankrelaterade åtgärder.

Reflektion:
Mitt val att använda statisk datastruktur: Jag valde att använda statiska arrayer för att lagra användarnamn, pinkoder, kontonamn och kontosaldo. Detta tyckte jag fungerar bra för ett enkelt bankomatprogram som detta. Det gör programmet enkelt att förstå och underhålla, särskilt med en mindre mängd data.

Mitt val att använda metoder: Jag valde att organisera koden genom att använda metoder, vilket förbättrar läsbarheten och eftersom det stod i uppgiften att man skulle använda minst 3 stycken metoder. Varje metod har en tydlig uppgift och ansvar, vilket gör det lätt att följa programflödet.

Mitt val av felhantering: Jag valde att hantera fel genom att kontrollera användarinput och hantera felaktiga inloggningsförsök samt ogiltiga överföringar eller uttag. Detta är viktigt för att säkerställa att programmet fungerar på ett förutsägbart sätt och för att förhindra fel från användaren.

Hinder på vägen:
Jag började med att använda arrayer eftersom det stod i uppgiften att man skulle ha det, och jag visste inte annars var jag skulle kunna använda dem. Nu i efterhand skulle man egentligen bara använda en enkel array för att skriva ut flera meddelanden eller liknande, men jag valde detta från början och först tyckte jag att det var för jobbigt att börja om. Men sedan tog jag det som en utmaning att lösa det, även om det kanske hade varit lättare med "list" eller liknande. Jag började bygga mitt program, och efter att jag hade kanske byggt halva programmet eller mer insåg jag att alla användare skulle ha olika konton och olika många, vilket då blev ett problem. Men som jag kände nu att jag löste ganska bra med hjälp av statiska arrayer, där jag även var tvungen att fixa väldigt mycket i hela programmet, men det var utmanande och kul! Annars har jag tyckt att det har gått väldigt bra, inte stött på så stora problem, mest bara småsaker, osv, som man har kunnat rätta till snabbt. Detta har varit ett kul men utmanande program att skapa! :)

Alternativa lösningar:
Databaslagring: Istället för att använda statiska arrayer skulle jag i så fall, efter att ha googlat och pratat med folk som jobbar med programmering, överväga att lagra användarinformation och kontosaldo i en databas, vilket skulle göra det enklare att hantera fler användare och mer komplexa transaktioner. Jag skulle i så fall behöva använda en databasanslutning och SQL för att hämta och uppdatera data (detta ser jag fram emot att lära mig!).

Om jag skulle göra ett mer komplext program och inkludera fler funktioner, som kanske räntebearbetning (kommer att bli spännande när man lär sig detta) eller möjligheten att öppna nya konton, skulle en objektorienterad design vara mer lämplig. När jag googlar så skulle jag behöva skapa fler klasser för användare och konton och hantera dem som objekt med metoder och egenskaper.

Sammanfattningsvis har jag byggt ett enkelt men effektivt bankomatprogram med val av statiska datastrukturer, metoder, felhantering m.m. Om programmet skulle utökas eller användas i en mer krävande miljö, skulle bättre lösningar och andra tekniker vara bättre.
