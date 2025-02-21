using System.Reflection;
using Catharsis.Commons;
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
  private string _field;
  private string WriteOnlyProperty
  {
    set => _field = value;
  }

  private string ReadOnlyProperty => nameof(ReadOnlyProperty);
  private string ReadWriteProperty { get; set; } = nameof(ReadWriteProperty);
  private static string StaticProperty { get; set; } = nameof(StaticProperty);

  private PropertyInfo ReadOnlyPropertyInfo => GetType().AnyProperty(nameof(ReadOnlyProperty));
  private PropertyInfo WriteOnlyPropertyInfo => GetType().AnyProperty(nameof(WriteOnlyProperty));
  private PropertyInfo ReadWritePropertyInfo => GetType().AnyProperty(nameof(ReadWriteProperty));
  private PropertyInfo StaticPropertyInfo => GetType().AnyProperty(nameof(StaticProperty));

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoAssertions.Readable(IAssertion, PropertyInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Readable_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => PropertyInfoAssertions.Readable(null, ReadWritePropertyInfo)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => PropertyInfoAssertions.Readable(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("property");

      Validate(true, ReadOnlyPropertyInfo);
      Validate(true, ReadWritePropertyInfo);
      Validate(false, WriteOnlyPropertyInfo);
    }

    return;

    static void Validate(bool result, PropertyInfo property)
    {
      if (result)
      {
        Assert.To.Readable(property).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Readable(property, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoAssertions.ReadOnly(IAssertion, PropertyInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => PropertyInfoAssertions.ReadOnly(null, ReadWritePropertyInfo)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => PropertyInfoAssertions.ReadOnly(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("property");

      Validate(true, ReadOnlyPropertyInfo);
      Validate(false, ReadWritePropertyInfo);
      Validate(false, WriteOnlyPropertyInfo);
    }

    return;

    static void Validate(bool result, PropertyInfo property)
    {
      if (result)
      {
        Assert.To.ReadOnly(property).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.ReadOnly(property, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoAssertions.Writable(IAssertion, PropertyInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Writable_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => PropertyInfoAssertions.Writable(null, ReadWritePropertyInfo)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => PropertyInfoAssertions.Writable(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("property");

      Validate(true, ReadWritePropertyInfo);
      Validate(true, WriteOnlyPropertyInfo);
      Validate(false, ReadOnlyPropertyInfo);
    }

    return;

    static void Validate(bool result, PropertyInfo property)
    {
      if (result)
      {
        Assert.To.Writable(property).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Writable(property, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="PropertyInfoAssertions.WriteOnly(IAssertion, PropertyInfo, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void WriteOnly_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => PropertyInfoAssertions.WriteOnly(null, ReadWritePropertyInfo)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
      AssertionExtensions.Should(() => PropertyInfoAssertions.WriteOnly(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("property");

      Validate(true, WriteOnlyPropertyInfo);
      Validate(false, ReadWritePropertyInfo);
      Validate(false, ReadOnlyPropertyInfo);
    }

    return;

    static void Validate(bool result, PropertyInfo property)
    {
      if (result)
      {
        Assert.To.WriteOnly(property).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.WriteOnly(property, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
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

      Validate(true, ReadOnlyPropertyInfo, this, ReadOnlyProperty);
      Validate(false, ReadOnlyPropertyInfo, this, null);
    }

    return;

    static void Validate(bool result, PropertyInfo property, object subject, object value)
    {
      if (result)
      {
        Assert.To.Value(property, subject, value).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
      }
      else
      {
        AssertionExtensions.Should(() => Assert.To.Value(property, subject, value, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
      }
    }
  }
}