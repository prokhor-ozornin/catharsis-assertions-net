using System.Security;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="SecureStringAssertions"/>.</para>
/// </summary>
public sealed class SecureStringAssertionsTest : UnitTest
{
  private SecureString Secure { get; } = new();

  /// <summary>
  ///   <para>Performs testing of <see cref="SecureStringAssertions.Length(IAssertion, System.Security.SecureString, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    AssertionExtensions.Should(() => SecureStringAssertions.Length(null, Secure, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => SecureStringAssertions.Length(Assert.To, null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("secure");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SecureStringAssertions.Empty(IAssertion, System.Security.SecureString, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => SecureStringAssertions.Empty(null, Secure)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => SecureStringAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("secure");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SecureStringAssertions.ReadOnly(IAssertion, System.Security.SecureString, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    AssertionExtensions.Should(() => SecureStringAssertions.ReadOnly(null, Secure)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => SecureStringAssertions.ReadOnly(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("secure");

    throw new NotImplementedException();
  }

  public override void Dispose()
  {
    base.Dispose();
    Secure.Dispose();
  }
}