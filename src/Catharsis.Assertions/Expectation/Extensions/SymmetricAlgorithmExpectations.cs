using System.Security.Cryptography;

namespace Catharsis.Assertions;

/// <summary>
///   <para>A set of expectations for the <see cref="SymmetricAlgorithm"/> type.</para>
/// </summary>
/// <seealso cref="SymmetricAlgorithm"/>
public static class SymmetricAlgorithmExpectations
{
  /// <param name="expectation">Expectation to be fulfilled.</param>
  extension(IExpectation<SymmetricAlgorithm> expectation)
  {
    /// <summary>
    ///   <para>Expects that the given <see cref="SymmetricAlgorithm"/> has a specified block size of the cryptographic operations.</para>
    /// </summary>
    /// <param name="size">Expected block size in bits.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<SymmetricAlgorithm> BlockSize(int size) => expectation.HaveSubject().And().Expected(algorithm => algorithm.BlockSize == size);

    /// <summary>
    ///   <para>Expects that the given <see cref="SymmetricAlgorithm"/> has a specified size of the secret key.</para>
    /// </summary>
    /// <param name="size">Expected key size in bits.</param>
    /// <returns>Back self-reference to the given <paramref name="expectation"/>.</returns>
    /// <exception cref="ArgumentNullException">If the <paramref name="expectation"/> is either a <see langword="null"/> or has an undefined subject.</exception>
    public IExpectation<SymmetricAlgorithm> KeySize(int size) => expectation.HaveSubject().And().Expected(algorithm => algorithm.KeySize == size);
  }
}