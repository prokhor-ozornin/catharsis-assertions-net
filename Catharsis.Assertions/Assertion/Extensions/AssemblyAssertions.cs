using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class AssemblyAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="assembly"></param>
  /// <param name="type"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Define(this IAssertion assertion, Assembly assembly, Type type, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (assembly is null) throw new ArgumentNullException(nameof(assembly));
    if (type is null) throw new ArgumentNullException(nameof(type));

    return assertion.Contain(assembly.DefinedTypes, type, null, message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="assembly"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Define<T>(this IAssertion assertion, Assembly assembly, string message = null) => assertion.Define(assembly, typeof(T), message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="assembly"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <exception cref="ArgumentException"></exception>
  public static IAssertion Dynamic(this IAssertion assertion, Assembly assembly, string message = null) => assembly is not null ? assertion.True(assembly.IsDynamic, message) : throw new ArgumentNullException(nameof(assembly));
}