using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DictionaryAssertions"/>.</para>
/// </summary>
public sealed class DictionaryAssertionsTest : UnitTest
{
  private IDictionary<object, object> Dictionary { get; } = new Dictionary<object, object>();

  /// <summary>
  ///   <para>Performs testing of <see cref="DictionaryAssertions.ContainKey{TKey, TValue}(IAssertion, IDictionary{TKey, TValue}, TKey, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainKey_Method()
  {
    AssertionExtensions.Should(() => DictionaryAssertions.ContainKey(null, Dictionary, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ContainKey<object, object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("dictionary");

    AssertionExtensions.Should(() => Assert.To.ContainKey(Dictionary, Guid.NewGuid(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    Dictionary.With(dictionary =>
    {
      dictionary.Add(Guid.Empty, new object());
      Assert.To.ContainKey(Dictionary, Guid.Empty).Should().NotBeNull().And.BeSameAs(Assert.To);
    });
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DictionaryAssertions.ContainValue{TKey, TValue}(IAssertion, IDictionary{TKey, TValue}, TValue, IEqualityComparer{TValue}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ContainValue_Method()
  {
    AssertionExtensions.Should(() => DictionaryAssertions.ContainValue(null, Dictionary, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ContainValue<object, object>(null, new object())).ThrowExactly<ArgumentNullException>().WithParameterName("dictionary");

    AssertionExtensions.Should(() => Assert.To.ContainValue(Dictionary, null, null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");

    Dictionary.With(dictionary =>
    {
      dictionary.Add(Guid.NewGuid(), null);
      Assert.To.ContainValue(Dictionary, null).Should().NotBeNull().And.BeSameAs(Assert.To);
    });
  }
}