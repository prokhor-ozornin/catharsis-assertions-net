using System.Xml.Linq;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="XContainer"/> type.</para>
/// </summary>
/// <seealso cref="XContainer"/>
public static class XContainerExpectations
{
  /// <param name="expectation">Expectation to be fulfilled.</param>
  extension(IExpectation<XContainer> expectation)
  {
    /// <summary>
    ///   <para>Expects that the given <see cref="XContainer"/> has a child element with the specified name.</para>
    /// </summary>
    /// <param name="name">Expected element name.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject, or <paramref name="name"/> is <see langword="null"/>.</exception>
    public IExpectation<XContainer> Element(XName name) => expectation.HaveSubject().And().ThrowIfNull(name, nameof(name)).And().Expected(container => container.Elements(name).Any());

    /// <summary>
    ///   <para>Expects that the given <see cref="XContainer"/> is empty, meaning it contains no child nodes.</para>
    /// </summary>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<XContainer> Empty() => expectation.HaveSubject().And().Expected(container => !container.Nodes().Any());
  }
}