namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="Range"/> type.</para>
/// </summary>
/// <seealso cref="Range"/>
public static class RangeExpectations
{
  /// <summary>
  ///   <para>Expects that a given range's start index has a specified value.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="index">Expected index value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<Range> StartIndex(this IExpectation<Range> expectation, int index) => expectation.Expected(range => range.Start.Value == index);

  /// <summary>
  ///   <para>Expects that a given range's end index has a specified value.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="index">Expected index value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<Range> EndIndex(this IExpectation<Range> expectation, int index) => expectation.Expected(range => range.End.Value == index);
}