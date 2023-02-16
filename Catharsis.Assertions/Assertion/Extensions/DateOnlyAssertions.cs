namespace Catharsis.Assertions;

#if NET7_0_OR_GREATER
/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="DateOnly"/>
public static class DateOnlyAssertions
{
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
  public static IAssertion DayOfYear(this IAssertion assertion, DateOnly date, int day, string error = null) => assertion.True(date.DayOfYear == day, error);

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
  public static IAssertion Year(this IAssertion assertion, DateOnly date, int year, string error = null) => assertion.True(date.Year == year, error);

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
  public static IAssertion Month(this IAssertion assertion, DateOnly date, int month, string error = null) => assertion.True(date.Month == month, error);

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
  public static IAssertion Day(this IAssertion assertion, DateOnly date, int day, string error = null) => assertion.True(date.Day == day, error);
}
#endif