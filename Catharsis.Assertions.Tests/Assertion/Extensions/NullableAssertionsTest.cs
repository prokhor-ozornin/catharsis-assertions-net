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

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="NullableAssertions.Value{T}(IAssertion, T?, T, string)"/> method.</para>
  /// </summary>
  public void Value_Method()
  {
    AssertionExtensions.Should(() => NullableAssertions.Value(null, default, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

    throw new NotImplementedException();
  }
}