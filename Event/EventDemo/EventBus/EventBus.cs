using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using EventDemo.Abstraction;

namespace EventDemo.EventBus {
    public class EventBusManager {
        public static EventBusManager Default => new EventBusManager ();

        private readonly ConcurrentDictionary<Type, List<Type>> _eventAndHandlerMapping;

        public EventBusManager () {
            _eventAndHandlerMapping = new ConcurrentDictionary<Type, List<Type>> ();
            MapEventToHandler ();
        }

        private void MapEventToHandler () {
            Assembly assembly = Assembly.GetExecutingAssembly ();

            foreach (var type in assembly.GetTypes ()) {
                if (typeof (IEventHandler).IsAssignableFrom (type)) {
                    Type handlerInterface = type.GetInterface ("IEventHandler`1");

                    if (handlerInterface != null) {
                        Type eventDataType = handlerInterface.GetGenericArguments () [0];

                        if (_eventAndHandlerMapping.ContainsKey (eventDataType)) {
                            List<Type> handlerTypes = _eventAndHandlerMapping[eventDataType];
                            handlerTypes.Add (type);
                            _eventAndHandlerMapping[eventDataType] = handlerTypes;
                        } else {
                            var handlerTypes = new List<Type> { type };
                            _eventAndHandlerMapping[eventDataType] = handlerTypes;
                        }
                    }
                }
            }
        }

        public void Register<TEventData> (Type eventDataType) {
            List<Type> handlerType = _eventAndHandlerMapping[typeof (TEventData)];

            if (!handlerType.Contains (eventDataType)) {
                handlerType.Add (eventDataType);
                _eventAndHandlerMapping[typeof (TEventData)] = handlerType;
            }
        }

        public void UnRegister<TEventData> (Type eventHandler) {
            List<Type> handlerTypes = _eventAndHandlerMapping[typeof (TEventData)];
            if (handlerTypes.Contains (eventHandler)) {
                handlerTypes.Remove (eventHandler);
                _eventAndHandlerMapping[typeof (TEventData)] = handlerTypes;
            }
        }

        public void Trigger<TEventData> (TEventData eventData) where TEventData : IEventData {
            List<Type> handlers = _eventAndHandlerMapping[eventData.GetType ()];

            if (handlers != null && handlers.Count > 0) {
                foreach (var handler in handlers) {
                    MethodInfo methodInfo = handler.GetMethod ("EventHandle");
                    if (methodInfo != null) {
                        object obj = Activator.CreateInstance (handler);
                        methodInfo.Invoke (obj, new object[] { eventData });
                    }
                }
            }
        }
    }
}