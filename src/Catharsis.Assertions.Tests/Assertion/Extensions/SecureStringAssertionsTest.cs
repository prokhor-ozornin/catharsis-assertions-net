using System.Security;
using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="SecureStringAssertions"/>.</para>
/// </summary>
public sealed class SecureStringAssertionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="SecureStringAssertions.Length(IAssertion, SecureString, int, string)"/> method.</para> </summary>
  [Fact]
  public void Length_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => SecureStringAssertions.Length(Assert.To, null, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("secure");

      Validate(true, new SecureString(), 0);
      Validate(false, new SecureString(), int.MinValue);
      Validate(false, new SecureString(), int.MaxValue);
    }

    return;

    static void Validate(bool result, SecureString secure, int length)
    {
      using (secure)
      {
        AssertionExtensions.Should(() => SecureStringAssertions.Length(null, secure, 0)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

        if (result)
        {
          Assert.To.Length(secure, length).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Length(secure, length, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SecureStringAssertions.Empty(IAssertion, SecureString, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => SecureStringAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("secure");

      Validate(true, new SecureString());
      Validate(false, new SecureString().With(char.MinValue));
    }

    return;

    static void Validate(bool result, SecureString secure)
    {
      using (secure)
      {
        AssertionExtensions.Should(() => SecureStringAssertions.Empty(null, secure)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

        if (result)
        {
          Assert.To.Empty(secure).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.Empty(secure, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SecureStringAssertions.ReadOnly(IAssertion, SecureString, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => SecureStringAssertions.ReadOnly(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("secure");

      Validate(true, new SecureString().AsReadOnly());
      Validate(false, new SecureString());
    }

    return;

    static void Validate(bool result, SecureString secure)
    {
      using (secure)
      {
        AssertionExtensions.Should(() => SecureStringAssertions.ReadOnly(null, secure)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");

        if (result)
        {
          Assert.To.ReadOnly(secure).Should().BeOfType<Assertion>().And.BeSameAs(Assert.To);
        }
        else
        {
          AssertionExtensions.Should(() => Assert.To.ReadOnly(secure, "error")).ThrowExactly<InvalidOperationException>().WithMessage("error");
        }
      }
    }
  }
}