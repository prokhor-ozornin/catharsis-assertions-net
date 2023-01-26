using System.Xml.Linq;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XContainerExpectations"/>.</para>
/// </summary>
public sealed class XContainerExpectationsTest : UnitTest
{
  private XContainer Container { get; } = new XDocument();

  /// <summary>
  ///   <para>Performs testing of <see cref="XContainerExpectations.Element(IExpectation{XContainer}, XName)"/> method.</para>
  /// </summary>
  [Fact]
  public void Element_Method()
  {
    AssertionExtensions.Should(() => XContainerExpectations.Element(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((XContainer) null).Expect().Element("name")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Container.Expect().Element(null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XContainerExpectations.Empty(IExpectation{XContainer})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => XContainerExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((XContainer) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }
}