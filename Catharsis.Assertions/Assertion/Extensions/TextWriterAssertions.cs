namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="TextWriter"/>
public static class TextWriterAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="writer"></param>
  /// <param name="format"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Format(this IAssertion assertion, TextWriter writer, IFormatProvider format, string message = null) => writer is not null ? assertion.Equal(writer.FormatProvider, format, message) : throw new ArgumentNullException(nameof(writer));
}