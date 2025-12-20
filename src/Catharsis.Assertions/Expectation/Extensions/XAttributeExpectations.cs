using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="XAttribute"/> type.</para>
/// </summary>
/// <seealso cref="XAttribute"/>
public static class XAttributeExpectations
{
  /// <param name="expectation">Expectation to be fulfilled.</param>
  extension(IExpectation<XAttribute> expectation)
  {
    /// <summary>
    ///   <para>Expects that the given <see cref="XAttribute"/> has a specified name.</para>
    /// </summary>
    /// <param name="name">Expected attribute name.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="name"/> is <see langword="null"/>.</exception>
    public IExpectation<XAttribute> Name(XName name) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(attribute => attribute.Name == name);

    /// <summary>
    ///   <para>Expects that the given <see cref="XAttribute"/> has a specified value.</para>
    /// </summary>
    /// <param name="value">Expected attribute value.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="value"/> is <see langword="null"/>.</exception>
    public IExpectation<XAttribute> Value(string value) => expectation.HaveSubject().And().ThrowIfNull(value, nameof(value)).And().Expected(attribute => attribute.Value == value);
  }
}