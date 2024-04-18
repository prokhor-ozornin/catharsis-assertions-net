using System.Xml.Linq;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XContainerAssertions.Element(null, Container, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => XContainerAssertions.Element(Assert.To, null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("container");
      AssertionExtensions.Should(() => Assert.To.Element(Container, null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

      Container.With(container =>
      {
        var root = new XElement("parent");
        root.Add(new XElement("child"));
        container.Add(root);

        Assert.To.Element(container, "parent").Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        AssertionExtensions.Should(() => Assert.To.Element(container, "child", "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      });
    }

    return;

    static void Validate(bool result, XContainer container, XName name)
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
      AssertionExtensions.Should(() => XContainerAssertions.Empty(null, Container)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => XContainerAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("container");

      Container.With(container =>
      {
        container.Add(new XElement("root"));
        AssertionExtensions.Should(() => Assert.To.Empty(container, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      });
    }

    return;

    static void Validate(bool result, XContainer container)
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