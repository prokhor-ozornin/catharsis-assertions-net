using System.ComponentModel;
using System.Reflection;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="MemberInfoAssertions"/>.</para>
/// </summary>
public sealed class MemberInfoAssertionsTest : UnitTest
{
  [Description]
  private string Property => nameof(Property);

  private MemberInfo Member => GetType().AnyProperty(nameof(Property));

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="MemberInfoAssertions.Attribute(IAssertion, MemberInfo, Type, string)"/></description></item>
  ///     <item><description><see cref="MemberInfoAssertions.Attribute{T}(IAssertion, MemberInfo, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Attribute_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MemberInfoAssertions.Attribute(null, Member, typeof(Attribute))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Attribute(null, typeof(Attribute))).ThrowExactly<ArgumentNullException>().WithParameterName("member");
      AssertionExtensions.Should(() => Assert.To.Attribute(Member, null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

      Assert.To.Attribute(Member, typeof(Attribute)).Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.Attribute(Member, typeof(DescriptionAttribute)).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.Attribute(Member, typeof(ObsoleteAttribute), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      AssertionExtensions.Should(() => Assert.To.Attribute(Member, typeof(object))).ThrowExactly<ArgumentException>();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MemberInfoAssertions.Attribute<Attribute>(null, Member)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Attribute<Attribute>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("member");

      Assert.To.Attribute<Attribute>(Member).Should().NotBeNull().And.BeSameAs(Assert.To);
      Assert.To.Attribute< DescriptionAttribute>(Member).Should().NotBeNull().And.BeSameAs(Assert.To);
      AssertionExtensions.Should(() => Assert.To.Attribute<ObsoleteAttribute>(Member, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MemberInfoAssertions.Type(IAssertion, MemberInfo, MemberTypes, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Type_Method()
  {
    AssertionExtensions.Should(() => MemberInfoAssertions.Type(null, Member, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => MemberInfoAssertions.Type(Assert.To, null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("member");

    AssertionExtensions.Should(() => Assert.To.Type(Member, MemberTypes.All, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Type(Member, Member.MemberType).Should().NotBeNull().And.BeSameAs(Assert.To);
  }
}