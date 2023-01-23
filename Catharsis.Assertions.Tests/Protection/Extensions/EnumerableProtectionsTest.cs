using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="EnumerableProtections"/>.</para>
/// </summary>
public sealed class EnumerableProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableProtections.Empty{T}(IProtection, IEnumerable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => EnumerableProtections.Empty(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((IEnumerable<object>) null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="EnumerableProtections.AnyOf{T}(IProtection, T, string, IEnumerable{T})"/></description></item>
  ///     <item><description><see cref="EnumerableProtections.AnyOf{T}(IProtection, T, string, T[])"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void AnyOf_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => EnumerableProtections.AnyOf(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => EnumerableProtections.AnyOf(null, new object(), null, Array.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");

    }

    throw new NotImplementedException();
  }
}