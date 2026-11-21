using UnionTypeDemo.interfaceway;

// OLD INTERFACE WAY
ITapResult GetTap()
{
   return new TapAccepted("1234", "StationA");
}

var tapResult = GetTap();

if(tapResult is TapAccepted accepted)
{
    Console.WriteLine($"Tap accepted for card {accepted.CardId} at station {accepted.StationId}");
}
else if(tapResult is CardBlocked cardBlocked)
{
    Console.WriteLine($"Card {cardBlocked.CardId} is blocked");
}
else if(tapResult is CardUnreadable)
{
    Console.WriteLine("Card is unreadable");
}
else if(tapResult is UnsupportedCard unsupported)
{
    Console.WriteLine($"Unsupported card type: {unsupported.CardType}");
}else
{
    Console.WriteLine("Unknown tap result");
}

// NEW UNION TYPE WAY

