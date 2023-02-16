using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="Assembly"/> class.</para>
/// </summary>
/// <seealso cref="Assembly"/>
public static class AssemblyAssertions
{
  /// <summary>
  ///   <para>Asserts that a given assembly contains a definition of the specified type.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="assembly">Assembly to search for a type definition.</param>
  /// <param name="type">Type to look for.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="assembly"/>, or <paramref name="type"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Define{T}(IAssertion, Assembly, string)"/> 
  public static IAssertion Define(this IAssertion assertion, Assembly assembly, Type type, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (assembly is null) throw new ArgumentNullException(nameof(assembly));
    if (type is null) throw new ArgumentNullException(nameof(type));

    return assertion.Contain(assembly.DefinedTypes, type, null, error);
  }

  /// <summary>
  ///   <para>Asserts that a given assembly contains a definition of the specified type.</para>
  /// </summary>
  /// <typeparam name="T">Type to look for.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="assembly">Assembly to search for a type definition.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="assembly"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Define(IAssertion, Assembly, Type, string)"/>
  public static IAssertion Define<T>(this IAssertion assertion, Assembly assembly, string error = null) => assertion.Define(assembly, typeof(T), error);

  /// <summary>
  ///   <para>Asserts that a given assembly was generated dynamically in the current process with reflection.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="assembly">Assembly to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="assembly"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Dynamic(this IAssertion assertion, Assembly assembly, string error = null) => assembly is not null ? assertion.True(assembly.IsDynamic, error) : throw new ArgumentNullException(nameof(assembly));
}