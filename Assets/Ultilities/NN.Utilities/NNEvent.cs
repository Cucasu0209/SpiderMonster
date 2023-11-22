using System;

namespace NN.Utilities
{
    public class NNEvent : NNCommond
    {
        private Action act;
        public NNEvent(Action act, Action<Exception> onException = null)
            : base(onException)
        {
            this.act = act;
        }

        protected override void Publish(object[] args)
        {
            act();
        }
    }

    public class NNEvent<T1> : NNCommond
    {
        private Action<T1> act;
        public NNEvent(Action<T1> act, Action<Exception> onException = null)
            : base(onException)
        {
            this.act = act;
        }

        protected override void Publish(object[] args)
        {
            act((T1)args[0]);
        }
    }

    public class NNEvent<T1, T2> : NNCommond
    {
        private Action<T1, T2> act;
        public NNEvent(Action<T1, T2> act, Action<Exception> onException = null)
            : base(onException)
        {
            this.act = act;
        }

        protected override void Publish(object[] args)
        {
            act((T1)args[0], (T2)args[1]);
        }
    }

    public class NNEvent<T1, T2, T3> : NNCommond
    {
        private Action<T1, T2, T3> act;
        public NNEvent(Action<T1, T2, T3> act, Action<Exception> onException = null)
            : base(onException)
        {
            this.act = act;
        }

        protected override void Publish(object[] args)
        {
            act((T1)args[0], (T2)args[1], (T3)args[2]);
        }
    }

    public class NNEvent<T1, T2, T3, T4> : NNCommond
    {
        private Action<T1, T2, T3, T4> act;
        public NNEvent(Action<T1, T2, T3, T4> act, Action<Exception> onException = null)
            : base(onException)
        {
            this.act = act;
        }

        protected override void Publish(object[] args)
        {
            act((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3]);
        }
    }
}

