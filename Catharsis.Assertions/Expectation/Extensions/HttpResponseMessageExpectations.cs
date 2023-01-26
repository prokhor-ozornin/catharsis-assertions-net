using System.Net;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="HttpResponseMessage"/>
public static class HttpResponseMessageExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<HttpResponseMessage> Successful(this IExpectation<HttpResponseMessage> expectation) => expectation.HaveSubject().And().Expected(response => response.IsSuccessStatusCode);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="status"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<HttpResponseMessage> Status(this IExpectation<HttpResponseMessage> expectation, HttpStatusCode status) => expectation.HaveSubject().And().Expected(response => response.StatusCode == status);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="name"></param>
  /// <param name="value"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<HttpResponseMessage> Header(this IExpectation<HttpResponseMessage> expectation, string name, string value) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(response => response.Headers.GetValues(name).Contains(value));
}