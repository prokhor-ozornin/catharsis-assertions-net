using System.Collections.Specialized;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="NameValueCollectionProtections"/>.</para>
/// </summary>
public sealed class NameValueCollectionProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="NameValueCollectionProtections.Empty(IProtection, NameValueCollection, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => NameValueCollectionProtections.Empty(null, new NameValueCollection())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((NameValueCollection) null)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

    new NameValueCollection().With(collection => AssertionExtensions.Should(() => AssertionExtensions.Should(() => Protect.From.Empty(collection, "error")).ThrowExactly<ArgumentException>().WithMessage("error")));
    new NameValueCollection().With(collection => Protect.From.Empty(collection.AddRange(("name", "value"))).Should().NotBeNull().And.BeSameAs(collection));
  }
}