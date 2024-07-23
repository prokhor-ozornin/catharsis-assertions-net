using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="Regex"/> type.</para>
/// </summary>
/// <seealso cref="Regex"/>
public static class RegexAssertions
{
  /// <summary>
  ///   <para>Asserts that a specified text string matches a given <see cref="Regex"/>.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="regex">Regular expression to match against.</param>
  /// <param name="text">Asserted matched text.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="regex"/>, or <paramref name="text"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Match(this IAssertion assertion, Regex regex, string text, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (regex is null) throw new ArgumentNullException(nameof(regex));
    if (text is null) throw new ArgumentNullException(nameof(text));

    return assertion.True(regex.IsMatch(text), error);
  }
}