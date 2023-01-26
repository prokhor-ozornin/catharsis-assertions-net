﻿namespace Catharsis.Assertions;

#if NET7_0_OR_GREATER
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
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateOnly> Day(this IExpectation<DateOnly> expectation, int day) => expectation.Expected(date => date.Day == day);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="month"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateOnly> Month(this IExpectation<DateOnly> expectation, int month) => expectation.Expected(date => date.Month == month);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="year"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateOnly> Year(this IExpectation<DateOnly> expectation, int year) => expectation.Expected(date => date.Year == year);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="day"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<DateOnly> DayOfYear(this IExpectation<DateOnly> expectation, int day) => expectation.Expected(date => date.DayOfYear == day);
}
#endif