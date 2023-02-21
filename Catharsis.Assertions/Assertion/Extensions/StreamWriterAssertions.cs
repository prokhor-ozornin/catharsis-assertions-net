using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="StreamWriter"/> type.</para>
/// </summary>
/// <seealso cref="StreamWriter"/>
public static class StreamWriterAssertions
{
  /// <summary>
  ///   <para>Asserts that a given stream writer uses a specified character encoding.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="writer">Stream writer to inspect.</param>
  /// <param name="encoding">Text character encoding.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="writer"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Encoding(this IAssertion assertion, StreamWriter writer, Encoding encoding, string error = null) => writer is not null ? assertion.Equal(writer.Encoding, encoding, error) : throw new ArgumentNullException(nameof(writer));
}