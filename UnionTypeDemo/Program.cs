using UnionTypeDemo.Interfaceway;
using UnionTypeDemo.UnionWay;

// OLD INTERFACE WAY
ITapResult GetTap()
{
//   return new TapAccepted("1234", "StationA");
   return new CardMistake();
}

var tapResult = GetTap();

if(tapResult is UnionTypeDemo.Interfaceway.TapAccepted accepted)
{
    Console.WriteLine($"Tap accepted for card {accepted.CardId} at station {accepted.StationId}");
}
else if(tapResult is UnionTypeDemo.Interfaceway.CardBlocked cardBlocked)
{
    Console.WriteLine($"Card {cardBlocked.CardId} is blocked");
}
else if(tapResult is UnionTypeDemo.Interfaceway.CardUnreadable)
{
    Console.WriteLine("Card is unreadable");
}
else if(tapResult is UnionTypeDemo.Interfaceway.UnsupportedCard unsupported)
{
    Console.WriteLine($"Unsupported card type: {unsupported.CardType}");
}else
{
    Console.WriteLine("Unknown tap result");
}

// NEW UNION TYPE WAY
TapResult GetUnionTap()
{
    return new UnionTypeDemo.UnionWay.TapAccepted("1234", "StationA");
}

var tap = GetUnionTap();
var result = tap switch
{
    UnionTypeDemo.UnionWay.TapAccepted tapAccepted =>
        $"Tap accepted for card {tapAccepted.CardId} at station {tapAccepted.StationId}",
    UnionTypeDemo.UnionWay.CardBlocked cardBlocked => $"Card {cardBlocked.CardId} is blocked",
    UnionTypeDemo.UnionWay.CardUnreadable => "Card is unreadable",
    UnionTypeDemo.UnionWay.UnsupportedCard unsupported => $"Unsupported card type: {unsupported.CardType}",
};
