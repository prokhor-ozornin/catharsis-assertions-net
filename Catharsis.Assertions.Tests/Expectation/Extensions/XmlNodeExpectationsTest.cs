using System.Xml;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="XmlNodeExpectations"/>.</para>
/// </summary>
public sealed class XmlNodeExpectationsTest : UnitTest
{
  private XmlNode Node { get; } = new XmlDocument().CreateElement("root");

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeExpectations.Empty(IExpectation{XmlNode})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XmlNodeExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((XmlNode) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, new XmlDocument());
      Validate(false, new XmlDocument().With(document => document.With(document.CreateElement("root"))));
    }

    return;

    static void Validate(bool result, XmlNode node) => node.Expect().Empty().Should().BeOfType<Expectation<XmlNode>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeExpectations.Name(IExpectation{XmlNode}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XmlNodeExpectations.Name(null, "name")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((XmlNode) null).Expect().Name("name")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => Node.Expect().Name(null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");

      //Validate(true, new);
      //Validate(false, null);

      Node.Expect().Name(Attributes.RandomString()).Result.Should().BeFalse();
      Node.Expect().Name(Node.Name).Result.Should().BeTrue();
    }

    return;

    static void Validate(bool result, XmlNode node, string name) => node.Expect().Name(name).Should().BeOfType<Expectation<XmlNode>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeExpectations.InnerText(IExpectation{XmlNode}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InnerText_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XmlNodeExpectations.InnerText(null, "text")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((XmlNode) null).Expect().InnerText("text")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => Node.Expect().InnerText(null)).ThrowExactly<ArgumentNullException>().WithParameterName("text");

      Node.Expect().InnerText(Attributes.RandomString()).Result.Should().BeFalse();
      Node.Expect().InnerText(Node.InnerText).Result.Should().BeTrue();
    }

    return;

    static void Validate(bool result, XmlNode node, string text) => node.Expect().InnerText(text).Should().BeOfType<Expectation<XmlNode>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeExpectations.InnerXml(IExpectation{XmlNode}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void InnerXml_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XmlNodeExpectations.InnerXml(null, "text")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((XmlNode)null).Expect().InnerXml("text")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => Node.Expect().InnerXml(null)).ThrowExactly<ArgumentNullException>().WithParameterName("xml");

      Node.Expect().InnerXml(Attributes.RandomString()).Result.Should().BeFalse();
      Node.Expect().InnerXml(Node.InnerXml).Result.Should().BeTrue();
    }

    return;

    static void Validate(bool result, XmlNode node, string xml) => node.Expect().InnerXml(xml).Should().BeOfType<Expectation<XmlNode>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeExpectations.OuterXml(IExpectation{XmlNode}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void OuterXml_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XmlNodeExpectations.OuterXml(null, "text")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((XmlNode) null).Expect().OuterXml("text")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => Node.Expect().OuterXml(null)).ThrowExactly<ArgumentNullException>().WithParameterName("xml");

      Node.Expect().OuterXml(Attributes.RandomString()).Result.Should().BeFalse();
      Node.Expect().OuterXml(Node.OuterXml).Result.Should().BeTrue();
    }

    return;

    static void Validate(bool result, XmlNode node, string xml) => node.Expect().OuterXml(xml).Should().BeOfType<Expectation<XmlNode>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="XmlNodeExpectations.Value(IExpectation{XmlNode}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => XmlNodeExpectations.Value(null, "value")).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((XmlNode) null).Expect().Value("value")).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Node.Expect().Value(Attributes.RandomString()).Result.Should().BeFalse();
      Node.Expect().Value(Node.Value).Result.Should().BeTrue();
    }

    return;

    static void Validate(bool result, XmlNode node, string value) => node.Expect().Value(value).Should().BeOfType<Expectation<XmlNode>>().Which.Result.Should().Be(result);
  }
}