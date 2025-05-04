using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IDictionaryAssertions"/>.</para>
/// </summary>
public sealed class IDictionaryAssertionsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IDictionaryAssertions.ContainKey{TKey, TValue}(IAssertion, IDictionary{TKey, TValue}, TKey, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainKey_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDictionaryAssertions.ContainKey(null, new Dictionary<object, object>(), new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.ContainKey<object, object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("dictionary");

      Validate(true, new Dictionary<object, object>().With(("id", null)), "id");
      Validate(false, new Dictionary<object, object>(), new object());
    }

    return;

    static void Validate<TKey, TValue>(bool result, IDictionary<TKey, TValue> dictionary, TKey key)
    {
      if (result)
      {
        Assert.To.ContainKey(dictionary, key).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.ContainKey(dictionary, key, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDictionaryAssertions.ContainValue{TKey, TValue}(IAssertion, IDictionary{TKey, TValue}, TValue, IEqualityComparer{TValue}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainValue_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDictionaryAssertions.ContainValue(null, new Dictionary<object, object>(), new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.ContainValue<object, object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("dictionary");

      Validate(true, new Dictionary<object, object>().With("id", null), null);
      Validate(false, new Dictionary<object, object>(), null);
    }

    return;

    static void Validate<TKey, TValue>(bool result, IDictionary<TKey, TValue> dictionary, TValue value, IEqualityComparer<TValue> comparer = null)
    {
      if (result)
      {
        Assert.To.ContainValue(dictionary, value, comparer).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.ContainValue(dictionary, value, comparer, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}