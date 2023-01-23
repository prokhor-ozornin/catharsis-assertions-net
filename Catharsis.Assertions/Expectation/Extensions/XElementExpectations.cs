using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
public static class XElementExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation"></param>
  /// <param name="name"></param>
  /// <param name="value"></param>
  /// <returns></returns>
  public static IExpectation<XElement> Attribute(this IExpectation<XElement> expectation, XName name, string value = null) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expect(element => value is not null ? element.Attributes(name).Any(attribute => attribute.Name == name && attribute.Value == value) : element.Attributes(name).Any(attribute => attribute.Name == name));
}