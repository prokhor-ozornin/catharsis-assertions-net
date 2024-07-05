namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="HttpContent"/> type.</para>
/// </summary>
/// <seealso cref="HttpContent"/>
public static class HttpContentAssertions
{
  /// <summary>
  ///   <para>This function asserts that the given HTTP content instance contains a header with the specified name.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="content">Content instance to inspect.</param>
  /// <param name="name">Asserted name of HTTP header.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="content"/>, or <paramref name="name"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion ContainHeader(this IAssertion assertion, HttpContent content, string name, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (content is null) throw new ArgumentNullException(nameof(content));
    if (name is null) throw new ArgumentNullException(nameof(name));

    return assertion.True(content.Headers.Contains(name), error);
  }
}