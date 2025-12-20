namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="Range"/> type.</para>
/// </summary>
/// <seealso cref="Range"/>
public static class RangeExpectations
{
  /// <param name="expectation">Expectation to be fulfilled.</param>
  extension(IExpectation<Range> expectation)
  {
    /// <summary>
    ///   <para>Expects that the starting index of the given <see cref="Range"/> is equal to a specified value.</para>
    /// </summary>
    /// <param name="index">Expected index value.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    public IExpectation<Range> StartIndex(int index) => expectation.Expected(range => range.Start.Value == index);

    /// <summary>
    ///   <para>Expects that the ending index of the given <see cref="Range"/> is equal to a specified value.</para>
    /// </summary>
    /// <param name="index">Expected index value.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is <see langword="null"/>.</exception>
    public IExpectation<Range> EndIndex(int index) => expectation.Expected(range => range.End.Value == index);
  }
}