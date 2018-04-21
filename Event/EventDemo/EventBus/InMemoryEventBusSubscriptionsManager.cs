using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using EventDemo.Abstraction;
using EventDemo.CarDemo;
using Newtonsoft.Json;

namespace EventDemo.EventBus {
    public class InMemoryEventBusSubscriptionsManager : IEventBusSubscriptionsManager {
        private readonly Dictionary<string, List<Type>> _handler; //Type is HandlerType
        private readonly List<Type> _eventTypes;
        public event CarNotificationDelegate OnEventRemoved;
        private readonly ILifetimeScope _autofac;

        public InMemoryEventBusSubscriptionsManager (ILifetimeScope autofac) {
            _handler = new Dictionary<string, List<Type>> ();
            _eventTypes = new List<Type> ();
            _autofac = autofac;
            OnEventRemoved += BeiginProcess;
        }

        public bool IsEmpty => !_handler.Keys.Any ();

        public void AddSubscription<T, TH> ()
        where T : CarNotificationEventData
        where TH : IEventHandler<T> {
            var eventName = GetEventKey<T> ();

            if (!HasSubscriptionsForEvent<T> ()) {
                _handler.Add (eventName, new List<Type> ());
            }

            if (_handler[eventName].Any (t => t == typeof (TH))) {
                throw new ArgumentException (
                    $"Handler Type {typeof(TH).Name} already registered");
            }
            _handler[eventName].Add (typeof (TH));

            _eventTypes.Add (typeof (T));
        }

        public void RemoveSubscription<T, TH> (T eventData)
        where T : CarNotificationEventData
        where TH : IEventHandler<T> {
            var handlerToRemove = FindSubscriptionToRemove<T, TH> ();
            DoRemoveHandler (eventData, handlerToRemove);
        }

        private void DoRemoveHandler (CarNotificationEventData eventData, Type subsToRemove) {
            if (subsToRemove != null) {

                var eventName = eventData.GetType ().Name;

                _handler[eventName].Remove (subsToRemove);
                if (!_handler[eventName].Any ()) {
                    _handler.Remove (eventName);
                    var eventType = _eventTypes.SingleOrDefault (e => e == eventName.GetType ());
                    if (eventType != null) {
                        _eventTypes.Remove (eventType);
                    }
                    RaiseOnEventRemoved (eventData);
                }

            }
        }

        private void RaiseOnEventRemoved (CarNotificationEventData eventData) {
            var handler = OnEventRemoved;
            if (handler != null) {
                OnEventRemoved (eventData);
            }
        }

        private Type FindSubscriptionToRemove<T, TH> ()
        where T : CarNotificationEventData
        where TH : IEventHandler<T> {
            var eventName = GetEventKey<T> ();
            return DoFindSubscriptionToRemove (eventName, typeof (TH));
        }

        private Type DoFindSubscriptionToRemove (string eventName, Type handlerType) {
            if (!HasSubscriptionsForEvent (eventName)) {
                return null;
            }

            return _handler[eventName].SingleOrDefault (s => s == handlerType);

        }
        public bool HasSubscriptionsForEvent<T> () where T : CarNotificationEventData {
            var keyName = GetEventKey<T> ();
            return _handler.ContainsKey (keyName);
        }

        public bool HasSubscriptionsForEvent (string eventName) => _handler.ContainsKey (eventName);

        public string GetEventKey<T> () {
            return typeof (T).Name;
        }

        public Type GetEventTypeByName (string eventName) => _eventTypes.SingleOrDefault (t => t.Name == eventName);

        public async void BeiginProcess (CarNotificationEventData eventData) {
            await Process (eventData);
        }

        private async Task Process (CarNotificationEventData eventBusData) {
            var eventName = eventBusData.GetType ().Name;
            if (HasSubscriptionsForEvent (eventName)) {
                using (var scope = _autofac.BeginLifetimeScope ("RabbitMQ")) {
                    var subscriptions = _handler[eventName];

                    foreach (var subscription in subscriptions) {
                        var eventType = GetEventTypeByName (eventName);
                        var handler = scope.ResolveOptional (subscription);
                        var concreteType = typeof (IEventHandler<>).MakeGenericType (eventType);

                        await (Task) concreteType.GetMethod ("EventHandle").Invoke (handler, new object[] { eventBusData });
                    }
                }
            }
        }
    }
}