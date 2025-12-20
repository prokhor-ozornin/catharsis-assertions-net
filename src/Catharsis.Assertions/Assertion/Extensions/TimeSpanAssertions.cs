namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="TimeSpan"/> type.</para>
/// </summary>
/// <seealso cref="TimeSpan"/>
public static class TimeSpanAssertions
{
  /// <param name="assertion">Assertion to validate.</param>
  extension(IAssertion assertion)
  {
    /// <summary>
    ///   <para>Asserts that the given <see cref="TimeSpan"/> has a specified number of days.</para>
    /// </summary>
    /// <param name="timeSpan">Time interval to inspect.</param>
    /// <param name="days">Asserted days count.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Days(TimeSpan timeSpan, int days, string error = null) => assertion.True(timeSpan.Days == days, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="TimeSpan"/> has a specified number of hours.</para>
    /// </summary>
    /// <param name="timeSpan">Time interval to inspect.</param>
    /// <param name="hours">Asserted hours count.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Hours(TimeSpan timeSpan, int hours, string error = null) => assertion.True(timeSpan.Hours == hours, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="TimeSpan"/> has a specified number of minutes.</para>
    /// </summary>
    /// <param name="timeSpan">Time interval to inspect.</param>
    /// <param name="minutes">Asserted minutes count.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Minutes(TimeSpan timeSpan, int minutes, string error = null) => assertion.True(timeSpan.Minutes == minutes, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="TimeSpan"/> has a specified number of seconds.</para>
    /// </summary>
    /// <param name="timeSpan">Time interval to inspect.</param>
    /// <param name="seconds">Asserted seconds count.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Seconds(TimeSpan timeSpan, int seconds, string error = null) => assertion.True(timeSpan.Seconds == seconds, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="TimeSpan"/> has a specified number of milliseconds.</para>
    /// </summary>
    /// <param name="timeSpan">Time interval to inspect.</param>
    /// <param name="milliseconds">Asserted milliseconds count.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Milliseconds(TimeSpan timeSpan, int milliseconds, string error = null) => assertion.True(timeSpan.Milliseconds == milliseconds, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="TimeSpan"/> has a specified number of total days.</para>
    /// </summary>
    /// <param name="timeSpan">Time interval to inspect.</param>
    /// <param name="days">Asserted days count.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion TotalDays(TimeSpan timeSpan, int days, string error = null) => assertion.True((int) timeSpan.TotalDays == days, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="TimeSpan"/> has a specified number of total hours.</para>
    /// </summary>
    /// <param name="timeSpan">Time interval to inspect.</param>
    /// <param name="hours">Asserted hours count.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion TotalHours(TimeSpan timeSpan, int hours, string error = null) => assertion.True((int) timeSpan.TotalHours == hours, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="TimeSpan"/> has a specified number of total minutes.</para>
    /// </summary>
    /// <param name="timeSpan">Time interval to inspect.</param>
    /// <param name="minutes">Asserted minutes count.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion TotalMinutes(TimeSpan timeSpan, int minutes, string error = null) => assertion.True((int) timeSpan.TotalMinutes == minutes, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="TimeSpan"/> has a specified number of total seconds.</para>
    /// </summary>
    /// <param name="timeSpan">Time interval to inspect.</param>
    /// <param name="seconds">Asserted seconds count.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion TotalSeconds(TimeSpan timeSpan, int seconds, string error = null) => assertion.True((int) timeSpan.TotalSeconds == seconds, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="TimeSpan"/> has a specified number of total milliseconds.</para>
    /// </summary>
    /// <param name="timeSpan">Time interval to inspect.</param>
    /// <param name="milliseconds">Asserted milliseconds count.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion TotalMilliseconds(TimeSpan timeSpan, int milliseconds, string error = null) => assertion.True((int) timeSpan.TotalMilliseconds == milliseconds, error);
  }
}