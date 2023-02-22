namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="HttpContent"/> type.</para>
/// </summary>
/// <seealso cref="HttpContent"/>
public static class HttpContentAssertions
{
  /// <summary>
  ///   <para>Asserts that a given HTTP content instance contains a header with specified name.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="content">Content instance to inspect.</param>
  /// <param name="name">Asserted HTTP header name.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="content"/>, or <paramref name="name"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ContainHeader(this IAssertion assertion, HttpContent content, string name, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (content is null) throw new ArgumentNullException(nameof(content));
    if (name is null) throw new ArgumentNullException(nameof(name));

    return assertion.True(content.Headers.Contains(name), error);
  }
}