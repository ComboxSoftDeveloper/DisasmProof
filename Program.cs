using System.Runtime.CompilerServices;

namespace DisasmProof;

internal static class Program
{
    private static void Main()
    {
        int[] array = Enumerable.Range(0, 512).ToArray();

        // Гоняем метод много раз, чтобы он прошел все ярусы компиляции:
        // tier0 -> tier0 с PGO-инструментацией -> tier1 (финальный оптимизированный код).
        long total = 0;
        for (int i = 0; i < 200_000; i++)
        {
            total += SumOverInterface(array);
        }

        Console.WriteLine(total);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int SumOverInterface(IEnumerable<int> values)
    {
        int sum = 0;
        foreach (int i in values)
        {
            sum += i;
        }

        return sum;
    }
}
