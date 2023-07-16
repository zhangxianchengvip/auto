using Auto.Core.Lock;
using Microsoft.AspNetCore.Mvc;

namespace Auto.Controllers;

[ApiController]
[Route("[controller]")]
public class LockController
{
    private int _data = 50;

    [HttpGet]
    public virtual Task<bool> Run()
    {
        for (int i = 0; i < 10; i++)
        {
            Task.Run(Data);
        }

        return Task.FromResult(true);
    }

    [AutoLock]
    protected virtual void Data()
    {
        Console.WriteLine(_data);
        _data++;
    }
}