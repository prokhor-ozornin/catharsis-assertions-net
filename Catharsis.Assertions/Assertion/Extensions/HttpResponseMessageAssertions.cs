using System.Net;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="HttpResponseMessage"/>
public static class HttpResponseMessageAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="response"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="response"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Successful(this IAssertion assertion, HttpResponseMessage response, string error = null) => response is not null ? assertion.True(response.IsSuccessStatusCode, error) : throw new ArgumentNullException(nameof(response));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="response"></param>
  /// <param name="status"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="response"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Status(this IAssertion assertion, HttpResponseMessage response, HttpStatusCode status, string error = null) => response is not null ? assertion.True(response.StatusCode == status, error) : throw new ArgumentNullException(nameof(response));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="response"></param>
  /// <param name="name"></param>
  /// <param name="value"></param>
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