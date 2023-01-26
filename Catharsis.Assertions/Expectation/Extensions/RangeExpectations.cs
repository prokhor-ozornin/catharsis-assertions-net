namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class RangeExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="index"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<Range> StartIndex(this IExpectation<Range> expectation, int index) => expectation.Expected(range => range.Start.Value == index);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="index"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<Range> EndIndex(this IExpectation<Range> expectation, int index) => expectation.Expected(range => range.End.Value == index);
}