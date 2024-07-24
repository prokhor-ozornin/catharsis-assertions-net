namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="TimeSpan"/> type.</para>
/// </summary>
/// <seealso cref="TimeSpan"/>
public static class TimeSpanExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="TimeSpan"/> has a specified number of days.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="days">Expected days count.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<TimeSpan> Days(this IExpectation<TimeSpan> expectation, int days) => expectation.Expected(timeSpan => timeSpan.Days == days);

  /// <summary>
  ///   <para>Expects that the given <see cref="TimeSpan"/> has a specified number of hours.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="hours">Expected hours count.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<TimeSpan> Hours(this IExpectation<TimeSpan> expectation, int hours) => expectation.Expected(timeSpan => timeSpan.Hours == hours);

  /// <summary>
  ///   <para>Expects that the given <see cref="TimeSpan"/> has a specified number of minutes.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="minutes">Expected minutes count.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<TimeSpan> Minutes(this IExpectation<TimeSpan> expectation, int minutes) => expectation.Expected(timeSpan => timeSpan.Minutes == minutes);

  /// <summary>
  ///   <para>Expects that the given <see cref="TimeSpan"/> has a specified number of seconds.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="seconds">Expected seconds count.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<TimeSpan> Seconds(this IExpectation<TimeSpan> expectation, int seconds) => expectation.Expected(timeSpan => timeSpan.Seconds == seconds);

  /// <summary>
  ///   <para>Expects that the given <see cref="TimeSpan"/> has a specified number of milliseconds.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="milliseconds">Expected milliseconds count.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<TimeSpan> Milliseconds(this IExpectation<TimeSpan> expectation, int milliseconds) => expectation.Expected(timeSpan => timeSpan.Milliseconds == milliseconds);

  /// <summary>
  ///   <para>Expects that the given <see cref="TimeSpan"/> has a specified number of total days.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="days">Expected days count.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<TimeSpan> TotalDays(this IExpectation<TimeSpan> expectation, int days) => expectation.Expected(timeSpan => (int) timeSpan.TotalDays == days);

  /// <summary>
  ///   <para>Expects that the given <see cref="TimeSpan"/> has a specified number of total hours.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="hours">Expected hours count.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<TimeSpan> TotalHours(this IExpectation<TimeSpan> expectation, int hours) => expectation.Expected(timeSpan => (int) timeSpan.TotalHours == hours);

  /// <summary>
  ///   <para>Expects that the given <see cref="TimeSpan"/> has a specified number of total minutes.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="minutes">Expected minutes count.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<TimeSpan> TotalMinutes(this IExpectation<TimeSpan> expectation, int minutes) => expectation.Expected(timeSpan => (int) timeSpan.TotalMinutes == minutes);

  /// <summary>
  ///   <para>Expects that the given <see cref="TimeSpan"/> has a specified number of total seconds.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="seconds">Expected seconds count.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<TimeSpan> TotalSeconds(this IExpectation<TimeSpan> expectation, int seconds) => expectation.Expected(timeSpan => (int) timeSpan.TotalSeconds == seconds);

  /// <summary>
  ///   <para>Expects that the given <see cref="TimeSpan"/> has a specified number of total milliseconds.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="milliseconds">Expected milliseconds count.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<TimeSpan> TotalMilliseconds(this IExpectation<TimeSpan> expectation, int milliseconds) => expectation.Expected(timeSpan => (int) timeSpan.TotalMilliseconds == milliseconds);
}