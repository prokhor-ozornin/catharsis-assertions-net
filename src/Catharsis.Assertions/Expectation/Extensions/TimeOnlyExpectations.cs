namespace Catharsis.Assertions;

#if NET10_0_OR_GREATER
/// <summary>
///   <para>A set of expectations for the <see cref="TimeOnly"/> type.</para>
/// </summary>
/// <seealso cref="TimeOnly"/>
public static class TimeOnlyExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="TimeOnly"/> has a specified hour.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="hour">Expected hour.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<TimeOnly> Hour(this IExpectation<TimeOnly> expectation, int hour) => expectation.Expected(time => time.Hour == hour);

  /// <summary>
  ///   <para>Expects that the given <see cref="TimeOnly"/> has a specified minute.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="minute">Expected minute.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<TimeOnly> Minute(this IExpectation<TimeOnly> expectation, int minute) => expectation.Expected(time => time.Minute == minute);

  /// <summary>
  ///   <para>Expects that the given <see cref="TimeOnly"/> has a specified second.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="second">Expected second.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<TimeOnly> Second(this IExpectation<TimeOnly> expectation, int second) => expectation.Expected(time => time.Second == second);

  /// <summary>
  ///   <para>Expects that the given <see cref="TimeOnly"/> has a specified millisecond.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="millisecond">Expected millisecond.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<TimeOnly> Millisecond(this IExpectation<TimeOnly> expectation, int millisecond) => expectation.Expected(time => time.Millisecond == millisecond);
}
#endif