namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="HttpContent"/> type.</para>
/// </summary>
/// <seealso cref="HttpContent"/>
public static class HttpContentExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="HttpContent"/> contains a header with the specified name.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="name">Expected name of HTTP header.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="name"/> is <see langword="null"/>.</exception>
  public static IExpectation<HttpContent> ContainHeader(this IExpectation<HttpContent> expectation, string name) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(content => content.Headers.Contains(name));
}