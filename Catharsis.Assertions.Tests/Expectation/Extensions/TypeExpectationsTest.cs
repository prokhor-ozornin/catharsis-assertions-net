using System.Reflection;
using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using Catharsis.Extensions;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TypeExpectations"/>.</para>
/// </summary>
public sealed class TypeExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TypeExpectations.Abstract(IExpectation{Type})"/> method.</para>
  /// </summary>
  [Fact]
  public void Abstract_Method()
  {
    AssertionExtensions.Should(() => TypeExpectations.Abstract(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Type) null).Expect().Abstract()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    typeof(object).Expect().Abstract().Result.Should().BeFalse();
    typeof(Stream).Expect().Abstract().Result.Should().BeTrue();

    Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => type.Expect().Abstract().Result.Should().Be(type.IsAbstract));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TypeExpectations.Sealed(IExpectation{Type})"/> method.</para>
  /// </summary>
  [Fact]
  public void Sealed_Method()
  {
    AssertionExtensions.Should(() => TypeExpectations.Sealed(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Type) null).Expect().Sealed()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    typeof(object).Expect().Sealed().Result.Should().BeFalse();
    typeof(FileInfo).Expect().Sealed().Result.Should().BeTrue();

    Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => type.Expect().Sealed().Result.Should().Be(type.IsSealed));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TypeExpectations.Static(IExpectation{Type})"/> method.</para>
  /// </summary>
  [Fact]
  public void Static_Method()
  {
    AssertionExtensions.Should(() => TypeExpectations.Static(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Type) null).Expect().Static()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    typeof(object).Expect().Static().Result.Should().BeFalse();
    typeof(Enumerable).Expect().Static().Result.Should().BeTrue();

    Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => type.Expect().Static().Result.Should().Be(type.IsAbstract && type.IsSealed));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TypeExpectations.Public(IExpectation{Type})"/> method.</para>
  /// </summary>
  [Fact]
  public void Public_Method()
  {
    AssertionExtensions.Should(() => TypeExpectations.Public(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Type) null).Expect().Public()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    typeof(object).Expect().Public().Result.Should().BeTrue();
    typeof(Assertion).Expect().Public().Result.Should().BeFalse();

    Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => type.Expect().Public().Result.Should().Be(type.IsPublic && type.IsVisible));
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TypeExpectations.Internal(IExpectation{Type})"/> method.</para>
  /// </summary>
  [Fact]
  public void Internal_Method()
  {
    AssertionExtensions.Should(() => TypeExpectations.Internal(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((Type) null).Expect().Internal()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    typeof(object).Expect().Internal().Result.Should().BeFalse();
    typeof(Assertion).Expect().Internal().Result.Should().BeTrue();

    Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => type.Expect().Internal().Result.Should().Be(type.IsNotPublic && !type.IsVisible));
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TypeExpectations.Subclass(IExpectation{Type}, Type)"/></description></item>
  ///     <item><description><see cref="TypeExpectations.Subclass{T}(IExpectation{Type})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Subclass_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.Subclass(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Type) null).Expect().Subclass(null)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      typeof(object).Expect().Subclass(typeof(object)).Result.Should().BeFalse();
      typeof(object).Expect().Subclass(typeof(string)).Result.Should().BeFalse();
      typeof(string).Expect().Subclass(typeof(object)).Result.Should().BeTrue();
      typeof(string).Expect().Subclass(typeof(IEnumerable<char>)).Result.Should().BeFalse();

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => type.Expect().Subclass(typeof(object)).Result.Should().BeTrue());
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.Subclass<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      typeof(object).Expect().Subclass<object>().Result.Should().BeFalse();
      typeof(object).Expect().Subclass<string>().Result.Should().BeFalse();
      typeof(string).Expect().Subclass<object>().Result.Should().BeTrue();
      typeof(string).Expect().Subclass<IEnumerable<char>>().Result.Should().BeFalse();

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => type.Expect().Subclass<object>().Result.Should().BeTrue());
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TypeExpectations.AssignableFrom(IExpectation{Type}, Type)"/></description></item>
  ///     <item><description><see cref="TypeExpectations.AssignableFrom{T}(IExpectation{Type})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void AssignableFrom_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.AssignableFrom(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Type) null).Expect().AssignableFrom(typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      typeof(object).Expect().AssignableFrom(typeof(object)).Result.Should().BeTrue();
      typeof(string).Expect().AssignableFrom(typeof(object)).Result.Should().BeFalse();
      typeof(object).Expect().AssignableFrom(typeof(string)).Result.Should().BeTrue();
      typeof(IEnumerable<char>).Expect().AssignableFrom(typeof(string)).Result.Should().BeTrue();

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type =>
      {
        type.Expect().AssignableFrom(type).Result.Should().BeTrue();
        typeof(object).Expect().AssignableFrom(type).Result.Should().BeTrue();
      });
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.AssignableFrom<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Type) null).Expect().AssignableFrom<object>()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      typeof(object).Expect().AssignableFrom<object>().Result.Should().BeTrue();
      typeof(string).Expect().AssignableFrom<object>().Result.Should().BeFalse();
      typeof(object).Expect().AssignableFrom<string>().Result.Should().BeTrue();
      typeof(IEnumerable<char>).Expect().AssignableFrom<string>().Result.Should().BeTrue();
    }
  }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TypeExpectations.AssignableTo(IExpectation{Type}, Type)"/></description></item>
  ///     <item><description><see cref="TypeExpectations.AssignableTo{T}(IExpectation{Type})"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void AssignableTo_Methods()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.AssignableTo(null, typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Type) null).Expect().AssignableTo(typeof(object))).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      typeof(object).Expect().AssignableTo(typeof(object)).Result.Should().BeTrue();
      typeof(object).Expect().AssignableTo(typeof(string)).Result.Should().BeFalse();
      typeof(string).Expect().AssignableTo(typeof(object)).Result.Should().BeTrue();
      typeof(string).Expect().AssignableTo(typeof(IEnumerable<char>)).Result.Should().BeTrue();

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type =>
      {
        type.Expect().AssignableTo(type).Result.Should().BeTrue();
        type.Expect().AssignableTo(typeof(object)).Result.Should().BeTrue();
      });
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.AssignableTo<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Type) null).Expect().AssignableTo<object>()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      typeof(object).Expect().AssignableTo<object>().Result.Should().BeTrue();
      typeof(object).Expect().AssignableTo<string>().Result.Should().BeFalse();
      typeof(string).Expect().AssignableTo<object>().Result.Should().BeTrue();
      typeof(string).Expect().AssignableTo<IEnumerable<char>>().Result.Should().BeTrue();

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type =>
      {
        type.Expect().AssignableTo<object>().Result.Should().BeTrue();
      });
    }
  }
}