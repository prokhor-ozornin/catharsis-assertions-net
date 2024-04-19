using System.Xml;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XmlDocumentExpectations"/>.</para>
/// </summary>
public sealed class XmlDocumentExpectationsTest : UnitTest
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
        
        Validate(true, document, parent.Name);
        Validate(true, document, parent.Name, parent.NamespaceURI);

        Validate(true, document, child.Name);
        Validate(true, document, child.Name, child.NamespaceURI);
      });

      Validate(false, new XmlDocument(), Attributes.RandomString());
    }

    return;

    static void Validate(bool result, XmlDocument document, string name, string uri = null) => document.Expect().Element(name, uri).Should().BeOfType<Expectation<XmlDocument>>().Which.Result.Should().Be(result);
  }
}