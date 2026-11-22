using UnionTypeDemo.Interfaceway;
using UnionTypeDemo.UnionWay;

// OLD INTERFACE WAY
ITapResult GetTap()
{
//   return new TapAccepted("1234", "StationA");
   return new CardMistake();
}

var result = GetTap() switch
{
    UnionTypeDemo.Interfaceway.TapAccepted tapAccepted =>
        $"Tap accepted for card {tapAccepted.CardId} at station {tapAccepted.StationId}",
    UnionTypeDemo.Interfaceway.CardBlocked cardBlocked => $"Card {cardBlocked.CardId} is blocked",
    UnionTypeDemo.Interfaceway.CardUnreadable => "Card is unreadable",
    UnionTypeDemo.Interfaceway.UnsupportedCard unsupported => $"Unsupported card type: {unsupported.CardType}",
    _ => "Unknown tap result"
};

Console.WriteLine($"The interface way result: {result}");


// NEW UNION TYPE WAY
TapResult GetUnionTap()
{
    return new UnionTypeDemo.UnionWay.TapAccepted("1234", "StationA");
}

result = GetUnionTap() switch
{
    UnionTypeDemo.UnionWay.TapAccepted tapAccepted =>
        $"Tap accepted for card {tapAccepted.CardId} at station {tapAccepted.StationId}",
    UnionTypeDemo.UnionWay.CardBlocked cardBlocked => $"Card {cardBlocked.CardId} is blocked",
    UnionTypeDemo.UnionWay.CardUnreadable => "Card is unreadable",
    UnionTypeDemo.UnionWay.UnsupportedCard unsupported => $"Unsupported card type: {unsupported.CardType}",
};

Console.WriteLine($"The union type way result: {result}");
