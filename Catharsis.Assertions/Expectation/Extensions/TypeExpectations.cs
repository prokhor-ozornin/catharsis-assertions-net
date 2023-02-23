namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="Type"/> type.</para>
/// </summary>
/// <seealso cref="Type"/>
public static class TypeExpectations
{
  /// <summary>
  ///   <para>Expects that a given type is declared <see langword="abstract"/>.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Type> Abstract(this IExpectation<Type> expectation) => expectation.HaveSubject().And().Expected(type => type.IsAbstract && !type.IsSealed);

  /// <summary>
  ///   <para>Expects that a given type is declared <see langword="sealed"/>.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Type> Sealed(this IExpectation<Type> expectation) => expectation.HaveSubject().And().Expected(type => type.IsSealed && !type.IsAbstract);

  /// <summary>
  ///   <para>Expects that a given type is declared <see langword="static"/>.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Type> Static(this IExpectation<Type> expectation) => expectation.HaveSubject().And().Expected(type => type.IsAbstract && type.IsSealed);

  /// <summary>
  ///   <para>Expects that a given type is of <see langword="public"/> visibility.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Type> Public(this IExpectation<Type> expectation) => expectation.HaveSubject().And().Expected(type => type.IsPublic && type.IsVisible);

  /// <summary>
  ///   <para>Expects that a given type is of <see langword="internal"/> visibility.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Type> Internal(this IExpectation<Type> expectation) => expectation.HaveSubject().And().Expected(type => type.IsNotPublic && !type.IsVisible);

  /// <summary>
  ///   <para>Expects that a given type is derived from a specified type.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="superclass">Expected superclass type.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="superclass"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<Type> Subclass(this IExpectation<Type> expectation, Type superclass) => expectation.HaveSubject().And().ThrowIfNull(superclass, nameof(superclass)).And().Expected(subclass => subclass.IsSubclassOf(superclass));

  /// <summary>
  ///   <para>Expects that a given type is derived from a specified type.</para>
  /// </summary>
  /// <typeparam name="T">Expected superclass type.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Type> Subclass<T>(this IExpectation<Type> expectation) => expectation.Subclass(typeof(T));

  /// <summary>
  ///   <para>Expects that an instance of the given type is assignable from an instance of the specified type.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="from">Asserted assigned type.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="from"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="AssignableFrom{T}(IExpectation{Type})"/>
  public static IExpectation<Type> AssignableFrom(this IExpectation<Type> expectation, Type from) => expectation.HaveSubject().And().ThrowIfNull(from, nameof(from)).And().Expected(it => it.IsAssignableFrom(from));

  /// <summary>
  ///   <para>Expects that an instance of the given type is assignable from an instance of the specified type.</para>
  /// </summary>
  /// <typeparam name="T">Asserted assigned type.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="AssignableFrom(IExpectation{Type}, Type)"/>
  public static IExpectation<Type> AssignableFrom<T>(this IExpectation<Type> expectation) => expectation.AssignableFrom(typeof(T));

#if NET7_0_OR_GREATER
  /// <summary>
  ///   <para>Asserts that an instance of the given type is assignable to an instance of the specified type.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="to">Asserted assigned type.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="to"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="AssignableTo{T}(IExpectation{Type})"/>
  public static IExpectation<Type> AssignableTo(this IExpectation<Type> expectation, Type to) => expectation.HaveSubject().And().ThrowIfNull(to, nameof(to)).And().Expected(it => it.IsAssignableTo(to));

  /// <summary>
  ///   <para>Asserts that an instance of the given type is assignable to an instance of the specified type.</para>
  /// </summary>
  /// <typeparam name="T">Asserted assigned type.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="AssignableTo(IExpectation{Type}, Type)"/>
  public static IExpectation<Type> AssignableTo<T>(this IExpectation<Type> expectation) => expectation.AssignableTo(typeof(T));
  #endif
}