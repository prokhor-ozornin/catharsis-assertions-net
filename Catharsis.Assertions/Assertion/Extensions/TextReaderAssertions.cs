namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="TextReader"/>
public static class TextReaderAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="reader"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion End(this IAssertion assertion, TextReader reader, string message = null) => reader is not null ? assertion.True(reader.Peek() < 0, message) : throw new ArgumentNullException(nameof(reader));
}