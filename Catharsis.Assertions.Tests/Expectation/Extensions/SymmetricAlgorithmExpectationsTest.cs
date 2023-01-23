﻿using System.Security.Cryptography;
using FluentAssertions;
using Xunit;

namespace Catharsis.Assertions.Tests.Expectation.Extensions;

/// <summary>
///   <para>Tests set for class <see cref="SymmetricAlgorithmExpectations"/>.</para>
/// </summary>
public sealed class SymmetricAlgorithmExpectationsTest : UnitTest
{
  private SymmetricAlgorithm Algorithm { get; } = Aes.Create();

  /// <summary>
  ///   <para>Performs testing of <see cref="SymmetricAlgorithmExpectations.BlockSize(IExpectation{SymmetricAlgorithm}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void BlockSize_Method()
  {
    AssertionExtensions.Should(() => SymmetricAlgorithmExpectations.BlockSize(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((SymmetricAlgorithm) null).Expect().BlockSize(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="SymmetricAlgorithmExpectations.KeySize(IExpectation{SymmetricAlgorithm}, int)"/> method.</para>
  /// </summary>
  [Fact]
  public void KeySize_Method()
  {
    AssertionExtensions.Should(() => SymmetricAlgorithmExpectations.KeySize(null, default)).ThrowExactly<ArgumentNullException>().WithParameterName("expectation");
    AssertionExtensions.Should(() => ((SymmetricAlgorithm) null).Expect().KeySize(default)).ThrowExactly<ArgumentNullException>().WithParameterName("subject");

    throw new NotImplementedException();
  }

  public override void Dispose()
  {
    base.Dispose();
    Algorithm.Dispose();
  }
}