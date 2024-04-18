using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IEnumerableProtections"/>.</para>
/// </summary>
public sealed class IEnumerableProtectionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableProtections.Empty{T}(IProtection, IEnumerable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableProtections.Empty(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.Empty((IEnumerable<object>) null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

      Validate(true, Attributes.RandomSequence());
      Validate(false, Enumerable.Empty<object>());
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence)
    {
      if (result)
      {
        Protect.From.Empty(sequence).Should().BeOfType<IEnumerable<T>>().And.BeSameAs(sequence);
      }
      else
      {
        AssertionExtensions.Should(() => Protect.From.Empty(sequence, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }
    }
  }
}