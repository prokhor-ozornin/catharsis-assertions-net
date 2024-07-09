using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for <see cref="Regex"/> type.</para>
/// </summary>
/// <seealso cref="Regex"/>
public static class RegexExpectations
{
  /// <summary>
  ///   <para>Expects that a specified text string matches a given regular expression.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="text">Expected matched text.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="text"/> is <see langword="null"/>.</exception>
  public static IExpectation<Regex> Match(this IExpectation<Regex> expectation, string text) => expectation.HaveSubject().And().ThrowIfNull(text, nameof(text)).And().Expected(regex => regex.IsMatch(text));
}