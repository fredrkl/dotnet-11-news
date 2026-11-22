namespace UnionTypeDemo.UnionWay;

public record TapAccepted(string CardId, string StationId);
public record CardBlocked(string CardId);
public record CardUnreadable;
public record UnsupportedCard(string CardType);

//public record CardMistake;

public readonly union TapResult(
    TapAccepted,
    CardBlocked,
    CardUnreadable,
//   CardMistake,
    UnsupportedCard);
