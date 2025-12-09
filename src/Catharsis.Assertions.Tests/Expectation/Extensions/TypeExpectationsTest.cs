using System.Reflection;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TypeExpectations"/>.</para>
/// </summary>
/// <seealso cref="TypeExpectations"/>
public sealed class TypeExpectationsTest : Test
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

      Test(true, typeof(Stream));
      Test(false, typeof(object));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Test(type.IsAbstract && !type.IsSealed, type));
    }

    return;

    static void Test(bool result, Type type) => type.Expect().Abstract().Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
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

      Test(true, typeof(FileInfo));
      Test(false, typeof(object));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Test(type.IsSealed && !type.IsAbstract, type));
    }

    return;

    static void Test(bool result, Type type) => type.Expect().Sealed().Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
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

      Test(true, typeof(Enumerable));
      Test(false, typeof(object));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Test(type.IsAbstract && type.IsSealed, type));
    }

    return;

    static void Test(bool result, Type type) => type.Expect().Static().Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
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

      Test(true, typeof(object));
      Test(false, typeof(Assertion));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Test(type.IsPublic && type.IsVisible, type));
    }

    return;

    static void Test(bool result, Type type) => type.Expect().Public().Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
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

      Test(true, typeof(Assertion));
      Test(false, typeof(object));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Test(type.IsNotPublic && !type.IsVisible, type));
    }

    return;

    static void Test(bool result, Type type) => type.Expect().Internal().Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
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

      Test(true, typeof(string), typeof(object));
      Test(false, typeof(object), typeof(object));
      Test(false, typeof(object), typeof(string));
      Test(false, typeof(string), typeof(IEnumerable<char>));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Test(true, type, typeof(object)));

      static void Test(bool result, Type type, Type superclass) => type.Expect().Subclass(superclass).Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.Subclass<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");

      Test<object>(false, typeof(object));
      Test<string>(false, typeof(object));
      Test<object>(true, typeof(string));
      Test<IEnumerable<char>>(false, typeof(string));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type => Test<object>(true, type));

      static void Test<T>(bool result, Type type) => type.Expect().Subclass<T>().Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
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

      Test(true, typeof(object), typeof(object));
      Test(true, typeof(string), typeof(string));
      Test(true, typeof(object), typeof(string));
      Test(true, typeof(IEnumerable<char>), typeof(string));
      Test(false, typeof(string), typeof(object));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type =>
      {
        Test(true, type, type);
        Test(true, typeof(object), type);
      });

      static void Test(bool result, Type type, Type from) => type.Expect().AssignableFrom(from).Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.AssignableFrom<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Type) null).Expect().AssignableFrom<object>()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test<object>(true, typeof(object));
      Test<string>(true, typeof(string));
      Test<string>(true, typeof(object));
      Test<string>(true, typeof(IEnumerable<char>));
      Test<object>(false, typeof(string));

      static void Test<T>(bool result, Type type) => type.Expect().AssignableFrom<T>().Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
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

      Test(true, typeof(object), typeof(object));
      Test(true, typeof(string), typeof(object));
      Test(true, typeof(string), typeof(IEnumerable<char>));
      Test(false, typeof(object), typeof(string));

      Assembly.GetExecutingAssembly().DefinedTypes.ForEach(type =>
      {
        Test(true, type, type);
        Test(true, type, typeof(object));
      });

      static void Test(bool result, Type type, Type to) => type.Expect().AssignableTo(to).Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
    }

    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => TypeExpectations.AssignableTo<object>(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((Type) null).Expect().AssignableTo<object>()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Test<object>(true, typeof(object));
      Test<object>(true, typeof(string));
      Test<IEnumerable<char>>(true, typeof(string));
      Test<string>(false, typeof(object));

      static void Test<T>(bool result, Type type) => type.Expect().AssignableTo<T>().Should().BeOfType<Expectation<Type>>().Which.Result.Should().Be(result);
    }
  }
}