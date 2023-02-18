namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="Type"/> type.</para>
/// </summary>
/// <seealso cref="Type"/>
public static class TypeExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Type> Abstract(this IExpectation<Type> expectation) => expectation.HaveSubject().And().Expected(type => type.IsAbstract && !type.IsSealed);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Type> Sealed(this IExpectation<Type> expectation) => expectation.HaveSubject().And().Expected(type => type.IsSealed && !type.IsAbstract);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Type> Static(this IExpectation<Type> expectation) => expectation.HaveSubject().And().Expected(type => type.IsAbstract && type.IsSealed);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Type> Public(this IExpectation<Type> expectation) => expectation.HaveSubject().And().Expected(type => type.IsPublic && type.IsVisible);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Type> Internal(this IExpectation<Type> expectation) => expectation.HaveSubject().And().Expected(type => type.IsNotPublic && !type.IsVisible);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="type"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="type"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<Type> Subclass(this IExpectation<Type> expectation, Type type) => expectation.HaveSubject().And().ThrowIfNull(type, nameof(type)).And().Expected(subclass => subclass.IsSubclassOf(type));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Type> Subclass<T>(this IExpectation<Type> expectation) => expectation.Subclass(typeof(T));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="type"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="type"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="AssignableFrom{T}(IExpectation{Type})"/>
  public static IExpectation<Type> AssignableFrom(this IExpectation<Type> expectation, Type type) => expectation.HaveSubject().And().ThrowIfNull(type, nameof(type)).And().Expected(it => it.IsAssignableFrom(type));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="AssignableFrom(IExpectation{Type}, Type)"/>
  public static IExpectation<Type> AssignableFrom<T>(this IExpectation<Type> expectation) => expectation.AssignableFrom(typeof(T));

#if NET7_0_OR_GREATER
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="type"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="type"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="AssignableTo{T}(IExpectation{Type})"/>
  public static IExpectation<Type> AssignableTo(this IExpectation<Type> expectation, Type type) => expectation.HaveSubject().And().ThrowIfNull(type, nameof(type)).And().Expected(it => it.IsAssignableTo(type));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="AssignableTo(IExpectation{Type}, Type)"/>
  public static IExpectation<Type> AssignableTo<T>(this IExpectation<Type> expectation) => expectation.AssignableTo(typeof(T));
  #endif
}