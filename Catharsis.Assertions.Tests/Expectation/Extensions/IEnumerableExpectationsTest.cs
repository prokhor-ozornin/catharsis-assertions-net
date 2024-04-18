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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableExpectations.Count<object>(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Count(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Attributes.RandomSequence().Expect().Count(int.MinValue).Result.Should().BeFalse();
      Attributes.RandomSequence().Expect().Count(int.MaxValue).Result.Should().BeFalse();
      Attributes.RandomSequence().Expect().Count(Attributes.RandomSequence().Count()).Result.Should().BeTrue();
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

       Enumerable.Empty<object>().Expect().Empty().Result.Should().BeTrue();
      Attributes.RandomSequence().Expect().Empty().Result.Should().BeFalse();
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
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().EquivalentTo( Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().EquivalentTo(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

      Enumerable.Empty<object>().Expect().EquivalentTo([]).Result.Should().BeTrue();
      
       Enumerable.Empty<object>().Expect().EquivalentTo( Enumerable.Empty<object>()).Result.Should().BeTrue();
      
      Attributes.RandomSequence().With(sequence => sequence.ToList().Expect().EquivalentTo(sequence.ToLinkedList()).Result.Should().BeTrue());
      Attributes.RandomSequence().Expect().EquivalentTo( Enumerable.Empty<object>()).Result.Should().BeFalse();
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence, IEnumerable<T> left, IEnumerable<T> right, IEqualityComparer<T> comparer = null) => left.Expect().EquivalentTo(right, comparer).Should().BeOfType<Expectation<IEnumerable<T>>>().Which.Result.Should().Be(result);
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

       Enumerable.Empty<object>().Expect().Contain(new object()).Result.Should().BeFalse();
      
      Attributes.RandomSequence().Expect().Contain(new object()).Result.Should().BeFalse();
      Attributes.RandomSequence().With(sequence => sequence.Expect().Contain(sequence.Random()).Result.Should().BeTrue());
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
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ContainAll( Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().ContainAll(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

      Enumerable.Empty<object>().Expect().ContainAll([]).Result.Should().BeTrue();
      
       Enumerable.Empty<object>().Expect().ContainAll( Enumerable.Empty<object>()).Result.Should().BeTrue();
       Enumerable.Empty<object>().Expect().ContainAll(Attributes.RandomSequence()).Result.Should().BeFalse();

      Attributes.RandomSequence().With(sequence => sequence.Expect().ContainAll(sequence.Reverse()).Result.Should().BeTrue());
      Attributes.RandomSequence().Expect().ContainAll( Enumerable.Empty<object>()).Result.Should().BeTrue();
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
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ContainAnyOf( Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().ContainAnyOf(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

       Enumerable.Empty<object>().Expect().ContainAnyOf(new object().ToSequence()).Result.Should().BeFalse();
       Enumerable.Empty<object>().Expect().ContainAnyOf( Enumerable.Empty<object>()).Result.Should().BeFalse();
       Enumerable.Empty<object>().Expect().ContainAnyOf(Attributes.RandomSequence()).Result.Should().BeFalse();

      Attributes.RandomSequence().Expect().ContainAnyOf(new object().ToSequence()).Result.Should().BeFalse();
      Attributes.RandomSequence().Expect().ContainAnyOf( Enumerable.Empty<object>()).Result.Should().BeFalse();
      Attributes.RandomSequence().With(sequence => sequence.Expect().ContainAnyOf(new[] { sequence.Random() }).Result.Should().BeTrue());
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

       Enumerable.Empty<object>().Expect().ContainNulls().Result.Should().BeFalse();
      Attributes.RandomSequence().Expect().ContainNulls().Result.Should().BeFalse();
      1.Nulls().Expect().ContainNulls().Result.Should().BeTrue();
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

       Enumerable.Empty<object>().Expect().ContainUnique().Result.Should().BeTrue();
      Attributes.RandomSequence().Expect().ContainUnique().Result.Should().BeTrue();
      2.Nulls().Expect().ContainUnique().Result.Should().BeFalse();
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
      AssertionExtensions.Should(() => IEnumerableExpectations.ElementAt(null, default, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ElementAt(default, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().ElementAt(0, new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");
      AssertionExtensions.Should(() => Attributes.RandomSequence().Expect().ElementAt(-1, new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");
      AssertionExtensions.Should(() => Attributes.RandomSequence().Expect().ElementAt(Attributes.RandomSequence().Count(), new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");

      Attributes.RandomSequence().With(sequence => sequence.ForEach((index, element) =>
      {
        sequence.Expect().ElementAt(index, element).Result.Should().BeTrue();
        sequence.Expect().ElementAt(index, null).Result.Should().BeFalse();
      }));

      static void Validate<T>(bool result, IEnumerable<T> sequence, int index, T value) => sequence.Expect().ElementAt(index, value).Should().BeOfType<Expectation<IEnumerable<T>>>().Which.Result.Should().Be(result);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableExpectations.ElementAt(null, Index.Start, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().ElementAt(Index.Start, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().ElementAt(Index.FromStart(0), new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");
      AssertionExtensions.Should(() => Attributes.RandomSequence().Expect().ElementAt(Index.FromStart(Attributes.RandomSequence().Count()), new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");

      Attributes.RandomSequence().With(sequence => sequence.ForEach((index, element) =>
      {
        sequence.Expect().ElementAt(Index.FromStart(index), element).Result.Should().BeTrue();
        sequence.Expect().ElementAt(Index.FromStart(index), null).Result.Should().BeFalse();
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
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().SubsetOf( Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().SubsetOf(null)).ThrowExactly<ArgumentNullException>().WithParameterName("superset");

       Enumerable.Empty<object>().Expect().SubsetOf( Enumerable.Empty<object>()).Result.Should().BeTrue();
      Attributes.RandomSequence().Expect().SubsetOf(Attributes.RandomSequence()).Result.Should().BeTrue();
       Enumerable.Empty<object>().Expect().SubsetOf(Attributes.RandomSequence()).Result.Should().BeTrue();
      Attributes.RandomSequence().Expect().SubsetOf( Enumerable.Empty<object>()).Result.Should().BeFalse();
      Attributes.RandomSequence().Take(Attributes.RandomSequence().Count() / 2).Expect().SubsetOf(Attributes.RandomSequence()).Result.Should().BeTrue();
      Attributes.RandomSequence().Expect().SubsetOf(Attributes.RandomSequence().Randomize()).Result.Should().BeTrue();
      new object().ToSequence().Expect().SubsetOf(new object().ToSequence()).Result.Should().BeFalse();
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
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().SupersetOf( Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().SupersetOf(null)).ThrowExactly<ArgumentNullException>().WithParameterName("subset");

       Enumerable.Empty<object>().Expect().SupersetOf( Enumerable.Empty<object>()).Result.Should().BeTrue();
      Attributes.RandomSequence().Expect().SupersetOf(Attributes.RandomSequence()).Result.Should().BeTrue();
      Attributes.RandomSequence().Expect().SupersetOf( Enumerable.Empty<object>()).Result.Should().BeTrue();
       Enumerable.Empty<object>().Expect().SupersetOf(Attributes.RandomSequence()).Result.Should().BeFalse();
      Attributes.RandomSequence().Expect().SupersetOf(Attributes.RandomSequence().Take(Attributes.RandomSequence().Count() / 2)).Result.Should().BeTrue();
      Attributes.RandomSequence().Expect().SupersetOf(Attributes.RandomSequence().Randomize()).Result.Should().BeTrue();
      new object().ToSequence().Expect().SupersetOf(new object().ToSequence()).Result.Should().BeFalse();
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
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().Reversed( Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().Reversed(null)).ThrowExactly<ArgumentNullException>().WithParameterName("reversed");

       Enumerable.Empty<object>().Expect().Reversed( Enumerable.Empty<object>()).Result.Should().BeTrue();
      Attributes.RandomSequence().Expect().Reversed(Attributes.RandomSequence()).Result.Should().BeFalse();
      Attributes.RandomSequence().Expect().Reversed(Attributes.RandomSequence().Reverse()).Result.Should().BeTrue();
      Attributes.RandomSequence().Expect().Reversed( Enumerable.Empty<object>()).Result.Should().BeFalse();
      Attributes.RandomSequence().Expect().Reversed(Attributes.RandomSequence().Take(Attributes.RandomSequence().Count() / 2).Reverse()).Result.Should().BeFalse();
      2.Nulls().Expect().Reversed(2.Nulls()).Result.Should().BeTrue();
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

      AssertionExtensions.Should(() => Attributes.RandomSequence().Expect().Ordered()).ThrowExactly<InvalidOperationException>();

       Enumerable.Empty<object>().Expect().Ordered().Result.Should().BeTrue();

      Attributes.Random().IntSequence(byte.MaxValue).ToArray().With(sequence =>
      {
        sequence.Expect().Ordered().Result.Should().BeFalse();
        sequence.Order().Expect().Ordered().Result.Should().BeTrue();
      });
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
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().StartWith( Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().StartWith(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

       Enumerable.Empty<object>().Expect().StartWith( Enumerable.Empty<object>()).Result.Should().BeTrue();
      Attributes.RandomSequence().Expect().StartWith( Enumerable.Empty<object>()).Result.Should().BeTrue();
      Attributes.RandomSequence().Expect().StartWith(Attributes.RandomSequence()).Result.Should().BeTrue();
       Enumerable.Empty<object>().Expect().StartWith(Attributes.RandomSequence()).Result.Should().BeFalse();
      Attributes.RandomSequence().Expect().StartWith(Attributes.RandomSequence().Take(Attributes.RandomSequence().Count() / 2)).Result.Should().BeTrue();
      Attributes.RandomSequence().Expect().StartWith(Attributes.RandomSequence().Randomize()).Result.Should().BeFalse();
      new object().ToSequence().Expect().StartWith(new object().ToSequence()).Result.Should().BeFalse();
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
      AssertionExtensions.Should(() => ((IEnumerable<object>) null).Expect().EndWith(Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() =>  Enumerable.Empty<object>().Expect().EndWith(null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

       Enumerable.Empty<object>().Expect().EndWith( Enumerable.Empty<object>()).Result.Should().BeTrue();
      Attributes.RandomSequence().Expect().EndWith( Enumerable.Empty<object>()).Result.Should().BeTrue();
      Attributes.RandomSequence().Expect().EndWith(Attributes.RandomSequence()).Result.Should().BeTrue();
       Enumerable.Empty<object>().Expect().EndWith(Attributes.RandomSequence()).Result.Should().BeFalse();
      Attributes.RandomSequence().Expect().EndWith(Attributes.RandomSequence().TakeLast(Attributes.RandomSequence().Count() / 2)).Result.Should().BeTrue();
      Attributes.RandomSequence().Expect().EndWith(Attributes.RandomSequence().Randomize()).Result.Should().BeFalse();
      new object().ToSequence().Expect().EndWith(new object().ToSequence()).Result.Should().BeFalse();
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

       Enumerable.Empty<object>().Expect().Match(_ => true).Result.Should().BeTrue();
       Enumerable.Empty<object>().Expect().Match(_ => false).Result.Should().BeTrue();
      Attributes.RandomSequence().Expect().Match(_ => true).Result.Should().BeTrue();
      Attributes.RandomSequence().Expect().Match(_ => false).Result.Should().BeFalse();
      Attributes.RandomSequence().Expect().Match(element => element is not null).Result.Should().BeTrue();
      1.Nulls().Expect().Match(element => element is null).Result.Should().BeTrue();
      1.Nulls().Expect().Match(element => element is not null).Result.Should().BeFalse();
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence, Predicate<T> condition) => sequence.Expect().Match(condition).Should().BeOfType<Expectation<IEnumerable<T>>>().Which.Result.Should().Be(result);
  }
}