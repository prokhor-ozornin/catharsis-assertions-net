using System.Xml.Linq;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XDocumentAssertions"/>.</para>
/// </summary>
public sealed class XDocumentAssertionsTest : UnitTest
{
  private XDocument Document { get; } = new();

  /// <summary>
  ///   <para>Performs testing of <see cref="XDocumentAssertions.Empty(IAssertion, System.Xml.Linq.XDocument, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => XDocumentAssertions.Empty(null, Document)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => XDocumentAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("document");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XDocumentAssertions.Name(IAssertion, System.Xml.Linq.XDocument, XName, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    AssertionExtensions.Should(() => XDocumentAssertions.Name(null, Document, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => XDocumentAssertions.Name(Assert.To, null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("document");
    AssertionExtensions.Should(() => Assert.To.Name(Document, null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    throw new NotImplementedException();
  }
}