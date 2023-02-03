using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="BooleanProtections"/>.</para>
/// </summary>
public sealed class BooleanProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="BooleanProtections.Truth(IProtection, bool, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Truth_Method()
  {
    AssertionExtensions.Should(() => BooleanProtections.Truth(null, true)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    AssertionExtensions.Should(() => Protect.From.Truth(true, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Protect.From.Truth(false);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="BooleanProtections.Lie(IProtection, bool, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Lie_Method()
  {
    AssertionExtensions.Should(() => BooleanProtections.Lie(null, false)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    AssertionExtensions.Should(() => Protect.From.Lie(false, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Protect.From.Lie(true);
  }
}