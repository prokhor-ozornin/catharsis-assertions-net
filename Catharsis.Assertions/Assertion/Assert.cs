namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class Assert
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  public static IAssertion To { get; } = new Assertion(true);

  /// <summary>
  ///   <para></para>
  /// </summary>
  public static IAssertion NotTo { get; } = new Assertion(false);
}