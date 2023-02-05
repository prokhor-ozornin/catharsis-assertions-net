using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="EnumerableAssertions"/>.</para>
/// </summary>
public sealed class EnumerableAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.Count{T}(IAssertion, IEnumerable{T}, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Count_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.Count(null, EmptySequence, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => EnumerableAssertions.Count<object>(Assert.To, null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    AssertionExtensions.Should(() => Assert.To.Count(RandomSequence, int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Count(RandomSequence, int.MaxValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Count(RandomSequence, RandomSequence.Count()).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.Empty{T}(IAssertion, IEnumerable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.Empty(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => EnumerableAssertions.Empty<object>(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    Assert.To.Empty(EmptySequence).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Empty(RandomSequence, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.EquivalentTo{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void EquivalentTo_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.EquivalentTo(null, EmptySequence, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.EquivalentTo(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.EquivalentTo(EmptySequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    Assert.To.EquivalentTo(Enumerable.Empty<object>(), Array.Empty<object>()).Should().NotBeNull().And.BeSameAs(Assert.To);
    
    Assert.To.EquivalentTo(EmptySequence, EmptySequence).Should().NotBeNull().And.BeSameAs(Assert.To);
    
    RandomSequence.ToArray().With(sequence => Assert.To.EquivalentTo(sequence.ToList(), sequence.ToLinkedList()).Should().NotBeNull().And.BeSameAs(Assert.To));
    AssertionExtensions.Should(() => Assert.To.EquivalentTo(RandomSequence, EmptySequence, null, "error")).ThrowExactly<ArgumentException>();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.Contain{T}(IAssertion, IEnumerable{T}, T, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Contain_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.Contain(null, EmptySequence, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Contain(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    AssertionExtensions.Should(() => Assert.To.Contain(EmptySequence, new object(), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    
    AssertionExtensions.Should(() => Assert.To.Contain(RandomSequence, new object(), null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    RandomSequence.ToArray().With(sequence => Assert.To.Contain(sequence, sequence.Random()).Should().NotBeNull().And.BeSameAs(Assert.To));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.ContainAll{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainAll_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.ContainAll(null, EmptySequence, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ContainAll(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.ContainAll(EmptySequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    Assert.To.ContainAll(Enumerable.Empty<object>(), Array.Empty<object>()).Should().NotBeNull().And.BeSameAs(Assert.To);
    
    Assert.To.ContainAll(EmptySequence, EmptySequence, null, "error").Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.ContainAll(EmptySequence, RandomSequence, null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    RandomSequence.ToArray().With(sequence => Assert.To.ContainAll(sequence, sequence.Reverse()).Should().NotBeNull().And.BeSameAs(Assert.To));
    Assert.To.ContainAll(RandomSequence, EmptySequence).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.ContainAnyOf{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainAnyOf_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.ContainAnyOf(null, EmptySequence, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(EmptySequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(EmptySequence, new object[] { new() }).Should().NotBeNull().And.BeSameAs(Assert.To));
    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(EmptySequence, EmptySequence).Should().NotBeNull().And.BeSameAs(Assert.To));
    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(EmptySequence, RandomSequence).Should().NotBeNull().And.BeSameAs(Assert.To));

    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(RandomSequence, new object[] { new() }).Should().NotBeNull().And.BeSameAs(Assert.To));
    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(RandomSequence, EmptySequence).Should().NotBeNull().And.BeSameAs(Assert.To));
    RandomSequence.ToArray().With(sequence => Assert.To.ContainAnyOf(sequence, new[] { sequence.Random() }).Should().NotBeNull().And.BeSameAs(Assert.To));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.ContainNulls{T}(IAssertion, IEnumerable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainNulls_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.ContainNulls(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ContainNulls<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.ContainUnique{T}(IAssertion, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainUnique_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.ContainUnique(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ContainUnique<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="EnumerableAssertions.ElementAt{T}(IAssertion, IEnumerable{T}, int, T, string)"/></description></item>
  ///     <item><description><see cref="EnumerableAssertions.ElementAt{T}(IAssertion, IEnumerable{T}, Index, T, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void ElementAt_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => EnumerableAssertions.ElementAt(null, EmptySequence, default, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.ElementAt(null, default, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => EnumerableAssertions.ElementAt(null, EmptySequence, Index.Start, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.ElementAt(null, Index.Start, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.SubsetOf{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void SubsetOf_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.SubsetOf(null, EmptySequence, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.SubsetOf(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.SubsetOf(EmptySequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("superset");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.SupersetOf{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void SupersetOf_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.SupersetOf(null, EmptySequence, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.SupersetOf(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.SupersetOf(EmptySequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("subset");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.Reversed{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Reversed_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.Reversed(null, EmptySequence, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Reversed(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.Reversed(EmptySequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("reversed");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.Ordered{T}(IAssertion, IEnumerable{T}, IComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Ordered_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.Ordered(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Ordered<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.StartWith{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void StartWith_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.StartWith(null, EmptySequence, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.StartWith(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.StartWith(EmptySequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.EndWith{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void EndWith_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.EndWith(null, EmptySequence, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.EndWith(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.EndWith(EmptySequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.Match{T}(IAssertion, IEnumerable{T}, Predicate{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Match_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.Match(null, EmptySequence, _ => true)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Match<object>(null, _ => true)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.Match(EmptySequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("condition");

    throw new NotImplementedException();
  }
}