using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="Match"/>
public static class MatchExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<Match> Successful(this IExpectation<Match> expectation) => expectation.HaveSubject().And().Expected(match => match.Success);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="value"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<Match> Value(this IExpectation<Match> expectation, string value) => expectation.HaveSubject().And().ThrowIfNull(value, nameof(value)).And().Expected(match => match.Value == value);
}