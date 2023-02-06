using System.Reflection;
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
  public string PublicField = nameof(PublicField);
  internal string InternalField = nameof(InternalField);
  static string StaticField = nameof(StaticField);

  private FieldInfo PrivateFieldInfo => GetType().AnyField(nameof(PrivateField));
  private FieldInfo PublicFieldInfo => GetType().AnyField(nameof(PublicField));
  private FieldInfo InternalFieldInfo => GetType().AnyField(nameof(InternalField));
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
      void Validate(FieldInfo field)
      {
        Assert.To.Type(field, field.FieldType).Should().NotBeNull().And.BeSameAs(Assert.To);
        AssertionExtensions.Should(() => Assert.To.Type(field, GetType(), "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }

      AssertionExtensions.Should(() => FieldInfoAssertions.Type(null, Field, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Type(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("field");
      AssertionExtensions.Should(() => Assert.To.Type(Field, null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

      Validate(PrivateFieldInfo);
      Validate(PublicFieldInfo);
      Validate(InternalFieldInfo);
      Validate(StaticFieldInfo);
    }

    using (new AssertionScope())
    {
      void Validate(FieldInfo field)
      {
        Assert.To.Type<string>(field).Should().NotBeNull().And.BeSameAs(Assert.To);
        AssertionExtensions.Should(() => Assert.To.Type<object>(field, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      }

      AssertionExtensions.Should(() => FieldInfoAssertions.Type<object>(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => Assert.To.Type<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

      Validate(PrivateFieldInfo);
      Validate(PublicFieldInfo);
      Validate(InternalFieldInfo);
      Validate(StaticFieldInfo);
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
    AssertionExtensions.Should(() => Assert.To.Private(PublicFieldInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Private(InternalFieldInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Private(StaticFieldInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.Public(IAssertion, FieldInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Public_Method()
  {
    AssertionExtensions.Should(() => FieldInfoAssertions.Public(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Public((FieldInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

    AssertionExtensions.Should(() => Assert.To.Public(PrivateFieldInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Public(PublicFieldInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Public(InternalFieldInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Public(StaticFieldInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.Internal(IAssertion, FieldInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Internal_Method()
  {
    AssertionExtensions.Should(() => FieldInfoAssertions.Internal(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Internal((FieldInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

    AssertionExtensions.Should(() => Assert.To.Internal(PrivateFieldInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Internal(PublicFieldInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Internal(InternalFieldInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Internal(StaticFieldInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.Static(IAssertion, FieldInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Static_Method()
  {
    AssertionExtensions.Should(() => FieldInfoAssertions.Static(null, Field)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => Assert.To.Static((FieldInfo) null)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

    AssertionExtensions.Should(() => Assert.To.Static(PrivateFieldInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Static(PublicFieldInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Static(InternalFieldInfo, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Static(StaticFieldInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoAssertions.Value(IAssertion, FieldInfo, object, object, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    void Validate(FieldInfo field, object instance)
    {
      AssertionExtensions.Should(() => Assert.To.Value(field, instance, null, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
      Assert.To.Value(field, instance, field.Name).Should().NotBeNull().And.BeSameAs(Assert.To);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoAssertions.Value(null, Field, string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => FieldInfoAssertions.Value(Assert.To, null, string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("field");

      Validate(PrivateFieldInfo, this);
      Validate(PublicFieldInfo, this);
      Validate(InternalFieldInfo, this);
      Validate(StaticFieldInfo, null);
    }
  }
}