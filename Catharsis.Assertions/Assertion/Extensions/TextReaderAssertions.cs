namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="TextReader"/> type.</para>
/// </summary>
/// <seealso cref="TextReader"/>
public static class TextReaderAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="reader"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="reader"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion End(this IAssertion assertion, TextReader reader, string error = null) => reader is not null ? assertion.True(reader.Peek() < 0, error) : throw new ArgumentNullException(nameof(reader));
}