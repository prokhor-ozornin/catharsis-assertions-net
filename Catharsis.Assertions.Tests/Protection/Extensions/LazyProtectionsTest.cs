using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LazyProtections"/>.</para>
/// </summary>
public sealed class LazyProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="LazyProtections.Null{T}(IProtection, Lazy{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Null_Method()
  {
    AssertionExtensions.Should(() => ObjectProtections.Null(null, new Lazy<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    AssertionExtensions.Should(() => Protect.From.Null(new Lazy<object>((object) null), "error")).ThrowExactly<ArgumentNullException>().WithParameterName("error");
    AssertionExtensions.Should(() => Protect.From.Null(new Lazy<object>(), "error")).ThrowExactly<ArgumentNullException>().WithParameterName("error");
    new Lazy<object>(new object()).With(lazy => Protect.From.Null(lazy).Should().NotBeNull().And.BeSameAs(lazy));
  }
}