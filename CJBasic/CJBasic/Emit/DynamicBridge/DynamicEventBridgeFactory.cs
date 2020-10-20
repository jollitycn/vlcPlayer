namespace CJBasic.Emit.DynamicBridge
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public static class DynamicEventBridgeFactory
    {
        private static CJBasic.Emit.DynamicBridge.DynamicEventBridgeEmitter DynamicEventBridgeEmitter = new CJBasic.Emit.DynamicBridge.DynamicEventBridgeEmitter(false);

        public static IEventBridge CreateEventBridge(object eventPublisher, object eventHandler, IDictionary<string, string> eventAndHanlerMapping)
        {
            lock (DynamicEventBridgeEmitter)
            {
                return (IEventBridge) Activator.CreateInstance(DynamicEventBridgeEmitter.EmitEventBridgeType(eventPublisher.GetType(), eventHandler.GetType(), eventAndHanlerMapping), new object[] { eventPublisher, eventHandler });
            }
        }

        public static IEventBridge CreateEventBridge<TPublisher, THandler>(TPublisher eventPublisher, THandler eventHandler, IDictionary<string, string> eventAndHanlerMapping)
        {
            lock (DynamicEventBridgeEmitter)
            {
                ConstructorInfo info = DynamicEventBridgeEmitter.EmitEventBridgeType(typeof(TPublisher), typeof(THandler), eventAndHanlerMapping).GetConstructors()[0];
                return (IEventBridge) info.Invoke(new object[] { eventPublisher, eventHandler });
            }
        }

        public static IEventBridge CreateEventBridge(object eventPublisher, object eventHandler, string eventHandlerNamePrefix)
        {
            lock (DynamicEventBridgeEmitter)
            {
                return (IEventBridge) Activator.CreateInstance(DynamicEventBridgeEmitter.EmitEventBridgeType(eventPublisher.GetType(), eventHandler.GetType(), eventHandlerNamePrefix), new object[] { eventPublisher, eventHandler });
            }
        }

        public static IEventBridge CreateEventBridge<TPublisher, THandler>(TPublisher eventPublisher, THandler eventHandler, string eventHandlerNamePrefix)
        {
            lock (DynamicEventBridgeEmitter)
            {
                ConstructorInfo info = DynamicEventBridgeEmitter.EmitEventBridgeType(typeof(TPublisher), typeof(THandler), eventHandlerNamePrefix).GetConstructors()[0];
                return (IEventBridge) info.Invoke(new object[] { eventPublisher, eventHandler });
            }
        }
    }
}

