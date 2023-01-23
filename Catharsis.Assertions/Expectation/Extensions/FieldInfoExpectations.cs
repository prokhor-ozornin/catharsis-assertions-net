using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class FieldInfoExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="type"></param>
  /// <returns></returns>
  public static IExpectation<FieldInfo> Type(this IExpectation<FieldInfo> expectation, Type type) => expectation.HaveSubject().And().ThrowIfNull(type, nameof(type)).And().Expect(field => field.FieldType == type);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<FieldInfo> Type<T>(this IExpectation<FieldInfo> expectation) => expectation.Type(typeof(T));

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<FieldInfo> Private(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expect(field => field.IsPrivate);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<FieldInfo> Public(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expect(field => field.IsPublic);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<FieldInfo> Static(this IExpectation<FieldInfo> expectation) => expectation.HaveSubject().And().Expect(field => field.IsStatic);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="subject"></param>
  /// <param name="value"></param>
  /// <returns></returns>
  public static IExpectation<FieldInfo> Value(this IExpectation<FieldInfo> expectation, object subject, object value) => expectation.HaveSubject().And().ThrowIfNull(subject, nameof(subject)).And().Expect(field => Equals(field.GetValue(subject), value));
}