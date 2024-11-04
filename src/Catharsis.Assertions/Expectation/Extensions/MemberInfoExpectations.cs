using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="MemberInfo"/> type.</para>
/// </summary>
/// <seealso cref="MemberInfo"/>
public static class MemberInfoExpectations
{
  /// <summary>
  ///   <para>Expects that the given <see cref="Type"/> has a <see cref="MemberInfo"/> that is decorated with the specified custom attribute.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="type">Expected attribute's type.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="type"/> is <see langword="null"/>.</exception>
  /// <seealso cref="Attribute{T}(IExpectation{MemberInfo})"/>
  public static IExpectation<MemberInfo> Attribute(this IExpectation<MemberInfo> expectation, Type type) => expectation.HaveSubject().And().ThrowIfNull(type, nameof(type)).And().Expected(member => member.GetCustomAttribute(type) is not null);

  /// <summary>
  ///   <para>Expects that the given <see cref="Type"/> has a <see cref="MemberInfo"/> that is decorated with the specified custom attribute.</para>
  /// </summary>
  /// <typeparam name="T">Expected attribute's type.</typeparam>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  /// <seealso cref="Attribute(IExpectation{MemberInfo}, System.Type)"/>
  public static IExpectation<MemberInfo> Attribute<T>(this IExpectation<MemberInfo> expectation) where T : Attribute => expectation.Attribute(typeof(T));

  /// <summary>
  ///   <para>Expects that the given <see cref="MemberInfo"/> is of the expected <see cref="MemberTypes"/>.</para>
  /// </summary>
  /// <param name="expectation">Expectation to be fulfilled.</param>
  /// <param name="type">Asserted member's type.</param>
  /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
  public static IExpectation<MemberInfo> Type(this IExpectation<MemberInfo> expectation, MemberTypes type) => expectation.HaveSubject().And().Expected(member => member.MemberType == type);
}