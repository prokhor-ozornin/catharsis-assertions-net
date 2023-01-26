using System.Security;
using Catharsis.Extensions;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests;

/// <summary>
///   <para>Tests set for class <see cref="SecureStringExpectations"/>.</para>
/// </summary>
public sealed class SecureStringExpectationsTest : UnitTest
{
  private SecureString EmptySecureString { get; } = new();
  
  private SecureString RandomSecureString { get; } = Randomizer.SecureString(byte.MaxValue);

  /// <summary>
  ///   <para>Performs testing of <see cref="SecureStringExpectations.Length(IExpectation{SecureString}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void Length_Method()
  {
    AssertionExtensions.Should(() => SecureStringExpectations.Length(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((SecureString) null).Expect().Length(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    EmptySecureString.Expect().Length(int.MinValue).Result.Should().BeFalse();
    EmptySecureString.Expect().Length(int.MaxValue).Result.Should().BeFalse();
    EmptySecureString.Expect().Length(EmptySecureString.Length).Result.Should().BeTrue();

    RandomSecureString.Expect().Length(0).Result.Should().BeFalse();
    RandomSecureString.Expect().Length(RandomSecureString.Length).Result.Should().BeTrue();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SecureStringExpectations.Empty(IExpectation{SecureString})"/> method.</para>
  /// </summary>
  [Fact]
  public void Empty_Method()
  {
    AssertionExtensions.Should(() => SecureStringExpectations.Empty(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((SecureString) null).Expect().Empty()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    EmptySecureString.Expect().Empty().Result.Should().BeTrue();
    RandomSecureString.Expect().Empty().Result.Should().BeFalse();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SecureStringExpectations.ReadOnly(IExpectation{SecureString})"/> method.</para>
  /// </summary>
  [Fact]
  public void ReadOnly_Method()
  {
    AssertionExtensions.Should(() => SecureStringExpectations.ReadOnly(null)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((SecureString) null).Expect().ReadOnly()).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    EmptySecureString.Expect().ReadOnly().Result.Should().BeFalse();
    EmptySecureString.AsReadOnly().Expect().ReadOnly().Result.Should().BeTrue();
  }

  public override void Dispose()
  {
    base.Dispose();
    
    EmptySecureString.Dispose();
    RandomSecureString.Dispose();
  }
}