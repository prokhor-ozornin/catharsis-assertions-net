namespace Catharsis.Assertions;

internal sealed class Expectation<T> : IExpectation<T>
{
  private readonly T _subject;  
  private bool _state = true;

  public bool Result { get; private set; } = true;

  public Expectation(T subject) => _subject = subject;

  public IExpectation<T> Not()
  {
    _state = !_state;
    return this;
  }

  public IExpectation<T> Expect(Predicate<T> result)
  {
    if (result is null) throw new ArgumentNullException(nameof(result));

    var condition = result(_subject);

    Result = Result && (_state ? condition : !condition);
    
    return this;
  }
}