using System.Text;
using System.Xml.Linq;
using Catharsis.Extensions;
using Catharsis.Fixture;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XElementAssertions"/>.</para>
/// </summary>
public sealed class XElementAssertionsTest : Test
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

      Test(false, new XElement("root"), Fixture<string>.Create());

      new XElement("root").With(element =>
      {
        Encoding.GetEncodings().ForEach(encoding =>
        {
          element.SetAttributeValue("encoding", encoding.Name);

          Test(true, element, "encoding");
          Test(true, element, "encoding", encoding.Name);
          Test(false, element, "encoding", string.Empty);
        });
      });
    }

    return;

    static void Test(bool result, XElement element, XName name, string value = null)
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