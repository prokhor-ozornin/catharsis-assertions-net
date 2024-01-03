using System.Xml.Linq;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XElementAssertions"/>.</para>
/// </summary>
public sealed class XElementAssertionsTest : UnitTest
{
  private XElement Element { get; } = new("root");

  /// <summary>
  ///   <para>Performs testing of <see cref="XElementAssertions.Attribute(IAssertion, XElement, XName, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Attribute_Method()
  {
    AssertionExtensions.Should(() => XElementAssertions.Attribute(null, Element, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => XElementAssertions.Attribute(Assert.To, null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("element");
    AssertionExtensions.Should(() => Assert.To.Attribute(Element, null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    AssertionExtensions.Should(() => Assert.To.Element(Element, Attributes.RandomString(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");

    Element.With(element =>
    {
      element.SetAttributeValue("encoding", "utf-8");

      Assert.To.Attribute(element, "encoding").Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.Attribute(element, "encoding", "utf-8").Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.Attribute(element, "encoding", Attributes.RandomString(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    });
  }
}