using System.Text;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="StreamWriter"/>
public static class StreamWriterAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="writer"></param>
  /// <param name="encoding"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Encoding(this IAssertion assertion, StreamWriter writer, Encoding encoding, string error = null) => writer is not null ? assertion.Equal(writer.Encoding, encoding, error) : throw new ArgumentNullException(nameof(writer));
}