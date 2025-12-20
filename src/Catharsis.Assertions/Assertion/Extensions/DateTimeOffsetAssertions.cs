namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="DateTimeOffset"/> type.</para>
/// </summary>
/// <seealso cref="DateTimeOffset"/>
public static class DateTimeOffsetAssertions
{
  /// <param name="assertion">Assertion to validate.</param>
  extension(IAssertion assertion)
  {
    /// <summary>
    ///   <para>Asserts that the given <see cref="DateTimeOffset"/> is in the past.</para>
    /// </summary>
    /// <param name="date">Date to inspect.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    /// <seealso cref="Future(IAssertion, DateTimeOffset, string)"/>
    public IAssertion Past(DateTimeOffset date, string error = null) => assertion.True(date < DateTime.UtcNow, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="DateTimeOffset"/> is in the future.</para>
    /// </summary>
    /// <param name="date">Date to inspect.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    /// <seealso cref="Past(IAssertion, DateTimeOffset, string)"/>
    public IAssertion Future(DateTimeOffset date, string error = null) => assertion.True(date > DateTime.UtcNow, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="DateTimeOffset"/> corresponds to a specific day of the year.</para>
    /// </summary>
    /// <param name="date">Date to inspect.</param>
    /// <param name="day">Asserted day of the year.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion DayOfYear(DateTimeOffset date, int day, string error = null) => assertion.True(date.DayOfYear == day, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="DateTimeOffset"/> has a specified year.</para>
    /// </summary>
    /// <param name="date">Date to inspect.</param>
    /// <param name="year">Asserted year.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Year(DateTimeOffset date, int year, string error = null) => assertion.True(date.Year == year, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="DateTimeOffset"/> has a specified month.</para>
    /// </summary>
    /// <param name="date">Date to inspect.</param>
    /// <param name="month">Asserted month.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Month(DateTimeOffset date, int month, string error = null) => assertion.True(date.Month == month, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="DateTimeOffset"/> has a specified day.</para>
    /// </summary>
    /// <param name="date">Date to inspect.</param>
    /// <param name="day">Asserted day.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Day(DateTimeOffset date, int day, string error = null) => assertion.True(date.Day == day, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="DateTimeOffset"/> has a specified hour.</para>
    /// </summary>
    /// <param name="date">Date to inspect.</param>
    /// <param name="hour">Asserted hour.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Hour(DateTimeOffset date, int hour, string error = null) => assertion.True(date.Hour == hour, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="DateTimeOffset"/> has specified minute.</para>
    /// </summary>
    /// <param name="date">Date to inspect.</param>
    /// <param name="minute">Asserted minute.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Minute(DateTimeOffset date, int minute, string error = null) => assertion.True(date.Minute == minute, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="DateTimeOffset"/> has a specified second.</para>
    /// </summary>
    /// <param name="date">Date to inspect.</param>
    /// <param name="second">Asserted second.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Second(DateTimeOffset date, int second, string error = null) => assertion.True(date.Second == second, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="DateTimeOffset"/> has a specified millisecond.</para>
    /// </summary>
    /// <param name="date">Date to inspect.</param>
    /// <param name="millisecond">Asserted millisecond.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Millisecond(DateTimeOffset date, int millisecond, string error = null) => assertion.True(date.Millisecond == millisecond, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="DateTimeOffset"/> represents a specified day of the week.</para>
    /// </summary>
    /// <param name="date">Date to inspect.</param>
    /// <param name="day">Asserted day of the week.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion DayOfWeek(DateTimeOffset date, DayOfWeek day, string error = null) => assertion.True(date.DayOfWeek == day, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="DateTimeOffset"/> is offset by a specified amount from the UTC/GMT time zone.</para>
    /// </summary>
    /// <param name="date">Date to inspect.</param>
    /// <param name="offset">Asserted timezone offset.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Offset(DateTimeOffset date, TimeSpan offset, string error = null) => assertion.True(date.Offset == offset, error);
  }
}