using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="MemberInfo"/> type.</para>
/// </summary>
/// <seealso cref="MemberInfo"/>
public static class MemberInfoAssertions
{
  /// <summary>
  ///   <para>Asserts that the given <see cref="Type"/> has a <see cref="MemberInfo"/> that is decorated with the specified custom attribute.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="member">Type's member to inspect.</param>
  /// <param name="type">Asserted attribute's type.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/>, <paramref name="member"/>, or <paramref name="type"/> is <see langword="null"/>.</exception>
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
  ///   <para>Asserts that the given <see cref="Type"/> has a <see cref="MemberInfo"/> that is decorated with the specified custom attribute.</para>
  /// </summary>
  /// <typeparam name="T">Asserted attribute's type.</typeparam>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="member">Type's member to inspect.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="member"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  /// <seealso cref="Attribute(IAssertion, MemberInfo, System.Type, string)"/>
  public static IAssertion Attribute<T>(this IAssertion assertion, MemberInfo member, string error = null) where T : Attribute => assertion.Attribute(member, typeof(T), error);

  /// <summary>
  ///   <para>Asserts that the given <see cref="MemberInfo"/> is of the expected <see cref="MemberTypes"/>.</para>
  /// </summary>
  /// <param name="assertion">Assertion to validate.</param>
  /// <param name="member">Type's member to inspect.</param>
  /// <param name="type">Asserted member's type.</param>
  /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
  /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
  /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="member"/> is <see langword="null"/>.</exception>
  /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
  public static IAssertion Type(this IAssertion assertion, MemberInfo member, MemberTypes type, string error = null) => member is not null ? assertion.True(member.MemberType == type, error) : throw new ArgumentNullException(nameof(member));
}