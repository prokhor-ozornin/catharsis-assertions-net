using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="string"/>
public static class StringAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="text"></param>
  /// <param name="length"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Length(this IAssertion assertion, string text, int length, string error = null) => text is not null ? assertion.True(text.Length == length, error) : throw new ArgumentNullException(nameof(text));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="text"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Empty(this IAssertion assertion, string text, string error = null) => assertion.Length(text, 0, error);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="text"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion WhiteSpace(this IAssertion assertion, string text, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (text is null) throw new ArgumentNullException(nameof(text));

    return assertion.True(string.IsNullOrWhiteSpace(text), error);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="text"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="LowerCased(IAssertion, string, string)"/>
  public static IAssertion UpperCased(this IAssertion assertion, string text, string error = null) => text is not null ? assertion.True(text.All(char.IsUpper), error) : throw new ArgumentNullException(nameof(text));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="text"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="UpperCased(IAssertion, string, string)"/>
  public static IAssertion LowerCased(this IAssertion assertion, string text, string error = null) => text is not null ? assertion.True(text.All(char.IsLower), error) : throw new ArgumentNullException(nameof(text));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="text"></param>
  /// <param name="prefix"></param>
  /// <param name="comparison"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
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
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="text"></param>
  /// <param name="postfix"></param>
  /// <param name="comparison"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
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
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="text"></param>
  /// <param name="regex"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Match(this IAssertion assertion, string text, Regex regex, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (text is null) throw new ArgumentNullException(nameof(text));
    if (regex is null) throw new ArgumentNullException(nameof(regex));

    return assertion.True(regex.IsMatch(text), error);
  }
}