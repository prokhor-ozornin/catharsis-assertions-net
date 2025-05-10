using System.Collections.Specialized;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="NameValueCollectionProtections"/>.</para>
/// </summary>
public sealed class NameValueCollectionProtectionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="NameValueCollectionProtections.Empty(IProtection, NameValueCollection, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => NameValueCollectionProtections.Empty(null, [])).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.Empty((NameValueCollection) null)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

      Test(true, new NameValueCollection().With(("name", "value")));
      Test(false, []);
    }

    return;

    static void Test(bool result, NameValueCollection collection)
    {
      if (result)
      {
        Protect.From.Empty(collection).Should().BeOfType<NameValueCollection>().And.BeSameAs(collection);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Empty(collection, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }
}