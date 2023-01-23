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
  private MemberInfo Member { get; } = typeof(string).AnyProperty(nameof(string.Length));

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="MemberInfoAssertions.Attribute(IAssertion, System.Reflection.MemberInfo, Type, string)"/></description></item>
  ///     <item><description><see cref="MemberInfoAssertions.Attribute{T}(IAssertion, System.Reflection.MemberInfo, string)"/></description></item>
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

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MemberInfoAssertions.Attribute<Attribute>(null, Member)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Attribute<Attribute>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("member");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MemberInfoAssertions.Type(IAssertion, System.Reflection.MemberInfo, MemberTypes, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Type_Method()
  {
    AssertionExtensions.Should(() => MemberInfoAssertions.Type(null, Member, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => MemberInfoAssertions.Type(Assert.To, null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("member");

    throw new NotImplementedException();
  }
}