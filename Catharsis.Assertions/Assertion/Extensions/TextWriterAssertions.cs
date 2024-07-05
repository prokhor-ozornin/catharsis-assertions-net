namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="TextWriter"/> type.</para>
/// </summary>
/// <seealso cref="TextWriter"/>
public static class TextWriterAssertions
{
  /// <summary>
  ///   <para>This function asserts that the given text writer has a specified format provider that controls formatting.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="writer">Text writer to inspect.</param>
  /// <param name="format">Asserted object that controls formatting.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="writer"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Format(this IAssertion assertion, TextWriter writer, IFormatProvider format, string error = null) => writer is not null ? assertion.Equal(writer.FormatProvider, format, error) : throw new ArgumentNullException(nameof(writer));
}