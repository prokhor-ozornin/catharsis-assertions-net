using System.ComponentModel;
using System.Reflection;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="MemberInfoExpectations"/>.</para>
/// </summary>
public sealed class MemberInfoExpectationsTest : UnitTest
{
  [Description]
  private string Property => nameof(Property);

  private MemberInfo Member => GetType().AnyProperty(nameof(Property));

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="MemberInfoExpectations.Attribute(IExpectation{MemberInfo}, Type)"/></description></item>
  ///     <item><description><see cref="MemberInfoExpectations.Attribute{T}(IExpectation{MemberInfo})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Attribute_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MemberInfoExpectations.Attribute(null, typeof(Attribute))).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((MemberInfo) null).Expect().Attribute(typeof(Attribute))).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => Member.Expect().Attribute(null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

      Member.Expect().Attribute(typeof(Attribute)).Result.Should().BeTrue();
      Member.Expect().Attribute(typeof(DescriptionAttribute)).Result.Should().BeTrue();
      Member.Expect().Attribute(typeof(ObsoleteAttribute)).Result.Should().BeFalse();
      
      AssertionExtensions.Should(() => Member.Expect().Attribute(typeof(object))).ThrowExactly<ArgumentException>();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MemberInfoExpectations.Attribute<Attribute>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((MemberInfo) null).Expect().Attribute<Attribute>()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Member.Expect().Attribute<Attribute>().Result.Should().BeTrue();
      Member.Expect().Attribute<DescriptionAttribute>().Result.Should().BeTrue();
      Member.Expect().Attribute<ObsoleteAttribute>().Result.Should().BeFalse();
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MemberInfoExpectations.Type(IExpectation{MemberInfo}, MemberTypes)"/> method.</para>
  /// </summary>
  [Fact]
  public void Type_Method()
  {
    AssertionExtensions.Should(() => MemberInfoExpectations.Type(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((MemberInfo) null).Expect().Type(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Member.Expect().Type(MemberTypes.All).Result.Should().BeFalse();
    Member.Expect().Type(Member.MemberType).Result.Should().BeTrue();
  }
}