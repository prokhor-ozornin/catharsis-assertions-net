using System.Text;
using System.Xml;
using Catharsis.Extensions;
using Catharsis.Fixture;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XmlElementExpectations"/>.</para>
/// </summary>
/// <seealso cref="XmlElementExpectations"/>
public sealed class XmlElementExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="XmlElementExpectations.Attribute(IExpectation{XmlElement}, string, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Attribute_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XmlElementExpectations.Attribute(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((XmlElement) null).Expect().Attribute("name")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => new XmlDocument().CreateElement("root").Expect().Attribute(null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

      new XmlDocument().CreateElement("root").With(element =>
      {
        element.SetAttribute("encoding", null);
        Test(true, element, "encoding");
        Test(true, element, "encoding", element.NamespaceURI);

        Encoding.GetEncodings().ForEach(encoding =>
        {
          element.SetAttribute("encoding", encoding.Name);
          Test(true, element, "encoding");
          Test(true, element, "encoding", element.NamespaceURI);
        });
      });

      Test(false, new XmlDocument().CreateElement("root"), Fixture<string>.Create());
    }

    return;

    static void Test(bool result, XmlElement element, string name, string uri = null) => element.Expect().Attribute(name, uri).Should().BeOfType<Expectation<XmlElement>>().Which.Result.Should().Be(result);
  }
}