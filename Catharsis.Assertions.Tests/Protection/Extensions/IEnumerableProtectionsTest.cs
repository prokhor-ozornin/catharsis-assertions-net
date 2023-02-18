using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using Catharsis.Extensions;

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
    AssertionExtensions.Should(() => IEnumerableProtections.Empty(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
    AssertionExtensions.Should(() => Protect.From.Empty((IEnumerable<object>) null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    EmptySequence.With(sequence => AssertionExtensions.Should(() => Protect.From.Empty(sequence, "error")).ThrowExactly<ArgumentException>().WithMessage("error"));
    RandomSequence.With(sequence => Protect.From.Empty(sequence).Should().NotBeNull().And.BeSameAs(sequence));
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="IEnumerableProtections.AnyOf{T}(IProtection,T, IEnumerable{T}, string)"/></description></item>
  ///     <item><description><see cref="IEnumerableProtections.AnyOf{T}(IProtection, T, string, T[])"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void AnyOf_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableProtections.AnyOf(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.AnyOf(new object(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("values");

      AssertionExtensions.Should(() => Protect.From.AnyOf(null, new[] { string.Empty, null }, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

      EmptySequence.With(sequence => Protect.From.AnyOf(string.Empty, sequence).Should().NotBeNull().And.BeSameAs(string.Empty));
      RandomSequence.With(sequence => Protect.From.AnyOf(string.Empty, sequence).Should().NotBeNull().And.BeSameAs(string.Empty));
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableProtections.AnyOf(null, new object(), null, Array.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("protection");
      AssertionExtensions.Should(() => Protect.From.AnyOf(new object(), "error", null)).ThrowExactly<ArgumentNullException>().WithParameterName("values");

      AssertionExtensions.Should(() => Protect.From.AnyOf(null, "error", string.Empty, null)).ThrowExactly<ArgumentException>().WithMessage("error");

      EmptySequence.With(sequence => Protect.From.AnyOf(string.Empty, sequence.AsArray()).Should().NotBeNull().And.BeSameAs(string.Empty));
      RandomSequence.With(sequence => Protect.From.AnyOf(string.Empty, sequence.AsArray()).Should().NotBeNull().And.BeSameAs(string.Empty));
    }
  }
}