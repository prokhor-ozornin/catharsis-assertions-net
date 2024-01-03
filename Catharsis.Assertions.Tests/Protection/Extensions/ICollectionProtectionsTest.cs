using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ICollectionProtections"/>.</para>
/// </summary>
public sealed class ICollectionsProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ICollectionProtections.Empty{T}(IProtection, ICollection{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => ICollectionProtections.Empty(null, Array.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((ICollection<object>) null)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

    AssertionExtensions.Should(() => Protect.From.Empty(Array.Empty<object>(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Attributes.RandomSequence().ToArray().With(collection => Protect.From.Empty(collection).Should().NotBeNull().And.BeSameAs(collection));
  }
}