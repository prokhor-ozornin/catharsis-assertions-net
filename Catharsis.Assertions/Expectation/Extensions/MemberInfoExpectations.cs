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
  public static IExpectation<MemberInfo> Attribute(this IExpectation<MemberInfo> expectation, Type type) => expectation.HaveSubject().And().ThrowIfNull(type, nameof(type)).And().Expect(member => member.GetCustomAttribute(type) is not null);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<MemberInfo> Attribute<T>(this IExpectation<MemberInfo> expectation) where T : Attribute => expectation.Attribute(typeof(T));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="type"></param>
  /// <returns></returns>
  public static IExpectation<MemberInfo> Type(this IExpectation<MemberInfo> expectation, MemberTypes type) => expectation.HaveSubject().And().Expect(member => member.MemberType == type);
}