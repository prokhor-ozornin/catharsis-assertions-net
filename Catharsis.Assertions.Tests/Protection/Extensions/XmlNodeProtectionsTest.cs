using System.Xml;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XmlNodeProtections"/>.</para>
/// </summary>
public sealed class XmlNodeProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeProtections.Empty(IProtection, XmlNode, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_XmlNode_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XmlNodeProtections.Empty(null, new XmlDocument().CreateElement("element"))).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.Empty((XmlNode) null)).ThrowExactly<ArgumentNullException>().WithParameterName("node");

      Validate(true, new XmlDocument().With(document => document.With(document.CreateElement("element"))));
      Validate(false, new XmlDocument());
    }

    return;

    static void Validate(bool result, XmlNode node)
    {
      if (result)
      {
        Protect.From.Empty(node).Should().BeOfType<XmlElement>().And.BeSameAs(node);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Empty(node, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }
}