using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IEnumerableAssertions"/>.</para>
/// </summary>
public sealed class IEnumerableAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.Count{T}(IAssertion, IEnumerable{T}, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Count_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableAssertions.Count(null, Enumerable.Empty<object>(), 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => IEnumerableAssertions.Count<object>(Assert.To, null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

      Validate(true, Enumerable.Empty<object>(), 0);
      Validate(false, Enumerable.Empty<object>(), int.MinValue);
      Validate(false, Enumerable.Empty<object>(), int.MaxValue);
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence, int count)
    {
      if (result)
      {
        Assert.To.Count(sequence, count).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Count(sequence, count, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.Empty{T}(IAssertion, IEnumerable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableAssertions.Empty(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => IEnumerableAssertions.Empty<object>(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

      Validate(true, Enumerable.Empty<object>());
      Validate(false, RandomSequence);
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence)
    {
      if (result)
      {
        Assert.To.Empty(sequence).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Empty(sequence, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.EquivalentTo{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void EquivalentTo_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableAssertions.EquivalentTo(null, [], Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.EquivalentTo(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
      AssertionExtensions.Should(() => Assert.To.EquivalentTo(Enumerable.Empty<object>(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

      Validate(true, [], Enumerable.Empty<object>());
      Validate(true, [], Array.Empty<object>());
      RandomSequence.With(sequence => Validate(true, sequence.ToList(), sequence.ToLinkedList()));
      Validate(false, RandomSequence, []);
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> left, IEnumerable<T> right, IEqualityComparer<T> comparer = null)
    {
      if (result)
      {
        Assert.To.EquivalentTo(left, right, comparer).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.EquivalentTo(left, right, comparer, "error")).ThrowExactly<InvalidOperationException>();
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.Contain{T}(IAssertion, IEnumerable{T}, T, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Contain_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableAssertions.Contain(null, [], new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Contain(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

      Validate(false, [], new object());
      Validate(false, RandomSequence, new object());
      RandomSequence.With(sequence => Validate(true, sequence, sequence.Random()));
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence, T element, IEqualityComparer<T> comparer = null)
    {
      if (result)
      {
        Assert.To.Contain(sequence, element, comparer).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Contain(sequence, element, comparer, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.ContainAll{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainAll_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableAssertions.ContainAll(null, [], Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.ContainAll(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
      AssertionExtensions.Should(() => Assert.To.ContainAll(Enumerable.Empty<object>(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

      Validate(true, [], Enumerable.Empty<object>());
      Validate(true, Enumerable.Empty<object>(), []);
      Validate(false, [], [new object()]);
      Validate(true, RandomSequence, []);
      RandomSequence.With(sequence => Validate(true, sequence, sequence.Reverse()));
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> superset, IEnumerable<T> subset, IEqualityComparer<T> comparer = null)
    {
      if (result)
      {
        Assert.To.ContainAll(superset, subset, comparer).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.ContainAll(superset, subset, comparer, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.ContainAnyOf{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainAnyOf_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableAssertions.ContainAnyOf(null, [], Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.ContainAnyOf(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
      AssertionExtensions.Should(() => Assert.To.ContainAnyOf(Enumerable.Empty<object>(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

      RandomSequence.With(sequence => Validate(true, sequence, [sequence.Random()]));
      Validate(false, [], [new object()]);
      Validate(false, [], Enumerable.Empty<object>());
      Validate(false, RandomSequence, []);
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> superset, IEnumerable<T> subset, IEqualityComparer<T> comparer = null)
    {
      if (result)
      {
        Assert.To.ContainAnyOf(superset, subset, comparer).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.ContainAnyOf(superset, subset, comparer, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.ContainNulls{T}(IAssertion, IEnumerable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainNulls_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableAssertions.ContainNulls(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.ContainNulls<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

      Validate(true, 1.Nulls());
      Validate(false, Enumerable.Empty<object>());
      Validate(false, RandomSequence);
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence)
    {
      if (result)
      {
        Assert.To.ContainNulls(sequence).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.ContainNulls(sequence, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.ContainUnique{T}(IAssertion, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainUnique_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableAssertions.ContainUnique(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.ContainUnique<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

      Validate(true, Enumerable.Empty<object>());
      Validate(true, RandomSequence);
      Validate(false, 2.Nulls());
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence, IEqualityComparer<T> comparer = null)
    {
      if (result)
      {
        Assert.To.ContainUnique(sequence, comparer).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.ContainUnique(sequence, comparer, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
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
      AssertionExtensions.Should(() => IEnumerableAssertions.ElementAt(null, RandomSequence, 0, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.ElementAt(null, 0, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
      AssertionExtensions.Should(() => Assert.To.ElementAt([], 0, new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");
      AssertionExtensions.Should(() => Assert.To.ElementAt(RandomSequence, -1, new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");
      AssertionExtensions.Should(() => Assert.To.ElementAt(RandomSequence, RandomSequence.Count(), new object())).ThrowExactly<ArgumentOutOfRangeException>().WithParameterName("index");

      RandomSequence.With(sequence => sequence.ForEach((index, element) =>
      {
        Validate(true, sequence, index, element);
        Validate(false, sequence, index, null);
      }));

      static void Validate<T>(bool result, IEnumerable<T> sequence, int index, T value)
      {
        if (result)
        {
          Assert.To.ElementAt(sequence, index, value).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.ElementAt(sequence, index, value, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableAssertions.ElementAt(null, RandomSequence, Index.Start, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.ElementAt(null, Index.Start, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

      RandomSequence.With(sequence => sequence.ForEach((index, element) =>
      {
        Validate(true, sequence, Index.FromStart(index), element);
        Validate(false, sequence, Index.FromStart(index), null);
      }));

      static void Validate<T>(bool result, IEnumerable<T> sequence, Index index, T value)
      {
        if (result)
        {
          Assert.To.ElementAt(sequence, index, value).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.ElementAt(sequence, index, value, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.SubsetOf{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void SubsetOf_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableAssertions.SubsetOf(null, [], Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.SubsetOf(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("subset");
      AssertionExtensions.Should(() => Assert.To.SubsetOf(Enumerable.Empty<object>(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("superset");

      Validate(true, [], Enumerable.Empty<object>());
      Validate(true, RandomSequence, RandomSequence);
      Validate(true, [], RandomSequence);
      Validate(true, RandomSequence.Take(RandomSequence.Count() / 2), RandomSequence);
      Validate(true, RandomSequence, RandomSequence.Randomize());
      Validate(false, RandomSequence, []);
      Validate(false, [new object()], [new object()]);
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> subset, IEnumerable<T> superset, IEqualityComparer<T> comparer = null)
    {
      if (result)
      {
        Assert.To.SubsetOf(subset, superset, comparer).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.SubsetOf(subset, superset, comparer, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.SupersetOf{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void SupersetOf_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableAssertions.SupersetOf(null, [], Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.SupersetOf(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("superset");
      AssertionExtensions.Should(() => Assert.To.SupersetOf(Enumerable.Empty<object>(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("subset");

      Validate(true, [], Enumerable.Empty<object>());
      Validate(true, RandomSequence, RandomSequence);
      Validate(true, RandomSequence, []);
      Validate(true, RandomSequence, RandomSequence.Take(RandomSequence.Count() / 2));
      Validate(true, RandomSequence, RandomSequence.Randomize());
      Validate(false, [], RandomSequence);
      Validate(false, [new object()], [new object()]);
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> superset, IEnumerable<T> subset, IEqualityComparer<T> comparer = null)
    {
      if (result)
      {
        Assert.To.SupersetOf(superset, subset, comparer).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.SupersetOf(superset, subset, comparer, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.Reversed{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Reversed_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableAssertions.Reversed(null, [], Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Reversed(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
      AssertionExtensions.Should(() => Assert.To.Reversed(Enumerable.Empty<object>(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("reversed");

      Validate(true, [], Enumerable.Empty<object>());
      Validate(true, RandomSequence, RandomSequence.Reverse());
      Validate(true, 2.Nulls(), 2.Nulls());
      Validate(false, RandomSequence, RandomSequence);
      Validate(false, RandomSequence, []);
      Validate(false, RandomSequence, RandomSequence.Take(RandomSequence.Count() / 2).Reverse());
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence, IEnumerable<T> reversed, IEqualityComparer<T> comparer = null)
    {
      if (result)
      {
        Assert.To.Reversed(sequence, reversed, comparer).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Reversed(sequence, reversed, comparer, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.Ordered{T}(IAssertion, IEnumerable{T}, IComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Ordered_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableAssertions.Ordered(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Ordered<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");

      Validate(true, Enumerable.Empty<object>());
      Validate(true, Random.IntSequence(byte.MaxValue).Order().ToArray());
      Validate(false, Random.IntSequence(byte.MaxValue).ToArray());
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence, IComparer<T> comparer = null)
    {
      if (result)
      {
        Assert.To.Ordered(sequence, comparer).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Ordered(sequence, comparer)).ThrowExactly<InvalidOperationException>();
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.StartWith{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void StartWith_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableAssertions.StartWith(null, [], Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.StartWith(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
      AssertionExtensions.Should(() => Assert.To.StartWith(Enumerable.Empty<object>(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

      Validate(true, [], Enumerable.Empty<object>());
      Validate(true, RandomSequence, []);
      Validate(true, RandomSequence, RandomSequence);
      Validate(true, RandomSequence, RandomSequence.Take(RandomSequence.Count() / 2));
      Validate(false, [], RandomSequence);
      Validate(false, RandomSequence, RandomSequence.Randomize());
      Validate(false, [new object()], [new object()]);
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> superset, IEnumerable<T> subset, IEqualityComparer<T> comparer = null)
    {
      if (result)
      {
        Assert.To.StartWith(superset, subset, comparer).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.StartWith(superset, subset, comparer, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.EndWith{T}(IAssertion, IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void EndWith_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableAssertions.EndWith(null, [], Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.EndWith(null, Enumerable.Empty<object>())).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
      AssertionExtensions.Should(() => Assert.To.EndWith(Enumerable.Empty<object>(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("other");

      Validate(true, [], Enumerable.Empty<object>());
      Validate(true, RandomSequence, []);
      Validate(true, RandomSequence, RandomSequence);
      Validate(true, RandomSequence, RandomSequence.TakeLast(RandomSequence.Count() / 2));
      Validate(false, [], RandomSequence);
      Validate(false, RandomSequence, RandomSequence.Randomize());
      Validate(false, [new object()], [new object()]);
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> superset, IEnumerable<T> subset, IEqualityComparer<T> comparer = null)
    {
      if (result)
      {
        Assert.To.EndWith(superset, subset, comparer).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.EndWith(superset, subset, comparer, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEnumerableAssertions.Match{T}(IAssertion, IEnumerable{T}, Predicate{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Match_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEnumerableAssertions.Match(null, Enumerable.Empty<object>(), _ => true)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Match<object>(null, _ => true)).ThrowExactly<ArgumentNullException>().WithParameterName("sequence");
      AssertionExtensions.Should(() => Assert.To.Match(Enumerable.Empty<object>(), null)).ThrowExactly<ArgumentNullException>().WithParameterName("condition");

      Validate(true, Enumerable.Empty<object>(), _ => true);
      Validate(true, Enumerable.Empty<object>(), _ => false);
      Validate(true, RandomSequence, _ => true);
      Validate(true, RandomSequence, element => element is not null);
      Validate(true, 1.Nulls(), element => element is null);
      Validate(false, RandomSequence, _ => false);
      Validate(false, 1.Nulls(), element => element is not null);
    }

    return;

    static void Validate<T>(bool result, IEnumerable<T> sequence, Predicate<T> condition)
    {
      if (result)
      {
        Assert.To.Match(sequence, condition).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Match(sequence, condition, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}