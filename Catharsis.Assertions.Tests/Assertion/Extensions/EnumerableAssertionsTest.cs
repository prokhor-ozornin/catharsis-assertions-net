using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="EnumerableAssertions"/>.</para>
/// </summary>
public sealed class EnumerableAssertionsTest : UnitTest
{
  private IEnumerable<object> Sequence { get; } = Enumerable.Empty<object>();

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.Count{T}(IAssertion, IEnumerable{T}, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Count_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.Count(null, Sequence, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => EnumerableAssertions.Count<object>(Assert.To, null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.Empty{T}(IAssertion, IEnumerable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.Empty(null, Sequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => EnumerableAssertions.Empty<object>(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.EquivalentTo{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void EquivalentTo_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.EquivalentTo(null, Sequence, Sequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.EquivalentTo(null, Sequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.EquivalentTo(Sequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.Contain{T}(IAssertion, IEnumerable{T}, T, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Contain_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.Contain(null, Sequence, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Contain(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.ContainAll{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainAll_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.ContainAll(null, Sequence, Sequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ContainAll(null, Sequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.ContainAll(Sequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.ContainAnyOf{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainAnyOf_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.ContainAnyOf(null, Sequence, Sequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(null, Sequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.ContainAnyOf(Sequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.ContainNulls{T}(IAssertion, IEnumerable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainNulls_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.ContainNulls(null, Sequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ContainNulls<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.ContainUnique{T}(IAssertion, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainUnique_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.ContainUnique(null, Sequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
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
      AssertionExtensions.Should(() => EnumerableAssertions.ElementAt(null, Sequence, default, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.ElementAt(null, default, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => EnumerableAssertions.ElementAt(null, Sequence, Index.Start, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
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
    AssertionExtensions.Should(() => EnumerableAssertions.SubsetOf(null, Sequence, Sequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.SubsetOf(null, Sequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.SubsetOf(Sequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("superset");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.SupersetOf{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void SupersetOf_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.SupersetOf(null, Sequence, Sequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.SupersetOf(null, Sequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.SupersetOf(Sequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("subset");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.Reversed{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Reversed_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.Reversed(null, Sequence, Sequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Reversed(null, Sequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.Reversed(Sequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("reversed");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.Ordered{T}(IAssertion, IEnumerable{T}, IComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Ordered_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.Ordered(null, Sequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Ordered<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.StartWith{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void StartWith_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.StartWith(null, Sequence, Sequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.StartWith(null, Sequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.StartWith(Sequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.EndWith{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void EndWith_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.EndWith(null, Sequence, Sequence)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.EndWith(null, Sequence)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.EndWith(Sequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableAssertions.Match{T}(IAssertion, IEnumerable{T}, Predicate{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Match_Method()
  {
    AssertionExtensions.Should(() => EnumerableAssertions.Match(null, Sequence, _ => true)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Match<object>(null, _ => true)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
    AssertionExtensions.Should(() => Assert.To.Match(Sequence, null)).ThrowExactly<ArgumentNullException>().WithParameterName("condition");

    throw new NotImplementedException();
  }
}