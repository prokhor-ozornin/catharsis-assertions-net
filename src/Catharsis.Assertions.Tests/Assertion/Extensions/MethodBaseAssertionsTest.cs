using System.Reflection;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MethodBaseAssertions.Abstract(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => MethodBaseAssertions.Abstract(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

      Validate(true, PublicAbstractMethodInfo);
      Validate(false, PublicFinalMethodInfo);
      Validate(false, PublicMethodInfo);
      Validate(false, PrivateMethodInfo);
      Validate(false, ProtectedVirtualMethodInfo);
      Validate(false, PublicStaticMethodInfo);
      Validate(false, InternalVirtualMethodInfo);
      Validate(false, ProtectedInternalMethodInfo);
    }

    return;

    static void Validate(bool result, MethodBase method)
    {
      if (result)
      {
        Assert.To.Abstract(method).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Abstract(method, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Static(IAssertion, MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Static_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MethodBaseAssertions.Static(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => MethodBaseAssertions.Static(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

      Validate(true, PublicStaticMethodInfo);
      Validate(false, PublicAbstractMethodInfo);
      Validate(false, PublicFinalMethodInfo);
      Validate(false, PublicMethodInfo);
      Validate(false, PrivateMethodInfo);
      Validate(false, ProtectedVirtualMethodInfo);
      Validate(false, InternalVirtualMethodInfo);
      Validate(false, ProtectedInternalMethodInfo);
    }

    return;

    static void Validate(bool result, MethodBase method)
    {
      if (result)
      {
        Assert.To.Static(method, "error").Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Static(method, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Final(IAssertion, MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Final_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MethodBaseAssertions.Final(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Final(null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

      Validate(true, PublicFinalMethodInfo);
      Validate(false, PublicAbstractMethodInfo);
      Validate(false, PublicMethodInfo);
      Validate(false, PrivateMethodInfo);
      Validate(false, ProtectedVirtualMethodInfo);
      Validate(false, PublicStaticMethodInfo);
      Validate(false, InternalVirtualMethodInfo);
      Validate(false, ProtectedInternalMethodInfo);
    }

    return;

    static void Validate(bool result, MethodBase method)
    {
      if (result)
      {
        Assert.To.Final(method).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Final(method, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Virtual(IAssertion, MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Virtual_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MethodBaseAssertions.Virtual(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Virtual(null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

      Validate(true, PublicAbstractMethodInfo);
      Validate(true, PublicFinalMethodInfo);
      Validate(true, ProtectedVirtualMethodInfo);
      Validate(true, InternalVirtualMethodInfo);
      Validate(false, PublicMethodInfo);
      Validate(false, PrivateMethodInfo);
      Validate(false, PublicStaticMethodInfo);
      Validate(false, ProtectedInternalMethodInfo);
    }

    return;

    static void Validate(bool result, MethodBase method)
    {
      if (result)
      {
        Assert.To.Virtual(method).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Virtual(method, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Overridable(IAssertion, MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Overridable_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MethodBaseAssertions.Overridable(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Overridable(null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

      Validate(true, PublicAbstractMethodInfo);
      Validate(true, ProtectedVirtualMethodInfo);
      Validate(true, InternalVirtualMethodInfo);
      Validate(false, PublicFinalMethodInfo);
      Validate(false, PublicMethodInfo);
      Validate(false, PrivateMethodInfo);
      Validate(false, PublicStaticMethodInfo);
      Validate(false, ProtectedInternalMethodInfo);
    }

    return;

    static void Validate(bool result, MethodBase method)
    {
      if (result)
      {
        Assert.To.Overridable(method, "error").Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Overridable(method, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Private(IAssertion, MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Private_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MethodBaseAssertions.Private(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => MethodBaseAssertions.Private(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

      Validate(true, PrivateMethodInfo);
      Validate(false, PublicAbstractMethodInfo);
      Validate(false, PublicFinalMethodInfo);
      Validate(false, PublicMethodInfo);
      Validate(false, ProtectedVirtualMethodInfo);
      Validate(false, PublicStaticMethodInfo);
      Validate(false, InternalVirtualMethodInfo);
      Validate(false, ProtectedInternalMethodInfo);
    }

    return;

    static void Validate(bool result, MethodBase method)
    {
      if (result)
      {
        Assert.To.Private(method, "error").Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Private(method, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Protected(IAssertion, MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Protected_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MethodBaseAssertions.Protected(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => MethodBaseAssertions.Protected(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

      Validate(true, ProtectedVirtualMethodInfo);
      Validate(false, PublicAbstractMethodInfo);
      Validate(false, PublicFinalMethodInfo);
      Validate(false, PublicMethodInfo);
      Validate(false, PrivateMethodInfo);
      Validate(false, PublicStaticMethodInfo);
      Validate(false, InternalVirtualMethodInfo);
      Validate(false, ProtectedInternalMethodInfo);
    }

    return;

    static void Validate(bool result, MethodBase method)
    {
      if (result)
      {
        Assert.To.Protected(method, "error").Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Protected(method, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Public(IAssertion, MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Public_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MethodBaseAssertions.Public(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => MethodBaseAssertions.Public(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

      Validate(true, PublicAbstractMethodInfo);
      Validate(true, PublicFinalMethodInfo);
      Validate(true, PublicMethodInfo);
      Validate(true, PublicStaticMethodInfo);
      Validate(false, PrivateMethodInfo);
      Validate(false, ProtectedVirtualMethodInfo);
      Validate(false, InternalVirtualMethodInfo);
      Validate(false, ProtectedInternalMethodInfo);
    }

    return;

    static void Validate(bool result, MethodBase method)
    {
      if (result)
      {
        Assert.To.Public(method, "error").Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Public(method, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.Internal(IAssertion, MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Internal_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MethodBaseAssertions.Internal(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => MethodBaseAssertions.Internal(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

      Validate(true, InternalVirtualMethodInfo);
      Validate(false, PublicAbstractMethodInfo);
      Validate(false, PublicFinalMethodInfo);
      Validate(false, PublicMethodInfo);
      Validate(false, PrivateMethodInfo);
      Validate(false, ProtectedVirtualMethodInfo);
      Validate(false, PublicStaticMethodInfo);
      Validate(false, ProtectedInternalMethodInfo);
    }

    return;

    static void Validate(bool result, MethodBase method)
    {
      if (result)
      {
        Assert.To.Internal(method, "error").Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Internal(method, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="MethodBaseAssertions.ProtectedInternal(IAssertion, MethodBase, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ProtectedInternal_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => MethodBaseAssertions.ProtectedInternal(null, Method)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => MethodBaseAssertions.ProtectedInternal(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("method");

      Validate(true, ProtectedInternalMethodInfo);
      Validate(false, PublicAbstractMethodInfo);
      Validate(false, PublicFinalMethodInfo);
      Validate(false, PublicMethodInfo);
      Validate(false, PrivateMethodInfo);
      Validate(false, ProtectedVirtualMethodInfo);
      Validate(false, PublicStaticMethodInfo);
      Validate(false, InternalVirtualMethodInfo);
    }

    return;

    static void Validate(bool result, MethodBase method)
    {
      if (result)
      {
        Assert.To.ProtectedInternal(method, "error").Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.ProtectedInternal(method, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  public sealed override void Dispose() => base.Dispose();
}