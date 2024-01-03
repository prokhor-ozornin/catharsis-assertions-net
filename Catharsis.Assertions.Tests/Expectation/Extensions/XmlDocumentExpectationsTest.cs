using System.Xml;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XmlDocumentExpectations"/>.</para>
/// </summary>
public sealed class XmlDocumentExpectationsTest : UnitTest
{
  private XmlDocument Document { get; } = new();

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlDocumentExpectations.Element(IExpectation{XmlDocument}, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Element_Method()
  {
    AssertionExtensions.Should(() => XmlDocumentExpectations.Element(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((XmlDocument) null).Expect().Element("name")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Document.Expect().Element(null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    Document.Expect().Element(Attributes.RandomString()).Result.Should().BeFalse();

    Document.With(document =>
    {
      var parent = document.AppendChild(document.CreateElement("parent"));
      var child = parent.AppendChild(document.CreateElement("child"));
      
      document.Expect().Element(parent.Name).Result.Should().BeTrue();
      document.Expect().Element(parent.Name, parent.NamespaceURI).Result.Should().BeTrue();

      document.Expect().Element(child.Name).Result.Should().BeTrue();
      document.Expect().Element(child.Name, child.NamespaceURI).Result.Should().BeTrue();
    });
  }
}