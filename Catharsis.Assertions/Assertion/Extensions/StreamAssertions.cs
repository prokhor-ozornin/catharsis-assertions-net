namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="Stream"/>
public static class StreamAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream"></param>
  /// <param name="length"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Length(this IAssertion assertion, Stream stream, long length, string error = null) => stream is not null ? assertion.True(stream.Length == length, error)  : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Empty(this IAssertion assertion, Stream stream, string error = null) => assertion.Length(stream, 0, error);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream"></param>
  /// <param name="position"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Position(this IAssertion assertion, Stream stream, long position, string error = null) => stream is not null ? assertion.True(stream.Position == position, error) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion End(this IAssertion assertion, Stream stream, string error = null) => stream is not null ? assertion.True(stream.Position == stream.Length, error) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Readable(this IAssertion assertion, Stream stream, string error = null) => stream is not null ? assertion.True(stream.CanRead, error) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Writable(this IAssertion assertion, Stream stream, string error = null) => stream is not null ? assertion.True(stream.CanWrite, error) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Seekable(this IAssertion assertion, Stream stream, string error = null) => stream is not null ? assertion.True(stream.CanSeek, error) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ReadOnly(this IAssertion assertion, Stream stream, string error = null) => stream is not null ? assertion.True(stream.CanRead && !stream.CanWrite, error) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion WriteOnly(this IAssertion assertion, Stream stream, string error = null) => stream is not null ? assertion.True(stream.CanWrite && !stream.CanRead, error) : throw new ArgumentNullException(nameof(stream));
}