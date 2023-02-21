namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="TextReader"/> type.</para>
/// </summary>
/// <seealso cref="TextReader"/>
public static class TextReaderExpectations
{
  /// <summary>
  ///   <para>Asserts that a given text reader has no more available characters to read.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<TextReader> End(this IExpectation<TextReader> expectation) => expectation.HaveSubject().And().Expected(reader => reader.Peek() < 0);
}