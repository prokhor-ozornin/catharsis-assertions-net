namespace Catharsis.Assertions;

internal sealed class Assertion : IAssertion
{
  private readonly bool state;

  public Assertion(bool state) => this.state = state;

  public bool Valid(bool result) => result == state;

  public bool Invalid(bool result) => result != state;
}