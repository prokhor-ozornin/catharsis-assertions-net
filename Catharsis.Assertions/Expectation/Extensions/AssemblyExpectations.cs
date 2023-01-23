using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class AssemblyExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="type"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<Assembly> Define(this IExpectation<Assembly> expectation, Type type) => expectation.HaveSubject().And().ThrowIfNull(type, nameof(type)).And().Expect(assembly => assembly.DefinedTypes.Contains(type));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Assembly> Define<T>(this IExpectation<Assembly> expectation) => expectation.Define(typeof(T));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<Assembly> Dynamic(this IExpectation<Assembly> expectation) => expectation.HaveSubject().And().Expect(assembly => assembly.IsDynamic);
}