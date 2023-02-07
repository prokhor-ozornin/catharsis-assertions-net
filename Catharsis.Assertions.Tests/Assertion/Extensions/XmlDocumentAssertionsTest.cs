using System.Xml;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XmlDocumentAssertions"/>.</para>
/// </summary>
public sealed class XmlDocumentAssertionsTest : UnitTest
{
  private XmlDocument Document { get; } = new();

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlDocumentAssertions.Element(IAssertion, System.Xml.XmlDocument, string, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Element_Method()
  {
    AssertionExtensions.Should(() => XmlDocumentAssertions.Element(null, Document, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Element(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("document");
    AssertionExtensions.Should(() => Assert.To.Element(Document, null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    AssertionExtensions.Should(() => Assert.To.Element(Document, RandomString, null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    Document.With(document =>
    {
      var parent = document.AppendChild(document.CreateElement("parent"));
      var child = parent.AppendChild(document.CreateElement("child"));

      Assert.To.Element(document, parent.Name).Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.Element(document, parent.Name, parent.NamespaceURI).Should().NotBeNull().And.BeSameAs(Assert.To);

      Assert.To.Element(document, child.Name).Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.Element(document, child.Name, child.NamespaceURI).Should().NotBeNull().And.BeSameAs(Assert.To);
    });
  }
}