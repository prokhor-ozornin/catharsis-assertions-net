namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="TextWriter"/> type.</para>
/// </summary>
/// <seealso cref="TextWriter"/>
public static class TextWriterExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="TextWriter"/> has a specified associated <see cref="IFormatProvider"/>.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="format">Expected format provider.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<TextWriter> Format(this IExpectation<TextWriter> expectation, IFormatProvider format) => expectation.HaveSubject().And().Expected(writer => Equals(writer.FormatProvider, format));
}