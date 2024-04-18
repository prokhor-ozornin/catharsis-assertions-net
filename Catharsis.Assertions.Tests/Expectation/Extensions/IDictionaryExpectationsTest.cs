using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IDictionaryExpectations"/>.</para>
/// </summary>
public sealed class IDictionaryExpectationsTest : UnitTest
{
  private IDictionary<object, object> Dictionary { get; } = new Dictionary<object, object>();

  /// <summary>
  ///   <para>Performs testing of <see cref="IDictionaryExpectations.ContainKey{TKey, TValue}(IExpectation{IDictionary{TKey, TValue}}, TKey)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainKey_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDictionaryExpectations.ContainKey<object, object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IDictionary<object, object>) null).Expect().ContainKey(new object())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => Dictionary.Expect().ContainKey(null)).ThrowExactly<ArgumentNullException>().WithParameterName("key");

      Dictionary.Expect().ContainKey(Guid.NewGuid()).Result.Should().BeFalse();
      
      Dictionary.With(dictionary =>
      {
        dictionary.Add(Guid.Empty, new object());
        dictionary.Expect().ContainKey(Guid.Empty).Result.Should().BeTrue();
      });
    }

    return;

    static void Validate<TKey, TValue>(bool result, IDictionary<TKey, TValue> dictionary, TKey key) => dictionary.Expect().ContainKey(key).Should().BeOfType<Expectation<IDictionary<TKey, TValue>>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IDictionaryExpectations.ContainValue{TKey, TValue}(IExpectation{IDictionary{TKey, TValue}}, TValue, IEqualityComparer{TValue})"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainValue_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IDictionaryExpectations.ContainValue<object, object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((IDictionary<object, object>) null).Expect().ContainValue(new object())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Dictionary.Expect().ContainValue(null).Result.Should().BeFalse();

      Dictionary.With(dictionary =>
      {
        dictionary.Add(Guid.NewGuid(), null);
        dictionary.Expect().ContainValue(null).Result.Should().BeTrue();
      });
    }

    return;

    static void Validate<TKey, TValue>(bool result, IDictionary<TKey, TValue> dictionary, TValue value, IEqualityComparer<TValue> comparer = null) => dictionary.Expect().ContainValue(value, comparer).Should().BeOfType<Expectation<IDictionary<TKey, TValue>>>().Which.Result.Should().Be(result);
  }
}