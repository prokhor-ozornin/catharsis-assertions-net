namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="DateTime"/> type.</para>
/// </summary>
/// <seealso cref="DateTime"/>
public static class DateTimeExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="DateTime"/> is in the past.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  /// <seealso cref="Future(IExpectation{DateTime})"/>
  public static IExpectation<DateTime> Past(this IExpectation<DateTime> expectation) => expectation.Expected(date => date.ToUniversalTime() < DateTime.UtcNow);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTime"/> is in the future.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  /// <seealso cref="Past(IExpectation{DateTime})"/>
  public static IExpectation<DateTime> Future(this IExpectation<DateTime> expectation) => expectation.Expected(date => date.ToUniversalTime() > DateTime.UtcNow);

  /// <summary>
  ///   <para>Expects that a given <see cref="DateTime"/> represents a specified day of the year.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="day">Expected day of the year.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<DateTime> DayOfYear(this IExpectation<DateTime> expectation, int day) => expectation.Expected(date => date.DayOfYear == day);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTime"/> has a specified year.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="year">Expected year.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<DateTime> Year(this IExpectation<DateTime> expectation, int year) => expectation.Expected(date => date.Year == year);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTime"/> has a specified month.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="month">Expected month.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<DateTime> Month(this IExpectation<DateTime> expectation, int month) => expectation.Expected(date => date.Month == month);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTime"/> has a specified day.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="day">Expected day.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<DateTime> Day(this IExpectation<DateTime> expectation, int day) => expectation.Expected(date => date.Day == day);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTime"/> has a specified hour.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="hour">Expected hour.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<DateTime> Hour(this IExpectation<DateTime> expectation, int hour) => expectation.Expected(date => date.Hour == hour);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTime"/> has specified minute.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="minute">Expected minute.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<DateTime> Minute(this IExpectation<DateTime> expectation, int minute) => expectation.Expected(date => date.Minute == minute);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTime"/> has a specified second.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="second">Expected second.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<DateTime> Second(this IExpectation<DateTime> expectation, int second) => expectation.Expected(date => date.Second == second);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTime"/> has a specified millisecond.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="millisecond">Expected millisecond.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<DateTime> Millisecond(this IExpectation<DateTime> expectation, int millisecond) => expectation.Expected(date => date.Millisecond == millisecond);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTime"/> represents a specified day of the week.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="day">Expected day of the week.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<DateTime> DayOfWeek(this IExpectation<DateTime> expectation, DayOfWeek day) => expectation.Expected(date => date.DayOfWeek == day);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTime"/> represents a specified date and time in the local timezone.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  /// <seealso cref="UtcTime(IExpectation{DateTime})"/>
  public static IExpectation<DateTime> LocalTime(this IExpectation<DateTime> expectation) => expectation.Expected(date => date.Kind == DateTimeKind.Local);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTime"/> represents a date and time in the UTC/GMT timezone.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  /// <seealso cref="LocalTime(IExpectation{DateTime})"/>
  public static IExpectation<DateTime> UtcTime(this IExpectation<DateTime> expectation) => expectation.Expected(date => date.Kind == DateTimeKind.Utc);
}