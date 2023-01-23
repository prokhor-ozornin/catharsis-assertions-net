namespace Catharsis.Assertions;

#if NET7_0
/// <summary>
///   <para></para>
/// </summary>
public static class DateOnlyExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="day"></param>
  /// <returns></returns>
  public static IExpectation<DateOnly> Day(this IExpectation<DateOnly> expectation, int day) => expectation.Expect(date => date.Day == day);
  
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="month"></param>
  /// <returns></returns>
  public static IExpectation<DateOnly> Month(this IExpectation<DateOnly> expectation, int month) => expectation.Expect(date => date.Month == month);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="year"></param>
  /// <returns></returns>
  public static IExpectation<DateOnly> Year(this IExpectation<DateOnly> expectation, int year) => expectation.Expect(date => date.Year == year);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="day"></param>
  /// <returns></returns>
  public static IExpectation<DateOnly> DayOfYear(this IExpectation<DateOnly> expectation, int day) => expectation.Expect(date => date.DayOfYear == day);
}
#endif