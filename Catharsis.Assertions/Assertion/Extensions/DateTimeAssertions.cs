namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="DateTime"/>
public static class DateTimeAssertions
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
  /// <seealso cref="Future(IAssertion, DateTime, string)"/>
  public static IAssertion Past(this IAssertion assertion, DateTime date, string message = null) => assertion.True(date.ToUniversalTime() < DateTime.UtcNow, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="date"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="Past(IAssertion, DateTime, string)"/>
  public static IAssertion Future(this IAssertion assertion, DateTime date, string message = null) => assertion.True(date.ToUniversalTime() > DateTime.UtcNow, message);

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
  public static IAssertion DayOfYear(this IAssertion assertion, DateTime date, int day, string message = null) => assertion.True(date.DayOfYear == day, message);

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
  public static IAssertion Year(this IAssertion assertion, DateTime date, int year, string message = null) => assertion.True(date.Year == year, message);

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
  public static IAssertion Month(this IAssertion assertion, DateTime date, int month, string message = null) => assertion.True(date.Month == month, message);

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
  public static IAssertion Day(this IAssertion assertion, DateTime date, int day, string message = null) => assertion.True(date.Day == day, message);

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
  public static IAssertion Hour(this IAssertion assertion, DateTime date, int hour, string message = null) => assertion.True(date.Hour == hour, message);

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
  public static IAssertion Minute(this IAssertion assertion, DateTime date, int minute, string message = null) => assertion.True(date.Minute == minute, message);

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
  public static IAssertion Second(this IAssertion assertion, DateTime date, int second, string message = null) => assertion.True(date.Second == second, message);

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
  public static IAssertion Millisecond(this IAssertion assertion, DateTime date, int millisecond, string message = null) => assertion.True(date.Millisecond == millisecond, message);

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
  public static IAssertion DayOfWeek(this IAssertion assertion, DateTime date, DayOfWeek day, string message = null) => assertion.True(date.DayOfWeek == day, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="date"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="UtcTime(IAssertion, DateTime, string)"/>
  public static IAssertion LocalTime(this IAssertion assertion, DateTime date, string message = null) => assertion.True(date.Kind == DateTimeKind.Local, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="date"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  /// <seealso cref="LocalTime(IAssertion, DateTime, string)"/>
  public static IAssertion UtcTime(this IAssertion assertion, DateTime date, string message = null) => assertion.True(date.Kind == DateTimeKind.Utc, message);
}