using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="NullableAssertions"/>.</para>
/// </summary>
public sealed class NullableAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="NullableAssertions.HasValue{T}(IAssertion, T?, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void HasValue_Method()
  {
    AssertionExtensions.Should(() => NullableAssertions.HasValue<int>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    Assert.To.HasValue((int?) 0).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.HasValue((int?) null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="NullableAssertions.Value{T}(IAssertion, T?, T, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    AssertionExtensions.Should(() => NullableAssertions.Value(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    Assert.To.Value(0, 0).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.Value(null, 0).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Value(null, int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Value(null, int.MaxValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");

    Assert.To.Value(DateTime.MinValue, DateTime.MinValue).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.Value(DateTime.MaxValue, DateTime.MaxValue).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.Value(null, DateTime.MinValue).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Value(null, DateTime.MaxValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");

    Assert.To.Value(Guid.Empty, Guid.Empty).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.Value(null, Guid.Empty).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Value(null, Guid.NewGuid(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }
}