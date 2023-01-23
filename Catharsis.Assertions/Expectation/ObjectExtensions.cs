namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class ObjectExtensions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="subject"></param>
  /// <returns></returns>
  public static IExpectation<T> Expect<T>(this T subject) => new Expectation<T>(subject);
}