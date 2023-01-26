namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class DateTimeOffsetAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="date"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="Future(IAssertion, DateTimeOffset, string)"/>
  public static IAssertion Past(this IAssertion assertion, DateTimeOffset date, string message = null) => assertion.True(date < DateTime.UtcNow, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="date"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="Past(IAssertion, DateTimeOffset, string)"/>
  public static IAssertion Future(this IAssertion assertion, DateTimeOffset date, string message = null) => assertion.True(date > DateTime.UtcNow, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="date"></param>
  /// <param name="day"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion DayOfYear(this IAssertion assertion, DateTimeOffset date, int day, string message = null) => assertion.True(date.DayOfYear == day, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="date"></param>
  /// <param name="year"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Year(this IAssertion assertion, DateTimeOffset date, int year, string message = null) => assertion.True(date.Year == year, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="date"></param>
  /// <param name="month"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Month(this IAssertion assertion, DateTimeOffset date, int month, string message = null) => assertion.True(date.Month == month, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="date"></param>
  /// <param name="day"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Day(this IAssertion assertion, DateTimeOffset date, int day, string message = null) => assertion.True(date.Day == day, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="date"></param>
  /// <param name="hour"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Hour(this IAssertion assertion, DateTimeOffset date, int hour, string message = null) => assertion.True(date.Hour == hour, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="date"></param>
  /// <param name="minute"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Minute(this IAssertion assertion, DateTimeOffset date, int minute, string message = null) => assertion.True(date.Minute == minute, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="date"></param>
  /// <param name="second"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Second(this IAssertion assertion, DateTimeOffset date, int second, string message = null) => assertion.True(date.Second == second, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="date"></param>
  /// <param name="millisecond"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Millisecond(this IAssertion assertion, DateTimeOffset date, int millisecond, string message = null) => assertion.True(date.Millisecond == millisecond, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="date"></param>
  /// <param name="day"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion DayOfWeek(this IAssertion assertion, DateTimeOffset date, DayOfWeek day, string message = null) => assertion.True(date.DayOfWeek == day, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="date"></param>
  /// <param name="offset"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Offset(this IAssertion assertion, DateTimeOffset date, TimeSpan offset, string message = null) => assertion.True(date.Offset == offset, message);
}