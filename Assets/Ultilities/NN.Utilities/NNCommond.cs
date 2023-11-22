using System;


namespace NN.Utilities
{
    public abstract class NNCommond : IDisposable
    {
        private Action<Exception> onError;
        public NNCommond(Action<Exception> onError = null)
        {
            this.onError = onError;
        }

        protected virtual void Publish(object[] args) { }
        protected virtual object Call(object[] args) { return (object)default; }

        public void Act(params object[] args)
        {
            //try
            //{
            //    Publish(args);
            //}
            //catch (Exception e)
            //{
            //    LogTool.LogErrorEditorOnly(e.Message);
            //    onError?.Invoke(e);
            //}

            Publish(args);
        }

        public object Func(params object[] args)
        {
            try
            {
                return Call(args);
            }
            catch (Exception e)
            {
                //LogTool.LogErrorEditorOnly(e.Message);
                onError?.Invoke(e);
                return (object)default;
            }
        }

        public void Dispose() { }
    }
}

