using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="MemberInfo"/> type.</para>
/// </summary>
/// <seealso cref="MemberInfo"/>
public static class MemberInfoExpectations
{
  /// <summary>
  ///   <para>Expects that a given type's member is decorated with a custom attribute of specified type.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="type">Type of the custom attribute.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="type"/> is a <see langword="null"/> reference.</exception>
  /// <seealso cref="Attribute{T}(IExpectation{MemberInfo})"/>
  public static IExpectation<MemberInfo> Attribute(this IExpectation<MemberInfo> expectation, Type type) => expectation.HaveSubject().And().ThrowIfNull(type, nameof(type)).And().Expected(member => member.GetCustomAttribute(type) is not null);

  /// <summary>
  ///   <para>Expects that a given type's member is decorated with a custom attribute of specified type.</para>
  /// </summary>
  /// <typeparam name="T">Type of the custom attribute.</typeparam>
  /// <param name="expectation">Expectation to be met.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  /// <seealso cref="Attribute(IExpectation{MemberInfo}, System.Type)"/>
  public static IExpectation<MemberInfo> Attribute<T>(this IExpectation<MemberInfo> expectation) where T : Attribute => expectation.Attribute(typeof(T));

  /// <summary>
  ///   <para>Expects that a given type's member is of specified type.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="type">Type of the member.</param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject.</exception>
  public static IExpectation<MemberInfo> Type(this IExpectation<MemberInfo> expectation, MemberTypes type) => expectation.HaveSubject().And().Expected(member => member.MemberType == type);
}