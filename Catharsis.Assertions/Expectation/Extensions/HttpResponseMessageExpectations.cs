using System.Net;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="HttpResponseMessage"/> type.</para>
/// </summary>
/// <seealso cref="HttpResponseMessage"/>
public static class HttpResponseMessageExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<HttpResponseMessage> Successful(this IExpectation<HttpResponseMessage> expectation) => expectation.HaveSubject().And().Expected(response => response.IsSuccessStatusCode);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="status"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<HttpResponseMessage> Status(this IExpectation<HttpResponseMessage> expectation, HttpStatusCode status) => expectation.HaveSubject().And().Expected(response => response.StatusCode == status);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="name"></param>
  /// <param name="value"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="name"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<HttpResponseMessage> Header(this IExpectation<HttpResponseMessage> expectation, string name, string value) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(response => response.Headers.Contains(name) && response.Headers.GetValues(name).Contains(value));
}