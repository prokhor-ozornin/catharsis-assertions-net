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
  /// <param name="assertion"></param>
  /// <param name="text"></param>
  /// <param name="length"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Length(this IAssertion assertion, string text, int length, string message = null) => text is not null ? assertion.True(text.Length == length, message) : throw new ArgumentNullException(nameof(text));
  
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="text"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Empty(this IAssertion assertion, string text, string message = null) => assertion.Length(text, 0, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="text"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="LowerCased(IAssertion, string, string)"/>
  public static IAssertion UpperCased(this IAssertion assertion, string text, string message = null) => text is not null ? assertion.True(text.All(char.IsUpper), message) : throw new ArgumentNullException(nameof(text));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="text"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="UpperCased(IAssertion, string, string)"/>
  public static IAssertion LowerCased(this IAssertion assertion, string text, string message = null) => text is not null ? assertion.True(text.All(char.IsLower), message) : throw new ArgumentNullException(nameof(text));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="text"></param>
  /// <param name="prefix"></param>
  /// <param name="comparison"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="EndWith(IAssertion, string, string, StringComparison?, string)"/>
  public static IAssertion StartWith(this IAssertion assertion, string text, string prefix, StringComparison? comparison = null, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (text is null) throw new ArgumentNullException(nameof(text));
    if (prefix is null) throw new ArgumentNullException(nameof(prefix));

    return assertion.True(text.StartsWith(prefix, comparison.GetValueOrDefault()), message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="text"></param>
  /// <param name="postfix"></param>
  /// <param name="comparison"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="StartWith(IAssertion, string, string, StringComparison?, string)"/>
  public static IAssertion EndWith(this IAssertion assertion, string text, string postfix, StringComparison? comparison = null, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (text is null) throw new ArgumentNullException(nameof(text));
    if (postfix is null) throw new ArgumentNullException(nameof(postfix));

    return assertion.True(text.EndsWith(postfix, comparison.GetValueOrDefault()), message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="text"></param>
  /// <param name="regex"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Match(this IAssertion assertion, string text, Regex regex, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (text is null) throw new ArgumentNullException(nameof(text));
    if (regex is null) throw new ArgumentNullException(nameof(regex));

    return assertion.True(regex.IsMatch(text), message);
  }
}