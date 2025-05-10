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
public sealed class MemberInfoAssertionsTest : Test
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
      AssertionExtensions.Should(() => Assert.To.Attribute(Member, typeof(object))).ThrowExactly<ArgumentException>();

      Test(true, Member, typeof(Attribute));
      Test(true, Member, typeof(DescriptionAttribute));
      Test(false, Member, typeof(ObsoleteAttribute));

      static void Test(bool result, MemberInfo member, Type type)
      {
        if (result)
        {
          Assert.To.Attribute(member, type).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Attribute(member, type, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MemberInfoAssertions.Attribute<Attribute>(null, Member)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Attribute<Attribute>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("member");

      Test<Attribute>(true, Member);
      Test<DescriptionAttribute>(true, Member);
      Test<ObsoleteAttribute>(false, Member);

      static void Test<T>(bool result, MemberInfo member) where T : Attribute
      {
        if (result)
        {
          Assert.To.Attribute<Attribute>(member).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Attribute<ObsoleteAttribute>(member, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MemberInfoAssertions.Type(IAssertion, MemberInfo, MemberTypes, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Type_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MemberInfoAssertions.Type(null, Member, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => MemberInfoAssertions.Type(Assert.To, null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("member");

      Test(true, Member, Member.MemberType);
      Test(false, Member, MemberTypes.All);
    }

    return;

    static void Test(bool result, MemberInfo member, MemberTypes type)
    {
      if (result)
      {
        Assert.To.Type(member, type).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Type(member, type, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}