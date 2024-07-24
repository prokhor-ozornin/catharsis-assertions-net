using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="MethodBase"/> type.</para>
/// </summary>
/// <seealso cref="MethodBase"/>
public static class MethodBaseExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="MethodBase"/> represents an <see langword="abstract"/> method.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<MethodBase> Abstract(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsAbstract);

  /// <summary>
  ///   <para>Expects that the given <see cref="MethodBase"/> represents a <see langword="static"/> method.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<MethodBase> Static(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsStatic);

  /// <summary>
  ///   <para>Expects that the given <see cref="MethodBase"/> represents a <see langword="final"/> method.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<MethodBase> Final(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsFinal);

  /// <summary>
  ///   <para>Expects that the given <see cref="MethodBase"/> represents a <see langword="virtual"/> method.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<MethodBase> Virtual(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsVirtual);

  /// <summary>
  ///   <para>Expects that the given <see cref="MethodBase"/> represents a method that can be overriden by subclasses.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<MethodBase> Overridable(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsVirtual && !method.IsFinal);

  /// <summary>
  ///   <para>Expects that the given <see cref="MethodBase"/> represents a method with <see langword="private"/> visibility.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<MethodBase> Private(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsPrivate);

  /// <summary>
  ///   <para>Expects that the given <see cref="MethodBase"/> represents a method with <see langword="protected"/> visibility.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<MethodBase> Protected(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsFamily);

  /// <summary>
  ///   <para>Expects that the given <see cref="MethodBase"/> represents a method with <see langword="public"/> visibility.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<MethodBase> Public(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsPublic);

  /// <summary>
  ///   <para>Expects that the specified <see cref="MethodBase"/> has <see langword="internal"/> visibility.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<MethodBase> Internal(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsAssembly);

  /// <summary>
  ///   <para>Expects that the given <see cref="MethodBase"/> represents a method with <see langword="protected internal"/> visibility.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<MethodBase> ProtectedInternal(this IExpectation<MethodBase> expectation) => expectation.HaveSubject().And().Expected(method => method.IsFamilyOrAssembly);
}