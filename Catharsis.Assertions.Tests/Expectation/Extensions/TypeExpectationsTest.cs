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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.Abstract(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Type) null).Expect().Abstract()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, typeof(Stream));
      Validate(false, typeof(object));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Validate(type.IsAbstract && !type.IsSealed, type));
    }

    return;

    static void Validate(bool result, Type type) => type.Expect().Abstract().Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TypeExpectations.Sealed(IExpectation{Type})"/> method.</para>
  /// </summary>
  [Fact]
  public void Sealed_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.Sealed(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Type) null).Expect().Sealed()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, typeof(FileInfo));
      Validate(false, typeof(object));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Validate(type.IsSealed && !type.IsAbstract, type));
    }

    return;

    static void Validate(bool result, Type type) => type.Expect().Sealed().Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TypeExpectations.Static(IExpectation{Type})"/> method.</para>
  /// </summary>
  [Fact]
  public void Static_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.Static(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Type) null).Expect().Static()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, typeof(Enumerable));
      Validate(false, typeof(object));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Validate(type.IsAbstract && type.IsSealed, type));
    }

    return;

    static void Validate(bool result, Type type) => type.Expect().Static().Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TypeExpectations.Public(IExpectation{Type})"/> method.</para>
  /// </summary>
  [Fact]
  public void Public_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.Public(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Type) null).Expect().Public()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, typeof(object));
      Validate(false, typeof(Assertion));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Validate(type.IsPublic && type.IsVisible, type));
    }

    return;

    static void Validate(bool result, Type type) => type.Expect().Public().Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TypeExpectations.Internal(IExpectation{Type})"/> method.</para>
  /// </summary>
  [Fact]
  public void Internal_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.Internal(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Type) null).Expect().Internal()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, typeof(Assertion));
      Validate(false, typeof(object));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Validate(type.IsNotPublic && !type.IsVisible, type));
    }

    return;

    static void Validate(bool result, Type type) => type.Expect().Internal().Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
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

      Validate(true, typeof(string), typeof(object));
      Validate(false, typeof(object), typeof(object));
      Validate(false, typeof(object), typeof(string));
      Validate(false, typeof(string), typeof(IEnumerable<char>));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Validate(true, type, typeof(object)));

      static void Validate(bool result, Type type, Type superclass) => type.Expect().Subclass(superclass).Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.Subclass<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      Validate<object>(false, typeof(object));
      Validate<string>(false, typeof(object));
      Validate<object>(true, typeof(string));
      Validate<IEnumerable<char>>(false, typeof(string));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Validate<object>(true, type));

      static void Validate<T>(bool result, Type type) => type.Expect().Subclass<T>().Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
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

      Validate(true, typeof(object), typeof(object));
      Validate(true, typeof(string), typeof(string));
      Validate(true, typeof(object), typeof(string));
      Validate(true, typeof(IEnumerable<char>), typeof(string));
      Validate(false, typeof(string), typeof(object));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type =>
      {
        Validate(true, type, type);
        Validate(true, typeof(object), type);
      });

      static void Validate(bool result, Type type, Type from) => type.Expect().AssignableFrom(from).Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.AssignableFrom<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Type) null).Expect().AssignableFrom<object>()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate<object>(true, typeof(object));
      Validate<string>(true, typeof(string));
      Validate<string>(true, typeof(object));
      Validate<string>(true, typeof(IEnumerable<char>));
      Validate<object>(false, typeof(string));

      static void Validate<T>(bool result, Type type) => type.Expect().AssignableFrom<T>().Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
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

      Validate(true, typeof(object), typeof(object));
      Validate(true, typeof(string), typeof(object));
      Validate(true, typeof(string), typeof(IEnumerable<char>));
      Validate(false, typeof(object), typeof(string));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type =>
      {
        Validate(true, type, type);
        Validate(true, type, typeof(object));
      });

      static void Validate(bool result, Type type, Type to) => type.Expect().AssignableTo(to).Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.AssignableTo<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Type) null).Expect().AssignableTo<object>()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate<object>(true, typeof(object));
      Validate<object>(true, typeof(string));
      Validate<IEnumerable<char>>(true, typeof(string));
      Validate<string>(false, typeof(object));

      static void Validate<T>(bool result, Type type) => type.Expect().AssignableTo<T>().Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
    }
  }
}