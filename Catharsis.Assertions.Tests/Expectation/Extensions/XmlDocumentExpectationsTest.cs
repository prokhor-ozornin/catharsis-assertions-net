using System.Xml;
using FluentAssertions;
using Xunit;

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
    AssertionExtensions.Should(() => Document.Expect().Element(null)).ThrowExactly<ArgumentNullException>().WithParameterName("naem");

    throw new NotImplementedException();
  }
}