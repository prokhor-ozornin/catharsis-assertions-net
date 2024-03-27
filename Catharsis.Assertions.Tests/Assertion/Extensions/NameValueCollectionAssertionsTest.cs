using System.Collections.Specialized;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="NameValueCollectionAssertions"/>.</para>
/// </summary>
public sealed class NameValueCollectionAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="NameValueCollectionAssertions.Count(IAssertion, NameValueCollection, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Count_Method()
  {
    AssertionExtensions.Should(() => NameValueCollectionAssertions.Count(null, new NameValueCollection(), default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Count(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

    AssertionExtensions.Should(() => new NameValueCollection().With(collection => Assert.To.Count(collection, int.MinValue, "error"))).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => new NameValueCollection().With(collection => Assert.To.Count(collection, int.MaxValue, "error"))).ThrowExactly<InvalidOperationException>().WithMessage("error");
    new NameValueCollection().With(collection => Assert.To.Count(collection, collection.Count).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="NameValueCollectionAssertions.Empty(IAssertion, NameValueCollection, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => NameValueCollectionAssertions.Empty(null, new NameValueCollection())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Empty((NameValueCollection) null)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

    Assert.To.Empty(new NameValueCollection()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Empty(new NameValueCollection().AddRange(("name", "value")), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }
}