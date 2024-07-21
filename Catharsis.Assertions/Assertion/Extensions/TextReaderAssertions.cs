namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="TextReader"/> type.</para>
/// </summary>
/// <seealso cref="TextReader"/>
public static class TextReaderAssertions
{
  /// <summary>
  ///   <para>This function asserts that the given <see cref="TextReader"/> has no more available characters to read.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="reader">Text reader to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="reader"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion End(this IAssertion assertion, TextReader reader, string error = null) => reader is not null ? assertion.True(reader.Peek() < 0, error) : throw new ArgumentNullException(nameof(reader));
}