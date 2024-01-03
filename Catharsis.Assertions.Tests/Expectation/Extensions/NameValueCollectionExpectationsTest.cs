using FluentAssertions;
using System.Collections.Specialized;
using Catharsis.Commons;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="NameValueCollectionExpectations"/>.</para>
/// </summary>
public sealed class NameValueCollectionExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="NameValueCollectionExpectations.Count(IExpectation{NameValueCollection}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Count_Method()
  {
    AssertionExtensions.Should(() => NameValueCollectionExpectations.Count(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((NameValueCollection) null).Expect().Count(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    new NameValueCollection().With(collection => collection.Expect().Count(int.MinValue).Result.Should().BeFalse());
    new NameValueCollection().With(collection => collection.Expect().Count(int.MaxValue).Result.Should().BeFalse());
    new NameValueCollection().With(collection => collection.Expect().Count(collection.Count).Result.Should().BeTrue());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="NameValueCollectionExpectations.Empty(IExpectation{NameValueCollection})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => NameValueCollectionExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((NameValueCollection) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    new NameValueCollection().Expect().Empty().Result.Should().BeTrue();
    new NameValueCollection().With(collection => collection.AddRange(("name", "value")).Expect().Empty().Result.Should().BeFalse());
  }
}