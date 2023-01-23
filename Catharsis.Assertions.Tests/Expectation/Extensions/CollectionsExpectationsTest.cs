using FluentAssertions;
using System.Collections.Specialized;
using Xunit;

namespace Catharsis.Assertions.Tests.Expectation.Extensions;

/// <summary>
///   <para>Tests set for class <see cref="CollectionsExpectations"/>.</para>
/// </summary>
public sealed class CollectionsExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="CollectionsExpectations.Count{T}(IExpectation{ICollection{T}}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Count_Collection_Method()
  {
    AssertionExtensions.Should(() => CollectionsExpectations.Count(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((ICollection<object>) null).Expect().Count(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CollectionsExpectations.Empty{T}(IExpectation{ICollection{T}})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Collection_Method()
  {
    AssertionExtensions.Should(() => CollectionsExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((ICollection<object>) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CollectionsExpectations.ReadOnly{T}(IExpectation{ICollection{T}})"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Collection_Method()
  {
    AssertionExtensions.Should(() => CollectionsExpectations.ReadOnly<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((ICollection<object>) null).Expect().ReadOnly()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CollectionsExpectations.Count(IExpectation{NameValueCollection}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Count_NameValueCollection_Method()
  {
    AssertionExtensions.Should(() => CollectionsExpectations.Count(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((NameValueCollection) null).Expect().Count(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="CollectionsExpectations.Empty(IExpectation{NameValueCollection})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_NameValueCollection_Method()
  {
    AssertionExtensions.Should(() => CollectionsExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((NameValueCollection) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }
}