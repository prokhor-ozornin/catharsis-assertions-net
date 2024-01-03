using Catharsis.Commons;
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

    Attributes.RandomSequence().Expect().Count(int.MinValue).Result.Should().BeFalse();
    Attributes.RandomSequence().Expect().Count(int.MaxValue).Result.Should().BeFalse();
    Attributes.RandomSequence().Expect().Count(Attributes.RandomSequence().Count()).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.Empty{T}(IExpectation{IEnumerable{T}})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.Empty<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Attributes.EmptySequence().Expect().Empty().Result.Should().BeTrue();
    Attributes.RandomSequence().Expect().Empty().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.EquivalentTo{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void EquivalentTo_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.EquivalentTo(null, Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().EquivalentTo(Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Attributes.EmptySequence().Expect().EquivalentTo(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    Enumerable.Empty<object>().Expect().EquivalentTo([]).Result.Should().BeTrue();
    
    Attributes.EmptySequence().Expect().EquivalentTo(Attributes.EmptySequence()).Result.Should().BeTrue();
    
    Attributes.RandomSequence().With(sequence => sequence.ToList().Expect().EquivalentTo(sequence.ToLinkedList()).Result.Should().BeTrue());
    Attributes.RandomSequence().Expect().EquivalentTo(Attributes.EmptySequence()).Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.Contain{T}(IExpectation{IEnumerable{T}}, T, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Contain_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.Contain(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Contain(new object())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Attributes.EmptySequence().Expect().Contain(new object()).Result.Should().BeFalse();
    
    Attributes.RandomSequence().Expect().Contain(new object()).Result.Should().BeFalse();
    Attributes.RandomSequence().With(sequence => sequence.Expect().Contain(sequence.Random()).Result.Should().BeTrue());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.ContainAll{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainAll_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.ContainAll(null, Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ContainAll(Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Attributes.EmptySequence().Expect().ContainAll(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    Enumerable.Empty<object>().Expect().ContainAll([]).Result.Should().BeTrue();
    
    Attributes.EmptySequence().Expect().ContainAll(Attributes.EmptySequence()).Result.Should().BeTrue();
    Attributes.EmptySequence().Expect().ContainAll(Attributes.RandomSequence()).Result.Should().BeFalse();

    Attributes.RandomSequence().With(sequence => sequence.Expect().ContainAll(sequence.Reverse()).Result.Should().BeTrue());
    Attributes.RandomSequence().Expect().ContainAll(Attributes.EmptySequence()).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.ContainAnyOf{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainAnyOf_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.ContainAnyOf(null, Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ContainAnyOf(Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Attributes.EmptySequence().Expect().ContainAnyOf(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    Attributes.EmptySequence().Expect().ContainAnyOf(new object().ToSequence()).Result.Should().BeFalse();
    Attributes.EmptySequence().Expect().ContainAnyOf(Attributes.EmptySequence()).Result.Should().BeFalse();
    Attributes.EmptySequence().Expect().ContainAnyOf(Attributes.RandomSequence()).Result.Should().BeFalse();

    Attributes.RandomSequence().Expect().ContainAnyOf(new object().ToSequence()).Result.Should().BeFalse();
    Attributes.RandomSequence().Expect().ContainAnyOf(Attributes.EmptySequence()).Result.Should().BeFalse();
    Attributes.RandomSequence().With(sequence => sequence.Expect().ContainAnyOf(new[] { sequence.Random() }).Result.Should().BeTrue());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.ContainNulls{T}(IExpectation{IEnumerable{T}})"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainNulls_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.ContainNulls<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ContainNulls()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Attributes.EmptySequence().Expect().ContainNulls().Result.Should().BeFalse();
    Attributes.RandomSequence().Expect().ContainNulls().Result.Should().BeFalse();
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

    Attributes.EmptySequence().Expect().ContainUnique().Result.Should().BeTrue();
    Attributes.RandomSequence().Expect().ContainUnique().Result.Should().BeTrue();
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
      AssertionExtensions.Should(() => Attributes.EmptySequence().Expect().ElementAt(0, new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");
      AssertionExtensions.Should(() => Attributes.RandomSequence().Expect().ElementAt(-1, new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");
      AssertionExtensions.Should(() => Attributes.RandomSequence().Expect().ElementAt(Attributes.RandomSequence().Count(), new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");

      Attributes.RandomSequence().With(sequence => sequence.ForEach((index, element) =>
      {
        sequence.Expect().ElementAt(index, element).Result.Should().BeTrue();
        sequence.Expect().ElementAt(index, null).Result.Should().BeFalse();
      }));
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableExpectations.ElementAt(null, Index.Start, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ElementAt(Index.Start, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => Attributes.EmptySequence().Expect().ElementAt(Index.FromStart(0), new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");
      AssertionExtensions.Should(() => Attributes.RandomSequence().Expect().ElementAt(Index.FromStart(Attributes.RandomSequence().Count()), new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");

      Attributes.RandomSequence().With(sequence => sequence.ForEach((index, element) =>
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
    AssertionExtensions.Should(() => IEnumerableExpectations.SubsetOf(null, Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().SubsetOf(Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Attributes.EmptySequence().Expect().SubsetOf(null)).ThrowExactly<ArgumentNullException>().WithParameterName("superset");

    Attributes.EmptySequence().Expect().SubsetOf(Attributes.EmptySequence()).Result.Should().BeTrue();
    Attributes.RandomSequence().Expect().SubsetOf(Attributes.RandomSequence()).Result.Should().BeTrue();
    Attributes.EmptySequence().Expect().SubsetOf(Attributes.RandomSequence()).Result.Should().BeTrue();
    Attributes.RandomSequence().Expect().SubsetOf(Attributes.EmptySequence()).Result.Should().BeFalse();
    Attributes.RandomSequence().Take(Attributes.RandomSequence().Count() / 2).Expect().SubsetOf(Attributes.RandomSequence()).Result.Should().BeTrue();
    Attributes.RandomSequence().Expect().SubsetOf(Attributes.RandomSequence().Randomize()).Result.Should().BeTrue();
    new object().ToSequence().Expect().SubsetOf(new object().ToSequence()).Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.SupersetOf{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void SupersetOf_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.SupersetOf(null, Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().SupersetOf(Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Attributes.EmptySequence().Expect().SupersetOf(null)).ThrowExactly<ArgumentNullException>().WithParameterName("subset");

    Attributes.EmptySequence().Expect().SupersetOf(Attributes.EmptySequence()).Result.Should().BeTrue();
    Attributes.RandomSequence().Expect().SupersetOf(Attributes.RandomSequence()).Result.Should().BeTrue();
    Attributes.RandomSequence().Expect().SupersetOf(Attributes.EmptySequence()).Result.Should().BeTrue();
    Attributes.EmptySequence().Expect().SupersetOf(Attributes.RandomSequence()).Result.Should().BeFalse();
    Attributes.RandomSequence().Expect().SupersetOf(Attributes.RandomSequence().Take(Attributes.RandomSequence().Count() / 2)).Result.Should().BeTrue();
    Attributes.RandomSequence().Expect().SupersetOf(Attributes.RandomSequence().Randomize()).Result.Should().BeTrue();
    new object().ToSequence().Expect().SupersetOf(new object().ToSequence()).Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.Reversed{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Reversed_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.Reversed(null, Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Reversed(Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Attributes.EmptySequence().Expect().Reversed(null)).ThrowExactly<ArgumentNullException>().WithParameterName("reversed");

    Attributes.EmptySequence().Expect().Reversed(Attributes.EmptySequence()).Result.Should().BeTrue();
    Attributes.RandomSequence().Expect().Reversed(Attributes.RandomSequence()).Result.Should().BeFalse();
    Attributes.RandomSequence().Expect().Reversed(Attributes.RandomSequence().Reverse()).Result.Should().BeTrue();
    Attributes.RandomSequence().Expect().Reversed(Attributes.EmptySequence()).Result.Should().BeFalse();
    Attributes.RandomSequence().Expect().Reversed(Attributes.RandomSequence().Take(Attributes.RandomSequence().Count() / 2).Reverse()).Result.Should().BeFalse();
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

    AssertionExtensions.Should(() => Attributes.RandomSequence().Expect().Ordered()).ThrowExactly<InvalidOperationException>();

    Attributes.EmptySequence().Expect().Ordered().Result.Should().BeTrue();

    Attributes.Random().IntSequence(byte.MaxValue).ToArray().With(sequence =>
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
    AssertionExtensions.Should(() => IEnumerableExpectations.StartWith(null, Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().StartWith(Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Attributes.EmptySequence().Expect().StartWith(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    Attributes.EmptySequence().Expect().StartWith(Attributes.EmptySequence()).Result.Should().BeTrue();
    Attributes.RandomSequence().Expect().StartWith(Attributes.EmptySequence()).Result.Should().BeTrue();
    Attributes.RandomSequence().Expect().StartWith(Attributes.RandomSequence()).Result.Should().BeTrue();
    Attributes.EmptySequence().Expect().StartWith(Attributes.RandomSequence()).Result.Should().BeFalse();
    Attributes.RandomSequence().Expect().StartWith(Attributes.RandomSequence().Take(Attributes.RandomSequence().Count() / 2)).Result.Should().BeTrue();
    Attributes.RandomSequence().Expect().StartWith(Attributes.RandomSequence().Randomize()).Result.Should().BeFalse();
    new object().ToSequence().Expect().StartWith(new object().ToSequence()).Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.EndWith{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void EndWith_Method()
  {
    AssertionExtensions.Should(() => IEnumerableExpectations.EndWith(null, Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().EndWith(Attributes.EmptySequence())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
    AssertionExtensions.Should(() => Attributes.EmptySequence().Expect().EndWith(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

    Attributes.EmptySequence().Expect().EndWith(Attributes.EmptySequence()).Result.Should().BeTrue();
    Attributes.RandomSequence().Expect().EndWith(Attributes.EmptySequence()).Result.Should().BeTrue();
    Attributes.RandomSequence().Expect().EndWith(Attributes.RandomSequence()).Result.Should().BeTrue();
    Attributes.EmptySequence().Expect().EndWith(Attributes.RandomSequence()).Result.Should().BeFalse();
    Attributes.RandomSequence().Expect().EndWith(Attributes.RandomSequence().TakeLast(Attributes.RandomSequence().Count() / 2)).Result.Should().BeTrue();
    Attributes.RandomSequence().Expect().EndWith(Attributes.RandomSequence().Randomize()).Result.Should().BeFalse();
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
    AssertionExtensions.Should(() => Attributes.EmptySequence().Expect().Match(null)).ThrowExactly<ArgumentNullException>().WithParameterName("condition");

    Attributes.EmptySequence().Expect().Match(_ => true).Result.Should().BeTrue();
    Attributes.EmptySequence().Expect().Match(_ => false).Result.Should().BeTrue();
    Attributes.RandomSequence().Expect().Match(_ => true).Result.Should().BeTrue();
    Attributes.RandomSequence().Expect().Match(_ => false).Result.Should().BeFalse();
    Attributes.RandomSequence().Expect().Match(element => element is not null).Result.Should().BeTrue();
    1.Nulls().Expect().Match(element => element is null).Result.Should().BeTrue();
    1.Nulls().Expect().Match(element => element is not null).Result.Should().BeFalse();
  }
}