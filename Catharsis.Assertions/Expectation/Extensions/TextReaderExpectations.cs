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
  public static IExpectation<TextReader> End(this IExpectation<TextReader> expectation) => expectation.HaveSubject().And().Expect(reader => reader.Peek() < 0);
}