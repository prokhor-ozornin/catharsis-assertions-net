using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IEnumerableExpectations"/>.</para>
/// </summary>
public sealed class IEnumerableExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.Count{T}(IExpectation{IEnumerable{T}}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Count_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.Count<object>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Count(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    RandomSequence.Expect().Count(int.MinValue).Result.Should().BeFalse();
    RandomSequence.Expect().Count(int.MaxValue).Result.Should().BeFalse();
    RandomSequence.Expect().Count(RandomSequence.Count()).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.Empty{T}(IExpectation{IEnumerable{T}})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.Empty<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    EmptySequence.Expect().Empty().Result.Should().BeTrue();
    RandomSequence.Expect().Empty().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.EquivalentTo{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void EquivalentTo_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.EquivalentTo(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().EquivalentTo(EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => EmptySequence.Expect().EquivalentTo(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    Enumerable.Empty<object>().Expect().EquivalentTo([]).Result.Should().BeTrue();
    
    EmptySequence.Expect().EquivalentTo(EmptySequence).Result.Should().BeTrue();
    
    RandomSequence.With(sequence => sequence.ToList().Expect().EquivalentTo(sequence.ToLinkedList()).Result.Should().BeTrue());
    RandomSequence.Expect().EquivalentTo(EmptySequence).Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.Contain{T}(IExpectation{IEnumerable{T}}, T, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Contain_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.Contain(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Contain(new object())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    EmptySequence.Expect().Contain(new object()).Result.Should().BeFalse();
    
    RandomSequence.Expect().Contain(new object()).Result.Should().BeFalse();
    RandomSequence.With(sequence => sequence.Expect().Contain(sequence.Random()).Result.Should().BeTrue());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.ContainAll{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainAll_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.ContainAll(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ContainAll(EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => EmptySequence.Expect().ContainAll(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    Enumerable.Empty<object>().Expect().ContainAll([]).Result.Should().BeTrue();
    
    EmptySequence.Expect().ContainAll(EmptySequence).Result.Should().BeTrue();
    EmptySequence.Expect().ContainAll(RandomSequence).Result.Should().BeFalse();

    RandomSequence.With(sequence => sequence.Expect().ContainAll(sequence.Reverse()).Result.Should().BeTrue());
    RandomSequence.Expect().ContainAll(EmptySequence).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.ContainAnyOf{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainAnyOf_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.ContainAnyOf(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ContainAnyOf(EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => EmptySequence.Expect().ContainAnyOf(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    EmptySequence.Expect().ContainAnyOf(new object().ToSequence()).Result.Should().BeFalse();
    EmptySequence.Expect().ContainAnyOf(EmptySequence).Result.Should().BeFalse();
    EmptySequence.Expect().ContainAnyOf(RandomSequence).Result.Should().BeFalse();

    RandomSequence.Expect().ContainAnyOf(new object().ToSequence()).Result.Should().BeFalse();
    RandomSequence.Expect().ContainAnyOf(EmptySequence).Result.Should().BeFalse();
    RandomSequence.With(sequence => sequence.Expect().ContainAnyOf(new[] { sequence.Random() }).Result.Should().BeTrue());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.ContainNulls{T}(IExpectation{IEnumerable{T}})"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainNulls_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.ContainNulls<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ContainNulls()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    EmptySequence.Expect().ContainNulls().Result.Should().BeFalse();
    RandomSequence.Expect().ContainNulls().Result.Should().BeFalse();
    1.Nulls().Expect().ContainNulls().Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.ContainUnique{T}(IExpectation{IEnumerable{T}}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainUnique_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.ContainUnique<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ContainUnique()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    EmptySequence.Expect().ContainUnique().Result.Should().BeTrue();
    RandomSequence.Expect().ContainUnique().Result.Should().BeTrue();
    2.Nulls().Expect().ContainUnique().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="IEnumerableExpectations.ElementAt{T}(IExpectation{IEnumerable{T}}, int, T)"/></description></item>
  ///     <item><description><see cref="IEnumerableExpectations.ElementAt{T}(IExpectation{IEnumerable{T}}, Index, T)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void ElementAt_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableExpectations.ElementAt(null, default, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
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
      AssertionExtensions.Should(() => IEnumerableExpectations.ElementAt(null, Index.Start, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
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
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.SubsetOf{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void SubsetOf_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.SubsetOf(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
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
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.SupersetOf{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void SupersetOf_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.SupersetOf(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
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
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.Reversed{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Reversed_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.Reversed(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
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
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.Ordered{T}(IExpectation{IEnumerable{T}}, IComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Ordered_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.Ordered<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Ordered()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    AssertionExtensions.Should(() => RandomSequence.Expect().Ordered()).ThrowExactly<InvalidOperationException>();

    EmptySequence.Expect().Ordered().Result.Should().BeTrue();
    
    Randomizer.IntSequence(byte.MaxValue).ToArray().With(sequence =>
    {
      sequence.Expect().Ordered().Result.Should().BeFalse();
      sequence.Order().Expect().Ordered().Result.Should().BeTrue();
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.StartWith{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void StartWith_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.StartWith(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().StartWith(EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => EmptySequence.Expect().StartWith(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    EmptySequence.Expect().StartWith(EmptySequence).Result.Should().BeTrue();
    RandomSequence.Expect().StartWith(EmptySequence).Result.Should().BeTrue();
    RandomSequence.Expect().StartWith(RandomSequence).Result.Should().BeTrue();
    EmptySequence.Expect().StartWith(RandomSequence).Result.Should().BeFalse();
    RandomSequence.Expect().StartWith(RandomSequence.Take(RandomSequence.Count() / 2)).Result.Should().BeTrue();
    RandomSequence.Expect().StartWith(RandomSequence.Randomize()).Result.Should().BeFalse();
    new object().ToSequence().Expect().StartWith(new object().ToSequence()).Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.EndWith{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void EndWith_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.EndWith(null, EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().EndWith(EmptySequence)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => EmptySequence.Expect().EndWith(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    EmptySequence.Expect().EndWith(EmptySequence).Result.Should().BeTrue();
    RandomSequence.Expect().EndWith(EmptySequence).Result.Should().BeTrue();
    RandomSequence.Expect().EndWith(RandomSequence).Result.Should().BeTrue();
    EmptySequence.Expect().EndWith(RandomSequence).Result.Should().BeFalse();
    RandomSequence.Expect().EndWith(RandomSequence.TakeLast(RandomSequence.Count() / 2)).Result.Should().BeTrue();
    RandomSequence.Expect().EndWith(RandomSequence.Randomize()).Result.Should().BeFalse();
    new object().ToSequence().Expect().EndWith(new object().ToSequence()).Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.Match{T}(IExpectation{IEnumerable{T}}, Predicate{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Match_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.Match<object>(null, _ => true)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Match(_ => true)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => EmptySequence.Expect().Match(null)).ThrowExactly<ArgumentNullException>().WithParameterName("condition");

    EmptySequence.Expect().Match(_ => true).Result.Should().BeTrue();
    EmptySequence.Expect().Match(_ => false).Result.Should().BeTrue();
    RandomSequence.Expect().Match(_ => true).Result.Should().BeTrue();
    RandomSequence.Expect().Match(_ => false).Result.Should().BeFalse();
    RandomSequence.Expect().Match(element => element is not null).Result.Should().BeTrue();
    1.Nulls().Expect().Match(element => element is null).Result.Should().BeTrue();
    1.Nulls().Expect().Match(element => element is not null).Result.Should().BeFalse();
  }
}