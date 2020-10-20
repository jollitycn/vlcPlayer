namespace CJBasic.Helpers
{
    using CJBasic;
    using CJBasic.Loggers;
    using System;

    public static class EventHelper
    {
        public static void SpringEventSafely(IAgileLogger agileLogger, string eventPath, Delegate theEvent)
        {
            if (theEvent != null)
            {
                foreach (Delegate delegate2 in theEvent.GetInvocationList())
                {
                    try
                    {
                        CbGeneric generic = (CbGeneric) delegate2;
                        generic();
                    }
                    catch (Exception innerException)
                    {
                        while (innerException.InnerException != null)
                        {
                            innerException = innerException.InnerException;
                        }
                        agileLogger.Log(innerException, string.Format("{0} On handle event [{1}].", ReflectionHelper.GetMethodFullName(delegate2.Method), eventPath), ErrorLevel.Standard);
                    }
                }
            }
        }

        public static void SpringEventSafely<T1>(IAgileLogger agileLogger, string eventPath, Delegate theEvent, T1 t1)
        {
            if (theEvent != null)
            {
                foreach (Delegate delegate2 in theEvent.GetInvocationList())
                {
                    try
                    {
                        CbGeneric<T1> generic = (CbGeneric<T1>) delegate2;
                        generic(t1);
                    }
                    catch (Exception innerException)
                    {
                        while (innerException.InnerException != null)
                        {
                            innerException = innerException.InnerException;
                        }
                        agileLogger.Log(innerException, string.Format("{0} On handle event [{1}].", ReflectionHelper.GetMethodFullName(delegate2.Method), eventPath), ErrorLevel.Standard);
                    }
                }
            }
        }

        public static void SpringEventSafely<T1, T2>(IAgileLogger agileLogger, string eventPath, Delegate theEvent, T1 t1, T2 t2)
        {
            if (theEvent != null)
            {
                foreach (Delegate delegate2 in theEvent.GetInvocationList())
                {
                    try
                    {
                        CbGeneric<T1, T2> generic = (CbGeneric<T1, T2>) delegate2;
                        generic(t1, t2);
                    }
                    catch (Exception innerException)
                    {
                        while (innerException.InnerException != null)
                        {
                            innerException = innerException.InnerException;
                        }
                        agileLogger.Log(innerException, string.Format("{0} On handle event [{1}].", ReflectionHelper.GetMethodFullName(delegate2.Method), eventPath), ErrorLevel.Standard);
                    }
                }
            }
        }

        public static void SpringEventSafely<T1, T2, T3>(IAgileLogger agileLogger, string eventPath, Delegate theEvent, T1 t1, T2 t2, T3 t3)
        {
            if (theEvent != null)
            {
                foreach (Delegate delegate2 in theEvent.GetInvocationList())
                {
                    try
                    {
                        CbGeneric<T1, T2, T3> generic = (CbGeneric<T1, T2, T3>) delegate2;
                        generic(t1, t2, t3);
                    }
                    catch (Exception innerException)
                    {
                        while (innerException.InnerException != null)
                        {
                            innerException = innerException.InnerException;
                        }
                        agileLogger.Log(innerException, string.Format("{0} On handle event [{1}].", ReflectionHelper.GetMethodFullName(delegate2.Method), eventPath), ErrorLevel.Standard);
                    }
                }
            }
        }

        public static void SpringEventSafely<T1, T2, T3, T4>(IAgileLogger agileLogger, string eventPath, Delegate theEvent, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            if (theEvent != null)
            {
                foreach (Delegate delegate2 in theEvent.GetInvocationList())
                {
                    try
                    {
                        CbGeneric<T1, T2, T3, T4> generic = (CbGeneric<T1, T2, T3, T4>) delegate2;
                        generic(t1, t2, t3, t4);
                    }
                    catch (Exception innerException)
                    {
                        while (innerException.InnerException != null)
                        {
                            innerException = innerException.InnerException;
                        }
                        agileLogger.Log(innerException, string.Format("{0} On handle event [{1}].", ReflectionHelper.GetMethodFullName(delegate2.Method), eventPath), ErrorLevel.Standard);
                    }
                }
            }
        }

        public static void SpringEventSafelyAsyn(IAgileLogger agileLogger, string eventPath, Delegate theEvent)
        {
            if (theEvent != null)
            {
                new CbGeneric<IAgileLogger, string, Delegate>(EventHelper.SpringEventSafely).BeginInvoke(agileLogger, eventPath, theEvent, null, null);
            }
        }

        public static void SpringEventSafelyAsyn<T1>(IAgileLogger agileLogger, string eventPath, Delegate theEvent, T1 t1)
        {
            if (theEvent != null)
            {
                new CbGeneric<IAgileLogger, string, Delegate, T1>(EventHelper.SpringEventSafely<T1>).BeginInvoke(agileLogger, eventPath, theEvent, t1, null, null);
            }
        }

        public static void SpringEventSafelyAsyn<T1, T2>(IAgileLogger agileLogger, string eventPath, Delegate theEvent, T1 t1, T2 t2)
        {
            if (theEvent != null)
            {
                new CbGeneric<IAgileLogger, string, Delegate, T1, T2>(EventHelper.SpringEventSafely<T1, T2>).BeginInvoke(agileLogger, eventPath, theEvent, t1, t2, null, null);
            }
        }

        public static void SpringEventSafelyAsyn<T1, T2, T3>(IAgileLogger agileLogger, string eventPath, Delegate theEvent, T1 t1, T2 t2, T3 t3)
        {
            if (theEvent != null)
            {
                new CbGeneric<IAgileLogger, string, Delegate, T1, T2, T3>(EventHelper.SpringEventSafely<T1, T2, T3>).BeginInvoke(agileLogger, eventPath, theEvent, t1, t2, t3, null, null);
            }
        }

        public static void SpringEventSafelyAsyn<T1, T2, T3, T4>(IAgileLogger agileLogger, string eventPath, Delegate theEvent, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            if (theEvent != null)
            {
                new CbGeneric<IAgileLogger, string, Delegate, T1, T2, T3, T4>(EventHelper.SpringEventSafely<T1, T2, T3, T4>).BeginInvoke(agileLogger, eventPath, theEvent, t1, t2, t3, t4, null, null);
            }
        }
    }
}

