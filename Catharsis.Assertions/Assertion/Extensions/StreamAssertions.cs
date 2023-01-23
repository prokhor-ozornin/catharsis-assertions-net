namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class StreamAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="stream"></param>
  /// <param name="length"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Length(this IAssertion assertion, Stream stream, long length, string message = null) => stream is not null ? assertion.True(stream.Length == length, message)  : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="stream"></param>
  /// <param name="position"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Position(this IAssertion assertion, Stream stream, long position, string message = null) => stream is not null ? assertion.True(stream.Position == position, message) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="stream"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Empty(this IAssertion assertion, Stream stream, string message = null) => assertion.Length(stream, 0, message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="stream"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Readable(this IAssertion assertion, Stream stream, string message = null) => stream is not null ? assertion.True(stream.CanRead, message) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="stream"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Writable(this IAssertion assertion, Stream stream, string message = null) => stream is not null ? assertion.True(stream.CanWrite, message) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="stream"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Seekable(this IAssertion assertion, Stream stream, string message = null) => stream is not null ? assertion.True(stream.CanSeek, message) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="stream"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion ReadOnly(this IAssertion assertion, Stream stream, string message = null) => stream is not null ? assertion.True(stream.CanRead && !stream.CanWrite, message) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="stream"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion WriteOnly(this IAssertion assertion, Stream stream, string message = null) => stream is not null ? assertion.True(stream.CanWrite && !stream.CanRead, message) : throw new ArgumentNullException(nameof(stream));
}