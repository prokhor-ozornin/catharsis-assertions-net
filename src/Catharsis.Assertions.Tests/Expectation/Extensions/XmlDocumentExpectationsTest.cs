using AutoFixture;
using System.Xml;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XmlDocumentExpectations"/>.</para>
/// </summary>
public sealed class XmlDocumentExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="XmlDocumentExpectations.Element(IExpectation{XmlDocument}, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Element_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XmlDocumentExpectations.Element(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((XmlDocument) null).Expect().Element("name")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => new XmlDocument().Expect().Element(null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

      new XmlDocument().With(document =>
      {
        var parent = document.AppendChild(document.CreateElement("parent"));
        var child = parent.AppendChild(document.CreateElement("child"));
        
        Test(true, document, parent.Name);
        Test(true, document, parent.Name, parent.NamespaceURI);

        Test(true, document, child.Name);
        Test(true, document, child.Name, child.NamespaceURI);
      });

      Test(false, new XmlDocument(), Fixture.Create<string>());
    }

    return;

    static void Test(bool result, XmlDocument document, string name, string uri = null) => document.Expect().Element(name, uri).Should().BeOfType<Expectation<XmlDocument>>().Which.Result.Should().Be(result);
  }
}