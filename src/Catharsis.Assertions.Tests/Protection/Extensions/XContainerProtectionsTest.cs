using System.Xml.Linq;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XContainerProtections"/>.</para>
/// </summary>
public sealed class XContainerProtectionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="XContainerProtections.Empty(IProtection, XContainer, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XContainerProtections.Empty(null, new XElement("element"))).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.Empty((XContainer) null)).ThrowExactly<ArgumentNullException>().WithParameterName("container");

      Test(true, new XDocument().With(new XElement("root")));
      Test(false, new XDocument());
    }

    return;

    static void Test(bool result, XContainer container)
    {
      if (result)
      {
        Protect.From.Empty(container).Should().BeOfType<XDocument>().And.BeSameAs(container);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Empty(container, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }
}