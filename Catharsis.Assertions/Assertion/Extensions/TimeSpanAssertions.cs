namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="TimeSpan"/>
public static class TimeSpanAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="timeSpan"></param>
  /// <param name="days"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Days(this IAssertion assertion, TimeSpan timeSpan, int days, string message = null) => assertion.True(timeSpan.Days == days, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="timeSpan"></param>
  /// <param name="hours"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Hours(this IAssertion assertion, TimeSpan timeSpan, int hours, string message = null) => assertion.True(timeSpan.Hours == hours, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="timeSpan"></param>
  /// <param name="minutes"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Minutes(this IAssertion assertion, TimeSpan timeSpan, int minutes, string message = null) => assertion.True(timeSpan.Minutes == minutes, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="timeSpan"></param>
  /// <param name="seconds"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Seconds(this IAssertion assertion, TimeSpan timeSpan, int seconds, string message = null) => assertion.True(timeSpan.Seconds == seconds, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="timeSpan"></param>
  /// <param name="milliseconds"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Milliseconds(this IAssertion assertion, TimeSpan timeSpan, int milliseconds, string message = null) => assertion.True(timeSpan.Milliseconds == milliseconds, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="timeSpan"></param>
  /// <param name="days"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion TotalDays(this IAssertion assertion, TimeSpan timeSpan, int days, string message = null) => assertion.True((int) timeSpan.TotalDays == days, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="timeSpan"></param>
  /// <param name="hours"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion TotalHours(this IAssertion assertion, TimeSpan timeSpan, int hours, string message = null) => assertion.True((int) timeSpan.TotalHours == hours, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="timeSpan"></param>
  /// <param name="minutes"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion TotalMinutes(this IAssertion assertion, TimeSpan timeSpan, int minutes, string message = null) => assertion.True((int) timeSpan.TotalMinutes == minutes, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="timeSpan"></param>
  /// <param name="seconds"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion TotalSeconds(this IAssertion assertion, TimeSpan timeSpan, int seconds, string message = null) => assertion.True((int) timeSpan.TotalSeconds == seconds, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="timeSpan"></param>
  /// <param name="milliseconds"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  public static IAssertion TotalMilliseconds(this IAssertion assertion, TimeSpan timeSpan, int milliseconds, string message = null) => assertion.True((int) timeSpan.TotalMilliseconds == milliseconds, message);
}