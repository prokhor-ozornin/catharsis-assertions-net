using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of assertions for <see cref="MemberInfo"/> type.</para>
/// </summary>
/// <seealso cref="MemberInfo"/>
public static class MemberInfoAssertions
{
  /// <summary>
  ///   <para>Asserts that a given type's member is decorated with a custom attribute of specified type.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="member">Type's member to inspect.</param>
  /// <param name="type">Asserted custom attribute type.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="member"/>, or <paramref name="type"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Attribute{T}(IAssertion, MemberInfo, string)"/>
  public static IAssertion Attribute(this IAssertion assertion, MemberInfo member, Type type, string error = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (member is null) throw new ArgumentNullException(nameof(member));
    if (type is null) throw new ArgumentNullException(nameof(type));

    return assertion.True(member.GetCustomAttribute(type) is not null, error);
  }

  /// <summary>
  ///   <para>Asserts that a given type's member is decorated with a custom attribute of specified type.</para>
  /// </summary>
  /// <typeparam name="T">Asserted custom attribute type.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="member">Type's member to inspect.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="member"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Attribute(IAssertion, MemberInfo, System.Type, string)"/>
  public static IAssertion Attribute<T>(this IAssertion assertion, MemberInfo member, string error = null) where T : Attribute => assertion.Attribute(member, typeof(T), error);

  /// <summary>
  ///   <para>Asserts that a given type's member is of specified type.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="member">Type's member to inspect.</param>
  /// <param name="type">Asserted member type.</param>
  /// <param name="error">Error description phrase for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="member"/> is a <see langword="null"/> reference.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Type(this IAssertion assertion, MemberInfo member, MemberTypes type, string error = null) => member is not null ? assertion.True(member.MemberType == type, error) : throw new ArgumentNullException(nameof(member));
}