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
  private MemberInfo Member { get; } = typeof(string).AnyProperty(nameof(string.Length));

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

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MemberInfoExpectations.Attribute<Attribute>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((MemberInfo) null).Expect().Attribute<Attribute>()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MemberInfoExpectations.Type(IExpectation{MemberInfo}, MemberTypes)"/> method.</para>
  /// </summary>
  [Fact]
  public void Type_Method()
  {
    AssertionExtensions.Should(() => MemberInfoExpectations.Type(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((MemberInfo) null).Expect().Type(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }
}