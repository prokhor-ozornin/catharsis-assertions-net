namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class TimeSpanExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="days"></param>
  /// <returns></returns>
  public static IExpectation<TimeSpan> Days(this IExpectation<TimeSpan> expectation, int days) => expectation.Expect(timeSpan => timeSpan.Days == days);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="hours"></param>
  /// <returns></returns>
  public static IExpectation<TimeSpan> Hours(this IExpectation<TimeSpan> expectation, int hours) => expectation.Expect(timeSpan => timeSpan.Hours == hours);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="minutes"></param>
  /// <returns></returns>
  public static IExpectation<TimeSpan> Minutes(this IExpectation<TimeSpan> expectation, int minutes) => expectation.Expect(timeSpan => timeSpan.Minutes == minutes);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="seconds"></param>
  /// <returns></returns>
  public static IExpectation<TimeSpan> Seconds(this IExpectation<TimeSpan> expectation, int seconds) => expectation.Expect(timeSpan => timeSpan.Seconds == seconds);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="milliseconds"></param>
  /// <returns></returns>
  public static IExpectation<TimeSpan> Milliseconds(this IExpectation<TimeSpan> expectation, int milliseconds) => expectation.Expect(timeSpan => timeSpan.Milliseconds == milliseconds);
}