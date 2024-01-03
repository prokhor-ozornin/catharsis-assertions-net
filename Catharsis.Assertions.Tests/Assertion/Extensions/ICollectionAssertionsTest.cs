using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ICollectionAssertions"/>.</para>
/// </summary>
public sealed class ICollectionAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ICollectionAssertions.Count{T}(IAssertion, ICollection{T}, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Count_Method()
  {
    AssertionExtensions.Should(() => ICollectionAssertions.Count(null, Array.Empty<object>(), default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Count<object>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

    AssertionExtensions.Should(() => Assert.To.Count(Attributes.RandomSequence(), int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Count(Attributes.RandomSequence(), int.MaxValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Attributes.RandomSequence().ToArray().With(collection => Assert.To.Count(collection, collection.Length).Should().NotBeNull().And.BeSameAs(Assert.To));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ICollectionAssertions.Empty{T}(IAssertion, ICollection{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => ICollectionAssertions.Empty(null, Array.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Empty<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

    Assert.To.Empty(Attributes.EmptySequence().ToArray()).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Empty(Attributes.RandomSequence().ToArray(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ICollectionAssertions.ReadOnly{T}(IAssertion, ICollection{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    AssertionExtensions.Should(() => ICollectionAssertions.ReadOnly(null, Array.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ReadOnly<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

    Assert.To.ReadOnly(Attributes.RandomSequence().ToArray()).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.ReadOnly(Attributes.RandomSequence().ToList(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }
}