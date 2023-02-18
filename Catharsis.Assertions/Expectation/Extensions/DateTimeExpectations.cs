namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="DateTime"/> type.</para>
/// </summary>
/// <seealso cref="DateTime"/>
public static class DateTimeExpectations
{
  /// <summary>
  ///   <para>Expect that a given date lies in the past (lesser than the current).</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="Future(IExpectation{DateTime})"/>
  public static IExpectation<DateTime> Past(this IExpectation<DateTime> expectation) => expectation.Expected(date => date.ToUniversalTime() < DateTime.UtcNow);

  /// <summary>
  ///   <para>Expects that a given date lies in the future (greater than the current).</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="Past(IExpectation{DateTime})"/>
  public static IExpectation<DateTime> Future(this IExpectation<DateTime> expectation) => expectation.Expected(date => date.ToUniversalTime() > DateTime.UtcNow);

  /// <summary>
  ///   <para>Expects that a given date represents a specified day of the year.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="day">Day of the year value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateTime> DayOfYear(this IExpectation<DateTime> expectation, int day) => expectation.Expected(date => date.DayOfYear == day);

  /// <summary>
  ///   <para>Expects that a given date has a specified year component.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="year">Year component value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateTime> Year(this IExpectation<DateTime> expectation, int year) => expectation.Expected(date => date.Year == year);

  /// <summary>
  ///   <para>Expects that a given date has a specified month component.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="month">Month component value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateTime> Month(this IExpectation<DateTime> expectation, int month) => expectation.Expected(date => date.Month == month);

  /// <summary>
  ///   <para>Expects that a given date has a specified day component.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="day">Day component value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateTime> Day(this IExpectation<DateTime> expectation, int day) => expectation.Expected(date => date.Day == day);

  /// <summary>
  ///   <para>Expects that a given date has a specified hour component.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="hour">Hour component value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateTime> Hour(this IExpectation<DateTime> expectation, int hour) => expectation.Expected(date => date.Hour == hour);

  /// <summary>
  ///   <para>Expects that a given date has specified minute component.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="minute">Minute component value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateTime> Minute(this IExpectation<DateTime> expectation, int minute) => expectation.Expected(date => date.Minute == minute);

  /// <summary>
  ///   <para>Expects that a given date has a specified second component.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="second">Second component value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateTime> Second(this IExpectation<DateTime> expectation, int second) => expectation.Expected(date => date.Second == second);

  /// <summary>
  ///   <para>Expects that a given date has a specified millisecond component.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="millisecond">Millisecond component value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateTime> Millisecond(this IExpectation<DateTime> expectation, int millisecond) => expectation.Expected(date => date.Millisecond == millisecond);

  /// <summary>
  ///   <para>Expects that a given date represents a specified day of the week.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="day">Day of the week value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<DateTime> DayOfWeek(this IExpectation<DateTime> expectation, DayOfWeek day) => expectation.Expected(date => date.DayOfWeek == day);

  /// <summary>
  ///   <para>Expects that a given date represents a date/time in the local timezone.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="UtcTime(IExpectation{DateTime})"/>
  public static IExpectation<DateTime> LocalTime(this IExpectation<DateTime> expectation) => expectation.Expected(date => date.Kind == DateTimeKind.Local);

  /// <summary>
  ///   <para>Expects that a given date represents a date/time in the UTC/GMT timezone.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="LocalTime(IExpectation{DateTime})"/>
  public static IExpectation<DateTime> UtcTime(this IExpectation<DateTime> expectation) => expectation.Expected(date => date.Kind == DateTimeKind.Utc);
}