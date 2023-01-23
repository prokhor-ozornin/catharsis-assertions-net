using System.Xml;
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

    throw new NotImplementedException();
  }
}