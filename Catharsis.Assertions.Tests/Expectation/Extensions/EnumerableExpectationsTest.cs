using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="EnumerableExpectations"/>.</para>
/// </summary>
public sealed class EnumerableExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableExpectations.Count{T}(IExpectation{IEnumerable{T}}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Count_Method()
  {
    AssertionExtensions.Should(() => EnumerableExpectations.Count<object>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Count(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    RandomSequence.Expect().Count(int.MinValue).Result.Should().BeFalse();
    RandomSequence.Expect().Count(int.MaxValue).Result.Should().BeFalse();
    RandomSequence.Expect().Count(RandomSequence.Count()).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableExpectations.Empty{T}(IExpectation{IEnumerable{T}})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => EnumerableExpectations.Empty<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    EmptySequence.Expect().Empty().Result.Should().BeTrue();
    RandomSequence.Expect().Empty().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableExpectations.EquivalentTo{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void EquivalentTo_Method()
  {
    AssertionExtensions.Should(() => EnumerableExpectations.EquivalentTo(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().EquivalentTo(EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => EmptySequence.Expect().EquivalentTo(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    Enumerable.Empty<object>().Expect().EquivalentTo(Array.Empty<object>()).Result.Should().BeTrue();
    
    EmptySequence.Expect().EquivalentTo(EmptySequence).Result.Should().BeTrue();
    
    RandomSequence.With(sequence => sequence.ToList().Expect().EquivalentTo(sequence.ToLinkedList()).Result.Should().BeTrue());
    RandomSequence.Expect().EquivalentTo(EmptySequence).Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableExpectations.Contain{T}(IExpectation{IEnumerable{T}}, T, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Contain_Method()
  {
    AssertionExtensions.Should(() => EnumerableExpectations.Contain(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Contain(new object())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    EmptySequence.Expect().Contain(new object()).Result.Should().BeFalse();
    
    RandomSequence.Expect().Contain(new object()).Result.Should().BeFalse();
    RandomSequence.With(sequence => sequence.Expect().Contain(sequence.Random()).Result.Should().BeTrue());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableExpectations.ContainAll{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainAll_Method()
  {
    AssertionExtensions.Should(() => EnumerableExpectations.ContainAll(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ContainAll(EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => EmptySequence.Expect().ContainAll(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    Enumerable.Empty<object>().Expect().ContainAll(Array.Empty<object>()).Result.Should().BeTrue();
    
    EmptySequence.Expect().ContainAll(EmptySequence).Result.Should().BeTrue();
    EmptySequence.Expect().ContainAll(RandomSequence).Result.Should().BeFalse();

    RandomSequence.With(sequence => sequence.Expect().ContainAll(sequence.Reverse()).Result.Should().BeTrue());
    RandomSequence.Expect().ContainAll(EmptySequence).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableExpectations.ContainAnyOf{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainAnyOf_Method()
  {
    AssertionExtensions.Should(() => EnumerableExpectations.ContainAnyOf(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ContainAnyOf(EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => EmptySequence.Expect().ContainAnyOf(null)).ThrowExactly<ArgumentNullException>().WithParameterName("elements");

    EmptySequence.Expect().ContainAnyOf(new object().ToSequence()).Result.Should().BeFalse();
    EmptySequence.Expect().ContainAnyOf(EmptySequence).Result.Should().BeFalse();
    EmptySequence.Expect().ContainAnyOf(RandomSequence).Result.Should().BeFalse();

    RandomSequence.Expect().ContainAnyOf(new object().ToSequence()).Result.Should().BeFalse();
    RandomSequence.Expect().ContainAnyOf(EmptySequence).Result.Should().BeFalse();
    RandomSequence.With(sequence => sequence.Expect().ContainAnyOf(new[] { sequence.Random() }).Result.Should().BeTrue());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableExpectations.ContainNulls{T}(IExpectation{IEnumerable{T}})"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainNulls_Method()
  {
    AssertionExtensions.Should(() => EnumerableExpectations.ContainNulls<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ContainNulls()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    EmptySequence.Expect().ContainNulls().Result.Should().BeFalse();
    RandomSequence.Expect().ContainNulls().Result.Should().BeFalse();
    1.Nulls().Expect().ContainNulls().Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableExpectations.ContainUnique{T}(IExpectation{IEnumerable{T}}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainUnique_Method()
  {
    AssertionExtensions.Should(() => EnumerableExpectations.ContainUnique<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ContainUnique()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    EmptySequence.Expect().ContainUnique().Result.Should().BeTrue();
    RandomSequence.Expect().ContainUnique().Result.Should().BeTrue();
    2.Nulls().Expect().ContainUnique().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="EnumerableExpectations.ElementAt{T}(IExpectation{IEnumerable{T}}, int, T)"/></description></item>
  ///     <item><description><see cref="EnumerableExpectations.ElementAt{T}(IExpectation{IEnumerable{T}}, Index, T)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void ElementAt_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => EnumerableExpectations.ElementAt(null, default, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ElementAt(default, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => EmptySequence.Expect().ElementAt(0, new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");
      AssertionExtensions.Should(() => RandomSequence.Expect().ElementAt(-1, new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");
      AssertionExtensions.Should(() => RandomSequence.Expect().ElementAt(RandomSequence.Count(), new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");

      RandomSequence.With(sequence => sequence.ForEach((index, element) =>
      {
        sequence.Expect().ElementAt(index, element).Result.Should().BeTrue();
        sequence.Expect().ElementAt(index, null).Result.Should().BeFalse();
      }));
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => EnumerableExpectations.ElementAt(null, Index.Start, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ElementAt(Index.Start, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => EmptySequence.Expect().ElementAt(Index.FromStart(0), new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");
      AssertionExtensions.Should(() => RandomSequence.Expect().ElementAt(Index.FromStart(RandomSequence.Count()), new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");

      RandomSequence.With(sequence => sequence.ForEach((index, element) =>
      {
        sequence.Expect().ElementAt(Index.FromStart(index), element).Result.Should().BeTrue();
        sequence.Expect().ElementAt(Index.FromStart(index), null).Result.Should().BeFalse();
      }));
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableExpectations.SubsetOf{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void SubsetOf_Method()
  {
    AssertionExtensions.Should(() => EnumerableExpectations.SubsetOf(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().SubsetOf(EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => EmptySequence.Expect().SubsetOf(null)).ThrowExactly<ArgumentNullException>().WithParameterName("superset");

    EmptySequence.Expect().SubsetOf(EmptySequence).Result.Should().BeTrue();
    RandomSequence.Expect().SubsetOf(RandomSequence).Result.Should().BeTrue();
    EmptySequence.Expect().SubsetOf(RandomSequence).Result.Should().BeTrue();
    RandomSequence.Expect().SubsetOf(EmptySequence).Result.Should().BeFalse();
    RandomSequence.Take(RandomSequence.Count() / 2).Expect().SubsetOf(RandomSequence).Result.Should().BeTrue();
    RandomSequence.Expect().SubsetOf(RandomSequence.Randomize()).Result.Should().BeTrue();
    new object().ToSequence().Expect().SubsetOf(new object().ToSequence()).Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableExpectations.SupersetOf{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void SupersetOf_Method()
  {
    AssertionExtensions.Should(() => EnumerableExpectations.SupersetOf(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().SupersetOf(EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => EmptySequence.Expect().SupersetOf(null)).ThrowExactly<ArgumentNullException>().WithParameterName("subset");

    EmptySequence.Expect().SupersetOf(EmptySequence).Result.Should().BeTrue();
    RandomSequence.Expect().SupersetOf(RandomSequence).Result.Should().BeTrue();
    RandomSequence.Expect().SupersetOf(EmptySequence).Result.Should().BeTrue();
    EmptySequence.Expect().SupersetOf(RandomSequence).Result.Should().BeFalse();
    RandomSequence.Expect().SupersetOf(RandomSequence.Take(RandomSequence.Count() / 2)).Result.Should().BeTrue();
    RandomSequence.Expect().SupersetOf(RandomSequence.Randomize()).Result.Should().BeTrue();
    new object().ToSequence().Expect().SupersetOf(new object().ToSequence()).Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableExpectations.Reversed{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Reversed_Method()
  {
    AssertionExtensions.Should(() => EnumerableExpectations.Reversed(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Reversed(EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => EmptySequence.Expect().Reversed(null)).ThrowExactly<ArgumentNullException>().WithParameterName("reversed");

    EmptySequence.Expect().Reversed(EmptySequence).Result.Should().BeTrue();
    RandomSequence.Expect().Reversed(RandomSequence).Result.Should().BeFalse();
    RandomSequence.Expect().Reversed(RandomSequence.Reverse()).Result.Should().BeTrue();
    RandomSequence.Expect().Reversed(EmptySequence).Result.Should().BeFalse();
    RandomSequence.Expect().Reversed(RandomSequence.Take(RandomSequence.Count() / 2).Reverse()).Result.Should().BeFalse();
    2.Nulls().Expect().Reversed(2.Nulls()).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableExpectations.Ordered{T}(IExpectation{IEnumerable{T}}, IComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Ordered_Method()
  {
    AssertionExtensions.Should(() => EnumerableExpectations.Ordered<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Ordered()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    EmptySequence.Expect().Ordered().Result.Should().BeTrue();
    AssertionExtensions.Should(() => RandomSequence.Expect().Ordered()).ThrowExactly<InvalidOperationException>();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableExpectations.StartWith{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void StartWith_Method()
  {
    AssertionExtensions.Should(() => EnumerableExpectations.StartWith(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().StartWith(EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => EmptySequence.Expect().StartWith(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableExpectations.EndWith{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void EndWith_Method()
  {
    AssertionExtensions.Should(() => EnumerableExpectations.EndWith(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().EndWith(EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => EmptySequence.Expect().EndWith(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="EnumerableExpectations.Match{T}(IExpectation{IEnumerable{T}}, Predicate{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Match_Method()
  {
    AssertionExtensions.Should(() => EnumerableExpectations.Match<object>(null, _ => true)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Match(_ => true)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => EmptySequence.Expect().Match(null)).ThrowExactly<ArgumentNullException>().WithParameterName("condition");

    throw new NotImplementedException();
  }
}