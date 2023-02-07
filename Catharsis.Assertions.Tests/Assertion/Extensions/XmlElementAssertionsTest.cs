using System.Xml;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XmlElementAssertions"/>.</para>
/// </summary>
public sealed class XmlElementAssertionsTest : UnitTest
{
  private XmlElement Element { get; } = new XmlDocument().CreateElement("root");

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlElementAssertions.Attribute(IAssertion, XmlElement, string, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Attribute_Method()
  {
    AssertionExtensions.Should(() => XmlElementAssertions.Attribute(null, Element, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Attribute(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("element");
    AssertionExtensions.Should(() => Assert.To.Attribute(Element, null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    AssertionExtensions.Should(() => Assert.To.Attribute(Element, RandomString, null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    Element.With(element =>
    {
      element.SetAttribute("encoding", null);
      Assert.To.Attribute(element, "encoding").Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.Attribute(element, "encoding", element.NamespaceURI).Should().NotBeNull().And.BeSameAs(Assert.To);

      element.SetAttribute("encoding", "utf-8");
      Assert.To.Attribute(element, "encoding").Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.Attribute(element, "encoding", element.NamespaceURI).Should().NotBeNull().And.BeSameAs(Assert.To);

      AssertionExtensions.Should(() => Assert.To.Attribute(element, RandomString, null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    });
  }
}