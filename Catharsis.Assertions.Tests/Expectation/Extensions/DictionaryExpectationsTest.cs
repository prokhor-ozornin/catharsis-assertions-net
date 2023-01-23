using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests.Expectation.Extensions;

/// <summary>
///   <para>Tests set for class <see cref="DictionaryExpectations"/>.</para>
/// </summary>
public sealed class DictionaryExpectationsTest : UnitTest
{
  private IDictionary<object, object> Dictionary { get; } = new Dictionary<object, object>();

  /// <summary>
  ///   <para>Performs testing of <see cref="DictionaryExpectations.ContainKey{TKey, TValue}(IExpectation{IDictionary{TKey, TValue}}, TKey)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainKey_Method()
  {
    AssertionExtensions.Should(() => DictionaryExpectations.ContainKey<object, object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IDictionary<object, object>) null).Expect().ContainKey(new object())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DictionaryExpectations.ContainValue{TKey, TValue}(IExpectation{IDictionary{TKey, TValue}}, TValue, IEqualityComparer{TValue})"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainValue_Method()
  {
    AssertionExtensions.Should(() => DictionaryExpectations.ContainValue<object, object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((IDictionary<object, object>) null).Expect().ContainValue(new object())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }
}