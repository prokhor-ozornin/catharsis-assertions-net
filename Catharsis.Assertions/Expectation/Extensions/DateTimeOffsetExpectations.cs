namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class DateTimeOffsetExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<DateTimeOffset> Past(this IExpectation<DateTimeOffset> expectation) => expectation.Expect(date => date < DateTime.UtcNow);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<DateTimeOffset> Future(this IExpectation<DateTimeOffset> expectation) => expectation.Expect(date => date > DateTime.UtcNow);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="day"></param>
  /// <returns></returns>
  public static IExpectation<DateTimeOffset> DayOfYear(this IExpectation<DateTimeOffset> expectation, int day) => expectation.Expect(date => date.DayOfYear == day);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="year"></param>
  /// <returns></returns>
  public static IExpectation<DateTimeOffset> Year(this IExpectation<DateTimeOffset> expectation, int year) => expectation.Expect(date => date.Year == year);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="month"></param>
  /// <returns></returns>
  public static IExpectation<DateTimeOffset> Month(this IExpectation<DateTimeOffset> expectation, int month) => expectation.Expect(date => date.Month == month);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="day"></param>
  /// <returns></returns>
  public static IExpectation<DateTimeOffset> Day(this IExpectation<DateTimeOffset> expectation, int day) => expectation.Expect(date => date.Day == day);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="hour"></param>
  /// <returns></returns>
  public static IExpectation<DateTimeOffset> Hour(this IExpectation<DateTimeOffset> expectation, int hour) => expectation.Expect(date => date.Hour == hour);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="minute"></param>
  /// <returns></returns>
  public static IExpectation<DateTimeOffset> Minute(this IExpectation<DateTimeOffset> expectation, int minute) => expectation.Expect(date => date.Minute == minute);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="second"></param>
  /// <returns></returns>
  public static IExpectation<DateTimeOffset> Second(this IExpectation<DateTimeOffset> expectation, int second) => expectation.Expect(date => date.Second == second);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="millisecond"></param>
  /// <returns></returns>
  public static IExpectation<DateTimeOffset> Millisecond(this IExpectation<DateTimeOffset> expectation, int millisecond) => expectation.Expect(date => date.Millisecond == millisecond);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="day"></param>
  /// <returns></returns>
  public static IExpectation<DateTimeOffset> DayOfWeek(this IExpectation<DateTimeOffset> expectation, DayOfWeek day) => expectation.Expect(date => date.DayOfWeek == day);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="offset"></param>
  /// <returns></returns>
  public static IExpectation<DateTimeOffset> Offset(this IExpectation<DateTimeOffset> expectation, TimeSpan offset) => expectation.Expect(date => date.Offset == offset);
}