namespace Catharsis.Assertions;

internal sealed class Assertion : IAssertion
{
  private bool State { get; }

  public Assertion(bool state) => State = state;

  public bool Valid(bool result) => result == State;

  public bool Invalid(bool result) => result != State;
}