using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;

namespace RxDemo
{
    class EvenNumberObservable : IObservable<int>
    {
        public IDisposable Subscribe(IObserver<int> observer)
        {
            Enumerable.Range(1, 100).Where(x => x % 2 == 0).ToList().ForEach(x =>
            {
                observer.OnNext(x);
            });

            return Disposable.Empty;
        }
    }
}
