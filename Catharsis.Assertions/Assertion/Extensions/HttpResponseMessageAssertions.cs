using System.Net;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="HttpResponseMessage"/> type.</para>
/// </summary>
/// <seealso cref="HttpResponseMessage"/>
public static class HttpResponseMessageAssertions
{
  /// <summary>
  ///   <para>Asserts that a given HTTP response was successful.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="response">HTTP response message to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="response"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Successful(this IAssertion assertion, HttpResponseMessage response, string error = null) => response is not null ? assertion.True(response.IsSuccessStatusCode, error) : throw new ArgumentNullException(nameof(response));

  /// <summary>
  ///   <para>Asserts that a given HTTP response has a specified result status code.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="response">HTTP response message to inspect.</param>
  /// <param name="status">Asserted HTTP status code.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="response"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Status(this IAssertion assertion, HttpResponseMessage response, HttpStatusCode status, string error = null) => response is not null ? assertion.True(response.StatusCode == status, error) : throw new ArgumentNullException(nameof(response));

  /// <summary>
  ///   <para>Asserts that a given HTTP response contains a header with specified name and value.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="response">HTTP response message to inspect.</param>
  /// <param name="name">Asserted HTTP header name.</param>
  /// <param name="value">Asserted HTTP header value.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="response"/>, or <paramref name="name"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Header(this IAssertion assertion, HttpResponseMessage response, string name, string value, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (response is null) throw new ArgumentNullException(nameof(response));
    if (name is null) throw new ArgumentNullException(nameof(name));

    return assertion.Contain(response.Headers.Contains(name) ? response.Headers.GetValues(name) : Enumerable.Empty<string>(), value, null, error);
  }
}