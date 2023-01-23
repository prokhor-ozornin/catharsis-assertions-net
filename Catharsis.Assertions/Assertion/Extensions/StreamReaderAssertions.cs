using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class StreamReaderAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="reader"></param>
  /// <param name="encoding"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Encoding(this IAssertion assertion, StreamReader reader, Encoding encoding, string message = null) => reader is not null ? assertion.Equal(reader.CurrentEncoding, encoding, message) : throw new ArgumentNullException(nameof(reader));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="reader"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion End(this IAssertion assertion, StreamReader reader, string message = null) => reader is not null ? assertion.True(reader.EndOfStream, message) : throw new ArgumentNullException(nameof(reader));
}