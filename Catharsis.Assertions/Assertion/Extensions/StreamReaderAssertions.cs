using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="StreamReader"/> type.</para>
/// </summary>
/// <seealso cref="StreamReader"/>
public static class StreamReaderAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="reader"></param>
  /// <param name="encoding"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="reader"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Encoding(this IAssertion assertion, StreamReader reader, Encoding encoding, string error = null) => reader is not null ? assertion.Equal(reader.CurrentEncoding, encoding, error) : throw new ArgumentNullException(nameof(reader));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="reader"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="reader"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion End(this IAssertion assertion, StreamReader reader, string error = null) => reader is not null ? assertion.True(reader.EndOfStream, error) : throw new ArgumentNullException(nameof(reader));
}