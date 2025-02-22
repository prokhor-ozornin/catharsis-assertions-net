using System.Reflection;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="PropertyInfoExpectations"/>.</para>
/// </summary>
public sealed class PropertyInfoExpectationsTest : UnitTest
{
  private string Field;
  private string WriteOnlyProperty
  {
    set => Field = value;
  }

  private string ReadOnlyProperty => nameof(ReadOnlyProperty);
  private string ReadWriteProperty { get; set; } = nameof(ReadWriteProperty);
  private static string StaticProperty { get; set; } = nameof(StaticProperty);

  private PropertyInfo ReadOnlyPropertyInfo => GetType().AnyProperty(nameof(ReadOnlyProperty));
  private PropertyInfo WriteOnlyPropertyInfo => GetType().AnyProperty(nameof(WriteOnlyProperty));
  private PropertyInfo ReadWritePropertyInfo => GetType().AnyProperty(nameof(ReadWriteProperty));
  private PropertyInfo StaticPropertyInfo => GetType().AnyProperty(nameof(StaticProperty));

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoExpectations.Readable(IExpectation{PropertyInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Readable_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => PropertyInfoExpectations.Readable(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((PropertyInfo) null).Expect().Readable()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, ReadOnlyPropertyInfo);
      Validate(true, ReadWritePropertyInfo);
      Validate(false, WriteOnlyPropertyInfo);
    }

    return;

    static void Validate(bool result, PropertyInfo property) => property.Expect().Readable().Should().BeOfType<Expectation<PropertyInfo>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoExpectations.ReadOnly(IExpectation{PropertyInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => PropertyInfoExpectations.ReadOnly(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((PropertyInfo) null).Expect().ReadOnly()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, ReadOnlyPropertyInfo);
      Validate(false, ReadWritePropertyInfo);
      Validate(false, WriteOnlyPropertyInfo);
    }

    return;

    static void Validate(bool result, PropertyInfo property) => property.Expect().ReadOnly().Should().BeOfType<Expectation<PropertyInfo>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoExpectations.Writable(IExpectation{PropertyInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Writable_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => PropertyInfoExpectations.Writable(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((PropertyInfo) null).Expect().Writable()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, ReadWritePropertyInfo);
      Validate(true, WriteOnlyPropertyInfo);
      Validate(false, ReadOnlyPropertyInfo);
    }

    return;

    static void Validate(bool result, PropertyInfo property) => property.Expect().Writable().Should().BeOfType<Expectation<PropertyInfo>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoExpectations.WriteOnly(IExpectation{PropertyInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void WriteOnly_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => PropertyInfoExpectations.WriteOnly(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((PropertyInfo) null).Expect().WriteOnly()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, WriteOnlyPropertyInfo);
      Validate(false, ReadWritePropertyInfo);
      Validate(false, ReadOnlyPropertyInfo);
    }

    return;

    static void Validate(bool result, PropertyInfo property) => property.Expect().WriteOnly().Should().BeOfType<Expectation<PropertyInfo>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoExpectations.Value(IExpectation{PropertyInfo}, object, object)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => PropertyInfoExpectations.Value(null, string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((PropertyInfo) null).Expect().Value(string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, ReadOnlyPropertyInfo, this, ReadOnlyProperty);
      Validate(false, ReadOnlyPropertyInfo, this, null);
    }

    return;

    static void Validate(bool result, PropertyInfo property, object subject, object value) => property.Expect().Value(subject, value).Should().BeOfType<Expectation<PropertyInfo>>().Which.Result.Should().Be(result);
  }
}