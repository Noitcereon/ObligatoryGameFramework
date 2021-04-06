using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DTurnBasedGameFramework.Interfaces.ObserverPattern
{
    /// <summary>
    /// Part of the observer pattern.
    /// Implemented by objects that want to observe an ISubject.
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        /// Updates the observer according to the new data received from an ISubject.
        /// </summary>
        /// <param name="subject"></param>
        void Update(ISubject subject);
    }
}
