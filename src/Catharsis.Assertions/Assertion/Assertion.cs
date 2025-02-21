namespace Catharsis.Assertions;

internal sealed class Assertion : IAssertion
{
  private readonly bool _state;

  public Assertion(bool state) => _state = state;

  public bool Valid(bool result) => result == _state;

  public bool Invalid(bool result) => result != _state;
}