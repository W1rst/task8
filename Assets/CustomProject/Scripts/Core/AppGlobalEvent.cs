
using System;

namespace CustomProject
{
    public abstract class AppGlobalEvent<T>
    {
        #region Public Properties

        public string Name { get; private set; }

        #endregion


        #region Events

        private event Action<T> Callbacks;

        #endregion


        #region Construcotrs/Destructor

        public AppGlobalEvent()
        {
            Name = this.GetType().Name;
        }

        ~AppGlobalEvent()
        {
            Callbacks = null;
        }

        #endregion


        #region Public Methods

        public void Invoke(T data)
        {
            Callbacks?.Invoke(data);
        }

        public void Subscribe(Action<T> a)
        {
            Callbacks += a;
        }

        public void Unsubscribe(Action<T> a)
        {
            Callbacks -= a;
        }

        #endregion

    }

    public abstract class AppGlobalEvent<T, Y>
    {
        #region Public Properties

        public string Name { get; private set; }

        #endregion

        #region Events

        private event Action<T, Y> Callbacks;

        #endregion

        #region Construcotrs/Destructor

        public AppGlobalEvent()
        {
            Name = this.GetType().Name;
        }

        ~AppGlobalEvent()
        {
            Callbacks = null;
        }

        #endregion

        #region Public Methods

        public void Invoke(T data, Y secondData)
        {
            Callbacks?.Invoke(data, secondData);
        }

        public void Subscribe(Action<T, Y> a)
        {
            Callbacks += a;
        }

        public void Unsubscribe(Action<T, Y> a)
        {
            Callbacks -= a;
        }

        #endregion
    }

    public abstract class AppGlobalEvent
    {
        #region Public Properties

        public string Name { get; private set; }

        #endregion


        #region Events

        private event Action Callbacks;

        #endregion


        #region Construcotrs/Destructor

        public AppGlobalEvent()
        {
            Name = this.GetType().Name;
        }

        ~AppGlobalEvent()
        {
            Callbacks = null;
        }

        #endregion


        #region Public Methods

        public void Invoke()
        {
            Callbacks?.Invoke();
        }

        public void Subscribe(Action a)
        {
            Callbacks += a;
        }

        public void Unsubscribe(Action a)
        {
            Callbacks -= a;
        }

        #endregion
    }
}