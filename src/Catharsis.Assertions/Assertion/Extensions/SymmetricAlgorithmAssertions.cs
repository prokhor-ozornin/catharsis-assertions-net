using System.Security.Cryptography;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of assertions for the <see cref="SymmetricAlgorithm"/> type.</para>
/// </summary>
/// <seealso cref="SymmetricAlgorithm"/>
public static class SymmetricAlgorithmAssertions
{
  /// <param name="assertion">Assertion to validate.</param>
  extension(IAssertion assertion)
  {
    /// <summary>
    ///   <para>Asserts that the given <see cref="SymmetricAlgorithm"/> has a specified block size of the cryptographic operations.</para>
    /// </summary>
    /// <param name="algorithm">Cryptographic algorithm to inspect.</param>
    /// <param name="size">Asserted block size in bits.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="algorithm"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion BlockSize(SymmetricAlgorithm algorithm, int size, string error = null) => algorithm is not null ? assertion.True(algorithm.BlockSize == size, error) : throw new ArgumentNullException(nameof(algorithm));

    /// <summary>
    ///   <para>Asserts that the given <see cref="SymmetricAlgorithm"/> has a specified size of the secret key.</para>
    /// </summary>
    /// <param name="algorithm">Cryptographic algorithm to inspect.</param>
    /// <param name="size">Asserted key size in bits.</param>
    /// <param name="error">Error message for a failed <paramref name="assertion"/>.</param>
    /// <returns>Back self-reference to the given <paramref name="assertion"/>.</returns>
    /// <exception cref="ArgumentNullException">If either <paramref name="assertion"/> or <paramref name="algorithm"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">If the given <paramref name="assertion"/> is invalid.</exception>
    public IAssertion KeySize(SymmetricAlgorithm algorithm, int size, string error = null) => algorithm is not null ? assertion.True(algorithm.KeySize == size, error) : throw new ArgumentNullException(nameof(algorithm));
  }
}