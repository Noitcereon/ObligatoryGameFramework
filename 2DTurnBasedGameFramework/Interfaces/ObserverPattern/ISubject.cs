namespace _2DTurnBasedGameFramework.Interfaces.ObserverPattern
{
    /// <summary>
    /// Part of the observer pattern.
    /// Implemented by classses that need to be observable by IObservers.
    /// </summary>
    public interface ISubject
    {
        /// <summary>
        /// Attaches/registers an observer, which wants to be notified of any changes.
        /// </summary>
        /// <param name="observer"></param>
        void Attach(IObserver observer);

        /// <summary>
        /// Notifies the observers that something has been changed.
        /// </summary>
        void Notify();
    }
}
