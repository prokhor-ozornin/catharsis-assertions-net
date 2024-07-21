using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="StreamReader"/> type.</para>
/// </summary>
/// <seealso cref="StreamReader"/>
public static class StreamReaderAssertions
{
  /// <summary>
  ///   <para>This function asserts that the given <see cref="StreamReader"/> uses a specified character encoding.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="reader">Stream reader to inspect.</param>
  /// <param name="encoding">Asserted text character encoding.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="reader"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Encoding(this IAssertion assertion, StreamReader reader, Encoding encoding, string error = null) => reader is not null ? assertion.Equal(reader.CurrentEncoding, encoding, error) : throw new ArgumentNullException(nameof(reader));

  /// <summary>
  ///   <para>This function asserts that the given <see cref="StreamReader"/> has reached the end of the underlying stream.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="reader">Stream reader to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="reader"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion End(this IAssertion assertion, StreamReader reader, string error = null) => reader is not null ? assertion.True(reader.EndOfStream, error) : throw new ArgumentNullException(nameof(reader));
}