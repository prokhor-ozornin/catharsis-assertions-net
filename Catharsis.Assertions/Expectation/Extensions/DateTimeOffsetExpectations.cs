namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="DateTimeOffset"/>
public static class DateTimeOffsetExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Future(IExpectation{DateTimeOffset})"/>
  public static IExpectation<DateTimeOffset> Past(this IExpectation<DateTimeOffset> expectation) => expectation.Expected(date => date < DateTime.UtcNow);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Past(IExpectation{DateTimeOffset})"/>
  public static IExpectation<DateTimeOffset> Future(this IExpectation<DateTimeOffset> expectation) => expectation.Expected(date => date > DateTime.UtcNow);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="day"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateTimeOffset> DayOfYear(this IExpectation<DateTimeOffset> expectation, int day) => expectation.Expected(date => date.DayOfYear == day);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="year"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateTimeOffset> Year(this IExpectation<DateTimeOffset> expectation, int year) => expectation.Expected(date => date.Year == year);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="month"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateTimeOffset> Month(this IExpectation<DateTimeOffset> expectation, int month) => expectation.Expected(date => date.Month == month);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="day"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateTimeOffset> Day(this IExpectation<DateTimeOffset> expectation, int day) => expectation.Expected(date => date.Day == day);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="hour"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateTimeOffset> Hour(this IExpectation<DateTimeOffset> expectation, int hour) => expectation.Expected(date => date.Hour == hour);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="minute"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateTimeOffset> Minute(this IExpectation<DateTimeOffset> expectation, int minute) => expectation.Expected(date => date.Minute == minute);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="second"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateTimeOffset> Second(this IExpectation<DateTimeOffset> expectation, int second) => expectation.Expected(date => date.Second == second);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="millisecond"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateTimeOffset> Millisecond(this IExpectation<DateTimeOffset> expectation, int millisecond) => expectation.Expected(date => date.Millisecond == millisecond);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="day"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateTimeOffset> DayOfWeek(this IExpectation<DateTimeOffset> expectation, DayOfWeek day) => expectation.Expected(date => date.DayOfWeek == day);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="offset"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateTimeOffset> Offset(this IExpectation<DateTimeOffset> expectation, TimeSpan offset) => expectation.Expected(date => date.Offset == offset);
}