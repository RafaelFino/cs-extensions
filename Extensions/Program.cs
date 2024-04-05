

using Extensions.utils;

using (var ctx = new Context("My function Xpto"))
{
    Console.WriteLine("Doing some work...");    
    Thread.Sleep(1000);
}

using (var ctx = new Context("My function Ypto"))
{
    Console.WriteLine("Doing other some work...");    
    Thread.Sleep(2000);
}