﻿using System.Reflection;
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
  ///     <item><description><see cref="FieldInfoExpectations.Type(IExpectation{FieldInfo}, Type)"/></description></item>
  ///     <item><description><see cref="FieldInfoExpectations.Type{T}(IExpectation{FieldInfo})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Type_Methods()
  {
    using (new AssertionScope())
    {
      void Validate(FieldInfo field)
      {
        field.Expect().Type(field.FieldType).Result.Should().BeTrue();
        field.Expect().Type(GetType()).Result.Should().BeFalse();
      }

      AssertionExtensions.Should(() => FieldInfoExpectations.Type(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Type(typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("subject");
      AssertionExtensions.Should(() => Field.Expect().Type(null)).ThrowExactly<ArgumentNullException>().WithParameterName("type");

      Validate(PrivateFieldInfo);
      Validate(PublicFieldInfo);
      Validate(InternalFieldInfo);
      Validate(StaticFieldInfo);
    }

    using (new AssertionScope())
    {
      void Validate(FieldInfo field)
      {
        field.Expect().Type<string>().Result.Should().BeTrue();
        field.Expect().Type<object>().Result.Should().BeFalse();
      }

      AssertionExtensions.Should(() => FieldInfoExpectations.Type<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Type<object>()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(PrivateFieldInfo);
      Validate(PublicFieldInfo);
      Validate(InternalFieldInfo);
      Validate(StaticFieldInfo);
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoExpectations.Private(IExpectation{FieldInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Private_Method()
  {
    AssertionExtensions.Should(() => FieldInfoExpectations.Private(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Private()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    PrivateFieldInfo.Expect().Private().Result.Should().BeTrue();
    PublicFieldInfo.Expect().Private().Result.Should().BeFalse();
    InternalFieldInfo.Expect().Private().Result.Should().BeFalse();
    StaticFieldInfo.Expect().Private().Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoExpectations.Public(IExpectation{FieldInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Public_Method()
  {
    AssertionExtensions.Should(() => FieldInfoExpectations.Public(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Public()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    PrivateFieldInfo.Expect().Public().Result.Should().BeFalse();
    PublicFieldInfo.Expect().Public().Result.Should().BeTrue();
    InternalFieldInfo.Expect().Public().Result.Should().BeFalse();
    StaticFieldInfo.Expect().Public().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoExpectations.Internal(IExpectation{FieldInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Internal_Method()
  {
    AssertionExtensions.Should(() => FieldInfoExpectations.Internal(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Internal()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    PrivateFieldInfo.Expect().Internal().Result.Should().BeFalse();
    PublicFieldInfo.Expect().Internal().Result.Should().BeFalse();
    InternalFieldInfo.Expect().Internal().Result.Should().BeTrue();
    StaticFieldInfo.Expect().Internal().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoExpectations.Static(IExpectation{FieldInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Static_Method()
  {
    AssertionExtensions.Should(() => FieldInfoExpectations.Static(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Static()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    PrivateFieldInfo.Expect().Static().Result.Should().BeFalse();
    PublicFieldInfo.Expect().Static().Result.Should().BeFalse();
    InternalFieldInfo.Expect().Static().Result.Should().BeFalse();
    StaticFieldInfo.Expect().Static().Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="FieldInfoExpectations.Value(IExpectation{FieldInfo}, object, object)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    void Validate(FieldInfo field, object instance)
    {
      field.Expect().Value(instance, null).Result.Should().BeFalse();
      field.Expect().Value(instance, field.Name).Result.Should().BeTrue();
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => FieldInfoExpectations.Value(null, string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((FieldInfo) null).Expect().Value(string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(PrivateFieldInfo, this);
      Validate(PublicFieldInfo, this);
      Validate(InternalFieldInfo, this);
      Validate(StaticFieldInfo, null);
    }
  }
}