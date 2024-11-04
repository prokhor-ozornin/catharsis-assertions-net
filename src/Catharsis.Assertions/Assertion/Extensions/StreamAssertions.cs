namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="Stream"/> type.</para>
/// </summary>
/// <seealso cref="Stream"/>
public static class StreamAssertions
{
  /// <summary>
  ///   <para>Asserts that the given <see cref="Stream"/> has the specified length.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream">Stream to inspect.</param>
  /// <param name="length">Asserted stream length.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="stream"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Length(this IAssertion assertion, Stream stream, long length, string error = null) => stream is not null ? assertion.True(stream.Length == length, error)  : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para>Asserts that the given <see cref="Stream"/> is empty, meaning its length is zero.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream">Stream to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="stream"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Empty(this IAssertion assertion, Stream stream, string error = null) => assertion.Length(stream, 0, error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="Stream"/> is at the specified position within the stream.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream">Stream to inspect.</param>
  /// <param name="position">Asserted position.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="stream"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Position(this IAssertion assertion, Stream stream, long position, string error = null) => stream is not null ? assertion.True(stream.Position == position, error) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para>Asserts that the given <see cref="Stream"/> is positioned at the end.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream">Stream to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="stream"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion End(this IAssertion assertion, Stream stream, string error = null) => stream is not null ? assertion.True(stream.Position == stream.Length, error) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para>Asserts that the given <see cref="Stream"/> is able to perform reading operations.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream">Stream to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="stream"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Readable(this IAssertion assertion, Stream stream, string error = null) => stream is not null ? assertion.True(stream.CanRead, error) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para>Asserts that the given <see cref="Stream"/> is able to perform writing operations.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream">Stream to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="stream"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Writable(this IAssertion assertion, Stream stream, string error = null) => stream is not null ? assertion.True(stream.CanWrite, error) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para>Asserts that the given <see cref="Stream"/> is able to perform seeking operations.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream">Stream to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="stream"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Seekable(this IAssertion assertion, Stream stream, string error = null) => stream is not null ? assertion.True(stream.CanSeek, error) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para>Asserts that the given <see cref="Stream"/> is read-only, which means it's able to perform read operations, but not write operations.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream">Stream to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="stream"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ReadOnly(this IAssertion assertion, Stream stream, string error = null) => stream is not null ? assertion.True(stream.CanRead && !stream.CanWrite, error) : throw new ArgumentNullException(nameof(stream));

  /// <summary>
  ///   <para>Asserts that the given <see cref="Stream"/> is read-only, which means it's able to perform write operations, but not read operations.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="stream">Stream to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="stream"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion WriteOnly(this IAssertion assertion, Stream stream, string error = null) => stream is not null ? assertion.True(stream.CanWrite && !stream.CanRead, error) : throw new ArgumentNullException(nameof(stream));
}