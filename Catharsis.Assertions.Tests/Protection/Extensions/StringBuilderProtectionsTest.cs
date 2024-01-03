using System.Text;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StringBuilderProtections"/>.</para>
/// </summary>
public sealed class StringBuilderProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StringBuilderProtections.Empty(IProtection, StringBuilder, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => StringBuilderProtections.Empty(null, new StringBuilder())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((StringBuilder) null)).ThrowExactly<ArgumentNullException>().WithParameterName("builder");

    new StringBuilder().With(builder => AssertionExtensions.Should(() => Protect.From.Empty(builder, "error")).ThrowExactly<ArgumentException>().WithMessage("error"));
    new StringBuilder(Attributes.RandomString()).With(builder => Protect.From.Empty(builder).Should().NotBeNull().And.BeSameAs(builder));
  }
}