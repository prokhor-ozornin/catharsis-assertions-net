using System.Xml.Linq;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XElementExpectations"/>.</para>
/// </summary>
public sealed class XElementExpectationsTest : UnitTest
{
  private XElement Element { get; } = new("root");

  /// <summary>
  ///   <para>Performs testing of <see cref="XElementExpectations.Attribute(IExpectation{XElement}, XName, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Attribute_Method()
  {
    AssertionExtensions.Should(() => XElementExpectations.Attribute(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((XElement) null).Expect().Attribute("name")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Element.Expect().Attribute(null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    throw new NotImplementedException();
  }
}