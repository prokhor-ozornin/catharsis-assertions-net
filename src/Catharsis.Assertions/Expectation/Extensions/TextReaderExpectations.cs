namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="TextReader"/> type.</para>
/// </summary>
/// <seealso cref="TextReader"/>
public static class TextReaderExpectations
{
  /// <param name="expectation">Expectation to be fulfilled.</param>
  extension(IExpectation<TextReader> expectation)
  {
    /// <summary>
    ///   <para>Expects that the given <see cref="TextReader"/> has no more characters available to read.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<TextReader> End() => expectation.HaveSubject().And().Expected(reader => reader.Peek() < 0);
  }
}