using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="StreamWriter"/> type.</para>
/// </summary>
/// <seealso cref="StreamWriter"/>
public static class StreamWriterAssertions
{
  /// <summary>
  ///   <para>This function asserts that the given <see cref="StreamWriter"/> uses a specified character encoding.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="writer">Stream writer to inspect.</param>
  /// <param name="encoding">Asserted text character encoding.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="writer"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Encoding(this IAssertion assertion, StreamWriter writer, Encoding encoding, string error = null) => writer is not null ? assertion.Equal(writer.Encoding, encoding, error) : throw new ArgumentNullException(nameof(writer));
}