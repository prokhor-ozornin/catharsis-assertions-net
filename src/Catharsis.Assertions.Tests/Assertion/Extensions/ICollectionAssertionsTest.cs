using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using FluentAssertions.Execution;

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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ICollectionAssertions.Count(null, Array.Empty<object>(), 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Count<object>(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

      Validate(true, Array.Empty<object>(), 0);
      Validate(false, Array.Empty<object>(), int.MinValue);
      Validate(false, Array.Empty<object>(), int.MaxValue);
    }

    return;

    static void Validate<T>(bool result, ICollection<T> collection, int count)
    {
      if (result)
      {
        Assert.To.Count(collection, count).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Count(collection, count, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ICollectionAssertions.Empty{T}(IAssertion, ICollection{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ICollectionAssertions.Empty(null, Array.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Empty<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

      Validate(true, Array.Empty<object>());
      Validate(false, Attributes.RandomSequence().ToArray());
    }

    return;

    static void Validate<T>(bool result, ICollection<T> collection)
    {
      if (result)
      {
        Assert.To.Empty(collection).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Empty(collection, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ICollectionAssertions.ReadOnly{T}(IAssertion, ICollection{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ICollectionAssertions.ReadOnly(null, Array.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.ReadOnly<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

      Validate(true, Array.Empty<object>());
      Validate(false, new List<object>());
    }

    return;

    static void Validate<T>(bool result, ICollection<T> collection)
    {
      if (result)
      {
        Assert.To.ReadOnly(collection).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.ReadOnly(collection, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}