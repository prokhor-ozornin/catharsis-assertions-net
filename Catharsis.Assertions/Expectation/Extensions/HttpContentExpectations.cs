namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class HttpContentExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="name"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<HttpContent> ContainHeader(this IExpectation<HttpContent> expectation, string name) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(content => content.Headers.Contains(name));
}