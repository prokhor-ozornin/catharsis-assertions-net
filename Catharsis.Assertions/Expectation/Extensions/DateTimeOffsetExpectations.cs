namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="DateTimeOffset"/> type.</para>
/// </summary>
/// <seealso cref="DateTimeOffset"/>
public static class DateTimeOffsetExpectations
{
  /// <summary>
  ///   <para>Expects that a given date lies in the past (lesser than the current).</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="Future(IExpectation{DateTimeOffset})"/>
  public static IExpectation<DateTimeOffset> Past(this IExpectation<DateTimeOffset> expectation) => expectation.Expected(date => date < DateTime.UtcNow);

  /// <summary>
  ///   <para>Expects that a given date lies in the future (greater than the current).</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="Past(IExpectation{DateTimeOffset})"/>
  public static IExpectation<DateTimeOffset> Future(this IExpectation<DateTimeOffset> expectation) => expectation.Expected(date => date > DateTime.UtcNow);

  /// <summary>
  ///   <para>Expects that a given date represents a specified day of the year.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="day">Expected day of the year.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateTimeOffset> DayOfYear(this IExpectation<DateTimeOffset> expectation, int day) => expectation.Expected(date => date.DayOfYear == day);

  /// <summary>
  ///   <para>Expects that a given date has a specified year component.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="year">Expected year component value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateTimeOffset> Year(this IExpectation<DateTimeOffset> expectation, int year) => expectation.Expected(date => date.Year == year);

  /// <summary>
  ///   <para>Expects that a given date has a specified month component.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="month">Expected month component value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateTimeOffset> Month(this IExpectation<DateTimeOffset> expectation, int month) => expectation.Expected(date => date.Month == month);

  /// <summary>
  ///   <para>Expects that a given date has a specified day component.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="day">Expected day component value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateTimeOffset> Day(this IExpectation<DateTimeOffset> expectation, int day) => expectation.Expected(date => date.Day == day);

  /// <summary>
  ///   <para>Expects that a given date has a specified hour component.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="hour">Expected hour component value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateTimeOffset> Hour(this IExpectation<DateTimeOffset> expectation, int hour) => expectation.Expected(date => date.Hour == hour);

  /// <summary>
  ///   <para>Expects that a given date has specified minute component.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="minute">Expected minute component value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateTimeOffset> Minute(this IExpectation<DateTimeOffset> expectation, int minute) => expectation.Expected(date => date.Minute == minute);

  /// <summary>
  ///   <para>Expects that a given date has a specified second component.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="second">Expected second component value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateTimeOffset> Second(this IExpectation<DateTimeOffset> expectation, int second) => expectation.Expected(date => date.Second == second);

  /// <summary>
  ///   <para>Expects that a given date has a specified millisecond component.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="millisecond">Expected millisecond component value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateTimeOffset> Millisecond(this IExpectation<DateTimeOffset> expectation, int millisecond) => expectation.Expected(date => date.Millisecond == millisecond);

  /// <summary>
  ///   <para>Expects that a given date represents a specified day of the week.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="day">Expected day of the week.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateTimeOffset> DayOfWeek(this IExpectation<DateTimeOffset> expectation, DayOfWeek day) => expectation.Expected(date => date.DayOfWeek == day);

  /// <summary>
  ///   <para>Expects that a given date has a specified offset from UTC/GMT timezone.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="offset">Expected timezone offset.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateTimeOffset> Offset(this IExpectation<DateTimeOffset> expectation, TimeSpan offset) => expectation.Expected(date => date.Offset == offset);
}