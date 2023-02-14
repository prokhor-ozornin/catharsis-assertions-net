namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="DateTime"/>
public static class DateTimeExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Future(IExpectation{DateTime})"/>
  public static IExpectation<DateTime> Past(this IExpectation<DateTime> expectation) => expectation.Expected(date => date.ToUniversalTime() < DateTime.UtcNow);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Past(IExpectation{DateTime})"/>
  public static IExpectation<DateTime> Future(this IExpectation<DateTime> expectation) => expectation.Expected(date => date.ToUniversalTime() > DateTime.UtcNow);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="day"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateTime> DayOfYear(this IExpectation<DateTime> expectation, int day) => expectation.Expected(date => date.DayOfYear == day);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="year"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateTime> Year(this IExpectation<DateTime> expectation, int year) => expectation.Expected(date => date.Year == year);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="month"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateTime> Month(this IExpectation<DateTime> expectation, int month) => expectation.Expected(date => date.Month == month);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="day"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateTime> Day(this IExpectation<DateTime> expectation, int day) => expectation.Expected(date => date.Day == day);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="hour"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateTime> Hour(this IExpectation<DateTime> expectation, int hour) => expectation.Expected(date => date.Hour == hour);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="minute"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateTime> Minute(this IExpectation<DateTime> expectation, int minute) => expectation.Expected(date => date.Minute == minute);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="second"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateTime> Second(this IExpectation<DateTime> expectation, int second) => expectation.Expected(date => date.Second == second);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="millisecond"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateTime> Millisecond(this IExpectation<DateTime> expectation, int millisecond) => expectation.Expected(date => date.Millisecond == millisecond);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="day"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateTime> DayOfWeek(this IExpectation<DateTime> expectation, DayOfWeek day) => expectation.Expected(date => date.DayOfWeek == day);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="UtcTime(IExpectation{DateTime})"/>
  public static IExpectation<DateTime> LocalTime(this IExpectation<DateTime> expectation) => expectation.Expected(date => date.Kind == DateTimeKind.Local);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="LocalTime(IExpectation{DateTime})"/>
  public static IExpectation<DateTime> UtcTime(this IExpectation<DateTime> expectation) => expectation.Expected(date => date.Kind == DateTimeKind.Utc);
}