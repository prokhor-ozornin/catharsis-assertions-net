using System.Reflection;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FieldInfoAssertions"/>.</para>
/// </summary>
public sealed class FieldInfoAssertionsTest : UnitTest
{
  private FieldInfo Field { get; } = typeof(string).AnyField(nameof(string.Empty));

  private string PrivateField = nameof(PrivateField);
  protected string ProtectedField = nameof(ProtectedField);
  public string PublicField = nameof(PublicField);
  internal string InternalField = nameof(InternalField);
  protected internal string ProtectedInternalField = nameof(ProtectedInternalField);
  static string StaticField = nameof(StaticField);

  private FieldInfo PrivateFieldInfo => GetType().AnyField(nameof(PrivateField));
  private FieldInfo ProtectedFieldInfo => GetType().AnyField(nameof(ProtectedField));
  private FieldInfo PublicFieldInfo => GetType().AnyField(nameof(PublicField));
  private FieldInfo InternalFieldInfo => GetType().AnyField(nameof(InternalField));
  private FieldInfo ProtectedInternalFieldInfo => GetType().AnyField(nameof(ProtectedInternalField));
  private FieldInfo StaticFieldInfo => GetType().AnyField(nameof(StaticField));

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

      Validate(PrivateFieldInfo);
      Validate(ProtectedFieldInfo);
      Validate(PublicFieldInfo);
      Validate(InternalFieldInfo);
      Validate(ProtectedInternalFieldInfo);
      Validate(StaticFieldInfo);

      void Validate(FieldInfo field)
      {
        Assert.To.Type(field, field.FieldType).Should().NotBeNull().And.BeSameAs(Assert.To);
        AssertionExtensions.Should(() => Assert.To.Type(field, GetType(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoAssertions.Type<object>(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Type<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

      Validate(PrivateFieldInfo);
      Validate(ProtectedFieldInfo);
      Validate(PublicFieldInfo);
      Validate(InternalFieldInfo);
      Validate(ProtectedInternalFieldInfo);
      Validate(StaticFieldInfo);

      void Validate(FieldInfo field)
      {
        Assert.To.Type<string>(field).Should().NotBeNull().And.BeSameAs(Assert.To);
        AssertionExtensions.Should(() => Assert.To.Type<object>(field, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.Private(IAssertion, FieldInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Private_Method()
  {
    AssertionExtensions.Should(() => FieldInfoAssertions.Private(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Private((FieldInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

    Assert.To.Private(PrivateFieldInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Private(ProtectedFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Private(PublicFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Private(InternalFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Private(ProtectedInternalFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Private(StaticFieldInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.Protected(IAssertion, FieldInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Protected_Method()
  {
    AssertionExtensions.Should(() => FieldInfoAssertions.Protected(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Protected((FieldInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

    AssertionExtensions.Should(() => Assert.To.Protected(PrivateFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Protected(ProtectedFieldInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Protected(PublicFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Protected(InternalFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Protected(ProtectedInternalFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Protected(StaticFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.Public(IAssertion, FieldInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Public_Method()
  {
    AssertionExtensions.Should(() => FieldInfoAssertions.Public(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Public((FieldInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

    AssertionExtensions.Should(() => Assert.To.Public(PrivateFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Public(ProtectedFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Public(PublicFieldInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Public(InternalFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Public(ProtectedInternalFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Public(StaticFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.Internal(IAssertion, FieldInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Internal_Method()
  {
    AssertionExtensions.Should(() => FieldInfoAssertions.Internal(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Internal((FieldInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

    AssertionExtensions.Should(() => Assert.To.Internal(PrivateFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Internal(ProtectedFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Internal(PublicFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Internal(InternalFieldInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Internal(ProtectedInternalFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Internal(StaticFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.ProtectedInternal(IAssertion, FieldInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ProtectedInternal_Method()
  {
    AssertionExtensions.Should(() => FieldInfoAssertions.ProtectedInternal(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.ProtectedInternal((FieldInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

    AssertionExtensions.Should(() => Assert.To.ProtectedInternal(PrivateFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.ProtectedInternal(ProtectedFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.ProtectedInternal(PublicFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.ProtectedInternal(InternalFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.ProtectedInternal(ProtectedInternalFieldInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.ProtectedInternal(StaticFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.Static(IAssertion, FieldInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Static_Method()
  {
    AssertionExtensions.Should(() => FieldInfoAssertions.Static(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Static((FieldInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

    AssertionExtensions.Should(() => Assert.To.Static(PrivateFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Static(ProtectedFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Static(PublicFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Static(InternalFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Static(ProtectedInternalFieldInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Static(StaticFieldInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
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

      Validate(PrivateFieldInfo, this);
      Validate(ProtectedFieldInfo, this);
      Validate(PublicFieldInfo, this);
      Validate(InternalFieldInfo, this);
      Validate(ProtectedInternalFieldInfo, this);
      Validate(StaticFieldInfo, null);
    }

    return;

    static void Validate(FieldInfo field, object instance)
    {
      AssertionExtensions.Should(() => Assert.To.Value(field, instance, new object(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Value(field, instance, field.GetValue(instance)).Should().NotBeNull().And.BeSameAs(Assert.To);
    }
  }
}