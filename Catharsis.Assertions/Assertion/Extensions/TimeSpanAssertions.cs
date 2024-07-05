namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="TimeSpan"/> type.</para>
/// </summary>
/// <seealso cref="TimeSpan"/>
public static class TimeSpanAssertions
{
  /// <summary>
  ///   <para>This function asserts that the given time interval has a specified days component.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="timeSpan">Time interval to inspect.</param>
  /// <param name="days">Asserted days component value.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Days(this IAssertion assertion, TimeSpan timeSpan, int days, string error = null) => assertion.True(timeSpan.Days == days, error);

  /// <summary>
  ///   <para>This function asserts that the given time interval has a specified hours component.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="timeSpan">Time interval to inspect.</param>
  /// <param name="hours">Asserted hours component value.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Hours(this IAssertion assertion, TimeSpan timeSpan, int hours, string error = null) => assertion.True(timeSpan.Hours == hours, error);

  /// <summary>
  ///   <para>This function asserts that the given time interval has a specified minutes component.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="timeSpan">Time interval to inspect.</param>
  /// <param name="minutes">Asserted minutes component value.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Minutes(this IAssertion assertion, TimeSpan timeSpan, int minutes, string error = null) => assertion.True(timeSpan.Minutes == minutes, error);

  /// <summary>
  ///   <para>This function asserts that the given time interval has a specified seconds component.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="timeSpan">Time interval to inspect.</param>
  /// <param name="seconds">Asserted seconds component value.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Seconds(this IAssertion assertion, TimeSpan timeSpan, int seconds, string error = null) => assertion.True(timeSpan.Seconds == seconds, error);

  /// <summary>
  ///   <para>This function asserts that the given time interval has a specified milliseconds component.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="timeSpan">Time interval to inspect.</param>
  /// <param name="milliseconds">Asserted milliseconds component value.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Milliseconds(this IAssertion assertion, TimeSpan timeSpan, int milliseconds, string error = null) => assertion.True(timeSpan.Milliseconds == milliseconds, error);

  /// <summary>
  ///   <para>This function asserts that the given time interval represents a specified total number of whole days.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="timeSpan">Time interval to inspect.</param>
  /// <param name="days">Asserted days count.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion TotalDays(this IAssertion assertion, TimeSpan timeSpan, int days, string error = null) => assertion.True((int) timeSpan.TotalDays == days, error);

  /// <summary>
  ///   <para>This function asserts that the given time interval represents a specified total number of whole hours.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="timeSpan">Time interval to inspect.</param>
  /// <param name="hours">Asserted hours count.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion TotalHours(this IAssertion assertion, TimeSpan timeSpan, int hours, string error = null) => assertion.True((int) timeSpan.TotalHours == hours, error);

  /// <summary>
  ///   <para>This function asserts that the given time interval represents a specified total number of whole minutes.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="timeSpan">Time interval to inspect.</param>
  /// <param name="minutes">Asserted minutes count.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion TotalMinutes(this IAssertion assertion, TimeSpan timeSpan, int minutes, string error = null) => assertion.True((int) timeSpan.TotalMinutes == minutes, error);

  /// <summary>
  ///   <para>This function asserts that the given time interval represents a specified total number of whole seconds.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="timeSpan">Time interval to inspect.</param>
  /// <param name="seconds">Asserted seconds count.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion TotalSeconds(this IAssertion assertion, TimeSpan timeSpan, int seconds, string error = null) => assertion.True((int) timeSpan.TotalSeconds == seconds, error);

  /// <summary>
  ///   <para>This function asserts that the given time interval represents a specified total number of whole milliseconds.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="timeSpan">Time interval to inspect.</param>
  /// <param name="milliseconds">Asserted milliseconds count.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion TotalMilliseconds(this IAssertion assertion, TimeSpan timeSpan, int milliseconds, string error = null) => assertion.True((int) timeSpan.TotalMilliseconds == milliseconds, error);
}