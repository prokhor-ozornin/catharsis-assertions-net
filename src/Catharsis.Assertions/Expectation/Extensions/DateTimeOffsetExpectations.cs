namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="DateTimeOffset"/> type.</para>
/// </summary>
/// <seealso cref="DateTimeOffset"/>
public static class DateTimeOffsetExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="DateTimeOffset"/> is in the past.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  /// <seealso cref="Future(IExpectation{DateTimeOffset})"/>
  public static IExpectation<DateTimeOffset> Past(this IExpectation<DateTimeOffset> expectation) => expectation.Expected(date => date < DateTime.UtcNow);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTimeOffset"/> is in the future.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  /// <seealso cref="Past(IExpectation{DateTimeOffset})"/>
  public static IExpectation<DateTimeOffset> Future(this IExpectation<DateTimeOffset> expectation) => expectation.Expected(date => date > DateTime.UtcNow);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTimeOffset"/> corresponds to a specific day of the year.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="day">Expected day of the year.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<DateTimeOffset> DayOfYear(this IExpectation<DateTimeOffset> expectation, int day) => expectation.Expected(date => date.DayOfYear == day);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTimeOffset"/> has a specified year.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="year">Expected year.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<DateTimeOffset> Year(this IExpectation<DateTimeOffset> expectation, int year) => expectation.Expected(date => date.Year == year);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTimeOffset"/> has a specified month.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="month">Expected month.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<DateTimeOffset> Month(this IExpectation<DateTimeOffset> expectation, int month) => expectation.Expected(date => date.Month == month);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTimeOffset"/> has a specified day.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="day">Expected day.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<DateTimeOffset> Day(this IExpectation<DateTimeOffset> expectation, int day) => expectation.Expected(date => date.Day == day);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTimeOffset"/> has a specified hour.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="hour">Expected hour.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<DateTimeOffset> Hour(this IExpectation<DateTimeOffset> expectation, int hour) => expectation.Expected(date => date.Hour == hour);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTimeOffset"/> has specified minute.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="minute">Expected minute.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<DateTimeOffset> Minute(this IExpectation<DateTimeOffset> expectation, int minute) => expectation.Expected(date => date.Minute == minute);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTimeOffset"/> has a specified second.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="second">Expected second.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<DateTimeOffset> Second(this IExpectation<DateTimeOffset> expectation, int second) => expectation.Expected(date => date.Second == second);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTimeOffset"/> has a specified millisecond.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="millisecond">Expected millisecond.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<DateTimeOffset> Millisecond(this IExpectation<DateTimeOffset> expectation, int millisecond) => expectation.Expected(date => date.Millisecond == millisecond);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTimeOffset"/> represents a specified day of the week.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="day">Expected day of the week.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<DateTimeOffset> DayOfWeek(this IExpectation<DateTimeOffset> expectation, DayOfWeek day) => expectation.Expected(date => date.DayOfWeek == day);

  /// <summary>
  ///   <para>Expects that the given <see cref="DateTimeOffset"/> is offset by a specified amount from the UTC/GMT time zone.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="offset">Expected timezone offset.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
  public static IExpectation<DateTimeOffset> Offset(this IExpectation<DateTimeOffset> expectation, TimeSpan offset) => expectation.Expected(date => date.Offset == offset);
}