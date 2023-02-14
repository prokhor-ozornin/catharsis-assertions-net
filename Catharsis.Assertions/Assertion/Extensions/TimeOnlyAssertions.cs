namespace Catharsis.Assertions;

#if NET7_0_OR_GREATER
/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="TimeOnly"/>
public static class TimeOnlyAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="time"></param>
  /// <param name="hour"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Hour(this IAssertion assertion, TimeOnly time, int hour, string error = null) => assertion.True(time.Hour == hour, error);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="time"></param>
  /// <param name="minute"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Minute(this IAssertion assertion, TimeOnly time, int minute, string error = null) => assertion.True(time.Minute == minute, error);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="time"></param>
  /// <param name="second"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Second(this IAssertion assertion, TimeOnly time, int second, string error = null) => assertion.True(time.Second == second, error);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="time"></param>
  /// <param name="millisecond"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Millisecond(this IAssertion assertion, TimeOnly time, int millisecond, string error = null) => assertion.True(time.Millisecond == millisecond, error);
}
#endif