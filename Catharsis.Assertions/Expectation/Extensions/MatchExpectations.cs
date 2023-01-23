using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class MatchExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Match> Successful(this IExpectation<Match> expectation) => expectation.HaveSubject().And().Expect(match => match.Success);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="value"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<Match> Value(this IExpectation<Match> expectation, string value) => expectation.HaveSubject().And().ThrowIfNull(value, nameof(value)).And().Expect(match => match.Value == value);
}