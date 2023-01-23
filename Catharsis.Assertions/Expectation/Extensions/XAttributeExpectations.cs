using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class XAttributeExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="name"></param>
  /// <returns></returns>
  public static IExpectation<XAttribute> Name(this IExpectation<XAttribute> expectation, XName name) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expect(attribute => attribute.Name == name);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="value"></param>
  /// <returns></returns>
  public static IExpectation<XAttribute> Value(this IExpectation<XAttribute> expectation, string value) => expectation.HaveSubject().And().ThrowIfNull(value, nameof(value)).And().Expect(attribute => attribute.Value == value);
}