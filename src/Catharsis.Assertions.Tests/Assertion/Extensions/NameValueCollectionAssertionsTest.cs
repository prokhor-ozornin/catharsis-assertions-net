using System.Collections.Specialized;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="NameValueCollectionAssertions"/>.</para>
/// </summary>
/// <seealso cref="NameValueCollectionAssertions"/>
public sealed class NameValueCollectionAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="NameValueCollectionAssertions.Count(IAssertion, NameValueCollection, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Count_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => NameValueCollectionAssertions.Count(null, [], 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Count(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

      Test(true, [], 0);
      Test(false, [], int.MinValue);
      Test(false, [], int.MaxValue);
    }

    return;

    static void Test(bool result, NameValueCollection collection, int count)
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
  ///   <para>Performs testing of <see cref="NameValueCollectionAssertions.Empty(IAssertion, NameValueCollection, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => NameValueCollectionAssertions.Empty(null, [])).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Empty((NameValueCollection) null)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

      Test(true, []);
      Test(false, new NameValueCollection().With(("name", "value")));
    }

    return;

    static void Test(bool result, NameValueCollection collection)
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
}