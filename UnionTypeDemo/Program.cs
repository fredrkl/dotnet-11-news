using UnionTypeDemo.Interfaceway;
using UnionWay = UnionTypeDemo.UnionWay;

// OLD INTERFACE WAY
ITapResult GetTap()
{
//   return new TapAccepted("1234", "StationA");
   return new CardMistake();
}

var result = GetTap() switch
{
    TapAccepted tapAccepted =>
        $"Tap accepted for card {tapAccepted.CardId} at station {tapAccepted.StationId}",
    CardBlocked cardBlocked => $"Card {cardBlocked.CardId} is blocked",
    CardUnreadable => "Card is unreadable",
    UnsupportedCard unsupported => $"Unsupported card type: {unsupported.CardType}",
    _ => "Unknown tap result"
};

Console.WriteLine($"The interface way result: {result}");


// NEW UNION TYPE WAY
UnionWay.TapResult GetUnionTap()
{
    return new UnionWay.TapAccepted("1234", "StationA");
}

result = GetUnionTap() switch
{
    UnionWay.TapAccepted tapAccepted =>
        $"Tap accepted for card {tapAccepted.CardId} at station {tapAccepted.StationId}",
    UnionWay.CardBlocked cardBlocked => $"Card {cardBlocked.CardId} is blocked",
    UnionWay.CardUnreadable => "Card is unreadable",
    UnionWay.UnsupportedCard unsupported => $"Unsupported card type: {unsupported.CardType}",
};

Console.WriteLine($"The union type way result: {result}");
