namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="TextWriter"/>
public static class TextWriterExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="format"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<TextWriter> Format(this IExpectation<TextWriter> expectation, IFormatProvider format) => expectation.HaveSubject().And().Expected(writer => writer.FormatProvider.Equals(format));
}