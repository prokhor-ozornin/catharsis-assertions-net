namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="DateTime"/> type.</para>
/// </summary>
/// <seealso cref="DateTime"/>
public static class DateTimeAssertions
{
  /// <summary>
  ///   <para>Asserts that the given <see cref="DateTime"/> is in the past.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Future(IAssertion, DateTime, string)"/>
  public static IAssertion Past(this IAssertion assertion, DateTime date, string error = null) => assertion.True(date.ToUniversalTime() < DateTime.UtcNow, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="DateTime"/> is in the future.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Past(IAssertion, DateTime, string)"/>
  public static IAssertion Future(this IAssertion assertion, DateTime date, string error = null) => assertion.True(date.ToUniversalTime() > DateTime.UtcNow, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="DateTime"/> corresponds to a specific day of the year.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="day">Asserted day of the year.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion DayOfYear(this IAssertion assertion, DateTime date, int day, string error = null) => assertion.True(date.DayOfYear == day, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="DateTime"/> has a specified year.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="year">Asserted year.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Year(this IAssertion assertion, DateTime date, int year, string error = null) => assertion.True(date.Year == year, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="DateTime"/> has a specified month.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="month">Asserted month.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Month(this IAssertion assertion, DateTime date, int month, string error = null) => assertion.True(date.Month == month, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="DateTime"/> has a specified day.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="day">Asserted day.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Day(this IAssertion assertion, DateTime date, int day, string error = null) => assertion.True(date.Day == day, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="DateTime"/> has a specified hour.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="hour">Asserted hour.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Hour(this IAssertion assertion, DateTime date, int hour, string error = null) => assertion.True(date.Hour == hour, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="DateTime"/> has specified minute.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="minute">Asserted minute.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Minute(this IAssertion assertion, DateTime date, int minute, string error = null) => assertion.True(date.Minute == minute, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="DateTime"/> has a specified second.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="second">Asserted second.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Second(this IAssertion assertion, DateTime date, int second, string error = null) => assertion.True(date.Second == second, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="DateTime"/> has a specified millisecond.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="millisecond">Asserted millisecond.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Millisecond(this IAssertion assertion, DateTime date, int millisecond, string error = null) => assertion.True(date.Millisecond == millisecond, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="DateTime"/> represents a specified day of the week.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="day">Asserted day of the week.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion DayOfWeek(this IAssertion assertion, DateTime date, DayOfWeek day, string error = null) => assertion.True(date.DayOfWeek == day, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="DateTime"/> represents a specified date and time in the local timezone.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="UtcTime(IAssertion, DateTime, string)"/>
  public static IAssertion LocalTime(this IAssertion assertion, DateTime date, string error = null) => assertion.True(date.Kind == DateTimeKind.Local, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="DateTime"/> represents a date and time in the UTC/GMT timezone.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="LocalTime(IAssertion, DateTime, string)"/>
  public static IAssertion UtcTime(this IAssertion assertion, DateTime date, string error = null) => assertion.True(date.Kind == DateTimeKind.Utc, error);
}