using System.Reflection;
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
  ///   <para>Performs testing of <see cref="PropertyInfoExpectations.Readable(IExpectation{PropertyInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Readable_Method()
  {
    AssertionExtensions.Should(() => PropertyInfoExpectations.Readable(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((PropertyInfo) null).Expect().Readable()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    Assert.To.Readable(ReadOnlyPropertyInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Readable(WriteOnlyPropertyInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Readable(ReadWritePropertyInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoExpectations.WriteOnly(IExpectation{PropertyInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void WriteOnly_Method()
  {
    AssertionExtensions.Should(() => PropertyInfoExpectations.WriteOnly(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((PropertyInfo) null).Expect().WriteOnly()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    AssertionExtensions.Should(() => Assert.To.WriteOnly(ReadOnlyPropertyInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.WriteOnly(WriteOnlyPropertyInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.WriteOnly(ReadWritePropertyInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoExpectations.Writable(IExpectation{PropertyInfo})"/> method.</para>
  /// </summary>
  [Fact]
  public void Writable_Method()
  {
    AssertionExtensions.Should(() => PropertyInfoExpectations.Writable(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((PropertyInfo) null).Expect().Writable()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    AssertionExtensions.Should(() => Assert.To.Writable(ReadOnlyPropertyInfo, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
    Assert.To.Writable(WriteOnlyPropertyInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
    Assert.To.Writable(ReadWritePropertyInfo).Should().NotBeNull().And.BeSameAs(Assert.To);
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

      Validate(ReadOnlyPropertyInfo, this);
      Validate(ReadWritePropertyInfo, this);
      Validate(StaticPropertyInfo, null);
    }

    return;

    static void Validate(PropertyInfo property, object instance)
    {
      AssertionExtensions.Should(() => Assert.To.Value(property, instance, new object(), "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      Assert.To.Value(property, instance, property.GetValue(instance)).Should().NotBeNull().And.BeSameAs(Assert.To);
    }
  }
}