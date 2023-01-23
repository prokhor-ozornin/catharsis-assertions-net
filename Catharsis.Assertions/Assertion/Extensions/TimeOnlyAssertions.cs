namespace Catharsis.Assertions;

#if NET7_0
/// <summary>
///   <para></para>
/// </summary>
public static class TimeOnlyAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="time"></param>
  /// <param name="hour"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Hour(this IAssertion assertion, TimeOnly time, int hour, string message = null) => assertion.True(time.Hour == hour, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="time"></param>
  /// <param name="minute"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Minute(this IAssertion assertion, TimeOnly time, int minute, string message = null) => assertion.True(time.Minute == minute, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="time"></param>
  /// <param name="second"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Second(this IAssertion assertion, TimeOnly time, int second, string message = null) => assertion.True(time.Second == second, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="time"></param>
  /// <param name="millisecond"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Millisecond(this IAssertion assertion, TimeOnly time, int millisecond, string message = null) => assertion.True(time.Millisecond == millisecond, message);
}
#endif