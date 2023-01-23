namespace Catharsis.Assertions;

internal sealed class Expectation<T> : IExpectation<T>
{
  private readonly T subject;
  
  private bool flag = true;

  public bool Result { get; private set; } = true;

  public Expectation(T subject) => this.subject = subject;

  public IExpectation<T> Not()
  {
    flag = !flag;
    return this;
  }

  public IExpectation<T> Expect(Predicate<T> predicate)
  {
    Result = Result && predicate(subject) && flag;
    return this;
  }
}