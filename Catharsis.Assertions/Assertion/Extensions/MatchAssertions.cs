using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="Match"/> type.</para>
/// </summary>
/// <seealso cref="Match"/>
public static class MatchAssertions
{
  /// <summary>
  ///   <para>Asserts that a given regular expression match is successful.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="match">Text match to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="match"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Successful(this IAssertion assertion, Match match, string error = null) => match is not null ? assertion.True(match.Success, error) : throw new ArgumentNullException(nameof(match));

  /// <summary>
  ///   <para>Asserts that a result of a given regular expression match is equal to a specified value.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="match">Text match to inspect.</param>
  /// <param name="value">Captured substring of the match.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="match"/>, or <paramref name="value"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Value(this IAssertion assertion, Match match, string value, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (match is null) throw new ArgumentNullException(nameof(match));
    if (value is null) throw new ArgumentNullException(nameof(value));

    return assertion.Equal(match.Value, value, error);
  }
}