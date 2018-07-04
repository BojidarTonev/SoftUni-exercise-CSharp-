using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Lake : IEnumerable<int>
{
    private readonly List<int> stones;

    public Lake(int[] numbers)
    {
        this.stones = new List<int>(numbers);
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < stones.Count; i+=2)
        {
            yield return stones[i];
        }

        if (stones.Count % 2 ==0)
        {
            for (int i = stones.Count -1; i >= 1; i-=2)
            {
                yield return stones[i];
            }
        }
        else
        {
            for (int i = stones.Count - 2; i >= 1; i -= 2)
            {
                yield return stones[i];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

