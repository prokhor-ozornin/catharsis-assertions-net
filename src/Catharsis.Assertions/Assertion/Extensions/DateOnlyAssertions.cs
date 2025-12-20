namespace Catharsis.Assertions;

#if NET10_0_OR_GREATER
/// <summary>
///   <para>A set of assertions for the <see cref="DateOnly"/> type.</para>
/// </summary>
/// <seealso cref="DateOnly"/>
public static class DateOnlyAssertions
{
  /// <param name="assertion">Assertion to validate.</param>
  extension(IAssertion assertion)
  {
    /// <summary>
    ///   <para>Asserts that the given <see cref="DateOnly"/> corresponds to a specific day of the year.</para>
    /// </summary>
    /// <param name="date">Date to inspect.</param>
    /// <param name="day">Asserted day of the year.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion DayOfYear(DateOnly date, int day, string error = null) => assertion.True(date.DayOfYear == day, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="DateOnly"/> has a specified year.</para>
    /// </summary>
    /// <param name="date">Date to inspect.</param>
    /// <param name="year">Asserted year.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Year(DateOnly date, int year, string error = null) => assertion.True(date.Year == year, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="DateOnly"/> has a specified month.</para>
    /// </summary>
    /// <param name="date">Date to inspect.</param>
    /// <param name="month">Asserted month.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Month(DateOnly date, int month, string error = null) => assertion.True(date.Month == month, error);

    /// <summary>
    ///   <para>Asserts that the given <see cref="DateOnly"/> has a specified day.</para>
    /// </summary>
    /// <param name="date">Date to inspect.</param>
    /// <param name="day">Asserted day.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="assertion"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion Day(DateOnly date, int day, string error = null) => assertion.True(date.Day == day, error);
  }
}
#endif