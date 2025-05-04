using AutoFixture;
using System.Xml;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XmlDocumentAssertions"/>.</para>
/// </summary>
public sealed class XmlDocumentAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="XmlDocumentAssertions.Element(IAssertion, XmlDocument, string, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Element_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XmlDocumentAssertions.Element(null, new XmlDocument(), "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Element(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("document");
      AssertionExtensions.Should(() => Assert.To.Element(new XmlDocument(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

      new XmlDocument().With(document =>
      {
        var parent = document.AppendChild(document.CreateElement("parent"));
        var child = parent.AppendChild(document.CreateElement("child"));

        Validate(true, document, parent.Name);
        Validate(true, document, parent.Name, parent.NamespaceURI);

        Validate(true, document, child.Name);
        Validate(true, document, child.Name, child.NamespaceURI);
      });

      Validate(false, new XmlDocument(), Fixture.Create<string>());
    }

    return;

    static void Validate(bool result, XmlDocument document, string name, string uri = null)
    {
      if (result)
      {
        Assert.To.Element(document, name, uri).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Element(document, name, uri, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}