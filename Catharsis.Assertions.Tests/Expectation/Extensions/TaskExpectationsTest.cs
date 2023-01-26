using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TaskExpectations"/>.</para>
/// </summary>
public sealed class TaskExpectationsTest : UnitTest
{
  private Task<object> TypedTask { get; } = new(() => null);

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskExpectations.Exception(IExpectation{Task}, AggregateException)"/></description></item>
  ///     <item><description><see cref="TaskExpectations.Exception{T}(IExpectation{Task}, AggregateException)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Exception_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Exception(null, new AggregateException())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task) null).Expect().Exception(new AggregateException())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Exception<object>(null, new AggregateException())).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task<object>) null).Expect().Exception<object>(new AggregateException())).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskExpectations.Successful(IExpectation{Task})"/></description></item>
  ///     <item><description><see cref="TaskExpectations.Successful{T}(IExpectation{Task})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Successful_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Successful(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task) null).Expect().Successful()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Successful<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task<object>) null).Expect().Successful()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskExpectations.Unsuccessful(IExpectation{Task})"/></description></item>
  ///     <item><description><see cref="TaskExpectations.Unsuccessful{T}(IExpectation{Task})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Unsuccessful_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Unsuccessful(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task) null).Expect().Unsuccessful()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Unsuccessful<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task<object>) null).Expect().Unsuccessful()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskExpectations.Canceled(IExpectation{Task})"/></description></item>
  ///     <item><description><see cref="TaskExpectations.Canceled{T}(IExpectation{Task})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Canceled_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Canceled(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task) null).Expect().Canceled()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Canceled<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task<object>) null).Expect().Canceled()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    }

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TaskExpectations.Completed(IExpectation{Task})"/></description></item>
  ///     <item><description><see cref="TaskExpectations.Completed{T}(IExpectation{Task})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Completed_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Completed(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task) null).Expect().Completed()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TaskExpectations.Completed<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Task<object>) null).Expect().Completed()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    }

    throw new NotImplementedException();
  }

  public override void Dispose()
  {
    base.Dispose();
    TypedTask.Dispose();
  }
}