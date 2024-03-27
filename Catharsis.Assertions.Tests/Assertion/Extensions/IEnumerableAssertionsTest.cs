using Catharsis.Commons;
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
    AssertionExtensions.Should(() => IEnumerableAssertions.Count(null, Attributes.EmptySequence(), default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => IEnumerableAssertions.Count<object>(Assert.To, null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    AssertionExtensions.Should(() => Assert.To.Count(Attributes.RandomSequence(), int.MinValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Count(Attributes.RandomSequence(), int.MaxValue, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Count(Attributes.RandomSequence(), Attributes.RandomSequence().Count()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.Empty{T}(IAssertion, IEnumerable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.Empty(null, Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => IEnumerableAssertions.Empty<object>(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    Assert.To.Empty(Attributes.EmptySequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Empty(Attributes.RandomSequence(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.EquivalentTo{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void EquivalentTo_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.EquivalentTo(null, Attributes.EmptySequence(), Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.EquivalentTo(null, Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.EquivalentTo(Attributes.EmptySequence(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    Assert.To.EquivalentTo(Enumerable.Empty<object>(), []).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    
    Assert.To.EquivalentTo(Attributes.EmptySequence(), Attributes.EmptySequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);

    Attributes.RandomSequence().With(sequence => Assert.To.EquivalentTo(sequence.ToList(), sequence.ToLinkedList()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To));
    AssertionExtensions.Should(() => Assert.To.EquivalentTo(Attributes.RandomSequence(), Attributes.EmptySequence(), null, "error")).ThrowExactly<InvalidOperationException>();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.Contain{T}(IAssertion, IEnumerable{T}, T, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Contain_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.Contain(null, Attributes.EmptySequence(), new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Contain(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    AssertionExtensions.Should(() => Assert.To.Contain(Attributes.EmptySequence(), new object(), null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    
    AssertionExtensions.Should(() => Assert.To.Contain(Attributes.RandomSequence(), new object(), null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Attributes.RandomSequence().With(sequence => Assert.To.Contain(sequence, sequence.Random()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.ContainAll{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainAll_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.ContainAll(null, Attributes.EmptySequence(), Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ContainAll(null, Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.ContainAll(Attributes.EmptySequence(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    Assert.To.ContainAll(Enumerable.Empty<object>(), []).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    
    Assert.To.ContainAll(Attributes.EmptySequence(), Attributes.EmptySequence(), null, "error").Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.ContainAll(Attributes.EmptySequence(), Attributes.RandomSequence(), null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");

    Attributes.RandomSequence().With(sequence => Assert.To.ContainAll(sequence, sequence.Reverse()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To));
    Assert.To.ContainAll(Attributes.RandomSequence(), Attributes.EmptySequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.ContainAnyOf{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainAnyOf_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.ContainAnyOf(null, Attributes.EmptySequence(), Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(null, Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(Attributes.EmptySequence(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(Attributes.EmptySequence(), new object().ToSequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To));
    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(Attributes.EmptySequence(), Attributes.EmptySequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To));
    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(Attributes.EmptySequence(), Attributes.RandomSequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To));

    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(Attributes.RandomSequence(), new object().ToSequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To));
    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(Attributes.RandomSequence(), Attributes.EmptySequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To));
    Attributes.RandomSequence().With(sequence => Assert.To.ContainAnyOf(sequence, sequence.Random().ToSequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.ContainNulls{T}(IAssertion, IEnumerable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainNulls_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.ContainNulls(null, Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ContainNulls<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    AssertionExtensions.Should(() => Assert.To.ContainNulls(Attributes.EmptySequence(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.ContainNulls(Attributes.RandomSequence(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.ContainNulls(1.Nulls()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.ContainUnique{T}(IAssertion, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainUnique_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.ContainUnique(null, Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ContainUnique<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    Assert.To.ContainUnique(Attributes.EmptySequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    Assert.To.ContainUnique(Attributes.RandomSequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.ContainUnique(2.Nulls(), null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
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
      AssertionExtensions.Should(() => IEnumerableAssertions.ElementAt(null, Attributes.RandomSequence(), default, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.ElementAt(null, default, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
      AssertionExtensions.Should(() => Assert.To.ElementAt(Attributes.EmptySequence(), 0, new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");
      AssertionExtensions.Should(() => Assert.To.ElementAt(Attributes.RandomSequence(), -1, new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");
      AssertionExtensions.Should(() => Assert.To.ElementAt(Attributes.RandomSequence(), Attributes.RandomSequence().Count(), new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");

      Attributes.RandomSequence().With(sequence => sequence.ForEach((index, element) =>
      {
        Assert.To.ElementAt(sequence, index, element).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        AssertionExtensions.Should(() => Assert.To.ElementAt(sequence, index, null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }));
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableAssertions.ElementAt(null, Attributes.RandomSequence(), Index.Start, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.ElementAt(null, Index.Start, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

      Attributes.RandomSequence().With(sequence => sequence.ForEach((index, element) =>
      {
        Assert.To.ElementAt(sequence, Index.FromStart(index), element).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        AssertionExtensions.Should(() => Assert.To.ElementAt(sequence, Index.FromStart(index), null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }));
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.SubsetOf{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void SubsetOf_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.SubsetOf(null, Attributes.EmptySequence(), Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.SubsetOf(null, Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("subset");
    AssertionExtensions.Should(() => Assert.To.SubsetOf(Attributes.EmptySequence(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("superset");

    Assert.To.SubsetOf(Attributes.EmptySequence(), Attributes.EmptySequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    Assert.To.SubsetOf(Attributes.RandomSequence(), Attributes.RandomSequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    Assert.To.SubsetOf(Attributes.EmptySequence(), Attributes.RandomSequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.SubsetOf(Attributes.RandomSequence(), Attributes.EmptySequence(), null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.SubsetOf(Attributes.RandomSequence().Take(Attributes.RandomSequence().Count() / 2), Attributes.RandomSequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    Assert.To.SubsetOf(Attributes.RandomSequence(), Attributes.RandomSequence().Randomize()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.SubsetOf(new object().ToSequence(), new object().ToSequence(), null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.SupersetOf{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void SupersetOf_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.SupersetOf(null, Attributes.EmptySequence(), Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.SupersetOf(null, Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("superset");
    AssertionExtensions.Should(() => Assert.To.SupersetOf(Attributes.EmptySequence(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("subset");

    Assert.To.SupersetOf(Attributes.EmptySequence(), Attributes.EmptySequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    Assert.To.SupersetOf(Attributes.RandomSequence(), Attributes.RandomSequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    Assert.To.SupersetOf(Attributes.RandomSequence(), Attributes.EmptySequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.SupersetOf(Attributes.EmptySequence(), Attributes.RandomSequence(), null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.SupersetOf(Attributes.RandomSequence(), Attributes.RandomSequence().Take(Attributes.RandomSequence().Count() / 2)).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    Assert.To.SupersetOf(Attributes.RandomSequence(), Attributes.RandomSequence().Randomize()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.SupersetOf(new object().ToSequence(), new object().ToSequence(), null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.Reversed{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Reversed_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.Reversed(null, Attributes.EmptySequence(), Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Reversed(null, Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.Reversed(Attributes.EmptySequence(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("reversed");

    Assert.To.Reversed(Attributes.EmptySequence(), Attributes.EmptySequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Reversed(Attributes.RandomSequence(), Attributes.RandomSequence(), null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Reversed(Attributes.RandomSequence(), Attributes.RandomSequence().Reverse()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Reversed(Attributes.RandomSequence(), Attributes.EmptySequence(), null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Reversed(Attributes.RandomSequence(), Attributes.RandomSequence().Take(Attributes.RandomSequence().Count() / 2).Reverse(), null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Reversed(2.Nulls(), 2.Nulls()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.Ordered{T}(IAssertion, IEnumerable{T}, IComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Ordered_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.Ordered(null, Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Ordered<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    AssertionExtensions.Should(() => Assert.To.Ordered(Attributes.RandomSequence())).ThrowExactly<InvalidOperationException>();

    Assert.To.Ordered(Attributes.EmptySequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);

    Attributes.Random().IntSequence(byte.MaxValue).ToArray().With(sequence =>
    {
      AssertionExtensions.Should(() => Assert.To.Ordered(sequence, null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Ordered(sequence.Order()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.StartWith{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void StartWith_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.StartWith(null, Attributes.EmptySequence(), Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.StartWith(null, Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.StartWith(Attributes.EmptySequence(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    Assert.To.StartWith(Attributes.EmptySequence(), Attributes.EmptySequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    Assert.To.StartWith(Attributes.RandomSequence(), Attributes.EmptySequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    Assert.To.StartWith(Attributes.RandomSequence(), Attributes.RandomSequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.StartWith(Attributes.EmptySequence(), Attributes.RandomSequence(), null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.StartWith(Attributes.RandomSequence(), Attributes.RandomSequence().Take(Attributes.RandomSequence().Count() / 2)).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.StartWith(Attributes.RandomSequence(), Attributes.RandomSequence().Randomize(), null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.StartWith(new object().ToSequence(), new object().ToSequence(), null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.EndWith{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void EndWith_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.EndWith(null, Attributes.EmptySequence(), Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.EndWith(null, Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.EndWith(Attributes.EmptySequence(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    Assert.To.EndWith(Attributes.EmptySequence(), Attributes.EmptySequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    Assert.To.EndWith(Attributes.RandomSequence(), Attributes.EmptySequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    Assert.To.EndWith(Attributes.RandomSequence(), Attributes.RandomSequence()).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.EndWith(Attributes.EmptySequence(), Attributes.RandomSequence(), null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.EndWith(Attributes.RandomSequence(), Attributes.RandomSequence().TakeLast(Attributes.RandomSequence().Count() / 2)).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.EndWith(Attributes.RandomSequence(), Attributes.RandomSequence().Randomize(), null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.EndWith(new object().ToSequence(), new object().ToSequence(), null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.Match{T}(IAssertion, IEnumerable{T}, Predicate{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Match_Method()
  {
    AssertionExtensions.Should(() => IEnumerableAssertions.Match(null, Attributes.EmptySequence(), _ => true)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Match<object>(null, _ => true)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.Match(Attributes.EmptySequence(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("condition");

    Assert.To.Match(Attributes.EmptySequence(), _ => true).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    Assert.To.Match(Attributes.EmptySequence(), _ => false).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    Assert.To.Match(Attributes.RandomSequence(), _ => true).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Match(Attributes.RandomSequence(), _ => false, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Match(Attributes.RandomSequence(), element => element is not null).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    Assert.To.Match(1.Nulls(), element => element is null).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Match(1.Nulls(), element => element is not null, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }
}