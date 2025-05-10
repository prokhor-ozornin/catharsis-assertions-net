using FluentAssertions;
using Xunit;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ICollectionProtections"/>.</para>
/// </summary>
public sealed class ICollectionsProtectionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ICollectionProtections.Empty{T}(IProtection, ICollection{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ICollectionProtections.Empty(null, Array.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.Empty<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

      Test(true, RandomSequence.ToArray());
      Test(false, Array.Empty<object>());
    }

    return;

    static void Test<T>(bool result, ICollection<T> collection)
    {
      if (result)
      {
        Protect.From.Empty(collection).Should().BeAssignableTo<ICollection<T>>().And.BeSameAs(collection);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Empty(collection, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }
}