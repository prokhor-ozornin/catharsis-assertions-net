using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="Assembly"/> type.</para>
/// </summary>
/// <seealso cref="Assembly"/>
public static class AssemblyAssertions
{
  /// <summary>
  ///   <para>This function asserts that the given <see cref="Assembly"/> defines a specified type.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="assembly">Assembly to inspect.</param>
  /// <param name="type">Asserted type.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="assembly"/>, or <paramref name="type"/> is <see langword="null"/>.</exception>
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
  ///   <para>This function asserts that the given <see cref="Assembly"/> defines a specified type.</para>
  /// </summary>
  /// <typeparam name="T">Asserted type.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="assembly">Assembly to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="assembly"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Define(IAssertion, Assembly, Type, string)"/>
  public static IAssertion Define<T>(this IAssertion assertion, Assembly assembly, string error = null) => assertion.Define(assembly, typeof(T), error);

  /// <summary>
  ///   <para>This function asserts that the given <see cref="Assembly"/> was dynamically generated in the current process using reflection.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="assembly">Assembly to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="assembly"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Dynamic(this IAssertion assertion, Assembly assembly, string error = null) => assembly is not null ? assertion.True(assembly.IsDynamic, error) : throw new ArgumentNullException(nameof(assembly));
}