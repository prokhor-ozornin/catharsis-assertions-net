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
  /// <param name="value"></param>
  /// <returns></returns>
  public static IExpectation<HttpContent> Header(this IExpectation<HttpContent> expectation, string name, string value) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expect(content => content.Headers.GetValues(name).Contains(value));
}