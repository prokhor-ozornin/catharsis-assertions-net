namespace Catharsis.Assertions;

internal sealed class Expectation<T> : IExpectation<T>
{
  private T Subject { get; }
  private bool State { get; set; } = true;

  public bool Result { get; private set; } = true;

  public Expectation(T subject) => Subject = subject;

  public IExpectation<T> Not()
  {
    State = !State;
    return this;
  }

  public IExpectation<T> Expect(Predicate<T> result)
  {
    if (result is null) throw new ArgumentNullException(nameof(result));

    var condition = result(Subject);

    Result = Result && (State ? condition : !condition);
    
    return this;
  }
}