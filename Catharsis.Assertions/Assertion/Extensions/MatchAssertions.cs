using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="Match"/>
public static class MatchAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="match"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Successful(this IAssertion assertion, Match match, string error = null) => match is not null ? assertion.True(match.Success, error) : throw new ArgumentNullException(nameof(match));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="match"></param>
  /// <param name="value"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Value(this IAssertion assertion, Match match, string value, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (match is null) throw new ArgumentNullException(nameof(match));
    if (value is null) throw new ArgumentNullException(nameof(value));

    return assertion.Equal(match.Value, value, error);
  }
}