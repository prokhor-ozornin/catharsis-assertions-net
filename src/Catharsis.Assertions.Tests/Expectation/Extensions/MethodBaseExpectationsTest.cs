using System.Reflection;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="MethodBaseExpectations"/>.</para>
/// </summary>
public class MethodBaseExpectationsTest : Test
{
  public void PublicMethod() {}
  private void PrivateMethod() {}
  protected virtual void ProtectedVirtualMethod() {}
  public static void PublicStaticMethod() {}
  internal virtual void InternalVirtualMethod() {}
  protected internal void ProtectedInternalMethod() {}

  private MethodBase PublicAbstractMethodInfo => typeof(Stream).AnyMethod(nameof(Stream.Flush));
  private MethodBase PublicFinalMethodInfo => GetType().AnyMethod(nameof(Dispose));
  private MethodBase PublicMethodInfo => GetType().AnyMethod(nameof(PublicMethod));
  private MethodBase PrivateMethodInfo => GetType().AnyMethod(nameof(PrivateMethod));
  private MethodBase ProtectedVirtualMethodInfo => GetType().AnyMethod(nameof(ProtectedVirtualMethod));
  private MethodBase PublicStaticMethodInfo => GetType().AnyMethod(nameof(PublicStaticMethod));
  private MethodBase InternalVirtualMethodInfo => GetType().AnyMethod(nameof(InternalVirtualMethod));
  private MethodBase ProtectedInternalMethodInfo => GetType().AnyMethod(nameof(ProtectedInternalMethod));

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Abstract(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Abstract_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MethodBaseExpectations.Abstract(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((MethodBase) null).Expect().Abstract()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, PublicAbstractMethodInfo);
      Test(false, PublicFinalMethodInfo);
      Test(false, PublicMethodInfo);
      Test(false, PrivateMethodInfo);
      Test(false, ProtectedVirtualMethodInfo);
      Test(false, PublicStaticMethodInfo);
      Test(false, InternalVirtualMethodInfo);
      Test(false, ProtectedInternalMethodInfo);
    }

    return;

    static void Test(bool result, MethodBase method) => method.Expect().Abstract().Should().BeOfType<Expectation<MethodBase>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Static(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Static_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MethodBaseExpectations.Static(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((MethodBase) null).Expect().Static()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, PublicStaticMethodInfo);
      Test(false, PublicAbstractMethodInfo);
      Test(false, PublicFinalMethodInfo);
      Test(false, PublicMethodInfo);
      Test(false, PrivateMethodInfo);
      Test(false, ProtectedVirtualMethodInfo);
      Test(false, InternalVirtualMethodInfo);
      Test(false, ProtectedInternalMethodInfo);
    }

    return;

    static void Test(bool result, MethodBase method) => method.Expect().Static().Should().BeOfType<Expectation<MethodBase>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Final(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Final_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MethodBaseExpectations.Final(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((MethodBase) null).Expect().Final()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, PublicFinalMethodInfo);
      Test(false, PublicAbstractMethodInfo);
      Test(false, PublicMethodInfo);
      Test(false, PrivateMethodInfo);
      Test(false, ProtectedVirtualMethodInfo);
      Test(false, PublicStaticMethodInfo);
      Test(false, InternalVirtualMethodInfo);
      Test(false, ProtectedInternalMethodInfo);
    }

    return;

    static void Test(bool result, MethodBase method) => method.Expect().Final().Should().BeOfType<Expectation<MethodBase>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Virtual(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Virtual_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MethodBaseExpectations.Virtual(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((MethodBase) null).Expect().Virtual()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, PublicAbstractMethodInfo);
      Test(true, PublicFinalMethodInfo);
      Test(true, ProtectedVirtualMethodInfo);
      Test(true, InternalVirtualMethodInfo);
      Test(false, PublicMethodInfo);
      Test(false, PrivateMethodInfo);
      Test(false, PublicStaticMethodInfo);
      Test(false, ProtectedInternalMethodInfo);
    }

    return;

    static void Test(bool result, MethodBase method) => method.Expect().Virtual().Should().BeOfType<Expectation<MethodBase>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Overridable(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Overridable_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MethodBaseExpectations.Overridable(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((MethodBase) null).Expect().Overridable()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, PublicAbstractMethodInfo);
      Test(true, ProtectedVirtualMethodInfo);
      Test(true, InternalVirtualMethodInfo);
      Test(false, PublicFinalMethodInfo);
      Test(false, PublicMethodInfo);
      Test(false, PrivateMethodInfo);
      Test(false, PublicStaticMethodInfo);
      Test(false, ProtectedInternalMethodInfo);
    }

    return;

    static void Test(bool result, MethodBase method) => method.Expect().Overridable().Should().BeOfType<Expectation<MethodBase>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Private(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Private_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MethodBaseExpectations.Private(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((MethodBase) null).Expect().Private()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, PrivateMethodInfo);
      Test(false, PublicAbstractMethodInfo);
      Test(false, PublicFinalMethodInfo);
      Test(false, PublicMethodInfo);
      Test(false, ProtectedVirtualMethodInfo);
      Test(false, PublicStaticMethodInfo);
      Test(false, InternalVirtualMethodInfo);
      Test(false, ProtectedInternalMethodInfo);
    }

    return;

    static void Test(bool result, MethodBase method) => method.Expect().Private().Should().BeOfType<Expectation<MethodBase>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Protected(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Protected_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MethodBaseExpectations.Protected(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((MethodBase) null).Expect().Protected()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, ProtectedVirtualMethodInfo);
      Test(false, PublicAbstractMethodInfo);
      Test(false, PublicFinalMethodInfo);
      Test(false, PublicMethodInfo);
      Test(false, PrivateMethodInfo);
      Test(false, PublicStaticMethodInfo);
      Test(false, InternalVirtualMethodInfo);
      Test(false, ProtectedInternalMethodInfo);
    }

    return;

    static void Test(bool result, MethodBase method) => method.Expect().Protected().Should().BeOfType<Expectation<MethodBase>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Public(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Public_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MethodBaseExpectations.Public(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((MethodBase) null).Expect().Public()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, PublicAbstractMethodInfo);
      Test(true, PublicFinalMethodInfo);
      Test(true, PublicMethodInfo);
      Test(true, PublicStaticMethodInfo);
      Test(false, PrivateMethodInfo);
      Test(false, ProtectedVirtualMethodInfo);
      Test(false, InternalVirtualMethodInfo);
      Test(false, ProtectedInternalMethodInfo);
    }

    return;

    static void Test(bool result, MethodBase method) => method.Expect().Public().Should().BeOfType<Expectation<MethodBase>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Internal(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Internal_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MethodBaseExpectations.Internal(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((MethodBase) null).Expect().Internal()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, InternalVirtualMethodInfo);
      Test(false, PublicAbstractMethodInfo);
      Test(false, PublicFinalMethodInfo);
      Test(false, PublicMethodInfo);
      Test(false, PrivateMethodInfo);
      Test(false, ProtectedVirtualMethodInfo);
      Test(false, PublicStaticMethodInfo);
      Test(false, ProtectedInternalMethodInfo);
    }

    return;

    static void Test(bool result, MethodBase method) => method.Expect().Internal().Should().BeOfType<Expectation<MethodBase>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.ProtectedInternal(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void ProtectedInternal_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MethodBaseExpectations.ProtectedInternal(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((MethodBase) null).Expect().ProtectedInternal()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test(true, ProtectedInternalMethodInfo);
      Test(false, PublicAbstractMethodInfo);
      Test(false, PublicFinalMethodInfo);
      Test(false, PublicMethodInfo);
      Test(false, PrivateMethodInfo);
      Test(false, ProtectedVirtualMethodInfo);
      Test(false, PublicStaticMethodInfo);
      Test(false, InternalVirtualMethodInfo);
    }

    return;

    static void Test(bool result, MethodBase method) => method.Expect().ProtectedInternal().Should().BeOfType<Expectation<MethodBase>>().Which.Result.Should().Be(result);
  }

  public sealed override void Dispose() => base.Dispose();
}