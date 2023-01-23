namespace Catharsis.Assertions;

#if NET7_0
/// <summary>
///   <para></para>
/// </summary>
public static class DateOnlyAssertions
{
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
  public static IAssertion Day(this IAssertion assertion, DateOnly date, int day, string message = null) => assertion.True(date.Day == day, message);

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
  public static IAssertion Month(this IAssertion assertion, DateOnly date, int month, string message = null) => assertion.True(date.Month == month, message);

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
  public static IAssertion Year(this IAssertion assertion, DateOnly date, int year, string message = null) => assertion.True(date.Year == year, message);

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
  public static IAssertion DayOfYear(this IAssertion assertion, DateOnly date, int day, string message = null) => assertion.True(date.DayOfYear == day, message);
}
#endif