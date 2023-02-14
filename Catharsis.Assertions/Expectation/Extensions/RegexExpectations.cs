using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="Regex"/>
public static class RegexExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="text"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<Regex> Match(this IExpectation<Regex> expectation, string text) => expectation.HaveSubject().And().ThrowIfNull(text, nameof(text)).And().Expected(regex => regex.IsMatch(text));
}