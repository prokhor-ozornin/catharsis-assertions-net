namespace Catharsis.Assertions;

#if NET10_0_OR_GREATER
/// <summary>
///   <para>A set of expectations for the <see cref="DateOnly"/> type.</para>
/// </summary>
/// <seealso cref="DateOnly"/>
public static class DateOnlyExpectations
{
  /// <param name="expectation">Expectation to be fulfilled.</param>
  extension(IExpectation<DateOnly> expectation)
  {
    /// <summary>
    ///   <para>Expects that the given <see cref="DateOnly"/> corresponds to a specific day of the year.</para>
    /// </summary>
    /// <param name="day">Expected day of the year.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    public IExpectation<DateOnly> DayOfYear(int day) => expectation.Expected(date => date.DayOfYear == day);

    /// <summary>
    ///   <para>Expects that the given <see cref="DateOnly"/> has a specified year.</para>
    /// </summary>
    /// <param name="year">Expected year.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    public IExpectation<DateOnly> Year(int year) => expectation.Expected(date => date.Year == year);

    /// <summary>
    ///   <para>Expects that the given <see cref="DateOnly"/> has a specified month.</para>
    /// </summary>
    /// <param name="month">Expected month.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    public IExpectation<DateOnly> Month(int month) => expectation.Expected(date => date.Month == month);

    /// <summary>
    ///   <para>Expects that the given <see cref="DateOnly"/> has a specified day.</para>
    /// </summary>
    /// <param name="day">Expected day.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    public IExpectation<DateOnly> Day(int day) => expectation.Expected(date => date.Day == day);
  }
}
#endif