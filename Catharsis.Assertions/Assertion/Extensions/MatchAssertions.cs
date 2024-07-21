using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="Match"/> type.</para>
/// </summary>
/// <seealso cref="Match"/>
public static class MatchAssertions
{
  /// <summary>
  ///   <para>This function asserts that the given <see cref="Match"/> matches successfully.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="match">Match to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="match"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Successful(this IAssertion assertion, Match match, string error = null) => match is not null ? assertion.True(match.Success, error) : throw new ArgumentNullException(nameof(match));

  /// <summary>
  ///   <para>This function asserts that the result of a <see cref="Match"/> is equal to a specified value.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="match">Match to inspect.</param>
  /// <param name="value">Asserted captured substring.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="match"/>, or <paramref name="value"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Value(this IAssertion assertion, Match match, string value, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (match is null) throw new ArgumentNullException(nameof(match));
    if (value is null) throw new ArgumentNullException(nameof(value));

    return assertion.Equal(match.Value, value, error);
  }
}