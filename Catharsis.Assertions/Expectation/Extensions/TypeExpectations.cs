namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="Type"/>
public static class TypeExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<Type> Abstract(this IExpectation<Type> expectation) => expectation.HaveSubject().And().Expected(type => type.IsAbstract && !type.IsSealed);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<Type> Sealed(this IExpectation<Type> expectation) => expectation.HaveSubject().And().Expected(type => type.IsSealed && !type.IsAbstract);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<Type> Static(this IExpectation<Type> expectation) => expectation.HaveSubject().And().Expected(type => type.IsAbstract && type.IsSealed);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="target"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="AssignableFrom{T}(IExpectation{Type})"/>
  public static IExpectation<Type> AssignableFrom(this IExpectation<Type> expectation, Type target) => expectation.HaveSubject().And().ThrowIfNull(target, nameof(target)).And().Expected(type => type.IsAssignableFrom(target));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="AssignableFrom(IExpectation{Type}, Type)"/>
  public static IExpectation<Type> AssignableFrom<T>(this IExpectation<Type> expectation) => expectation.AssignableFrom(typeof(T));

  #if NET7_0_OR_GREATER
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="target"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="AssignableTo{T}(IExpectation{Type})"/>
  public static IExpectation<Type> AssignableTo(this IExpectation<Type> expectation, Type target) => expectation.HaveSubject().And().ThrowIfNull(target, nameof(target)).And().Expected(type => type.IsAssignableTo(target));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="AssignableTo(IExpectation{Type}, Type)"/>
  public static IExpectation<Type> AssignableTo<T>(this IExpectation<Type> expectation) => expectation.AssignableTo(typeof(T));
  #endif
}