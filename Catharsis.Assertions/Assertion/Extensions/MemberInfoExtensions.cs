using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="MemberInfo"/>
public static class MemberInfoAssertions
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="member"></param>
  /// <param name="type"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Attribute{T}(IAssertion, MemberInfo, string)"/>
  public static IAssertion Attribute(this IAssertion assertion, MemberInfo member, Type type, string message = null)
  {
    if (assertion is null) throw new ArgumentNullException(nameof(assertion));
    if (member is null) throw new ArgumentNullException(nameof(member));
    if (type is null) throw new ArgumentNullException(nameof(type));

    return assertion.True(member.GetCustomAttribute(type) is not null, message);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="assertion"></param>
  /// <param name="member"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <seealso cref="Attribute(IAssertion, MemberInfo, System.Type, string)"/>
  public static IAssertion Attribute<T>(this IAssertion assertion, MemberInfo member, string message = null) where T : Attribute => assertion.Attribute(member, typeof(T), message);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="assertion"></param>
  /// <param name="member"></param>
  /// <param name="type"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IAssertion Type(this IAssertion assertion, MemberInfo member, MemberTypes type, string message = null) => member is not null ? assertion.True(member.MemberType == type, message) : throw new ArgumentNullException(nameof(member));
}