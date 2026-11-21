namespace UnionTypeDemo.interfaceway;
public interface ITapResult;

public record TapAccepted(string CardId, string StationId)
    : ITapResult;

public record CardBlocked(string CardId)
    : ITapResult;

public record CardUnreadable
    : ITapResult;

public record UnsupportedCard(string CardType)
    : ITapResult;
