namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class DateTimeExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<DateTime> Past(this IExpectation<DateTime> expectation) => expectation.Expect(date => date.ToUniversalTime() < DateTime.UtcNow);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<DateTime> Future(this IExpectation<DateTime> expectation) => expectation.Expect(date => date.ToUniversalTime() > DateTime.UtcNow);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="day"></param>
  /// <returns></returns>
  public static IExpectation<DateTime> DayOfYear(this IExpectation<DateTime> expectation, int day) => expectation.Expect(date => date.DayOfYear == day);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="year"></param>
  /// <returns></returns>
  public static IExpectation<DateTime> Year(this IExpectation<DateTime> expectation, int year) => expectation.Expect(date => date.Year == year);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="month"></param>
  /// <returns></returns>
  public static IExpectation<DateTime> Month(this IExpectation<DateTime> expectation, int month) => expectation.Expect(date => date.Month == month);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="day"></param>
  /// <returns></returns>
  public static IExpectation<DateTime> Day(this IExpectation<DateTime> expectation, int day) => expectation.Expect(date => date.Day == day);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="hour"></param>
  /// <returns></returns>
  public static IExpectation<DateTime> Hour(this IExpectation<DateTime> expectation, int hour) => expectation.Expect(date => date.Hour == hour);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="minute"></param>
  /// <returns></returns>
  public static IExpectation<DateTime> Minute(this IExpectation<DateTime> expectation, int minute) => expectation.Expect(date => date.Minute == minute);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="second"></param>
  /// <returns></returns>
  public static IExpectation<DateTime> Second(this IExpectation<DateTime> expectation, int second) => expectation.Expect(date => date.Second == second);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="millisecond"></param>
  /// <returns></returns>
  public static IExpectation<DateTime> Millisecond(this IExpectation<DateTime> expectation, int millisecond) => expectation.Expect(date => date.Millisecond == millisecond);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="day"></param>
  /// <returns></returns>
  public static IExpectation<DateTime> DayOfWeek(this IExpectation<DateTime> expectation, DayOfWeek day) => expectation.Expect(date => date.DayOfWeek == day);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<DateTime> LocalTime(this IExpectation<DateTime> expectation) => expectation.Expect(date => date.Kind == DateTimeKind.Local);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<DateTime> UtcTime(this IExpectation<DateTime> expectation) => expectation.Expect(date => date.Kind == DateTimeKind.Utc);
}