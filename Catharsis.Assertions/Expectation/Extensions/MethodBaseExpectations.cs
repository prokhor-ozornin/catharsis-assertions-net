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
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<MethodBase> Abstract(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsAbstract);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<MethodBase> Final(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsFinal);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<MethodBase> Private(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsPrivate);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<MethodBase> Public(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsPublic);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<MethodBase> Static(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsStatic);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<MethodBase> Virtual(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsVirtual);
}