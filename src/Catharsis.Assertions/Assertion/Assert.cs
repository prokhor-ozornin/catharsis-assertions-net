namespace Catharsis.Assertions;

/// <summary>
///   <para>Assertion factory class for the creation of assertions.</para>
/// </summary>
public static class Assert
{
  /// <summary>
  ///   <para>Create a positive assertion that evaluates to be valid when its result is proven to be <see langword="true"/>.</para>
  /// </summary>
  public static IAssertion To { get; } = new Assertion(true);

  /// <summary>
  ///   <para>Create a negative assertion that evaluates to be valid when its result is proven to be <see langword="false"/>.</para>
  /// </summary>
  public static IAssertion NotTo { get; } = new Assertion(false);
}