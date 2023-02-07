using System.Collections.Specialized;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="CollectionsProtections"/>.</para>
/// </summary>
public sealed class CollectionsProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="CollectionsProtections.Empty{T}(IProtection, ICollection{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Collection_Method()
  {
    AssertionExtensions.Should(() => CollectionsProtections.Empty(null, Array.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((ICollection<object>) null)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

    AssertionExtensions.Should(() => Protect.From.Empty(Array.Empty<object>(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    RandomSequence.ToArray().With(collection => Protect.From.Empty(collection).Should().NotBeNull().And.BeSameAs(collection));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CollectionsProtections.Empty(IProtection, NameValueCollection, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_NameValueCollection_Method()
  {
    AssertionExtensions.Should(() => CollectionsProtections.Empty(null, new NameValueCollection())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((NameValueCollection) null)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

    new NameValueCollection().With(collection => AssertionExtensions.Should(() => AssertionExtensions.Should(() => Protect.From.Empty(collection, "error")).ThrowExactly<ArgumentException>().WithMessage("error")));
    new NameValueCollection().With(collection => Protect.From.Empty(collection.AddRange(("name", "value"))).Should().NotBeNull().And.BeSameAs(collection));
  }
}