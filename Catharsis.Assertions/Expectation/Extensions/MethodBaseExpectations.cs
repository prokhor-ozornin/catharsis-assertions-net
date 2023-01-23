using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class MethodBaseExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<MethodBase> Abstract(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expect(method => method.IsAbstract);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<MethodBase> Final(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expect(method => method.IsFinal);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<MethodBase> Private(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expect(method => method.IsPrivate);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<MethodBase> Public(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expect(method => method.IsPublic);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<MethodBase> Static(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expect(method => method.IsStatic);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<MethodBase> Virtual(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expect(method => method.IsVirtual);
}