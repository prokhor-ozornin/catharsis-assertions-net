using FluentAssertions;
using System.Collections.Specialized;
using Catharsis.Commons;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => NameValueCollectionExpectations.Count(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((NameValueCollection) null).Expect().Count(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, [], 0);
      Validate(false, [], int.MinValue);
      Validate(false, [], int.MaxValue);
    }

    return;

    static void Validate(bool result, NameValueCollection collection, int count) => collection.Expect().Count(count).Should().BeOfType<Expectation<NameValueCollection>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="NameValueCollectionExpectations.Empty(IExpectation{NameValueCollection})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => NameValueCollectionExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((NameValueCollection) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, []);
      Validate(false, new NameValueCollection().With(("name", "value")));
    }

    return;

    static void Validate(bool result, NameValueCollection collection) => collection.Expect().Empty().Should().BeOfType<Expectation<NameValueCollection>>().Which.Result.Should().Be(result);
  }
}