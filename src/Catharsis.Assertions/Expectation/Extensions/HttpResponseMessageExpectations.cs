using System.Net;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="HttpResponseMessage"/> type.</para>
/// </summary>
/// <seealso cref="HttpResponseMessage"/>
public static class HttpResponseMessageExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="HttpResponseMessage"/> was successful.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<HttpResponseMessage> Successful(this IExpectation<HttpResponseMessage> expectation) => expectation.HaveSubject().And().Expected(response => response.IsSuccessStatusCode);

  /// <summary>
  ///   <para>Expects that the given <see cref="HttpResponseMessage"/> has the specified result status code.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="status">Expected HTTP status code.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<HttpResponseMessage> Status(this IExpectation<HttpResponseMessage> expectation, HttpStatusCode status) => expectation.HaveSubject().And().Expected(response => response.StatusCode == status);

  /// <summary>
  ///   <para>Expects that the given <see cref="HttpResponseMessage"/> contains a header with the specified name and value.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="name">Expected HTTP header's name.</param>
  /// <param name="value">Expected HTTP header's value.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="name"/> is <see langword="null"/>.</exception>
  public static IExpectation<HttpResponseMessage> Header(this IExpectation<HttpResponseMessage> expectation, string name, string value) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(response => response.Headers.Contains(name) && response.Headers.GetValues(name).Contains(value));
}