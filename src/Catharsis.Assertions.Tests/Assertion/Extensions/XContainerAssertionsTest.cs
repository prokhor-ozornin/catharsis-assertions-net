using System.Xml.Linq;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XContainerAssertions"/>.</para>
/// </summary>
public sealed class XContainerAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="XContainerAssertions.Element(IAssertion, XContainer, XName, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Element_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XContainerAssertions.Element(null, new XDocument(), "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => XContainerAssertions.Element(Assert.To, null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("container");
      AssertionExtensions.Should(() => Assert.To.Element(new XDocument(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

      new XDocument(new XElement("parent", new XElement("child"))).With(container =>
      {
        Test(true, container, "parent");
        Test(false, container, "child");
      });
    }

    return;

    static void Test(bool result, XContainer container, XName name)
    {
      if (result)
      {
        Assert.To.Element(container, name).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Element(container, name, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XContainerAssertions.Empty(IAssertion, XContainer, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XContainerAssertions.Empty(null, new XDocument())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => XContainerAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("container");

      Test(true, new XDocument());
      Test(false, new XDocument(new XElement("root")));
    }

    return;

    static void Test(bool result, XContainer container)
    {
      if (result)
      {
        Assert.To.Empty(container).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Empty(container, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}