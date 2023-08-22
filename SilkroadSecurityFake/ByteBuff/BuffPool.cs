using System.Collections.Concurrent;

namespace SilkroadSecurityFake.ByteBuff;

public static class BuffPool
{
    private static readonly ConcurrentBag<Buff> Pool1K = new ConcurrentBag<Buff>();
    private static readonly ConcurrentBag<Buff> Pool2K = new ConcurrentBag<Buff>();
    private static readonly ConcurrentBag<Buff> Pool4K = new ConcurrentBag<Buff>();
    private static readonly ConcurrentBag<Buff> Pool8K = new ConcurrentBag<Buff>();
    private static readonly ConcurrentBag<Buff> Pool16K = new ConcurrentBag<Buff>();
    private static readonly ConcurrentBag<Buff> Pool32K = new ConcurrentBag<Buff>();
    private const int MaximumPoolSize = 50;

    /// <summary>
    /// Initialize the pool with a certain number of Packet objects.
    /// </summary>
    static BuffPool()
    {
        for (var i = 0; i < MaximumPoolSize; i++)
        {
            Pool1K.Add(new Buff(BuffSize.Buff1K));
            Pool2K.Add(new Buff(BuffSize.Buff2K));
            Pool4K.Add(new Buff(BuffSize.Buff4K));
            Pool8K.Add(new Buff(BuffSize.Buff8K));
            Pool16K.Add(new Buff(BuffSize.Buff16K));
            Pool32K.Add(new Buff(BuffSize.Buff2K));
        }
    }

    /// <summary>
    /// Rent a Buff object from the pool or create a new one if the pool is empty.
    /// </summary>
    /// <returns></returns>
    public static Buff Rent(BuffSize size)
    {
        var pool = GetPool(size);

        if (pool.TryTake(out var buff))
        {
            return buff;
        }

        Console.WriteLine($"BuffPool ({size}) Empty, creating new one");
        return new Buff(size);
    }

    private static ConcurrentBag<Buff> GetPool(BuffSize size)
    {
        return size switch
        {
            BuffSize.Buff1K => Pool1K,
            BuffSize.Buff2K => Pool2K,
            BuffSize.Buff4K => Pool4K,
            BuffSize.Buff8K => Pool8K,
            BuffSize.Buff16K => Pool16K,
            BuffSize.Buff32K => Pool32K,
            _ => throw new ArgumentOutOfRangeException(nameof(size), size, null)
        };
    }

    /// <summary>
    /// Return a Packet object to the pool. Discard the packet if the pool's size is above or equal to the maximum limit.
    /// </summary>
    /// <param name="buff"></param>
    public static void Return(Buff buff)
    {
        if (buff == null)
        {
            throw new ArgumentNullException(nameof(buff));
        }
        
        buff.Reset();
        var pool = GetPool(buff.Size);
        pool.Add(buff);
    }
}