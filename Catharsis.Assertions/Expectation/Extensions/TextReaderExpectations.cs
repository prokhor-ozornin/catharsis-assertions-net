namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for <see cref="TextReader"/> type.</para>
/// </summary>
/// <seealso cref="TextReader"/>
public static class TextReaderExpectations
{
  /// <summary>
  ///   <para>This function asserts that the given text reader has no more available characters to read.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<TextReader> End(this IExpectation<TextReader> expectation) => expectation.HaveSubject().And().Expected(reader => reader.Peek() < 0);
}