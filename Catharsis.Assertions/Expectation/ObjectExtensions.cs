namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of extension methods for <see cref="object"/> class.</para>
/// </summary>
/// <seealso cref="object"/>
public static class ObjectExtensions
{
  /// <summary>
  ///   <para>Create a new expectation for a target subject.</para>
  /// </summary>
  /// <typeparam name="T">Type of subject.</typeparam>
  /// <param name="subject">Subject instance.</param>
  /// <returns></returns>
  public static IExpectation<T> Expect<T>(this T subject) => new Expectation<T>(subject);
}