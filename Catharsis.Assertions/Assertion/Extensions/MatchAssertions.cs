using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class MatchAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="match"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Successful(this IAssertion assertion, Match match, string message = null) => match is not null ? assertion.True(match.Success, message) : throw new ArgumentNullException(nameof(match));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="match"></param>
  /// <param name="value"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Value(this IAssertion assertion, Match match, string value, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (match is null) throw new ArgumentNullException(nameof(match));
    if (value is null) throw new ArgumentNullException(nameof(value));

    return assertion.Equal(match.Value, value, message);
  }
}