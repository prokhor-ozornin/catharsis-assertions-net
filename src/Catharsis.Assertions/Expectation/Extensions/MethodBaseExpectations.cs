using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="MethodBase"/> type.</para>
/// </summary>
/// <seealso cref="MethodBase"/>
public static class MethodBaseExpectations
{
  /// <param name="expectation">Expectation to be fulfilled.</param>
  extension(IExpectation<MethodBase> expectation)
  {
    /// <summary>
    ///   <para>Expects that the given <see cref="MethodBase"/> represents an <see langword="abstract"/> method.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<MethodBase> Abstract() => expectation.HaveSubject().And().Expected(method => method.IsAbstract);

    /// <summary>
    ///   <para>Expects that the given <see cref="MethodBase"/> represents a <see langword="static"/> method.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<MethodBase> Static() => expectation.HaveSubject().And().Expected(method => method.IsStatic);

    /// <summary>
    ///   <para>Expects that the given <see cref="MethodBase"/> represents a <see langword="final"/> method.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<MethodBase> Final() => expectation.HaveSubject().And().Expected(method => method.IsFinal);

    /// <summary>
    ///   <para>Expects that the given <see cref="MethodBase"/> represents a <see langword="virtual"/> method.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<MethodBase> Virtual() => expectation.HaveSubject().And().Expected(method => method.IsVirtual);

    /// <summary>
    ///   <para>Expects that the given <see cref="MethodBase"/> represents a method that can be overriden by subclasses.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<MethodBase> Overridable() => expectation.HaveSubject().And().Expected(method => method.IsVirtual && !method.IsFinal);

    /// <summary>
    ///   <para>Expects that the given <see cref="MethodBase"/> represents a method with <see langword="private"/> visibility.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<MethodBase> Private() => expectation.HaveSubject().And().Expected(method => method.IsPrivate);

    /// <summary>
    ///   <para>Expects that the given <see cref="MethodBase"/> represents a method with <see langword="protected"/> visibility.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<MethodBase> Protected() => expectation.HaveSubject().And().Expected(method => method.IsFamily);

    /// <summary>
    ///   <para>Expects that the given <see cref="MethodBase"/> represents a method with <see langword="public"/> visibility.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<MethodBase> Public() => expectation.HaveSubject().And().Expected(method => method.IsPublic);

    /// <summary>
    ///   <para>Expects that the specified <see cref="MethodBase"/> has <see langword="internal"/> visibility.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<MethodBase> Internal() => expectation.HaveSubject().And().Expected(method => method.IsAssembly);

    /// <summary>
    ///   <para>Expects that the given <see cref="MethodBase"/> represents a method with <see langword="protected internal"/> visibility.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<MethodBase> ProtectedInternal() => expectation.HaveSubject().And().Expected(method => method.IsFamilyOrAssembly);
  }
}