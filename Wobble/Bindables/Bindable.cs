﻿using System;

namespace Wobble.Bindables
{
    /// <summary>
    ///     Generic class for values that you want to keep track of when they change.
    ///     This is usually used for configuration variables.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Bindable<T>
    {
        /// <summary>
        ///     Emitted when this value changes.
        /// </summary>
        internal EventHandler<BindableValueChangedEventArgs<T>> ValueChanged;

        /// <summary>
        ///     String'd name of the Bindable
        /// </summary>
        internal string Name { get; }

        /// <summary>
        ///     The default value for this bindable.
        /// </summary>
        internal T Default { get; set; }

        /// <summary>
        ///     The containing binded value.
        /// </summary>
        private T _value;
        internal T Value
        {
            get => _value;
            set
            {
                var oldVal = _value;

                _value = value;
                ValueChanged?.Invoke(this, new BindableValueChangedEventArgs<T>(value, oldVal));
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="defaultVal"></param>
        /// <param name="action"></param>
        public Bindable(T defaultVal, EventHandler<BindableValueChangedEventArgs<T>> action = null)
        {
            if (action != null)
                ValueChanged += action;

            Default = defaultVal;
        }

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defaultVal"></param>
        /// <param name="action"></param>
        public Bindable(string name, T defaultVal, EventHandler<BindableValueChangedEventArgs<T>> action = null)
        {
            if (action != null)
                ValueChanged += action;

            Name = name;
            Default = defaultVal;
        }

        /// <summary>
        ///     Unhooks all binded event handlers.
        /// </summary>
        public void UnHookEventHandlers() => ValueChanged = null;

        /// <summary>
        ///     Used as a failsafe. If trying to ToString() a Bindable itself, it'll throw an exception.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public override string ToString() => Value.ToString();
    }
}