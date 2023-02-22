namespace Catharsis.Assertions;

#if NET7_0_OR_GREATER
/// <summary>
///   <para>Set of expectations for <see cref="DateOnly"/> type.</para>
/// </summary>
/// <seealso cref="DateOnly"/>
public static class DateOnlyExpectations
{
  /// <summary>
  ///   <para>Expects that a given date represents a specified day of the year.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="day">Expected day of the year value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateOnly> DayOfYear(this IExpectation<DateOnly> expectation, int day) => expectation.Expected(date => date.DayOfYear == day);

  /// <summary>
  ///   <para>Expects that a given date has a specified year component.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="year">Expected year component value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateOnly> Year(this IExpectation<DateOnly> expectation, int year) => expectation.Expected(date => date.Year == year);

  /// <summary>
  ///   <para>Expects that a given date has a specified month component.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="month">Expected month component value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateOnly> Month(this IExpectation<DateOnly> expectation, int month) => expectation.Expected(date => date.Month == month);

  /// <summary>
  ///   <para>Expects that a given date has a specified day component.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="day">Expected day component value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateOnly> Day(this IExpectation<DateOnly> expectation, int day) => expectation.Expected(date => date.Day == day);
}
#endif