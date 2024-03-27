using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IEnumerableProtections"/>.</para>
/// </summary>
public sealed class IEnumerableProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableProtections.Empty{T}(IProtection, IEnumerable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => IEnumerableProtections.Empty(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((IEnumerable<object>) null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    Attributes.EmptySequence().With(sequence => AssertionExtensions.Should(() => Protect.From.Empty(sequence, "error")).ThrowExactly<ArgumentException>().WithMessage("error"));
    Attributes.RandomSequence().With(sequence => Protect.From.Empty(sequence).Should().BeOfType<IEnumerable<object>>().And.BeSameAs(sequence));
  }
}