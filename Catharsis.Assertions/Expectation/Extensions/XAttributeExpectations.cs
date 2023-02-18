using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para>Set of expectations for <see cref="XAttribute"/> type.</para>
/// </summary>
/// <seealso cref="XAttribute"/>
public static class XAttributeExpectations
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="name"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="name"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<XAttribute> Name(this IExpectation<XAttribute> expectation, XName name) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(attribute => attribute.Name == name);

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="expectation">Expectation to be met.</param>
  /// <param name="value"></param>
  /// <returns>Back reference to the given <paramref name="expectation"/>.</returns>
  /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> reference or has an undefined subject, or <paramref name="value"/> is a <see langword="null"/> reference.</exception>
  public static IExpectation<XAttribute> Value(this IExpectation<XAttribute> expectation, string value) => expectation.HaveSubject().And().ThrowIfNull(value, nameof(value)).And().Expected(attribute => attribute.Value == value);
}