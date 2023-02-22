using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="Assembly"/> class.</para>
/// </summary>
/// <seealso cref="Assembly"/>
public static class AssemblyExpectations
{
  /// <summary>
  ///   <para>Expects that a given assembly contains a definition of the specified type.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="type">Expected type.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="type"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="Define{T}(IExpectation{Assembly})"/>
  public static IExpectation<Assembly> Define(this IExpectation<Assembly> expectation, Type type) => expectation.HaveSubject().And().ThrowIfNull(type, nameof(type)).And().Expected(assembly => assembly.DefinedTypes.Contains(type));

  /// <summary>
  ///   <para>Expects that a given assembly contains a definition of the specified type.</para>
  /// </summary>
  /// <typeparam name="T">Expected type.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Define(IExpectation{Assembly}, Type)"/>
  public static IExpectation<Assembly> Define<T>(this IExpectation<Assembly> expectation) => expectation.Define(typeof(T));

  /// <summary>
  ///   <para>Expects that a given assembly was generated dynamically in the current process with reflection.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<Assembly> Dynamic(this IExpectation<Assembly> expectation) => expectation.HaveSubject().And().Expected(assembly => assembly.IsDynamic);
}