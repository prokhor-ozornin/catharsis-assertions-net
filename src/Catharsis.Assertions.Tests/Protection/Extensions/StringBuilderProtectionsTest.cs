using AutoFixture;
using System.Text;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StringBuilderProtections"/>.</para>
/// </summary>
public sealed class StringBuilderProtectionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StringBuilderProtections.Empty(IProtection, StringBuilder, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringBuilderProtections.Empty(null, new StringBuilder())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.Empty((StringBuilder) null)).ThrowExactly<ArgumentNullException>().WithParameterName("builder");

      Test(true, Fixture.Create<string>().ToStringBuilder());
      Test(false, new StringBuilder());
    }

    return;

    static void Test(bool result, StringBuilder builder)
    {
      if (result)
      {
        Protect.From.Empty(builder).Should().BeOfType<StringBuilder>().And.BeSameAs(builder);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Empty(builder, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }
}