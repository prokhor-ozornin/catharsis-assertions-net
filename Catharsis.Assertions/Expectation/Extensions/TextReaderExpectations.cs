namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class TextReaderExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<TextReader> End(this IExpectation<TextReader> expectation) => expectation.HaveSubject().And().Expected(reader => reader.Peek() < 0);
}