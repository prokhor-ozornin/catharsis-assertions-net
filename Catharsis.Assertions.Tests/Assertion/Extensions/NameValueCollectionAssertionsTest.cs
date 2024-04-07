using System.Collections.Specialized;
using System.Linq.Expressions;
using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => NameValueCollectionAssertions.Count(null, [], default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Count(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

      AssertionExtensions.Should(() => new NameValueCollection().With(collection => Assert.To.Count(collection, int.MinValue, "error"))).ThrowExactly<InvalidOperationException>().WithMessage("error");
      AssertionExtensions.Should(() => new NameValueCollection().With(collection => Assert.To.Count(collection, int.MaxValue, "error"))).ThrowExactly<InvalidOperationException>().WithMessage("error");
      new NameValueCollection().With(collection => Assert.To.Count(collection, collection.Count).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To));
    }

    return;

    static void Validate()
    {

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

      Validate(true, []);
      Validate(false, new NameValueCollection().With(("name", "value")));
    }

    return;

    static void Validate(bool result, NameValueCollection collection)
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