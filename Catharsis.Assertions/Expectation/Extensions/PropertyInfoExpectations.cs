using System.Reflection;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class PropertyInfoExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<PropertyInfo> Readable(this IExpectation<PropertyInfo> expectation) => expectation.HaveSubject().And().Expect(property => property.CanRead);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <returns></returns>
  public static IExpectation<PropertyInfo> Writable(this IExpectation<PropertyInfo> expectation) => expectation.HaveSubject().And().Expect(property => property.CanWrite);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="subject"></param>
  /// <param name="value"></param>
  /// <returns></returns>
  public static IExpectation<PropertyInfo> Value(this IExpectation<PropertyInfo> expectation, object subject, object value) => expectation.HaveSubject().And().ThrowIfNull(subject, nameof(subject)).And().Expect(property => Equals(property.GetValue(subject), value));
}