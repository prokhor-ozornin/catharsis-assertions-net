namespace Catharsis.Assertions;

internal sealed class Expectation<T> : IExpectation<T>
{
  private readonly T subject;
  
  private bool state = true;

  public bool Result { get; private set; } = true;

  public Expectation(T subject) => this.subject = subject;

  public IExpectation<T> Not()
  {
    state = !state;
    return this;
  }

  public IExpectation<T> Expect(Predicate<T> result)
  {
    if (result is null) throw new ArgumentNullException(nameof(result));

    var condition = result(subject);

    Result = Result && (state ? condition : !condition);
    
    return this;
  }
}