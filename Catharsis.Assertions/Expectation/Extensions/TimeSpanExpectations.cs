namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="TimeSpan"/> type.</para>
/// </summary>
/// <seealso cref="TimeSpan"/>
public static class TimeSpanExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="days"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<TimeSpan> Days(this IExpectation<TimeSpan> expectation, int days) => expectation.Expected(timeSpan => timeSpan.Days == days);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="hours"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<TimeSpan> Hours(this IExpectation<TimeSpan> expectation, int hours) => expectation.Expected(timeSpan => timeSpan.Hours == hours);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="minutes"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<TimeSpan> Minutes(this IExpectation<TimeSpan> expectation, int minutes) => expectation.Expected(timeSpan => timeSpan.Minutes == minutes);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="seconds"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<TimeSpan> Seconds(this IExpectation<TimeSpan> expectation, int seconds) => expectation.Expected(timeSpan => timeSpan.Seconds == seconds);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="milliseconds"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<TimeSpan> Milliseconds(this IExpectation<TimeSpan> expectation, int milliseconds) => expectation.Expected(timeSpan => timeSpan.Milliseconds == milliseconds);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="days"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<TimeSpan> TotalDays(this IExpectation<TimeSpan> expectation, int days) => expectation.Expected(timeSpan => (int) timeSpan.TotalDays == days);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="hours"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<TimeSpan> TotalHours(this IExpectation<TimeSpan> expectation, int hours) => expectation.Expected(timeSpan => (int) timeSpan.TotalHours == hours);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="minutes"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<TimeSpan> TotalMinutes(this IExpectation<TimeSpan> expectation, int minutes) => expectation.Expected(timeSpan => (int) timeSpan.TotalMinutes == minutes);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="seconds"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<TimeSpan> TotalSeconds(this IExpectation<TimeSpan> expectation, int seconds) => expectation.Expected(timeSpan => (int) timeSpan.TotalSeconds == seconds);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="milliseconds"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<TimeSpan> TotalMilliseconds(this IExpectation<TimeSpan> expectation, int milliseconds) => expectation.Expected(timeSpan => (int) timeSpan.TotalMilliseconds == milliseconds);
}