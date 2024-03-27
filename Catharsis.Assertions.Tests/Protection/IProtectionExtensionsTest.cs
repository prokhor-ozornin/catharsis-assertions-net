using Catharsis.Commons;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IProtectionExtensions"/>.</para>
/// </summary>
public sealed class IProtectionExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IProtectionExtensions.And(IProtection)"/> method.</para>
  /// </summary>
  [Fact]
  public void And_Method()
  {
    ((IProtection) null).And().Should().BeNull();
    Protect.From.And().Should().BeOfType<Protection>().And.BeSameAs(Protect.From);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IProtectionExtensions.Being(IProtection)"/> method.</para>
  /// </summary>
  [Fact]
  public void Being_Method()
  {
    ((IProtection) null).Being().Should().BeNull();
    Protect.From.Being().Should().BeOfType<Protection>().And.BeSameAs(Protect.From);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IProtectionExtensions.Having(IProtection)"/> method.</para>
  /// </summary>
  [Fact]
  public void Having_Method()
  {
    ((IProtection) null).Having().Should().BeNull();
    Protect.From.Having().Should().BeOfType<Protection>().And.BeSameAs(Protect.From);
  }
}