using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => BooleanProtections.Truth(null, true)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

      Validate(true, false);
      Validate(false, true);
    }

    return;

    static void Validate(bool result, bool value)
    {
      if (result)
      {
        Protect.From.Truth(value);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Truth(value, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="BooleanProtections.Lie(IProtection, bool, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Lie_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => BooleanProtections.Lie(null, false)).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

      Validate(true, true);
      Validate(false, false);
    }

    return;

    static void Validate(bool result, bool value)
    {
      if (result)
      {
        Protect.From.Lie(value);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Lie(value, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }
}