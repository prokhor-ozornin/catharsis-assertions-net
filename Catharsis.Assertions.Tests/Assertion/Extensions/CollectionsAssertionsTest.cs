using System.Collections.Specialized;
using FluentAssertions;
using Xunit;

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

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CollectionsAssertions.Empty{T}(IAssertion, ICollection{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Collection_Method()
  {
    AssertionExtensions.Should(() => CollectionsAssertions.Empty(null, Array.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Empty<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CollectionsAssertions.ReadOnly{T}(IAssertion, ICollection{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Collection_Method()
  {
    AssertionExtensions.Should(() => CollectionsAssertions.ReadOnly(null, Array.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ReadOnly<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CollectionsAssertions.Count(IAssertion, NameValueCollection, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Count_NameValueCollection_Method()
  {
    AssertionExtensions.Should(() => CollectionsAssertions.Count(null, new NameValueCollection(), default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Count(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CollectionsAssertions.Empty(IAssertion, NameValueCollection, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_NameValueCollection_Method()
  {
    AssertionExtensions.Should(() => CollectionsAssertions.Empty(null, new NameValueCollection())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Empty((NameValueCollection) null)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

    throw new NotImplementedException();
  }
}