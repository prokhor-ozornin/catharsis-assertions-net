using System.Xml.Linq;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XContainerAssertions"/>.</para>
/// </summary>
public sealed class XContainerAssertionsTest : UnitTest
{
  private XContainer Container { get; } = new XDocument();

  /// <summary>
  ///   <para>Performs testing of <see cref="XContainerAssertions.Element(IAssertion, XContainer, XName, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Element_Method()
  {
    AssertionExtensions.Should(() => XContainerAssertions.Element(null, Container, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => XContainerAssertions.Element(Assert.To, null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("container");
    AssertionExtensions.Should(() => Assert.To.Element(Container, null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

    AssertionExtensions.Should(() => Assert.To.Element(Container, RandomString, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");

    Container.With(container =>
    {
      var root = new XElement("parent");
      root.Add(new XElement("child"));
      container.Add(root);

      Assert.To.Element(container, "parent").Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.Element(container, "child", "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XContainerAssertions.Empty(IAssertion, XContainer, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => XContainerAssertions.Empty(null, Container)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => XContainerAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("container");

    Assert.To.Empty(Container).Should().NotBeNull().And.BeSameAs(Assert.To);

    Container.With(container =>
    {
      container.Add(new XElement("root"));
      AssertionExtensions.Should(() => Assert.To.Empty(container, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    });
  }
}