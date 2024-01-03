using System.Reflection;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="MethodBaseExpectations"/>.</para>
/// </summary>
public class MethodBaseExpectationsTest : UnitTest
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
    AssertionExtensions.Should(() => MethodBaseExpectations.Abstract(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((MethodBase) null).Expect().Abstract()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    PublicAbstractMethodInfo.Expect().Abstract().Result.Should().BeTrue();
    PublicFinalMethodInfo.Expect().Abstract().Result.Should().BeFalse();
    PublicMethodInfo.Expect().Abstract().Result.Should().BeFalse();
    PrivateMethodInfo.Expect().Abstract().Result.Should().BeFalse();
    ProtectedVirtualMethodInfo.Expect().Abstract().Result.Should().BeFalse();
    PublicStaticMethodInfo.Expect().Abstract().Result.Should().BeFalse();
    InternalVirtualMethodInfo.Expect().Abstract().Result.Should().BeFalse();
    ProtectedInternalMethodInfo.Expect().Abstract().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Static(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Static_Method()
  {
    AssertionExtensions.Should(() => MethodBaseExpectations.Static(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((MethodBase) null).Expect().Static()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    PublicAbstractMethodInfo.Expect().Static().Result.Should().BeFalse();
    PublicFinalMethodInfo.Expect().Static().Result.Should().BeFalse();
    PublicMethodInfo.Expect().Static().Result.Should().BeFalse();
    PrivateMethodInfo.Expect().Static().Result.Should().BeFalse();
    ProtectedVirtualMethodInfo.Expect().Static().Result.Should().BeFalse();
    PublicStaticMethodInfo.Expect().Static().Result.Should().BeTrue();
    InternalVirtualMethodInfo.Expect().Static().Result.Should().BeFalse();
    ProtectedInternalMethodInfo.Expect().Static().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Final(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Final_Method()
  {
    AssertionExtensions.Should(() => MethodBaseExpectations.Final(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((MethodBase) null).Expect().Final()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    PublicAbstractMethodInfo.Expect().Final().Result.Should().BeFalse();
    PublicFinalMethodInfo.Expect().Final().Result.Should().BeTrue();
    PublicMethodInfo.Expect().Final().Result.Should().BeFalse();
    PrivateMethodInfo.Expect().Final().Result.Should().BeFalse();
    ProtectedVirtualMethodInfo.Expect().Final().Result.Should().BeFalse();
    PublicStaticMethodInfo.Expect().Final().Result.Should().BeFalse();
    InternalVirtualMethodInfo.Expect().Final().Result.Should().BeFalse();
    ProtectedInternalMethodInfo.Expect().Final().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Virtual(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Virtual_Method()
  {
    AssertionExtensions.Should(() => MethodBaseExpectations.Virtual(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((MethodBase) null).Expect().Virtual()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    PublicAbstractMethodInfo.Expect().Virtual().Result.Should().BeTrue();
    PublicFinalMethodInfo.Expect().Virtual().Result.Should().BeTrue();
    PublicMethodInfo.Expect().Virtual().Result.Should().BeFalse();
    PrivateMethodInfo.Expect().Virtual().Result.Should().BeFalse();
    ProtectedVirtualMethodInfo.Expect().Virtual().Result.Should().BeTrue();
    PublicStaticMethodInfo.Expect().Virtual().Result.Should().BeFalse();
    InternalVirtualMethodInfo.Expect().Virtual().Result.Should().BeTrue();
    ProtectedInternalMethodInfo.Expect().Virtual().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Overridable(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Overridable_Method()
  {
    AssertionExtensions.Should(() => MethodBaseExpectations.Overridable(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((MethodBase) null).Expect().Overridable()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    PublicAbstractMethodInfo.Expect().Overridable().Result.Should().BeTrue();
    PublicFinalMethodInfo.Expect().Overridable().Result.Should().BeFalse();
    PublicMethodInfo.Expect().Overridable().Result.Should().BeFalse();
    PrivateMethodInfo.Expect().Overridable().Result.Should().BeFalse();
    ProtectedVirtualMethodInfo.Expect().Overridable().Result.Should().BeTrue();
    PublicStaticMethodInfo.Expect().Overridable().Result.Should().BeFalse();
    InternalVirtualMethodInfo.Expect().Overridable().Result.Should().BeTrue();
    ProtectedInternalMethodInfo.Expect().Overridable().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Private(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Private_Method()
  {
    AssertionExtensions.Should(() => MethodBaseExpectations.Private(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((MethodBase) null).Expect().Private()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    PublicAbstractMethodInfo.Expect().Private().Result.Should().BeFalse();
    PublicFinalMethodInfo.Expect().Private().Result.Should().BeFalse();
    PublicMethodInfo.Expect().Private().Result.Should().BeFalse();
    PrivateMethodInfo.Expect().Private().Result.Should().BeTrue();
    ProtectedVirtualMethodInfo.Expect().Private().Result.Should().BeFalse();
    PublicStaticMethodInfo.Expect().Private().Result.Should().BeFalse();
    InternalVirtualMethodInfo.Expect().Private().Result.Should().BeFalse();
    ProtectedInternalMethodInfo.Expect().Private().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Protected(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Protected_Method()
  {
    AssertionExtensions.Should(() => MethodBaseExpectations.Protected(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((MethodBase) null).Expect().Protected()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    PublicAbstractMethodInfo.Expect().Protected().Result.Should().BeFalse();
    PublicFinalMethodInfo.Expect().Protected().Result.Should().BeFalse();
    PublicMethodInfo.Expect().Protected().Result.Should().BeFalse();
    PrivateMethodInfo.Expect().Protected().Result.Should().BeFalse();
    ProtectedVirtualMethodInfo.Expect().Protected().Result.Should().BeTrue();
    PublicStaticMethodInfo.Expect().Protected().Result.Should().BeFalse();
    InternalVirtualMethodInfo.Expect().Protected().Result.Should().BeFalse();
    ProtectedInternalMethodInfo.Expect().Protected().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Public(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Public_Method()
  {
    AssertionExtensions.Should(() => MethodBaseExpectations.Public(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((MethodBase) null).Expect().Public()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    PublicAbstractMethodInfo.Expect().Public().Result.Should().BeTrue();
    PublicFinalMethodInfo.Expect().Public().Result.Should().BeTrue();
    PublicMethodInfo.Expect().Public().Result.Should().BeTrue();
    PrivateMethodInfo.Expect().Public().Result.Should().BeFalse();
    ProtectedVirtualMethodInfo.Expect().Public().Result.Should().BeFalse();
    PublicStaticMethodInfo.Expect().Public().Result.Should().BeTrue();
    InternalVirtualMethodInfo.Expect().Public().Result.Should().BeFalse();
    ProtectedInternalMethodInfo.Expect().Public().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.Internal(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void Internal_Method()
  {
    AssertionExtensions.Should(() => MethodBaseExpectations.Internal(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((MethodBase) null).Expect().Internal()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    PublicAbstractMethodInfo.Expect().Internal().Result.Should().BeFalse();
    PublicFinalMethodInfo.Expect().Internal().Result.Should().BeFalse();
    PublicMethodInfo.Expect().Internal().Result.Should().BeFalse();
    PrivateMethodInfo.Expect().Internal().Result.Should().BeFalse();
    ProtectedVirtualMethodInfo.Expect().Internal().Result.Should().BeFalse();
    PublicStaticMethodInfo.Expect().Internal().Result.Should().BeFalse();
    InternalVirtualMethodInfo.Expect().Internal().Result.Should().BeTrue();
    ProtectedInternalMethodInfo.Expect().Internal().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseExpectations.ProtectedInternal(IExpectation{MethodBase})"/> method.</para>
  /// </summary>
  [Fact]
  public void ProtectedInternal_Method()
  {
    AssertionExtensions.Should(() => MethodBaseExpectations.ProtectedInternal(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((MethodBase) null).Expect().ProtectedInternal()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    PublicAbstractMethodInfo.Expect().ProtectedInternal().Result.Should().BeFalse();
    PublicFinalMethodInfo.Expect().ProtectedInternal().Result.Should().BeFalse();
    PublicMethodInfo.Expect().ProtectedInternal().Result.Should().BeFalse();
    PrivateMethodInfo.Expect().ProtectedInternal().Result.Should().BeFalse();
    ProtectedVirtualMethodInfo.Expect().ProtectedInternal().Result.Should().BeFalse();
    PublicStaticMethodInfo.Expect().ProtectedInternal().Result.Should().BeFalse();
    InternalVirtualMethodInfo.Expect().ProtectedInternal().Result.Should().BeFalse();
    ProtectedInternalMethodInfo.Expect().ProtectedInternal().Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public override sealed void Dispose() => base.Dispose();
}