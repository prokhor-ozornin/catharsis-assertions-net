namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="DateTime"/> type.</para>
/// </summary>
/// <seealso cref="DateTime"/>
public static class DateTimeAssertions
{
  /// <summary>
  ///   <para>Asserts that a given date lies in the past (lesser than the current).</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Future(IAssertion, DateTime, string)"/>
  public static IAssertion Past(this IAssertion assertion, DateTime date, string error = null) => assertion.True(date.ToUniversalTime() < DateTime.UtcNow, error);

  /// <summary>
  ///   <para>Asserts that a given date lies in the future (greater than the current).</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Past(IAssertion, DateTime, string)"/>
  public static IAssertion Future(this IAssertion assertion, DateTime date, string error = null) => assertion.True(date.ToUniversalTime() > DateTime.UtcNow, error);

  /// <summary>
  ///   <para>Asserts that a given date represents a specified day of the year.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="day">Day of the year value.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion DayOfYear(this IAssertion assertion, DateTime date, int day, string error = null) => assertion.True(date.DayOfYear == day, error);

  /// <summary>
  ///   <para>Asserts that a given date has a specified year component.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="year">Year component value.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Year(this IAssertion assertion, DateTime date, int year, string error = null) => assertion.True(date.Year == year, error);

  /// <summary>
  ///   <para>Asserts that a given date has a specified month component.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="month">Month component value.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Month(this IAssertion assertion, DateTime date, int month, string error = null) => assertion.True(date.Month == month, error);

  /// <summary>
  ///   <para>Asserts that a given date has a specified day component.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="day">Day component value.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Day(this IAssertion assertion, DateTime date, int day, string error = null) => assertion.True(date.Day == day, error);

  /// <summary>
  ///   <para>Asserts that a given date has a specified hour component.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="hour">Hour component value.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Hour(this IAssertion assertion, DateTime date, int hour, string error = null) => assertion.True(date.Hour == hour, error);

  /// <summary>
  ///   <para>Asserts that a given date has specified minute component.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="minute">Minute component value.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Minute(this IAssertion assertion, DateTime date, int minute, string error = null) => assertion.True(date.Minute == minute, error);

  /// <summary>
  ///   <para>Asserts that a given date has a specified second component.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="second">Second component value.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Second(this IAssertion assertion, DateTime date, int second, string error = null) => assertion.True(date.Second == second, error);

  /// <summary>
  ///   <para>Asserts that a given date has a specified millisecond component.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="millisecond">Millisecond component value.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Millisecond(this IAssertion assertion, DateTime date, int millisecond, string error = null) => assertion.True(date.Millisecond == millisecond, error);

  /// <summary>
  ///   <para>Asserts that a given date represents a specified day of the week.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="day">Day of the week value.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion DayOfWeek(this IAssertion assertion, DateTime date, DayOfWeek day, string error = null) => assertion.True(date.DayOfWeek == day, error);

  /// <summary>
  ///   <para>Asserts that a given date represents a date/time in the local timezone.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="UtcTime(IAssertion, DateTime, string)"/>
  public static IAssertion LocalTime(this IAssertion assertion, DateTime date, string error = null) => assertion.True(date.Kind == DateTimeKind.Local, error);

  /// <summary>
  ///   <para>Asserts that a given date represents a date/time in the UTC/GMT timezone.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="date">Date to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="LocalTime(IAssertion, DateTime, string)"/>
  public static IAssertion UtcTime(this IAssertion assertion, DateTime date, string error = null) => assertion.True(date.Kind == DateTimeKind.Utc, error);
}