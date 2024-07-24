using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="string"/> type.</para>
/// </summary>
/// <seealso cref="string"/>
public static class StringAssertions
{
  /// <summary>
  ///   <para>Asserts that the given <see cref="string"/> has the specified length.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="text">String to inspect.</param>
  /// <param name="length">Asserted string length.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="text"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Length(this IAssertion assertion, string text, int length, string error = null) => text is not null ? assertion.True(text.Length == length, error) : throw new ArgumentNullException(nameof(text));

  /// <summary>
  ///   <para>Asserts that the given <see cref="string"/> is empty, meaning it contains no characters.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="text">String to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="text"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Empty(this IAssertion assertion, string text, string error = null) => assertion.Length(text, 0, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="string"/> is either <see langword="null"/>, empty, or consists only of white-space characters.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="text">String to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="text"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion WhiteSpace(this IAssertion assertion, string text, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (text is null) throw new ArgumentNullException(nameof(text));

    return assertion.True(string.IsNullOrWhiteSpace(text), error);
  }

  /// <summary>
  ///   <para>Asserts that the given <see cref="string"/> consists only of upper-cased characters.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="text">String to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="text"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="LowerCased(IAssertion, string, string)"/>
  public static IAssertion UpperCased(this IAssertion assertion, string text, string error = null) => text is not null ? assertion.True(text.All(char.IsUpper), error) : throw new ArgumentNullException(nameof(text));

  /// <summary>
  ///   <para>Asserts that the given <see cref="string"/> consists only of lower-cased characters.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="text">String to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="text"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="UpperCased(IAssertion, string, string)"/>
  public static IAssertion LowerCased(this IAssertion assertion, string text, string error = null) => text is not null ? assertion.True(text.All(char.IsLower), error) : throw new ArgumentNullException(nameof(text));

  /// <summary>
  ///   <para>Asserts that the given <see cref="string"/> begins with a specified prefix substring.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="text">String to inspect.</param>
  /// <param name="prefix">Asserted string prefix.</param>
  /// <param name="comparison">Strings comparison rules.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="text"/>, or <paramref name="prefix"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="EndWith(IAssertion, string, string, StringComparison?, string)"/>
  public static IAssertion StartWith(this IAssertion assertion, string text, string prefix, StringComparison? comparison = null, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (text is null) throw new ArgumentNullException(nameof(text));
    if (prefix is null) throw new ArgumentNullException(nameof(prefix));

    return assertion.True(text.StartsWith(prefix, comparison.GetValueOrDefault()), error);
  }

  /// <summary>
  ///   <para>Asserts that the given <see cref="string"/> ends with a specified postfix substring.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="text">String to inspect.</param>
  /// <param name="postfix">Asserted string postfix.</param>
  /// <param name="comparison">Strings comparison rules.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="text"/>, or <paramref name="postfix"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="StartWith(IAssertion, string, string, StringComparison?, string)"/>
  public static IAssertion EndWith(this IAssertion assertion, string text, string postfix, StringComparison? comparison = null, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (text is null) throw new ArgumentNullException(nameof(text));
    if (postfix is null) throw new ArgumentNullException(nameof(postfix));

    return assertion.True(text.EndsWith(postfix, comparison.GetValueOrDefault()), error);
  }

  /// <summary>
  ///   <para>Asserts that the given <see cref="string"/> matches the specified regular expression.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="text">String to inspect.</param>
  /// <param name="regex">Regular expression to match.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="text"/>, or <paramref name="regex"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Match(this IAssertion assertion, string text, Regex regex, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (text is null) throw new ArgumentNullException(nameof(text));
    if (regex is null) throw new ArgumentNullException(nameof(regex));

    return assertion.True(regex.IsMatch(text), error);
  }
}