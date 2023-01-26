using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class RegexExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="text"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<Regex> Matches(this IExpectation<Regex> expectation, string text) => expectation.HaveSubject().And().ThrowIfNull(text, nameof(text)).And().Expected(regex => regex.IsMatch(text));
}