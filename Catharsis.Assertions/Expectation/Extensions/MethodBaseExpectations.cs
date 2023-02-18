using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="MethodBase"/> type.</para>
/// </summary>
/// <seealso cref="MethodBase"/>
public static class MethodBaseExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<MethodBase> Abstract(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsAbstract);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<MethodBase> Final(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsFinal);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<MethodBase> Virtual(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsVirtual);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<MethodBase> Overridable(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsVirtual && !method.IsFinal);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<MethodBase> Private(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsPrivate);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<MethodBase> Protected(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsFamily);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<MethodBase> Public(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsPublic);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<MethodBase> Internal(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsAssembly);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<MethodBase> ProtectedInternal(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsFamilyOrAssembly);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<MethodBase> Static(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsStatic);
}