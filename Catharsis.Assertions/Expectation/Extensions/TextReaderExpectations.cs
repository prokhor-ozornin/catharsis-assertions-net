namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="TextReader"/>
public static class TextReaderExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<TextReader> End(this IExpectation<TextReader> expectation) => expectation.HaveSubject().And().Expected(reader => reader.Peek() < 0);
}