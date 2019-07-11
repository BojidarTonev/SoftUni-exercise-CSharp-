using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;


public class Tuple<T1, T2, T3>
{
    private T1 firstItem;
    private T2 secondItem;
    private T3 thirdItem;

    public Tuple(T1 first, T2 second, T3 third)
    {
        this.firstItem = first;
        this.secondItem = second;
        this.thirdItem = third;
    }

    public T3 ThirdItem
    {
        get { return thirdItem; }
        private set { thirdItem = value; }
    }

    public T2 SecondItem
    {
        get { return secondItem; }
        protected set { secondItem = value; }
    }

    public T1 FirstItem
    {
        get { return firstItem; }
        protected set { firstItem = value; }
    }

    public override string ToString()
    {
        return $"{firstItem} -> {secondItem} -> {thirdItem}";
    }
}

