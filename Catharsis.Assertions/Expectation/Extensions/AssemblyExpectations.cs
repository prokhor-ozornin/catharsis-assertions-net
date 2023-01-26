using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="Assembly"/>
public static class AssemblyExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="type"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Define{T}(IExpectation{Assembly})"/>
  public static IExpectation<Assembly> Define(this IExpectation<Assembly> expectation, Type type) => expectation.HaveSubject().And().ThrowIfNull(type, nameof(type)).And().Expected(assembly => assembly.DefinedTypes.Contains(type));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Define(IExpectation{Assembly}, Type)"/>
  public static IExpectation<Assembly> Define<T>(this IExpectation<Assembly> expectation) => expectation.Define(typeof(T));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<Assembly> Dynamic(this IExpectation<Assembly> expectation) => expectation.HaveSubject().And().Expected(assembly => assembly.IsDynamic);
}