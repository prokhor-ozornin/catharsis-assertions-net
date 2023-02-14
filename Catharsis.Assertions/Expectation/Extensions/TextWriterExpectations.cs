﻿namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="TextWriter"/>
public static class TextWriterExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="format"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<TextWriter> Format(this IExpectation<TextWriter> expectation, IFormatProvider format) => expectation.HaveSubject().And().Expected(writer => writer.FormatProvider.Equals(format));
}