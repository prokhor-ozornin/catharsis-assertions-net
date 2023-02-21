using System.Reflection;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="MethodBaseAssertions"/>.</para>
/// </summary>
public class MethodBaseAssertionsTest : UnitTest
{
  private MethodBase Method { get; } = typeof(object).AnyMethod(nameof(ToString));

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
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Abstract(IAssertion, MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Abstract_Method()
  {
    AssertionExtensions.Should(() => MethodBaseAssertions.Abstract(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => MethodBaseAssertions.Abstract(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

    Assert.To.Abstract(PublicAbstractMethodInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Abstract(PublicFinalMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Abstract(PublicMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Abstract(PrivateMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Abstract(ProtectedVirtualMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Abstract(PublicStaticMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Abstract(InternalVirtualMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Abstract(ProtectedInternalMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Static(IAssertion, MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Static_Method()
  {
    AssertionExtensions.Should(() => MethodBaseAssertions.Static(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => MethodBaseAssertions.Static(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

    AssertionExtensions.Should(() => Assert.To.Static(PublicAbstractMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Static(PublicFinalMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Static(PublicMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Static(PrivateMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To));
    AssertionExtensions.Should(() => Assert.To.Static(ProtectedVirtualMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To));
    Assert.To.Static(PublicStaticMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Static(InternalVirtualMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Static(ProtectedInternalMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Final(IAssertion, MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Final_Method()
  {
    AssertionExtensions.Should(() => MethodBaseAssertions.Final(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Final(null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

    AssertionExtensions.Should(() => Assert.To.Final(PublicAbstractMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Final(PublicFinalMethodInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Final(PublicMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Final(PrivateMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Final(ProtectedVirtualMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Final(PublicStaticMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Final(InternalVirtualMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Final(ProtectedInternalMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Virtual(IAssertion, MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Virtual_Method()
  {
    AssertionExtensions.Should(() => MethodBaseAssertions.Virtual(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Virtual(null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

    Assert.To.Virtual(PublicAbstractMethodInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.Virtual(PublicFinalMethodInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Virtual(PublicMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Virtual(PrivateMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error"); 
    Assert.To.Virtual(ProtectedVirtualMethodInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Virtual(PublicStaticMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Virtual(InternalVirtualMethodInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Virtual(ProtectedInternalMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Overridable(IAssertion, MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Overridable_Method()
  {
    AssertionExtensions.Should(() => MethodBaseAssertions.Overridable(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Overridable(null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

    Assert.To.Overridable(PublicAbstractMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Overridable(PublicFinalMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Overridable(PublicMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Overridable(PrivateMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Overridable(ProtectedVirtualMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Overridable(PublicStaticMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Overridable(InternalVirtualMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Overridable(ProtectedInternalMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Private(IAssertion, MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Private_Method()
  {
    AssertionExtensions.Should(() => MethodBaseAssertions.Private(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => MethodBaseAssertions.Private(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

    AssertionExtensions.Should(() => Assert.To.Private(PublicAbstractMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Private(PublicFinalMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Private(PublicMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Private(PrivateMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Private(ProtectedVirtualMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Private(PublicStaticMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Private(InternalVirtualMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Private(ProtectedInternalMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Protected(IAssertion, MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Protected_Method()
  {
    AssertionExtensions.Should(() => MethodBaseAssertions.Protected(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => MethodBaseAssertions.Protected(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

    AssertionExtensions.Should(() => Assert.To.Protected(PublicAbstractMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Protected(PublicFinalMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Protected(PublicMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Protected(PrivateMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To));
    Assert.To.Protected(ProtectedVirtualMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Protected(PublicStaticMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Protected(InternalVirtualMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Protected(ProtectedInternalMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Public(IAssertion, MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Public_Method()
  {
    AssertionExtensions.Should(() => MethodBaseAssertions.Public(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => MethodBaseAssertions.Public(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

    Assert.To.Public(PublicAbstractMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.Public(PublicFinalMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.Public(PublicMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Public(PrivateMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To));
    AssertionExtensions.Should(() => Assert.To.Public(ProtectedVirtualMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To));
    Assert.To.Public(PublicStaticMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Public(InternalVirtualMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Public(ProtectedInternalMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Internal(IAssertion, MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Internal_Method()
  {
    AssertionExtensions.Should(() => MethodBaseAssertions.Internal(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => MethodBaseAssertions.Internal(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

    AssertionExtensions.Should(() => Assert.To.Internal(PublicAbstractMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Internal(PublicFinalMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Internal(PublicMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Internal(PrivateMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To));
    AssertionExtensions.Should(() => Assert.To.Internal(ProtectedVirtualMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To));
    AssertionExtensions.Should(() => Assert.To.Internal(PublicStaticMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Internal(InternalVirtualMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Internal(ProtectedInternalMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.ProtectedInternal(IAssertion, MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ProtectedInternal_Method()
  {
    AssertionExtensions.Should(() => MethodBaseAssertions.ProtectedInternal(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => MethodBaseAssertions.ProtectedInternal(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

    AssertionExtensions.Should(() => Assert.To.ProtectedInternal(PublicAbstractMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.ProtectedInternal(PublicFinalMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.ProtectedInternal(PublicMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.ProtectedInternal(PrivateMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To));
    AssertionExtensions.Should(() => Assert.To.ProtectedInternal(ProtectedVirtualMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To));
    AssertionExtensions.Should(() => Assert.To.ProtectedInternal(PublicStaticMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.ProtectedInternal(InternalVirtualMethodInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.ProtectedInternal(ProtectedInternalMethodInfo, "error").Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public override sealed void Dispose() => base.Dispose();
}