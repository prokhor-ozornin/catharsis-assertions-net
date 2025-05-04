using AutoFixture;
using System.Text;
using System.Xml;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XmlElementAssertions"/>.</para>
/// </summary>
public sealed class XmlElementAssertionsTest : Test
{
  private XmlElement Element { get; } = new XmlDocument().CreateElement("root");

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlElementAssertions.Attribute(IAssertion, XmlElement, string, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Attribute_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XmlElementAssertions.Attribute(null, Element, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Attribute(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("element");
      AssertionExtensions.Should(() => Assert.To.Attribute(Element, null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

      new XmlDocument().CreateElement("root").With(element =>
      {
        element.SetAttribute("encoding", null);
        Validate(true, element, "encoding");
        Validate(true, element, "encoding", element.NamespaceURI);

        Encoding.GetEncodings().ForEach(encoding =>
        {
          element.SetAttribute("encoding", encoding.Name);
          Validate(true, element, "encoding");
          Validate(true, element, "encoding", element.NamespaceURI);
        });
      });

      Validate(false, new XmlDocument().CreateElement("root"), Fixture.Create<string>());
    }

    return;

    static void Validate(bool result, XmlElement element, string name, string uri = null)
    {
      if (result)
      {
        Assert.To.Attribute(element, name, uri).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Attribute(element, name, uri, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}