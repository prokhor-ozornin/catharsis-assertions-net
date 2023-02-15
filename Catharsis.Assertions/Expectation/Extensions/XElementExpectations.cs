using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="XElement"/>
public static class XElementExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="name"></param>
  /// <param name="value"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="name"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<XElement> Attribute(this IExpectation<XElement> expectation, XName name, string value = null) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(element => value is not null ? element.Attributes(name).Any(attribute => attribute.Name == name && attribute.Value == value) : element.Attributes(name).Any(attribute => attribute.Name == name));
}