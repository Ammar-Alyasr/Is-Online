using System;
using System.Threading;

public class thread
{
    private Action ana;
    private object target_method;

    public thread(Action ana)
    {
        this.ana = ana;
    }

    public thread(object target_method)
    {
        this.target_method = target_method;
    }

    public static implicit operator Thread(thread v)
    {
        throw new NotImplementedException();
    }
}