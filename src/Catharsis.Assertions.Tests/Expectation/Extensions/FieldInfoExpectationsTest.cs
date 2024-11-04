using System.Reflection;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="FieldInfoExpectations"/>.</para>
/// </summary>
public sealed class FieldInfoExpectationsTest : UnitTest
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
  ///     <item><description><see cref="FieldInfoExpectations.Type(IExpectation{FieldInfo}, Type)"/></description></item>
  ///     <item><description><see cref="FieldInfoExpectations.Type{T}(IExpectation{FieldInfo})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Type_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoExpectations.Type(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Type(typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => Field.Expect().Type(null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

      Validate(true, PrivateFieldInfo, typeof(string));
      Validate(false, PrivateFieldInfo, typeof(object));

      static void Validate(bool result, FieldInfo field, Type type) => field.Expect().Type(type).Should().BeOfType<Expectation<FieldInfo>>().Which.Result.Should().Be(result);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoExpectations.Type<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Type<object>()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate<string>(true, PrivateFieldInfo);
      Validate<object>(false, PrivateFieldInfo);

      void Validate<T>(bool result, FieldInfo field) => field.Expect().Type<T>().Should().BeOfType<Expectation<FieldInfo>>().Which.Result.Should().Be(result);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoExpectations.Private(IExpectation{FieldInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Private_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoExpectations.Private(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Private()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, PrivateFieldInfo);
      Validate(true, StaticFieldInfo);
      Validate(false, ProtectedFieldInfo);
      Validate(false, PublicFieldInfo);
      Validate(false, InternalFieldInfo);
      Validate(false, ProtectedInternalFieldInfo);
    }

    return;

    static void Validate(bool result, FieldInfo field) => field.Expect().Private().Should().BeOfType<Expectation<FieldInfo>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoExpectations.Protected(IExpectation{FieldInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Protected_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoExpectations.Protected(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Protected()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, ProtectedFieldInfo);
      Validate(false, PrivateFieldInfo);
      Validate(false, PublicFieldInfo);
      Validate(false, InternalFieldInfo);
      Validate(false, ProtectedInternalFieldInfo);
      Validate(false, StaticFieldInfo);
    }

    return;

    static void Validate(bool result, FieldInfo field) => field.Expect().Protected().Should().BeOfType<Expectation<FieldInfo>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoExpectations.Public(IExpectation{FieldInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Public_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoExpectations.Public(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Public()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, PublicFieldInfo);
      Validate(false, PrivateFieldInfo);
      Validate(false, ProtectedFieldInfo);
      Validate(false, InternalFieldInfo);
      Validate(false, ProtectedInternalFieldInfo);
      Validate(false, StaticFieldInfo);
    }

    return;

    static void Validate(bool result, FieldInfo field) => field.Expect().Public().Should().BeOfType<Expectation<FieldInfo>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoExpectations.Internal(IExpectation{FieldInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Internal_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoExpectations.Internal(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Internal()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, InternalFieldInfo);
      Validate(false, PrivateFieldInfo);
      Validate(false, ProtectedFieldInfo);
      Validate(false, PublicFieldInfo);
      Validate(false, ProtectedInternalFieldInfo);
      Validate(false, StaticFieldInfo);
    }

    return;

    static void Validate(bool result, FieldInfo field) => field.Expect().Internal().Should().BeOfType<Expectation<FieldInfo>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoExpectations.ProtectedInternal(IExpectation{FieldInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void ProtectedInternal_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoExpectations.ProtectedInternal(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FieldInfo) null).Expect().ProtectedInternal()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, ProtectedInternalFieldInfo);
      Validate(false, PrivateFieldInfo);
      Validate(false, ProtectedFieldInfo);
      Validate(false, PublicFieldInfo);
      Validate(false, InternalFieldInfo);
      Validate(false, StaticFieldInfo);
    }
    
    return;

    static void Validate(bool result, FieldInfo field) => field.Expect().ProtectedInternal().Should().BeOfType<Expectation<FieldInfo>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoExpectations.Static(IExpectation{FieldInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Static_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoExpectations.Static(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Static()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, StaticFieldInfo);
      Validate(false, PrivateFieldInfo);
      Validate(false, ProtectedFieldInfo);
      Validate(false, PublicFieldInfo);
      Validate(false, InternalFieldInfo);
      Validate(false, ProtectedInternalFieldInfo);
    }

    return;

    static void Validate(bool result, FieldInfo field) => field.Expect().Static().Should().BeOfType<Expectation<FieldInfo>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoExpectations.Value(IExpectation{FieldInfo}, object, object)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoExpectations.Value(null, string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Value(string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(false, PrivateFieldInfo, this, new object());
      Validate(true, PrivateFieldInfo, this, PrivateField);
    }

    return;

    static void Validate(bool result, FieldInfo field, object subject, object value) => field.Expect().Value(subject, value).Should().BeOfType<Expectation<FieldInfo>>().Which.Result.Should().Be(result);
  }
}