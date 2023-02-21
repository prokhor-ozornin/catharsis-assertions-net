﻿using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="Regex"/> type.</para>
/// </summary>
/// <seealso cref="Regex"/>
public static class RegexAssertions
{
  /// <summary>
  ///   <para>Asserts that a specified text string matches a given regular expression.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="regex">Regular expression to match against.</param>
  /// <param name="text">Text to match.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="regex"/>, or <paramref name="text"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Match(this IAssertion assertion, Regex regex, string text, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (regex is null) throw new ArgumentNullException(nameof(regex));
    if (text is null) throw new ArgumentNullException(nameof(text));

    return assertion.True(regex.IsMatch(text), error);
  }
}