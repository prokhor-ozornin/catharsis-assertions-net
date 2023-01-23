using System.Xml.Linq;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XContainerAssertions"/>.</para>
/// </summary>
public sealed class XContainerAssertionsTest : UnitTest
{
  private XContainer Container { get; } = new XDocument();

  /// <summary>
  ///   <para>Performs testing of <see cref="XContainerAssertions.Element(IAssertion, System.Xml.Linq.XContainer, XName, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Element_Method()
  {
    AssertionExtensions.Should(() => XContainerAssertions.Element(null, Container, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => XContainerAssertions.Element(Assert.To, null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("container");
    AssertionExtensions.Should(() => Assert.To.Element(Container, null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XContainerAssertions.Empty(IAssertion, System.Xml.Linq.XContainer, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => XContainerAssertions.Empty(null, Container)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => XContainerAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("container");

    throw new NotImplementedException();
  }
}