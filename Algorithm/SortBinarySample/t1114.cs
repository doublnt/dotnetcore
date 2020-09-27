using System;

public class Foo
{
    public Foo()
    {

    }

    private bool _isFirstEnd = false;
    private bool _isSecondEnd = false;

    public void First(Action printFirst)
    {

        // printFirst() outputs "first". Do not change or remove this line.
        printFirst();
        _isFirstEnd = true;
    }

    public void Second(Action printSecond)
    {

        // printSecond() outputs "second". Do not change or remove this line.

        while (!_isFirstEnd)
        {

        }
        printSecond();
        _isSecondEnd = true;
    }

    public void Third(Action printThird)
    {

        // printThird() outputs "third". Do not change or remove this line.
        while (!_isSecondEnd)
        {

        }

        printThird();
    }
}
