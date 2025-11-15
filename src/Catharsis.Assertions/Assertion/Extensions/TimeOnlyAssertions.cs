namespace Catharsis.Assertions;

#if NET10_0_OR_GREATER
/// <summary>
///   <para>A set of assertions for the <see cref="TimeOnly"/> type.</para>
/// </summary>
/// <seealso cref="TimeOnly"/>
public static class TimeOnlyAssertions
{
  /// <summary>
  ///   <para>Asserts that the given <see cref="TimeOnly"/> has a specified hour.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="time">Time to inspect.</param>
  /// <param name="hour">Asserted hour.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Hour(this IAssertion assertion, TimeOnly time, int hour, string error = null) => assertion.True(time.Hour == hour, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="TimeOnly"/> has a specified minute.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="time">Time to inspect.</param>
  /// <param name="minute">Asserted minute.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Minute(this IAssertion assertion, TimeOnly time, int minute, string error = null) => assertion.True(time.Minute == minute, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="TimeOnly"/> has a specified second.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="time">Time to inspect.</param>
  /// <param name="second">Asserted second.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Second(this IAssertion assertion, TimeOnly time, int second, string error = null) => assertion.True(time.Second == second, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="TimeOnly"/> has a specified millisecond.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="time">Time to inspect.</param>
  /// <param name="millisecond">Asserted millisecond.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Millisecond(this IAssertion assertion, TimeOnly time, int millisecond, string error = null) => assertion.True(time.Millisecond == millisecond, error);
}
#endif