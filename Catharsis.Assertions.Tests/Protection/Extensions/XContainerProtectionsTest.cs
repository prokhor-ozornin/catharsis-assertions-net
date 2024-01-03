using System.Xml.Linq;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XContainerProtections"/>.</para>
/// </summary>
public sealed class XContainerProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="XContainerProtections.Empty(IProtection, XContainer, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => XContainerProtections.Empty(null, new XElement("element"))).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((XContainer) null)).ThrowExactly<ArgumentNullException>().WithParameterName("container");

    AssertionExtensions.Should(() => Protect.From.Empty((XContainer) new XDocument(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    
    new XDocument().With(document =>
    {
      document.Add(new XElement("root"));
      Protect.From.Empty((XContainer) document).Should().NotBeNull().And.BeSameAs(document);
    });
  }
}