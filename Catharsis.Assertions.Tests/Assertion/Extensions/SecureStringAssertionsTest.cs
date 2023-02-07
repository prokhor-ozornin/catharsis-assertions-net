using System.Security;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="SecureStringAssertions"/>.</para>
/// </summary>
public sealed class SecureStringAssertionsTest : UnitTest
{
  private SecureString EmptySecureString { get; } = new SecureString().AsReadOnly();
  private SecureString RandomSecureString { get; } = Randomizer.SecureString(byte.MaxValue);

  /// <summary>
  ///   <para>Performs testing of <see cref="SecureStringAssertions.Length(IAssertion, System.Security.SecureString, int, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    AssertionExtensions.Should(() => SecureStringAssertions.Length(null, EmptySecureString, default)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => SecureStringAssertions.Length(Assert.To, null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("secure");

    AssertionExtensions.Should(() => Assert.To.Length(RandomSecureString, int.MinValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    AssertionExtensions.Should(() => Assert.To.Length(RandomSecureString, int.MaxValue, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.Length(RandomSecureString, RandomSecureString.Length).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SecureStringAssertions.Empty(IAssertion, System.Security.SecureString, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => SecureStringAssertions.Empty(null, EmptySecureString)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => SecureStringAssertions.Empty(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("secure");

    Assert.To.Empty(EmptySecureString).Should().NotBeNull().And.BeSameAs(Assert.To);
    AssertionExtensions.Should(() => Assert.To.Empty(RandomSecureString, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SecureStringAssertions.ReadOnly(IAssertion, System.Security.SecureString, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    AssertionExtensions.Should(() => SecureStringAssertions.ReadOnly(null, EmptySecureString)).ThrowExactly<ArgumentNullException>().WithParameterName("assertion");
    AssertionExtensions.Should(() => SecureStringAssertions.ReadOnly(Assert.To, null)).ThrowExactly<ArgumentNullException>().WithParameterName("secure");

    AssertionExtensions.Should(() => Assert.To.ReadOnly(RandomSecureString, "error")).ThrowExactly<ArgumentException>().WithMessage("error");
    Assert.To.ReadOnly(RandomSecureString.AsReadOnly()).Should().NotBeNull().And.BeSameAs(Assert.To);
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  public override void Dispose()
  {
    base.Dispose();
    EmptySecureString.Dispose();
    RandomSecureString.Dispose();
  }
}