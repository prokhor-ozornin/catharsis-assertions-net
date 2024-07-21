using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for <see cref="Match"/> type.</para>
/// </summary>
/// <seealso cref="Match"/>
public static class MatchExpectations
{
  /// <summary>
  ///   <para>Expects that a given regular expression <see cref="Match"/> is successful.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<Match> Successful(this IExpectation<Match> expectation) => expectation.HaveSubject().And().Expected(match => match.Success);

  /// <summary>
  ///   <para>Expects that a result of a given regular expression <see cref="Match"/> is equal to a specified value.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="value">Expected match captured substring.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="value"/> is <see langword="null"/>.</exception>
  public static IExpectation<Match> Value(this IExpectation<Match> expectation, string value) => expectation.HaveSubject().And().ThrowIfNull(value, nameof(value)).And().Expected(match => match.Value == value);
}