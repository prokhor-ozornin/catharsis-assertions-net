using FluentAssertions;
using Xunit;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ICollectionExpectations"/>.</para>
/// </summary>
/// <seealso cref="ICollectionExpectations"/>
public sealed class ICollectionExpectationsTest : Test
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ICollectionExpectations.Count{T}(IExpectation{ICollection{T}}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Count_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ((IExpectation<ICollection<object>>) null).Count(0)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((ICollection<object>) null).Expect().Count(0)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, Array.Empty<object>(), 0);
      Test(false, Array.Empty<object>(), int.MinValue);
      Test(false, Array.Empty<object>(), int.MaxValue);
    }

    return;

    static void Test<T>(bool result, ICollection<T> collection, int count) => collection.Expect().Count(count).Should().BeOfType<Expectation<ICollection<T>>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ICollectionExpectations.Empty{T}(IExpectation{ICollection{T}})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ((IExpectation<ICollection<object>>) null).Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((ICollection<object>) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, Array.Empty<object>());
      Test(false, RandomSequence.ToArray());
    }

    return;

    static void Test<T>(bool result, ICollection<T> collection) => collection.Expect().Empty().Should().BeOfType<Expectation<ICollection<T>>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ICollectionExpectations.ReadOnly{T}(IExpectation{ICollection{T}})"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ICollectionExpectations.ReadOnly<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((ICollection<object>) null).Expect().ReadOnly()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, Array.Empty<object>());
      Test(false, new List<object>());
    }

    return;

    static void Test<T>(bool result, ICollection<T> collection) => collection.Expect().ReadOnly().Should().BeOfType<Expectation<ICollection<T>>>().Which.Result.Should().Be(result);
  }
}