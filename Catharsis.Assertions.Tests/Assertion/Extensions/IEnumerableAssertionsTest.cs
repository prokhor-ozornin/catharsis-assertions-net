using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IEnumerableAssertions"/>.</para>
/// </summary>
public sealed class IEnumerableAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.Count{T}(IAssertion, IEnumerable{T}, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Count_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.Count(null, EmptySequence, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => IEnumerableAssertions.Count<object>(Assert.To, null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    AssertionExtensions.Should(() => Assert.To.Count(RandomSequence, int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Count(RandomSequence, int.MaxValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Count(RandomSequence, RandomSequence.Count()).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.Empty{T}(IAssertion, IEnumerable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.Empty(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => IEnumerableAssertions.Empty<object>(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    Assert.To.Empty(EmptySequence).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Empty(RandomSequence, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.EquivalentTo{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void EquivalentTo_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.EquivalentTo(null, EmptySequence, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.EquivalentTo(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.EquivalentTo(EmptySequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    Assert.To.EquivalentTo(Enumerable.Empty<object>(), Array.Empty<object>()).Should().NotBeNull().And.BeSameAs(Assert.To);
    
    Assert.To.EquivalentTo(EmptySequence, EmptySequence).Should().NotBeNull().And.BeSameAs(Assert.To);
    
    RandomSequence.With(sequence => Assert.To.EquivalentTo(sequence.ToList(), sequence.ToLinkedList()).Should().NotBeNull().And.BeSameAs(Assert.To));
    AssertionExtensions.Should(() => Assert.To.EquivalentTo(RandomSequence, EmptySequence, null, "error")).ThrowExactly<ArgumentException>();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.Contain{T}(IAssertion, IEnumerable{T}, T, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Contain_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.Contain(null, EmptySequence, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Contain(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    AssertionExtensions.Should(() => Assert.To.Contain(EmptySequence, new object(), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    
    AssertionExtensions.Should(() => Assert.To.Contain(RandomSequence, new object(), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    RandomSequence.With(sequence => Assert.To.Contain(sequence, sequence.Random()).Should().NotBeNull().And.BeSameAs(Assert.To));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.ContainAll{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainAll_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.ContainAll(null, EmptySequence, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ContainAll(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.ContainAll(EmptySequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    Assert.To.ContainAll(Enumerable.Empty<object>(), Array.Empty<object>()).Should().NotBeNull().And.BeSameAs(Assert.To);
    
    Assert.To.ContainAll(EmptySequence, EmptySequence, null, "error").Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.ContainAll(EmptySequence, RandomSequence, null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    RandomSequence.With(sequence => Assert.To.ContainAll(sequence, sequence.Reverse()).Should().NotBeNull().And.BeSameAs(Assert.To));
    Assert.To.ContainAll(RandomSequence, EmptySequence).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.ContainAnyOf{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainAnyOf_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.ContainAnyOf(null, EmptySequence, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(EmptySequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(EmptySequence, new object().ToSequence()).Should().NotBeNull().And.BeSameAs(Assert.To));
    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(EmptySequence, EmptySequence).Should().NotBeNull().And.BeSameAs(Assert.To));
    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(EmptySequence, RandomSequence).Should().NotBeNull().And.BeSameAs(Assert.To));

    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(RandomSequence, new object().ToSequence()).Should().NotBeNull().And.BeSameAs(Assert.To));
    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(RandomSequence, EmptySequence).Should().NotBeNull().And.BeSameAs(Assert.To));
    RandomSequence.With(sequence => Assert.To.ContainAnyOf(sequence, sequence.Random().ToSequence()).Should().NotBeNull().And.BeSameAs(Assert.To));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.ContainNulls{T}(IAssertion, IEnumerable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainNulls_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.ContainNulls(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ContainNulls<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    AssertionExtensions.Should(() => Assert.To.ContainNulls(EmptySequence, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.ContainNulls(RandomSequence, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.ContainNulls(1.Nulls()).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.ContainUnique{T}(IAssertion, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainUnique_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.ContainUnique(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ContainUnique<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    Assert.To.ContainUnique(EmptySequence).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.ContainUnique(RandomSequence).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.ContainUnique(2.Nulls(), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="IEnumerableAssertions.ElementAt{T}(IAssertion, IEnumerable{T}, int, T, string)"/></description></item>
  ///     <item><description><see cref="IEnumerableAssertions.ElementAt{T}(IAssertion, IEnumerable{T}, Index, T, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void ElementAt_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableAssertions.ElementAt(null, RandomSequence, default, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.ElementAt(null, default, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
      AssertionExtensions.Should(() => Assert.To.ElementAt(EmptySequence, 0, new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");
      AssertionExtensions.Should(() => Assert.To.ElementAt(RandomSequence, -1, new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");
      AssertionExtensions.Should(() => Assert.To.ElementAt(RandomSequence, RandomSequence.Count(), new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");

      RandomSequence.With(sequence => sequence.ForEach((index, element) =>
      {
        Assert.To.ElementAt(sequence, index, element).Should().NotBeNull().And.BeSameAs(Assert.To);
        AssertionExtensions.Should(() => Assert.To.ElementAt(sequence, index, null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }));
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableAssertions.ElementAt(null, RandomSequence, Index.Start, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.ElementAt(null, Index.Start, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

      RandomSequence.With(sequence => sequence.ForEach((index, element) =>
      {
        Assert.To.ElementAt(sequence, Index.FromStart(index), element).Should().NotBeNull().And.BeSameAs(Assert.To);
        AssertionExtensions.Should(() => Assert.To.ElementAt(sequence, Index.FromStart(index), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }));
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.SubsetOf{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void SubsetOf_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.SubsetOf(null, EmptySequence, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.SubsetOf(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("subset");
    AssertionExtensions.Should(() => Assert.To.SubsetOf(EmptySequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("superset");

    Assert.To.SubsetOf(EmptySequence, EmptySequence).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.SubsetOf(RandomSequence, RandomSequence).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.SubsetOf(EmptySequence, RandomSequence).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.SubsetOf(RandomSequence, EmptySequence, null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.SubsetOf(RandomSequence.Take(RandomSequence.Count() / 2), RandomSequence).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.SubsetOf(RandomSequence, RandomSequence.Randomize()).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.SubsetOf(new object().ToSequence(), new object().ToSequence(), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.SupersetOf{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void SupersetOf_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.SupersetOf(null, EmptySequence, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.SupersetOf(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("superset");
    AssertionExtensions.Should(() => Assert.To.SupersetOf(EmptySequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("subset");

    Assert.To.SupersetOf(EmptySequence, EmptySequence).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.SupersetOf(RandomSequence, RandomSequence).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.SupersetOf(RandomSequence, EmptySequence).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.SupersetOf(EmptySequence, RandomSequence, null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.SupersetOf(RandomSequence, RandomSequence.Take(RandomSequence.Count() / 2)).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.SupersetOf(RandomSequence, RandomSequence.Randomize()).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.SupersetOf(new object().ToSequence(), new object().ToSequence(), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.Reversed{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Reversed_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.Reversed(null, EmptySequence, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Reversed(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.Reversed(EmptySequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("reversed");

    Assert.To.Reversed(EmptySequence, EmptySequence).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Reversed(RandomSequence, RandomSequence, null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Reversed(RandomSequence, RandomSequence.Reverse()).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Reversed(RandomSequence, EmptySequence, null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Reversed(RandomSequence, RandomSequence.Take(RandomSequence.Count() / 2).Reverse(), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Reversed(2.Nulls(), 2.Nulls()).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.Ordered{T}(IAssertion, IEnumerable{T}, IComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Ordered_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.Ordered(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Ordered<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    AssertionExtensions.Should(() => Assert.To.Ordered(RandomSequence)).ThrowExactly<InvalidOperationException>();

    Assert.To.Ordered(EmptySequence).Should().NotBeNull().And.BeSameAs(Assert.To);

    Randomizer.IntSequence(byte.MaxValue).ToArray().With(sequence =>
    {
      AssertionExtensions.Should(() => Assert.To.Ordered(sequence, null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Ordered(sequence.Order()).Should().NotBeNull().And.BeSameAs(Assert.To);
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.StartWith{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void StartWith_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.StartWith(null, EmptySequence, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.StartWith(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.StartWith(EmptySequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    Assert.To.StartWith(EmptySequence, EmptySequence).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.StartWith(RandomSequence, EmptySequence).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.StartWith(RandomSequence, RandomSequence).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.StartWith(EmptySequence, RandomSequence, null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.StartWith(RandomSequence, RandomSequence.Take(RandomSequence.Count() / 2)).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.StartWith(RandomSequence, RandomSequence.Randomize(), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.StartWith(new object().ToSequence(), new object().ToSequence(), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.EndWith{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void EndWith_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.EndWith(null, EmptySequence, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.EndWith(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.EndWith(EmptySequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    Assert.To.EndWith(EmptySequence, EmptySequence).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.EndWith(RandomSequence, EmptySequence).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.EndWith(RandomSequence, RandomSequence).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.EndWith(EmptySequence, RandomSequence, null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.EndWith(RandomSequence, RandomSequence.TakeLast(RandomSequence.Count() / 2)).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.EndWith(RandomSequence, RandomSequence.Randomize(), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.EndWith(new object().ToSequence(), new object().ToSequence(), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.Match{T}(IAssertion, IEnumerable{T}, Predicate{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Match_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.Match(null, EmptySequence, _ => true)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Match<object>(null, _ => true)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.Match(EmptySequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("condition");

    Assert.To.Match(EmptySequence, _ => true).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.Match(EmptySequence, _ => false).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.Match(RandomSequence, _ => true).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Match(RandomSequence, _ => false, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Match(RandomSequence, element => element is not null).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.Match(1.Nulls(), element => element is null).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Match(1.Nulls(), element => element is not null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }
}