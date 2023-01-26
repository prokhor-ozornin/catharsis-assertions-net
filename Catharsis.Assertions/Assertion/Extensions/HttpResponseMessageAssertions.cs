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
  /// <param name="assertion"></param>
  /// <param name="response"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Successful(this IAssertion assertion, HttpResponseMessage response, string message = null) => response is not null ? assertion.True(response.IsSuccessStatusCode, message) : throw new ArgumentNullException(nameof(response));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="response"></param>
  /// <param name="status"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Status(this IAssertion assertion, HttpResponseMessage response, HttpStatusCode status, string message = null) => response is not null ? assertion.True(response.StatusCode == status, message) : throw new ArgumentNullException(nameof(response));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="response"></param>
  /// <param name="name"></param>
  /// <param name="value"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Header(this IAssertion assertion, HttpResponseMessage response, string name, string value, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (response is null) throw new ArgumentNullException(nameof(response));
    if (name is null) throw new ArgumentNullException(nameof(name));

    return assertion.Contain(response.Headers.GetValues(name), value, null, message);
  }
}