using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="Regex"/>
public static class RegexAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="regex"></param>
  /// <param name="text"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Match(this IAssertion assertion, Regex regex, string text, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (regex is null) throw new ArgumentNullException(nameof(regex));
    if (text is null) throw new ArgumentNullException(nameof(text));

    return assertion.True(regex.IsMatch(text), message);
  }
}