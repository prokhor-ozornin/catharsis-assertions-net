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
  /// <param name="protection"></param>
  /// <param name="task"></param>
  /// <param name="status"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static Task Status(this IProtection protection, Task task, TaskStatus status, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (task is null) throw new ArgumentNullException(nameof(task));

    protection.Truth(task.Status == status, message);
    
    return task;
  }

  /// <summary>
  ///   <para></para>
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="protection"></param>
  /// <param name="task"></param>
  /// <param name="status"></param>
  /// <param name="message"></param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException"></exception>
  public static Task<T> Status<T>(this IProtection protection, Task<T> task, TaskStatus status, string message = null)
  {
    if (protection is null) throw new ArgumentNullException(nameof(protection));
    if (task is null) throw new ArgumentNullException(nameof(task));

    protection.Truth(task.Status == status, message);

    return task;
  }
}