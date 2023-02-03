using System.Collections.Specialized;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="CollectionsAssertions"/>.</para>
/// </summary>
public sealed class CollectionsAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="CollectionsAssertions.Count{T}(IAssertion, ICollection{T}, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Count_Collection_Method()
  {
    AssertionExtensions.Should(() => CollectionsAssertions.Count(null, Array.Empty<object>(), default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Count<object>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

    AssertionExtensions.Should(() => Assert.To.Count(RandomSequence.ToArray(), int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Count(RandomSequence.ToArray(), int.MaxValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    RandomSequence.ToArray().With(collection => Assert.To.Count(collection, collection.Length).Should().NotBeNull().And.BeSameAs(Assert.To));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CollectionsAssertions.Empty{T}(IAssertion, ICollection{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Collection_Method()
  {
    AssertionExtensions.Should(() => CollectionsAssertions.Empty(null, Array.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Empty<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

    Assert.To.Empty(EmptySequence.ToArray()).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Empty(RandomSequence.ToArray(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CollectionsAssertions.ReadOnly{T}(IAssertion, ICollection{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Collection_Method()
  {
    AssertionExtensions.Should(() => CollectionsAssertions.ReadOnly(null, Array.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ReadOnly<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

    Assert.To.ReadOnly(RandomSequence.ToArray()).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.ReadOnly(RandomSequence.ToList(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CollectionsAssertions.Count(IAssertion, NameValueCollection, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Count_NameValueCollection_Method()
  {
    AssertionExtensions.Should(() => CollectionsAssertions.Count(null, new NameValueCollection(), default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Count(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

    AssertionExtensions.Should(() => new NameValueCollection().With(collection => Assert.To.Count(collection, int.MinValue, "error"))).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => new NameValueCollection().With(collection => Assert.To.Count(collection, int.MaxValue, "error"))).ThrowExactly<ArgumentException>().WithMessage("error");
    new NameValueCollection().With(collection => Assert.To.Count(collection, collection.Count).Should().NotBeNull().And.BeSameAs(Assert.To));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CollectionsAssertions.Empty(IAssertion, NameValueCollection, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_NameValueCollection_Method()
  {
    AssertionExtensions.Should(() => CollectionsAssertions.Empty(null, new NameValueCollection())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Empty((NameValueCollection) null)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

    Assert.To.Empty(new NameValueCollection()).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Empty(new NameValueCollection().AddRange(("name", "value")), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }
}