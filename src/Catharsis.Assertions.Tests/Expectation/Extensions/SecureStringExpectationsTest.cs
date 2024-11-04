using System.Security;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="SecureStringExpectations"/>.</para>
/// </summary>
public sealed class SecureStringExpectationsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="SecureStringExpectations.Length(IExpectation{SecureString}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => SecureStringExpectations.Length(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((SecureString) null).Expect().Length(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, new SecureString(), 0);
      Validate(false, new SecureString(), int.MinValue);
      Validate(false, new SecureString(), int.MaxValue);
    }

    return;

    static void Validate(bool result, SecureString secure, int length)
    {
      using (secure)
      {
        secure.Expect().Length(length).Should().BeOfType<Expectation<SecureString>>().Which.Result.Should().Be(result);
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SecureStringExpectations.Empty(IExpectation{SecureString})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => SecureStringExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((SecureString) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, new SecureString());
      Validate(false, new SecureString().With(char.MinValue));
    }

    return;

    static void Validate(bool result, SecureString secure)
    {
      using (secure)
      {
        secure.Expect().Empty().Should().BeOfType<Expectation<SecureString>>().Which.Result.Should().Be(result);
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SecureStringExpectations.ReadOnly(IExpectation{SecureString})"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => SecureStringExpectations.ReadOnly(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
      AssertionExtensions.Should(() => ((SecureString) null).Expect().ReadOnly()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

      Validate(true, new SecureString().AsReadOnly());
      Validate(false, new SecureString());
    }

    return;

    static void Validate(bool result, SecureString secure)
    {
      using (secure)
      {
        secure.Expect().ReadOnly().Should().BeOfType<Expectation<SecureString>>().Which.Result.Should().Be(result);
      }
    }
  }
}