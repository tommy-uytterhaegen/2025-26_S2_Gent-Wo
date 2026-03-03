
using System.Drawing;

// Dit is geen volledige oplossing voor de oefening op het einde van de les 'DCD & Overerving'. Het is wel een ondersteuning zodat de rest kan ingevuld worden
// Of nog beter: je maakt de oefening zelf en gebruikt dit project als naslagwerk

// TODO:
// - Maak voor alles aan factory aan. Kijk naar Coordinaat als voorbeeld
// - Dwing af dat er maar 1 prinses kan zijn
// - Maak de resterende klassen/eigenschappen/methoden aan om te voldoen aan https://thesurfingpikachus.github.io/so2/_images/dcd/interfaces-hond.png
// - Bedenk en implementeer een test scenario dat gebruik maakt van de verschillende klassen.
// - TIP 1: Denk altijd na wat een gebruiker van een klasse verkeerd kan doen
// - TIP 2: Indien je functionaliteit schrijft, denk altijd goed na waar deze 'hoort'. Bv. Code die kijkt of er een prinses is hoort bij het kasteel

int rasterHoogte = 3;
int rasterBreedte = 3;

var factoryResultKasteel1 = Kasteel.Create(2, 1, 3, Color.Red);
var factoryResultKasteel2 = Kasteel.Create(0, 2, 3, Color.Red);

if ( factoryResultKasteel1.IsSuccess && factoryResultKasteel2.IsSuccess )
{
    var kasteel1 = factoryResultKasteel1.Result;
    var kasteel2 = factoryResultKasteel2.Result;

    kasteel1.Bewoners.Add(new Prinses("Sneeuwwitje", "Appel etende prinses"));

    kasteel1.Bewoners.Add(new Ridder("Lancelot", 200));
    kasteel1.Bewoners.Add(new Ridder("Lance", 150));

    kasteel1.Bewoners.Add(new Kok("Gordon", "Spaghetti"));

    kasteel1.Bewoners.Add(new Stalknecht("Jef"));

    var isBewoondDoorPrinses = kasteel1.Bewoners.Any(bewoner => bewoner is Prinses);

    if (kasteel1.IsBewoondDoorPrinses())
    {

    }

    foreach (var bewoner in kasteel1.Bewoners)
    {
        if (bewoner is IStrijder strijder)
        {
            strijder.Vecht();
        }
    }

    if (kasteel1.LigtBinnenRaster(rasterBreedte, rasterHoogte))
    {
        Console.WriteLine("Het kasteel ligt binnen het raster");
    }
}
else
{
    Console.Write($"De kastelen zijn niet goed: " + factoryResultKasteel1.ErrorMessage + factoryResultKasteel2.ErrorMessage);
}



var r = new Random();


//Random.Shared.Next()

var nummer = r.Next(4);
switch (nummer)
{
    case -1:
    case 0: 
        break;
    case 1: break;
    case 2: break;
}
public static List<Bewoner> MaakWillekeurigeBewoners(int aantal)
{
    return Enumerable.Repeat(0, aantal)
                     .Select(x => MaakWillekeurigeBewoner())
                     .ToList();
}

public Bewoner MaakWillekeurigeBewoner()
{
    return r.Next(4) switch
    {
        0 => new Prinses(naam, MaakWillekeurigeString(50)),
        1 => new Ridder(v, 1),
        2 => new Stalknecht(naam),
        3 => new Kok(naam, MaakWillekeurigeString(30)),
        _ => throw new Exception()
    };
}

private static string MaakWillekeurigeString(int lengte = 10)
{
    return string.Join("", Enumerable.Repeat(0, lengte)
        .Select(n => (char)new Random().Next((int)'a', (int)'z'))));
    if (nummer == 0 )
{

}
else if ( nummer == 1)
{

}
else if (nummer == 2)
{

}