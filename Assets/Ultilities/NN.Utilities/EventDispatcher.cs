using System;
using System.Collections.Generic;

namespace NN.Utilities
{
    public static class EventDispatcher
    {
        private static Dictionary<Enum, Dictionary<Enum, NNCommond>> Events = new Dictionary<Enum, Dictionary<Enum, NNCommond>>();

        #region Void Action
        public static void Addlistener(Enum scriptName, Enum eventName, Action act, Action<Exception> exception = null)
        {
            if (!Events.ContainsKey(scriptName))
            {
                Events.Add(scriptName, new Dictionary<Enum, NNCommond>());
            }

            if (Events[scriptName].ContainsKey(eventName))
            {
                Events[scriptName][eventName] = new NNEvent(act, exception);
            }
            else
            {
                Events[scriptName].Add(eventName, new NNEvent(act, exception));
            }
        }

        public static void Addlistener<T1>(Enum scriptName, Enum eventName, Action<T1> act, Action<Exception> exception = null)
        {
            if (!Events.ContainsKey(scriptName))
            {
                Events.Add(scriptName, new Dictionary<Enum, NNCommond>());
            }

            if (Events[scriptName].ContainsKey(eventName))
            {
                Events[scriptName][eventName] = new NNEvent<T1>(act, exception);
            }
            else
            {
                Events[scriptName].Add(eventName, new NNEvent<T1>(act, exception));
            }
        }

        public static void Addlistener<T1, T2>(Enum scriptName, Enum eventName, Action<T1, T2> act, Action<Exception> exception = null)
        {
            if (!Events.ContainsKey(scriptName))
            {
                Events.Add(scriptName, new Dictionary<Enum, NNCommond>());
            }

            if (Events[scriptName].ContainsKey(eventName))
            {
                Events[scriptName][eventName] = new NNEvent<T1, T2>(act, exception);
            }
            else
            {
                Events[scriptName].Add(eventName, new NNEvent<T1, T2>(act, exception));
            }
        }

        public static void Addlistener<T1, T2, T3>(Enum scriptName, Enum eventName, Action<T1, T2, T3> act, Action<Exception> exception = null)
        {
            if (!Events.ContainsKey(scriptName))
            {
                Events.Add(scriptName, new Dictionary<Enum, NNCommond>());
            }

            if (Events[scriptName].ContainsKey(eventName))
            {
                Events[scriptName][eventName] = new NNEvent<T1, T2, T3>(act, exception);
            }
            else
            {
                Events[scriptName].Add(eventName, new NNEvent<T1, T2, T3>(act, exception));
            }
        }

        public static void Addlistener<T1, T2, T3, T4>(Enum scriptName, Enum eventName, Action<T1, T2, T3, T4> act, Action<Exception> exception = null)
        {
            if (!Events.ContainsKey(scriptName))
            {
                Events.Add(scriptName, new Dictionary<Enum, NNCommond>());
            }

            if (Events[scriptName].ContainsKey(eventName))
            {
                Events[scriptName][eventName] = new NNEvent<T1, T2, T3, T4>(act, exception);
            }
            else
            {
                Events[scriptName].Add(eventName, new NNEvent<T1, T2, T3, T4>(act, exception));
            }
        }

        public static void Publish(Enum scriptName, Events eventName)
        {
            if (Events.ContainsKey(scriptName))
            {
                if (Events[scriptName].ContainsKey(eventName))
                {
                    Events[scriptName][eventName].Act();
                }
                else
                {
                    LogTool.LogErrorEditorOnly($"{scriptName.ToString()} không có event {eventName}");
                }
            }
            else
            {
                LogTool.LogErrorEditorOnly($"{scriptName.ToString()} chưa được đăng ký");
            }
        }

        public static void Publish(Events eventName)
        {
            foreach (KeyValuePair<Enum, Dictionary<Enum, NNCommond>> eventOnScript in Events)
            {
                if (eventOnScript.Value.ContainsKey(eventName))
                    eventOnScript.Value[eventName].Act();
            }
        }    

        public static void Publish<T1>(Enum scriptName, Events eventName, T1 arg1)
        {
            if (Events.ContainsKey(scriptName))
            {
                if (Events[scriptName].ContainsKey(eventName))
                {
                    Events[scriptName][eventName].Act(arg1);
                }
                else
                {
                    LogTool.LogErrorEditorOnly($"{scriptName.ToString()} không có event {eventName}");
                }
            }
            else
            {
                LogTool.LogErrorEditorOnly($"{scriptName.ToString()} chưa được đăng ký");
            }
        }

        public static void Publish<T1>(Events eventName, T1 arg1)
        {
            foreach (KeyValuePair<Enum, Dictionary<Enum, NNCommond>> eventOnScript in Events)
            {
                if (eventOnScript.Value.ContainsKey(eventName))
                    eventOnScript.Value[eventName].Act(arg1);
            }
        }

        public static void Publish<T1, T2>(Enum scriptName, Events eventName, T1 arg1, T2 arg2)
        {
            if (Events.ContainsKey(scriptName))
            {
                if (Events[scriptName].ContainsKey(eventName))
                {
                    Events[scriptName][eventName].Act(arg1, arg2);
                }
                else
                {
                    LogTool.LogErrorEditorOnly($"{scriptName.ToString()} không có event {eventName}");
                }
            }
            else
            {
                LogTool.LogErrorEditorOnly($"{scriptName.ToString()} chưa được đăng ký");
            }
        }

        public static void Publish<T1, T2>(Events eventName, T1 arg1, T2 arg2)
        {
            foreach (KeyValuePair<Enum, Dictionary<Enum, NNCommond>> eventOnScript in Events)
            {
                if (eventOnScript.Value.ContainsKey(eventName))
                    eventOnScript.Value[eventName].Act(arg1, arg2);
            }
        }

        public static void Publish<T1, T2, T3>(Enum scriptName, Events eventName, T1 arg1, T2 arg2, T3 arg3)
        {
            if (Events.ContainsKey(scriptName))
            {
                if (Events[scriptName].ContainsKey(eventName))
                {
                    Events[scriptName][eventName].Act(arg1, arg2, arg3);
                }
                else
                {
                    LogTool.LogErrorEditorOnly($"{scriptName.ToString()} không có event {eventName}");
                }
            }
            else
            {
                LogTool.LogErrorEditorOnly($"{scriptName.ToString()} chưa được đăng ký");
            }
        }

        public static void Publish<T1, T2, T3>(Events eventName, T1 arg1, T2 arg2, T3 arg3)
        {
            foreach (KeyValuePair<Enum, Dictionary<Enum, NNCommond>> eventOnScript in Events)
            {
                if (eventOnScript.Value.ContainsKey(eventName))
                    eventOnScript.Value[eventName].Act(arg1, arg2, arg3);
            }
        }

        public static void Publish<T1, T2, T3, T4>(Enum scriptName, Events eventName, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            if (Events.ContainsKey(scriptName))
            {
                if (Events[scriptName].ContainsKey(eventName))
                {
                    Events[scriptName][eventName].Act(arg1, arg2, arg3, arg4);
                }
                else
                {
                    LogTool.LogErrorEditorOnly($"{scriptName.ToString()} không có event {eventName}");
                }
            }
            else
            {
                LogTool.LogErrorEditorOnly($"{scriptName.ToString()} chưa được đăng ký");
            }
        }

        public static void Publish<T1, T2, T3, T4>(Events eventName, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            foreach (KeyValuePair<Enum, Dictionary<Enum, NNCommond>> eventOnScript in Events)
            {
                if (eventOnScript.Value.ContainsKey(eventName))
                    eventOnScript.Value[eventName].Act(arg1, arg2, arg3, arg4);
            }
        }
        #endregion


        #region Return Action

        public static void Register<T>(Enum scriptName, Events eventName, Func<T> func, Action<Exception> exception = null)
        {
            if (!Events.ContainsKey(scriptName))
            {
                Events.Add(scriptName, new Dictionary<Enum, NNCommond>());
            }

            if (Events[scriptName].ContainsKey(eventName))
            {
                Events[scriptName][eventName] = new NNReturnMessenger<T>(func, exception);
            }
            else
            {
                Events[scriptName].Add(eventName, new NNReturnMessenger<T>(func, exception));
            }
        }

        public static void Register<T1, T>(Enum scriptName, Events eventName, Func<T1, T> func, Action<Exception> exception = null)
        {
            if (!Events.ContainsKey(scriptName))
            {
                Events.Add(scriptName, new Dictionary<Enum, NNCommond>());
            }

            if (Events[scriptName].ContainsKey(eventName))
            {
                Events[scriptName][eventName] = new NNReturnMessenger<T1, T>(func, exception);
            }
            else
            {
                Events[scriptName].Add(eventName, new NNReturnMessenger<T1, T>(func, exception));
            }
        }

        public static void Register<T1, T2, T>(Enum scriptName, Events eventName, Func<T1, T2, T> func, Action<Exception> exception = null)
        {
            if (!Events.ContainsKey(scriptName))
            {
                Events.Add(scriptName, new Dictionary<Enum, NNCommond>());
            }

            if (Events[scriptName].ContainsKey(eventName))
            {
                Events[scriptName][eventName] = new NNReturnMessenger<T1, T2, T>(func, exception);
            }
            else
            {
                Events[scriptName].Add(eventName, new NNReturnMessenger<T1, T2, T>(func, exception));
            }
        }

        public static void Register<T1, T2, T3, T>(Enum scriptName, Events eventName, Func<T1, T2, T3, T> func, Action<Exception> exception = null)
        {
            if (!Events.ContainsKey(scriptName))
            {
                Events.Add(scriptName, new Dictionary<Enum, NNCommond>());
            }

            if (Events[scriptName].ContainsKey(eventName))
            {
                Events[scriptName][eventName] = new NNReturnMessenger<T1, T2, T3, T>(func, exception);
            }
            else
            {
                Events[scriptName].Add(eventName, new NNReturnMessenger<T1, T2, T3, T>(func, exception));
            }
        }

        public static void Register<T1, T2, T3, T4, T>(Enum scriptName, Events eventName, Func<T1, T2, T3, T4, T> func, Action<Exception> exception = null)
        {
            if (!Events.ContainsKey(scriptName))
            {
                Events.Add(scriptName, new Dictionary<Enum, NNCommond>());
            }

            if (Events[scriptName].ContainsKey(eventName))
            {
                Events[scriptName][eventName] = new NNReturnMessenger<T1, T2, T3, T4, T>(func, exception);
            }
            else
            {
                Events[scriptName].Add(eventName, new NNReturnMessenger<T1, T2, T3, T4, T>(func, exception));
            }
        }

        public static object Call(Enum scriptName, Events eventName)
        {
            if (Events.ContainsKey(scriptName))
            {
                if (Events[scriptName].ContainsKey(eventName))
                {
                    return Events[scriptName][eventName].Func();
                }
                else
                {
                    LogTool.LogErrorEditorOnly($"{scriptName.ToString()} không có event {eventName}");
                    return null;
                }
            }
            else
            {
                LogTool.LogErrorEditorOnly($"{scriptName.ToString()} chưa được đăng ký");
                return null;
            }
        }

        public static object Call<T1>(Enum scriptName, Events eventName, T1 arg1)
        {
            if (Events.ContainsKey(scriptName))
            {
                if (Events[scriptName].ContainsKey(eventName))
                {
                    return Events[scriptName][eventName].Func(arg1);
                }
                else
                {
                    LogTool.LogErrorEditorOnly($"{scriptName.ToString()} không có event {eventName}");
                    return null;
                }
            }
            else
            {
                LogTool.LogErrorEditorOnly($"{scriptName.ToString()} chưa được đăng ký");
                return null;
            }
        }

        public static object Call<T1, T2>(Enum scriptName, Events eventName, T1 arg1, T2 arg2)
        {
            if (Events.ContainsKey(scriptName))
            {
                if (Events[scriptName].ContainsKey(eventName))
                {
                    return Events[scriptName][eventName].Func(arg1, arg2);
                }
                else
                {
                    LogTool.LogErrorEditorOnly($"{scriptName.ToString()} không có event {eventName}");
                    return null;
                }
            }
            else
            {
                LogTool.LogErrorEditorOnly($"{scriptName.ToString()} chưa được đăng ký");
                return null;
            }
        }

        public static object Call<T1, T2, T3>(Enum scriptName, Events eventName, T1 arg1, T2 arg2, T3 arg3)
        {
            if (Events.ContainsKey(scriptName))
            {
                if (Events[scriptName].ContainsKey(eventName))
                {
                    return Events[scriptName][eventName].Func(arg1, arg2, arg3);
                }
                else
                {
                    LogTool.LogErrorEditorOnly($"{scriptName.ToString()} không có event {eventName}");
                    return null;
                }
            }
            else
            {
                LogTool.LogErrorEditorOnly($"{scriptName.ToString()} chưa được đăng ký");
                return null;
            }
        }


        public static object Call<T1, T2, T3, T4>(Enum scriptName, Events eventName, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            if (Events.ContainsKey(scriptName))
            {
                if (Events[scriptName].ContainsKey(eventName))
                {
                    return Events[scriptName][eventName].Func(arg1, arg2, arg3, arg4);
                }
                else
                {
                    LogTool.LogErrorEditorOnly($"{scriptName.ToString()} không có event {eventName}");
                    return null;
                }
            }
            else
            {
                LogTool.LogErrorEditorOnly($"{scriptName.ToString()} chưa được đăng ký");
                return null;
            }
        }
        #endregion

        public static void RemoveEvent(Enum scriptName, Events eventName)
        {
            if (Events.ContainsKey(scriptName))
            {
                if (Events[scriptName].ContainsKey(eventName))
                {
                    Events[scriptName].Remove(eventName);
                }
            }
        }

        public static void RemoveEvents(Enum scriptName)
        {
            if (Events.ContainsKey(scriptName))
            {
                Events.Remove(scriptName);
            }
        }
    }
}

