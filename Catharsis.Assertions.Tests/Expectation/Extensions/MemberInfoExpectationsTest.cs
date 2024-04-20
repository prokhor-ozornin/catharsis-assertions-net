using System.ComponentModel;
using System.Reflection;
using Catharsis.Commons;
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

      Validate(true, Member, typeof(Attribute));
      Validate(true, Member, typeof(DescriptionAttribute));
      Validate(false, Member, typeof(ObsoleteAttribute));

      static void Validate(bool result, MemberInfo member, Type type) => member.Expect().Attribute(type).Should().BeOfType<Expectation<MemberInfo>>().Which.Result.Should().Be(result);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MemberInfoExpectations.Attribute<Attribute>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((MemberInfo) null).Expect().Attribute<Attribute>()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate<Attribute>(true, Member);
      Validate<DescriptionAttribute>(true, Member);
      Validate<ObsoleteAttribute>(false, Member);

      static void Validate<T>(bool result, MemberInfo member) where T : Attribute => member.Expect().Attribute<T>().Should().BeOfType<Expectation<MemberInfo>>().Which.Result.Should().Be(result);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MemberInfoExpectations.Type(IExpectation{MemberInfo}, MemberTypes)"/> method.</para>
  /// </summary>
  [Fact]
  public void Type_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MemberInfoExpectations.Type(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((MemberInfo) null).Expect().Type(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, Member, Member.MemberType);
      Validate(false, Member, MemberTypes.All);
    }

    return;

    static void Validate(bool result, MemberInfo member, MemberTypes type) => member.Expect().Type(type).Should().BeOfType<Expectation<MemberInfo>>().Which.Result.Should().Be(result);
  }
}