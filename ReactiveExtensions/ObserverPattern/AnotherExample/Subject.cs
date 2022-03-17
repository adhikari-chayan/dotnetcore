namespace AnotherExample
{
    internal interface ISubject
    {
        void UpdateUserAge(int age);
    }

    internal class Subject : IObservable<User>, IDisposable, ISubject
    {
        private readonly User _user;
        private IList<IObserver<User>> _observers = new List<IObserver<User>>();

        public Subject(string name, int age)
        {
            _user = new User { Age = age, Name = name };
        }

        public void Dispose()
        {
            _observers.Clear();
        }

        public IDisposable Subscribe(IObserver<User> observer)
        {
            _observers.Add(observer);
            observer.OnNext(_user);

            return this;
        }

        public void UpdateUserAge(int age)
        {
            _user.Age = age;
            foreach (var observer in _observers)
            {
                observer.OnNext(_user);
            }
        }
    }
}
