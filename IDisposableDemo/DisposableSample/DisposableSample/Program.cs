// https://stackoverflow.com/questions/19196889/cancelling-tasks-in-the-dispose-method
using DisposableSample;

//using (new MyClass())
//{
//    await Task.Delay(1000);
//}

new MyClass();
await Task.Delay(1000);

Console.WriteLine("Done");
