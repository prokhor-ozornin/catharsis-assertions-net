namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class HttpContentAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="content"></param>
  /// <param name="name"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion ContainHeader(this IAssertion assertion, HttpContent content, string name, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (content is null) throw new ArgumentNullException(nameof(content));
    if (name is null) throw new ArgumentNullException(nameof(name));

    return assertion.True(content.Headers.Contains(name), message);
  }
}