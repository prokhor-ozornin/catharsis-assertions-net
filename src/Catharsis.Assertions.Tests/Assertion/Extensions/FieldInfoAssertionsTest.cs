using System.Reflection;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FieldInfoAssertions"/>.</para>
/// </summary>
/// <seealso cref="FieldInfoAssertions"/>
public class FieldInfoAssertionsTest : Test
{
  private FieldInfo Field { get; } = typeof(string).AnyField(nameof(string.Empty));
  private readonly string PrivateField = nameof(PrivateField);
  internal readonly string InternalField = nameof(InternalField);
  static readonly string StaticField = nameof(StaticField);

  private FieldInfo PrivateFieldInfo => GetType().AnyField(nameof(PrivateField));
  private FieldInfo ProtectedFieldInfo => GetType().AnyField(nameof(ProtectedField));
  private FieldInfo PublicFieldInfo => GetType().AnyField(nameof(PublicField));
  private FieldInfo InternalFieldInfo => GetType().AnyField(nameof(InternalField));
  private FieldInfo ProtectedInternalFieldInfo => GetType().AnyField(nameof(ProtectedInternalField));
  private FieldInfo StaticFieldInfo => GetType().AnyField(nameof(StaticField));

  /// <summary>
  ///   <para></para>
  /// </summary>
  protected readonly string ProtectedField = nameof(ProtectedField);
  
  /// <summary>
  ///   <para></para>
  /// </summary>
  public readonly string PublicField = nameof(PublicField);
  
  /// <summary>
  ///   <para></para>
  /// </summary>
  protected internal readonly string ProtectedInternalField = nameof(ProtectedInternalField);

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="FieldInfoAssertions.Type(IAssertion, FieldInfo, Type, string)"/></description></item>
  ///     <item><description><see cref="FieldInfoAssertions.Type{T}(IAssertion, FieldInfo, string)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Type_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoAssertions.Type(null, Field, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Type(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("field");
      AssertionExtensions.Should(() => Assert.To.Type(Field, null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

      Test(true, PrivateFieldInfo, typeof(string));
      Test(false, PrivateFieldInfo, typeof(object));

      static void Test(bool result, FieldInfo field, Type type)
      {
        if (result)
        {
          Assert.To.Type(field, type).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Type(field, type, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoAssertions.Type<object>(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Type<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

      Test<string>(true, PrivateFieldInfo);
      Test<object>(false, PrivateFieldInfo);

      static void Test<T>(bool result, FieldInfo field)
      {
        if (result)
        {
          Assert.To.Type<T>(field).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Type<T>(field, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.Private(IAssertion, FieldInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Private_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoAssertions.Private(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Private((FieldInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

      Test(true, PrivateFieldInfo);
      Test(true, StaticFieldInfo);
      Test(false, ProtectedFieldInfo);
      Test(false, PublicFieldInfo);
      Test(false, InternalFieldInfo);
      Test(false, ProtectedInternalFieldInfo);
    }

    return;

    static void Test(bool result, FieldInfo field)
    {
      if (result)
      {
        Assert.To.Private(field).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Private(field, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.Protected(IAssertion, FieldInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Protected_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoAssertions.Protected(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Protected((FieldInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

      Test(true, ProtectedFieldInfo);
      Test(false, PrivateFieldInfo);
      Test(false, PublicFieldInfo);
      Test(false, InternalFieldInfo);
      Test(false, ProtectedInternalFieldInfo);
      Test(false, StaticFieldInfo);
    }

    return;

    static void Test(bool result, FieldInfo field)
    {
      if (result)
      {
        Assert.To.Protected(field).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Protected(field, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.Public(IAssertion, FieldInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Public_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoAssertions.Public(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Public((FieldInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

      Test(true, PublicFieldInfo);
      Test(false, PrivateFieldInfo);
      Test(false, ProtectedFieldInfo);
      Test(false, InternalFieldInfo);
      Test(false, ProtectedInternalFieldInfo);
      Test(false, StaticFieldInfo);
    }

    return;

    static void Test(bool result, FieldInfo field)
    {
      if (result)
      {
        Assert.To.Public(field).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Public(field, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.Internal(IAssertion, FieldInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Internal_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoAssertions.Internal(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Internal((FieldInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

      Test(true, InternalFieldInfo);
      Test(false, PrivateFieldInfo);
      Test(false, ProtectedFieldInfo);
      Test(false, PublicFieldInfo);
      Test(false, ProtectedInternalFieldInfo);
      Test(false, StaticFieldInfo);
    }

    return;

    static void Test(bool result, FieldInfo field)
    {
      if (result)
      {
        Assert.To.Internal(field).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Internal(field, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.ProtectedInternal(IAssertion, FieldInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ProtectedInternal_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoAssertions.ProtectedInternal(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.ProtectedInternal((FieldInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

      Test(true, ProtectedInternalFieldInfo);
      Test(false, PrivateFieldInfo);
      Test(false, ProtectedFieldInfo);
      Test(false, PublicFieldInfo);
      Test(false, InternalFieldInfo);
      Test(false, StaticFieldInfo);
    }

    return;

    static void Test(bool result, FieldInfo field)
    {
      if (result)
      {
        Assert.To.ProtectedInternal(field).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.ProtectedInternal(field, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.Static(IAssertion, FieldInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Static_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoAssertions.Static(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Static((FieldInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

      Test(true, StaticFieldInfo);
      Test(false, PrivateFieldInfo);
      Test(false, ProtectedFieldInfo);
      Test(false, PublicFieldInfo);
      Test(false, InternalFieldInfo);
      Test(false, ProtectedInternalFieldInfo);
    }

    return;

    static void Test(bool result, FieldInfo field)
    {
      if (result)
      {
        Assert.To.Static(field).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Static(field, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.Value(IAssertion, FieldInfo, object, object, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoAssertions.Value(null, Field, string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => FieldInfoAssertions.Value(Assert.To, null, string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

      Test(false, PrivateFieldInfo, this, new object());
      Test(true, PrivateFieldInfo, this, PrivateField);
    }

    return;

    static void Test(bool result, FieldInfo field, object subject, object value)
    {
      if (result)
      {
        Assert.To.Value(field, subject, value).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Value(field, subject, value, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}