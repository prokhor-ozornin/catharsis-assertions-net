using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="XElement"/> type.</para>
/// </summary>
/// <seealso cref="XElement"/>
public static class XElementExpectations
{
  /// <param name="expectation">Expectation to be fulfilled.</param>
  extension(IExpectation<XElement> expectation)
  {
    /// <summary>
    ///   <para>Expects that the given <see cref="XElement"/> has an attribute with the specified name and value.</para>
    /// </summary>
    /// <param name="name">Expected attribute name.</param>
    /// <param name="value">Expected attribute value or <see langword="null"/> to skip value check.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="name"/> is <see langword="null"/>.</exception>
    public IExpectation<XElement> Attribute(XName name, string value = null) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(element => value is not null ? element.Attributes(name).Any(attribute => attribute.Name == name && attribute.Value == value) : element.Attributes(name).Any(attribute => attribute.Name == name));
  }
}