namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="TextWriter"/> type.</para>
/// </summary>
/// <seealso cref="TextWriter"/>
public static class TextWriterExpectations
{
  /// <summary>
  ///   <para>Expects that a given text writer has a specified format provider that controls formatting.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="format">Expected object that controls formatting.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<TextWriter> Format(this IExpectation<TextWriter> expectation, IFormatProvider format) => expectation.HaveSubject().And().Expected(writer => Equals(writer.FormatProvider, format));
}