using System.Text;
using System.Xml.Linq;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using Catharsis.Fixture;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XElementExpectations"/>.</para>
/// </summary>
public sealed class XElementExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="XElementExpectations.Attribute(IExpectation{XElement}, XName, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Attribute_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XElementExpectations.Attribute(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((XElement) null).Expect().Attribute("name")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => new XElement("root").Expect().Attribute(null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

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

    static void Test(bool result, XElement element, XName name, string value = null) => element.Expect().Attribute(name, value).Should().BeOfType<Expectation<XElement>>().Which.Result.Should().Be(result);
  }
}