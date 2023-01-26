using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TypeExpectations"/>.</para>
/// </summary>
public sealed class TypeExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TypeExpectations.Abstract(IExpectation{Type})"/> method.</para>
  /// </summary>
  [Fact]
  public void Abstract_Method()
  {
    AssertionExtensions.Should(() => TypeExpectations.Abstract(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Type) null).Expect().Abstract()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TypeExpectations.Sealed(IExpectation{Type})"/> method.</para>
  /// </summary>
  [Fact]
  public void Sealed_Method()
  {
    AssertionExtensions.Should(() => TypeExpectations.Sealed(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Type) null).Expect().Sealed()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TypeExpectations.Static(IExpectation{Type})"/> method.</para>
  /// </summary>
  [Fact]
  public void Static_Method()
  {
    AssertionExtensions.Should(() => TypeExpectations.Static(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Type) null).Expect().Static()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TypeExpectations.AssignableTo(IExpectation{Type}, Type)"/></description></item>
  ///     <item><description><see cref="TypeExpectations.AssignableTo{T}(IExpectation{Type})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void AssignableTo_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.AssignableTo(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Type) null).Expect().AssignableTo(typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.AssignableTo<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Type) null).Expect().AssignableTo<object>()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TypeExpectations.AssignableFrom(IExpectation{Type}, Type)"/></description></item>
  ///     <item><description><see cref="TypeExpectations.AssignableFrom{T}(IExpectation{Type})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void AssignableFrom_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.AssignableFrom(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Type) null).Expect().AssignableFrom(typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.AssignableFrom<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Type) null).Expect().AssignableFrom<object>()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    }

    throw new NotImplementedException();
  }
}