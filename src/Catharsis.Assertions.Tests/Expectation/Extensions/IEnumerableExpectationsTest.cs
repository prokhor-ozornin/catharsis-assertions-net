using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IEnumerableExpectations"/>.</para>
/// </summary>
public sealed class IEnumerableExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.Count{T}(IExpectation{IEnumerable{T}}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Count_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableExpectations.Count<object>(null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Count(0)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, Enumerable.Empty<object>(), 0);
      Validate(false, Enumerable.Empty<object>(), int.MinValue);
      Validate(false, Enumerable.Empty<object>(), int.MaxValue);
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence, int count) => sequence.Expect().Count(count).Should().BeOfType<Expectation<IEnumerable<T>>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.Empty{T}(IExpectation{IEnumerable{T}})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableExpectations.Empty<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, Enumerable.Empty<object>());
      Validate(false, RandomSequence);
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence) => sequence.Expect().Empty().Should().BeOfType<Expectation<IEnumerable<T>>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.EquivalentTo{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void EquivalentTo_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableExpectations.EquivalentTo(null,  Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().EquivalentTo([])).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().EquivalentTo(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

      Validate(true, [], Enumerable.Empty<object>());
      Validate(true, [], Array.Empty<object>());
      RandomSequence.With(sequence => Validate(true, sequence.ToList(), sequence.ToLinkedList()));
      Validate(false, RandomSequence, Enumerable.Empty<object>());
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> left, IEnumerable<T> right, IEqualityComparer<T> comparer = null) => left.Expect().EquivalentTo(right, comparer).Should().BeOfType<Expectation<IEnumerable<T>>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.Contain{T}(IExpectation{IEnumerable{T}}, T, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Contain_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableExpectations.Contain(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Contain(new object())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(false, [], new object());
      Validate(false, RandomSequence, new object());
      RandomSequence.With(sequence => Validate(true, sequence, sequence.Random()));
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence, T element, IEqualityComparer<T> comparer = null) => sequence.Expect().Contain(element, comparer).Should().BeOfType<Expectation<IEnumerable<T>>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.ContainAll{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainAll_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableExpectations.ContainAll(null,  Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ContainAll([])).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().ContainAll(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

      Validate(true, [], Enumerable.Empty<object>());
      Validate(true, Enumerable.Empty<object>(), []);
      Validate(false, [], [new object()]);
      Validate(true, RandomSequence, []);
      RandomSequence.With(sequence => Validate(true, sequence, sequence.Reverse()));
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence, IEnumerable<T> other, IEqualityComparer<T> comparer = null) => sequence.Expect().ContainAll(other, comparer).Should().BeOfType<Expectation<IEnumerable<T>>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.ContainAnyOf{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainAnyOf_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableExpectations.ContainAnyOf(null,  Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ContainAnyOf([])).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().ContainAnyOf(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

      RandomSequence.With(sequence => Validate(true, sequence, [sequence.Random()]));
      Validate(false, [], [new object()]);
      Validate(false, [], Enumerable.Empty<object>());
      Validate(false, RandomSequence, []);
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence, IEnumerable<T> other, IEqualityComparer<T> comparer = null) => sequence.Expect().ContainAnyOf(other, comparer).Should().BeOfType<Expectation<IEnumerable<T>>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.ContainNulls{T}(IExpectation{IEnumerable{T}})"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainNulls_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableExpectations.ContainNulls<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ContainNulls()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, 1.Nulls());
      Validate(false, Enumerable.Empty<object>());
      Validate(false, RandomSequence);
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence) => sequence.Expect().ContainNulls().Should().BeOfType<Expectation<IEnumerable<T>>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.ContainUnique{T}(IExpectation{IEnumerable{T}}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainUnique_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableExpectations.ContainUnique<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ContainUnique()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, Enumerable.Empty<object>());
      Validate(true, RandomSequence);
      Validate(false, 2.Nulls());
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence, IEqualityComparer<T> comparer = null) => sequence.Expect().ContainUnique(comparer).Should().BeOfType<Expectation<IEnumerable<T>>>().Which.Result.Should().Be(result);
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
      AssertionExtensions.Should(() => IEnumerableExpectations.ElementAt(null, 0, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ElementAt(0, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().ElementAt(0, new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");
      AssertionExtensions.Should(() => RandomSequence.Expect().ElementAt(-1, new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");
      AssertionExtensions.Should(() => RandomSequence.Expect().ElementAt(RandomSequence.Count(), new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");

      RandomSequence.With(sequence => sequence.ForEach((index, element) =>
      {
        Validate(true, sequence, index, element);
        Validate(false, sequence, index, null);
      }));

      static void Validate<T>(bool result, IEnumerable<T> sequence, int index, T value) => sequence.Expect().ElementAt(index, value).Should().BeOfType<Expectation<IEnumerable<T>>>().Which.Result.Should().Be(result);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableExpectations.ElementAt(null, Index.Start, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ElementAt(Index.Start, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().ElementAt(Index.FromStart(0), new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");
      AssertionExtensions.Should(() => RandomSequence.Expect().ElementAt(Index.FromStart(RandomSequence.Count()), new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");

      RandomSequence.With(sequence => sequence.ForEach((index, element) =>
      {
        Validate(true, sequence, Index.FromStart(index), element);
        Validate(false, sequence, Index.FromStart(index), null);
      }));

      static void Validate<T>(bool result, IEnumerable<T> sequence, Index index, T value) => sequence.Expect().ElementAt(index, value).Should().BeOfType<Expectation<IEnumerable<T>>>().Which.Result.Should().Be(result);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.SubsetOf{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void SubsetOf_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableExpectations.SubsetOf(null,  Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().SubsetOf( [])).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().SubsetOf(null)).ThrowExactly<ArgumentNullException>().WithParameterName("superset");

      Validate(true, [], Enumerable.Empty<object>());
      Validate(true, RandomSequence, RandomSequence);
      Validate(true, [], RandomSequence);
      Validate(true, RandomSequence.Take(RandomSequence.Count() / 2), RandomSequence);
      Validate(true, RandomSequence, RandomSequence.Randomize());
      Validate(false, RandomSequence, []);
      Validate(false, [new object()], [new object()]);
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence, IEnumerable<T> superset, IEqualityComparer<T> comparer = null) => sequence.Expect().SubsetOf(superset, comparer).Should().BeOfType<Expectation<IEnumerable<T>>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.SupersetOf{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void SupersetOf_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableExpectations.SupersetOf(null,  Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().SupersetOf( [])).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().SupersetOf(null)).ThrowExactly<ArgumentNullException>().WithParameterName("subset");

      Validate(true, [], Enumerable.Empty<object>());
      Validate(true, RandomSequence, RandomSequence);
      Validate(true, RandomSequence, []);
      Validate(true, RandomSequence, RandomSequence.Take(RandomSequence.Count() / 2));
      Validate(true, RandomSequence, RandomSequence.Randomize());
      Validate(false, [], RandomSequence);
      Validate(false, [new object()], [new object()]);
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence, IEnumerable<T> subset, IEqualityComparer<T> comparer = null) => sequence.Expect().SupersetOf(subset, comparer).Should().BeOfType<Expectation<IEnumerable<T>>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.Reversed{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Reversed_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableExpectations.Reversed(null,  Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Reversed( [])).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().Reversed(null)).ThrowExactly<ArgumentNullException>().WithParameterName("reversed");

      Validate(true, [], Enumerable.Empty<object>());
      Validate(true, RandomSequence, RandomSequence.Reverse());
      Validate(true, 2.Nulls(), 2.Nulls());
      Validate(false, RandomSequence, RandomSequence);
      Validate(false, RandomSequence, []);
      Validate(false, RandomSequence, RandomSequence.Take(RandomSequence.Count() / 2).Reverse());
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence, IEnumerable<T> reversed, IEqualityComparer<T> comparer = null) => sequence.Expect().Reversed(reversed, comparer).Should().BeOfType<Expectation<IEnumerable<T>>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.Ordered{T}(IExpectation{IEnumerable{T}}, IComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Ordered_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableExpectations.Ordered<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Ordered()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => RandomSequence.Expect().Ordered()).ThrowExactly<InvalidOperationException>();

      Validate(true, Enumerable.Empty<object>());
      Validate(true, Random.IntSequence(byte.MaxValue).Order().ToArray());
      Validate(false, Random.IntSequence(byte.MaxValue).ToArray());
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence, IComparer<T> comparer = null) => sequence.Expect().Ordered(comparer).Should().BeOfType<Expectation<IEnumerable<T>>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.StartWith{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void StartWith_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableExpectations.StartWith(null,  Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().StartWith( [])).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().StartWith(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

      Validate(true, [], Enumerable.Empty<object>());
      Validate(true, RandomSequence, []);
      Validate(true, RandomSequence, RandomSequence);
      Validate(true, RandomSequence, RandomSequence.Take(RandomSequence.Count() / 2));
      Validate(false, [], RandomSequence);
      Validate(false, RandomSequence, RandomSequence.Randomize());
      Validate(false, [new object()], [new object()]);
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence, IEnumerable<T> other, IEqualityComparer<T> comparer = null) => sequence.Expect().StartWith(other, comparer).Should().BeOfType<Expectation<IEnumerable<T>>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.EndWith{T}(IExpectation{IEnumerable{T}}, IEnumerable{T}, IEqualityComparer{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void EndWith_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableExpectations.EndWith(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().EndWith([])).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().EndWith(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

      Validate(true, [], Enumerable.Empty<object>());
      Validate(true, RandomSequence, []);
      Validate(true, RandomSequence, RandomSequence);
      Validate(true, RandomSequence, RandomSequence.TakeLast(RandomSequence.Count() / 2));
      Validate(false, [], RandomSequence);
      Validate(false, RandomSequence, RandomSequence.Randomize());
      Validate(false, [new object()], [new object()]);
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence, IEnumerable<T> other, IEqualityComparer<T> comparer = null) => sequence.Expect().EndWith(other, comparer).Should().BeOfType<Expectation<IEnumerable<T>>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableExpectations.Match{T}(IExpectation{IEnumerable{T}}, Predicate{T})"/> method.</para>
  /// </summary>
  [Fact]
  public void Match_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableExpectations.Match<object>(null, _ => true)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Match(_ => true)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().Match(null)).ThrowExactly<ArgumentNullException>().WithParameterName("condition");

      Validate(true, Enumerable.Empty<object>(), _ => true);
      Validate(true, Enumerable.Empty<object>(), _ => false);
      Validate(true, RandomSequence, _ => true);
      Validate(true, RandomSequence, element => element is not null);
      Validate(true, 1.Nulls(), element => element is null);
      Validate(false, RandomSequence, _ => false);
      Validate(false, 1.Nulls(), element => element is not null);
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence, Predicate<T> condition) => sequence.Expect().Match(condition).Should().BeOfType<Expectation<IEnumerable<T>>>().Which.Result.Should().Be(result);
  }
}