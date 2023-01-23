namespace Catharsis.Assertions;

internal sealed class Assertion : IAssertion
{
  private readonly bool flag;

  public Assertion(bool flag) => this.flag = flag;

  public bool Confirmed(bool result) => result == flag;

  public bool Unconfirmed(bool result) => result != flag;
}