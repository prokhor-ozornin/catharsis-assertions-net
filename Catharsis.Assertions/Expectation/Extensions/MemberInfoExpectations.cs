using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class MemberInfoExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="type"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Attribute{T}(IExpectation{MemberInfo})"/>
  public static IExpectation<MemberInfo> Attribute(this IExpectation<MemberInfo> expectation, Type type) => expectation.HaveSubject().And().ThrowIfNull(type, nameof(type)).And().Expected(member => member.GetCustomAttribute(type) is not null);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <see cref="Attribute(IExpectation{MemberInfo}, System.Type)"/>
  public static IExpectation<MemberInfo> Attribute<T>(this IExpectation<MemberInfo> expectation) where T : Attribute => expectation.Attribute(typeof(T));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="type"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static IExpectation<MemberInfo> Type(this IExpectation<MemberInfo> expectation, MemberTypes type) => expectation.HaveSubject().And().Expected(member => member.MemberType == type);
}