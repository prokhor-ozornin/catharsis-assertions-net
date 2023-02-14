namespace Catharsis.Assertions;

/// <summary>
///   <para></para>
/// </summary>
/// <seealso cref="Task"/>
/// <seealso cref="ValueTask"/>
public static class TaskProtections
{
  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="task"></param>
  /// <param name="status"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <seealso cref="Status{T}(IProtection, Task{T}, TaskStatus, string)"/>
  public static Task Status(this IProtection protection, Task task, TaskStatus status, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (task is null) throw new ArgumentNullException(nameof(task));

    protection.Truth(task.Status == status, error);
    
    return task;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection">Protection to perform.</param>
  /// <param name="task"></param>
  /// <param name="status"></param>
  /// <param name="error">Error description phrase for a failed <paramref name="protection"/>.</param>
  /// <returns>Back reference to the given <paramref name="protection"/>.</returns>
  /// <exception cref="ArgumentNullException"></exception>
  /// <see cref="Status(IProtection, Task, TaskStatus, string)"/>
  public static Task<T> Status<T>(this IProtection protection, Task<T> task, TaskStatus status, string error = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (task is null) throw new ArgumentNullException(nameof(task));

    protection.Truth(task.Status == status, error);

    return task;
  }
}