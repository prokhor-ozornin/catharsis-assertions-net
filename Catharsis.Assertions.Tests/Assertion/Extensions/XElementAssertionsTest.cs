using System.Text;
using System.Xml.Linq;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XElementAssertions"/>.</para>
/// </summary>
public sealed class XElementAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="XElementAssertions.Attribute(IAssertion, XElement, XName, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Attribute_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XElementAssertions.Attribute(null, new XElement("root"), "name")).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => XElementAssertions.Attribute(Assert.To, null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("element");
      AssertionExtensions.Should(() => Assert.To.Attribute(new XElement("root"), null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

      Validate(false, new XElement("root"), string.Empty);

      new XElement("root").With(element =>
      {
        Encoding.GetEncodings().ForEach(encoding =>
        {
          element.SetAttributeValue("encoding", encoding.Name);

          Validate(true, element, "encoding");
          Validate(true, element, "encoding", encoding.Name);
          Validate(false, element, "encoding", string.Empty);
        });
      });
    }

    return;

    static void Validate(bool result, XElement element, XName name, string value = null)
    {
      if (result)
      {
        Assert.To.Attribute(element, name, value).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Attribute(element, name, value, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}