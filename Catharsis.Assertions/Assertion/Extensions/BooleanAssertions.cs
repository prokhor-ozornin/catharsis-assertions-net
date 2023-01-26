namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="bool"/>
public static class BooleanAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="expected"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion True(this IAssertion assertion, bool? expected, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));

    if (assertion.Unconfirmed(expected.GetValueOrDefault()))
    {
      throw new ArgumentException(message);
    }

    return assertion;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="expected"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion False(this IAssertion assertion, bool? expected, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));

    if (assertion.Unconfirmed(!expected.GetValueOrDefault()))
    {
      throw new ArgumentException(message);
    }

    return assertion;
  }
}