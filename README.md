# FunnyInsults.cs
Mobile-API for [Funny Insults](https://play.google.com/store/apps/details?id=com.funnylabz.funnyInsults) an application where you can share your own insults to other people by adding them in the application

## Example
```bash
using System;
using FunnyInsultsApi;
using System.Threading.Tasks;

namespace Application
{
    internal class Program
    {
        static async Task Main()
        {
            var api = new FunnyInsults();
            string contents = await api.getContents();
            Console.WriteLine(contents);
        }
    }
}
```
