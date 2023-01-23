using System.Xml.Linq;
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
  ///   <para>Performs testing of <see cref="XElementAssertions.Attribute(IAssertion, System.Xml.Linq.XElement, XName, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Attribute_Method()
  {
    AssertionExtensions.Should(() => XElementAssertions.Attribute(null, Element, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => XElementAssertions.Attribute(Assert.To, null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("element");
    AssertionExtensions.Should(() => Assert.To.Attribute(Element, null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    throw new NotImplementedException();
  }
}