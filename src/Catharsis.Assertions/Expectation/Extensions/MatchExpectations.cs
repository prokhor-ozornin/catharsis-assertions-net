using System.Text.RegularExpressions;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="Match"/> type.</para>
/// </summary>
/// <seealso cref="Match"/>
public static class MatchExpectations
{
  /// <param name="expectation">Expectation to be fulfilled.</param>
  extension(IExpectation<Match> expectation)
  {
    /// <summary>
    ///   <para>Expects that the given <see cref="Match"/> matches successfully.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<Match> Successful() => expectation.HaveSubject().And().Expected(match => match.Success);

    /// <summary>
    ///   <para>Expects that the result of a <see cref="Match"/> equals a specified value.</para>
    /// </summary>
    /// <param name="value">Expected captured substring.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="value"/> is <see langword="null"/>.</exception>
    public IExpectation<Match> Value(string value) => expectation.HaveSubject().And().ThrowIfNull(value, nameof(value)).And().Expected(match => match.Value == value);
  }
}