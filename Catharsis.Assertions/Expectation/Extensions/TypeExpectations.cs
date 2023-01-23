namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class TypeExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Type> Abstract(this IExpectation<Type> expectation) => expectation.HaveSubject().And().Expect(type => type.IsAbstract && !type.IsSealed);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Type> Sealed(this IExpectation<Type> expectation) => expectation.HaveSubject().And().Expect(type => type.IsSealed && !type.IsAbstract);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Type> Static(this IExpectation<Type> expectation) => expectation.HaveSubject().And().Expect(type => type.IsAbstract && type.IsSealed);

#if NET7_0
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="target"></param>
  /// <returns></returns>
  public static IExpectation<Type> AssignableTo(this IExpectation<Type> expectation, Type target) => expectation.HaveSubject().And().ThrowIfNull(target, nameof(target)).And().Expect(type => type.IsAssignableTo(target));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Type> AssignableTo<T>(this IExpectation<Type> expectation) => expectation.AssignableTo(typeof(T));
#endif

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="target"></param>
  /// <returns></returns>
  public static IExpectation<Type> AssignableFrom(this IExpectation<Type> expectation, Type target) => expectation.HaveSubject().And().ThrowIfNull(target, nameof(target)).And().Expect(type => type.IsAssignableFrom(target));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Type> AssignableFrom<T>(this IExpectation<Type> expectation) => expectation.AssignableFrom(typeof(T));
}