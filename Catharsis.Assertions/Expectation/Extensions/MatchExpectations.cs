using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="Match"/> type.</para>
/// </summary>
/// <seealso cref="Match"/>
public static class MatchExpectations
{
  /// <summary>
  ///   <para>Expects that a given regular expression match is successful.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Match> Successful(this IExpectation<Match> expectation) => expectation.HaveSubject().And().Expected(match => match.Success);

  /// <summary>
  ///   <para>Expects that a result of a given regular expression match is equal to a specified value.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="value">Captured substring of the match.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="value"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<Match> Value(this IExpectation<Match> expectation, string value) => expectation.HaveSubject().And().ThrowIfNull(value, nameof(value)).And().Expected(match => match.Value == value);
}