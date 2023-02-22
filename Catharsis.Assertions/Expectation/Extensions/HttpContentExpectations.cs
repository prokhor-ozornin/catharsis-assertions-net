namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="HttpContent"/> type.</para>
/// </summary>
/// <seealso cref="HttpContent"/>
public static class HttpContentExpectations
{
  /// <summary>
  ///   <para>Expects that a given HTTP content instance contains a header with specified name.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="name">Expected HTTP header name.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="name"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<HttpContent> ContainHeader(this IExpectation<HttpContent> expectation, string name) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(content => content.Headers.Contains(name));
}