using System.Text;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="StringBuilderAssertions"/>.</para>
/// </summary>
public sealed class StringBuilderAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="StringBuilderAssertions.Length(IAssertion, StringBuilder, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringBuilderAssertions.Length(null, new StringBuilder(), 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => StringBuilderAssertions.Length(Assert.To, null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("builder");

      Validate(true, new StringBuilder(), 0);
      Validate(false, new StringBuilder(), int.MinValue);
      Validate(false, new StringBuilder(), int.MaxValue);
    }

    return;

    static void Validate(bool result, StringBuilder builder, int length)
    {
      if (result)
      {
        Assert.To.Length(builder, length).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Length(builder, length, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="StringBuilderAssertions.Empty(IAssertion, StringBuilder, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => StringBuilderAssertions.Empty(null, new StringBuilder())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => StringBuilderAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("builder");

      Validate(true, new StringBuilder());
      Validate(false, new StringBuilder().With(char.MinValue));
    }

    return;

    static void Validate(bool result, StringBuilder builder)
    {
      if (result)
      {
        Assert.To.Empty(builder).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Empty(builder, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}