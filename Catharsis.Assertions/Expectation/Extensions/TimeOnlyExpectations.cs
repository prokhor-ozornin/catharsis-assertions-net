namespace Catharsis.Assertions;

#if NET7_0_OR_GREATER
/// <summary>
///   <para>Set of expectations for <see cref="TimeOnly"/> type.</para>
/// </summary>
/// <seealso cref="TimeOnly"/>
public static class TimeOnlyExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="hour"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<TimeOnly> Hour(this IExpectation<TimeOnly> expectation, int hour) => expectation.Expected(time => time.Hour == hour);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="minute"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<TimeOnly> Minute(this IExpectation<TimeOnly> expectation, int minute) => expectation.Expected(time => time.Minute == minute);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="second"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<TimeOnly> Second(this IExpectation<TimeOnly> expectation, int second) => expectation.Expected(time => time.Second == second);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="millisecond"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<TimeOnly> Millisecond(this IExpectation<TimeOnly> expectation, int millisecond) => expectation.Expected(time => time.Millisecond == millisecond);
}
#endif