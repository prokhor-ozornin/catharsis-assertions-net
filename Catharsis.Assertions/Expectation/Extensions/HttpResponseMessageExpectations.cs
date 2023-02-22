using System.Net;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="HttpResponseMessage"/> type.</para>
/// </summary>
/// <seealso cref="HttpResponseMessage"/>
public static class HttpResponseMessageExpectations
{
  /// <summary>
  ///   <para>Expects that a given HTTP response was successful.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<HttpResponseMessage> Successful(this IExpectation<HttpResponseMessage> expectation) => expectation.HaveSubject().And().Expected(response => response.IsSuccessStatusCode);

  /// <summary>
  ///   <para>Expects that a given HTTP response has a specified result status code.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="status">Expected HTTP status code.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<HttpResponseMessage> Status(this IExpectation<HttpResponseMessage> expectation, HttpStatusCode status) => expectation.HaveSubject().And().Expected(response => response.StatusCode == status);

  /// <summary>
  ///   <para>Expects that a given HTTP response contains a header with specified name and value.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="name">Expected HTTP header name.</param>
  /// <param name="value">Expected HTTP header value.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="name"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<HttpResponseMessage> Header(this IExpectation<HttpResponseMessage> expectation, string name, string value) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(response => response.Headers.Contains(name) && response.Headers.GetValues(name).Contains(value));
}