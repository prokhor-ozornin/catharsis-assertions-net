namespace Catharsis.Assertions;

#if NET7_0
/// <summary>
///   <para></para>
/// </summary>
public static class TimeOnlyExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="hour"></param>
  /// <returns></returns>
  public static IExpectation<TimeOnly> Hour(this IExpectation<TimeOnly> expectation, int hour) => expectation.Expect(time => time.Hour == hour);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="minute"></param>
  /// <returns></returns>
  public static IExpectation<TimeOnly> Minute(this IExpectation<TimeOnly> expectation, int minute) => expectation.Expect(time => time.Minute == minute);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="second"></param>
  /// <returns></returns>
  public static IExpectation<TimeOnly> Second(this IExpectation<TimeOnly> expectation, int second) => expectation.Expect(time => time.Second == second);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="millisecond"></param>
  /// <returns></returns>
  public static IExpectation<TimeOnly> Millisecond(this IExpectation<TimeOnly> expectation, int millisecond) => expectation.Expect(time => time.Millisecond == millisecond);
}
#endif