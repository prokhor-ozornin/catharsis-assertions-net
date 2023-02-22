namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="Stream"/> type.</para>
/// </summary>
/// <seealso cref="Stream"/>
public static class StreamAssertions
{
  /// <summary>
  ///   <para>Asserts that a given stream has a specified length in bytes.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream">Stream to inspect.</param>
  /// <param name="length">Stream length.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="stream"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Length(this IAssertion assertion, Stream stream, long length, string error = null) => stream is not null ? assertion.True(stream.Length == length, error)  : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para>Asserts that a given stream is empty (zero-length).</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream">Stream to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="stream"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Empty(this IAssertion assertion, Stream stream, string error = null) => assertion.Length(stream, 0, error);

  /// <summary>
  ///   <para>Asserts that a given stream is at specified position/offset.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream">Stream to inspect.</param>
  /// <param name="position">Position within the stream.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="stream"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Position(this IAssertion assertion, Stream stream, long position, string error = null) => stream is not null ? assertion.True(stream.Position == position, error) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para>Asserts that a given stream is positioned at the end of it.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream">Stream to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="stream"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion End(this IAssertion assertion, Stream stream, string error = null) => stream is not null ? assertion.True(stream.Position == stream.Length, error) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para>Asserts that a given stream supports reading operations.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream">Stream to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="stream"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Readable(this IAssertion assertion, Stream stream, string error = null) => stream is not null ? assertion.True(stream.CanRead, error) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para>Asserts that a given stream supports writing operations.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream">Stream to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="stream"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Writable(this IAssertion assertion, Stream stream, string error = null) => stream is not null ? assertion.True(stream.CanWrite, error) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para>Asserts that a given stream supports seeking operations.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream">Stream to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="stream"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Seekable(this IAssertion assertion, Stream stream, string error = null) => stream is not null ? assertion.True(stream.CanSeek, error) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para>Asserts that a given stream is read-only (does not support writing operations).</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream">Stream to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="stream"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ReadOnly(this IAssertion assertion, Stream stream, string error = null) => stream is not null ? assertion.True(stream.CanRead && !stream.CanWrite, error) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para>Asserts that a given stream is write-only (does not support reading operations).</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream">Stream to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="stream"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion WriteOnly(this IAssertion assertion, Stream stream, string error = null) => stream is not null ? assertion.True(stream.CanWrite && !stream.CanRead, error) : throw new ArgumentNullException(nameof(stream));
}