using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ICollectionProtections"/>.</para>
/// </summary>
public sealed class ICollectionsProtectionsTest : UnitTest
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
      AssertionExtensions.Should(() => Protect.From.Empty((ICollection<object>) null)).ThrowExactly<ArgumentNullException>().WithParameterName("collection");

      Validate(true, Attributes.RandomSequence().ToArray());
      Validate(false, Array.Empty<object>());
    }

    return;

    static void Validate<T>(bool result, ICollection<T> collection)
    {
      if (result)
      {
        Protect.From.Empty(collection).Should().BeOfType<ICollection<T>>().And.BeSameAs(collection);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Empty(collection, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }
}