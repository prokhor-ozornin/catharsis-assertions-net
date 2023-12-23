using System.Reflection;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="PropertyInfoAssertions"/>.</para>
/// </summary>
public sealed class PropertyInfoAssertionsTest : UnitTest
{
  private string field;

  private string WriteOnlyProperty
  {
    set => field = value;
  }

  private string ReadOnlyProperty => nameof(ReadOnlyProperty);

  private string ReadWriteProperty { get; set; } = nameof(ReadWriteProperty);

  private static string StaticProperty { get; set; } = nameof(StaticProperty);

  private PropertyInfo WriteOnlyPropertyInfo => GetType().AnyProperty(nameof(WriteOnlyProperty));
  private PropertyInfo ReadOnlyPropertyInfo => GetType().AnyProperty(nameof(ReadOnlyProperty));
  private PropertyInfo ReadWritePropertyInfo => GetType().AnyProperty(nameof(ReadWriteProperty));
  private PropertyInfo StaticPropertyInfo => GetType().AnyProperty(nameof(StaticProperty));

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoAssertions.Readable(IAssertion, PropertyInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Readable_Method()
  {
    AssertionExtensions.Should(() => PropertyInfoAssertions.Readable(null, ReadWritePropertyInfo)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => PropertyInfoAssertions.Readable(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("property");

    ReadOnlyPropertyInfo.Expect().Readable().Result.Should().BeTrue();
    WriteOnlyPropertyInfo.Expect().Readable().Result.Should().BeFalse();
    ReadWritePropertyInfo.Expect().Readable().Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoAssertions.ReadOnly(IAssertion, PropertyInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    AssertionExtensions.Should(() => PropertyInfoAssertions.ReadOnly(null, ReadWritePropertyInfo)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => PropertyInfoAssertions.ReadOnly(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("property");

    ReadOnlyPropertyInfo.Expect().ReadOnly().Result.Should().BeTrue();
    WriteOnlyPropertyInfo.Expect().ReadOnly().Result.Should().BeFalse();
    ReadWritePropertyInfo.Expect().ReadOnly().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoAssertions.Writable(IAssertion, PropertyInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Writable_Method()
  {
    AssertionExtensions.Should(() => PropertyInfoAssertions.Writable(null, ReadWritePropertyInfo)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => PropertyInfoAssertions.Writable(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("property");

    ReadOnlyPropertyInfo.Expect().Writable().Result.Should().BeFalse();
    WriteOnlyPropertyInfo.Expect().Writable().Result.Should().BeTrue();
    ReadWritePropertyInfo.Expect().Writable().Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoAssertions.WriteOnly(IAssertion, PropertyInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void WriteOnly_Method()
  {
    AssertionExtensions.Should(() => PropertyInfoAssertions.WriteOnly(null, ReadWritePropertyInfo)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => PropertyInfoAssertions.WriteOnly(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("property");

    ReadOnlyPropertyInfo.Expect().WriteOnly().Result.Should().BeFalse();
    WriteOnlyPropertyInfo.Expect().WriteOnly().Result.Should().BeTrue();
    ReadWritePropertyInfo.Expect().WriteOnly().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoAssertions.Value(IAssertion, PropertyInfo, object, object, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Value_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => PropertyInfoAssertions.Value(null, ReadWritePropertyInfo, string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => PropertyInfoAssertions.Value(Assert.To, null, string.Empty, string.Empty)).ThrowExactly<ArgumentNullException>().WithParameterName("property");
      AssertionExtensions.Should(() => Assert.To.Value(WriteOnlyPropertyInfo, string.Empty, string.Empty)).ThrowExactly<ArgumentException>();

      Validate(ReadOnlyPropertyInfo, this);
      Validate(ReadWritePropertyInfo, this);
      Validate(StaticPropertyInfo, null);
    }

    return;

    static void Validate(PropertyInfo property, object instance)
    {
      property.Expect().Value(instance, new object()).Result.Should().BeFalse();
      property.Expect().Value(instance, property.GetValue(instance)).Result.Should().BeTrue();
    }
  }
}