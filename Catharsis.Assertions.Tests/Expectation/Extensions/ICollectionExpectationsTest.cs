using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ICollectionExpectations"/>.</para>
/// </summary>
public sealed class ICollectionExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ICollectionExpectations.Count{T}(IExpectation{ICollection{T}}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Count_Method()
  {
    AssertionExtensions.Should(() => ((IExpectation<ICollection<object>>) null).Count(default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((ICollection<object>) null).Expect().Count(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Attributes.RandomSequence().ToArray().Expect().Count(int.MinValue).Result.Should().BeFalse();
    Attributes.RandomSequence().ToArray().Expect().Count(int.MaxValue).Result.Should().BeFalse();
    Attributes.RandomSequence().ToArray().With(collection => collection.Expect().Count(collection.Length).Result.Should().BeTrue());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ICollectionExpectations.Empty{T}(IExpectation{ICollection{T}})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => ((IExpectation<ICollection<object>>) null).Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((ICollection<object>) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Attributes.EmptySequence().ToArray().Expect().Empty().Result.Should().BeTrue();
    Attributes.RandomSequence().ToArray().Expect().Empty().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="ICollectionExpectations.ReadOnly{T}(IExpectation{ICollection{T}})"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    AssertionExtensions.Should(() => ICollectionExpectations.ReadOnly<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((ICollection<object>) null).Expect().ReadOnly()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Attributes.RandomSequence().ToArray().Expect().ReadOnly().Result.Should().BeTrue();
    Attributes.RandomSequence().ToList().Expect().ReadOnly().Result.Should().BeFalse();
  }
}