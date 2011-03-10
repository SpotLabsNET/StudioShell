/*
   Copyright (c) 2011 Code Owls LLC, All Rights Reserved.

   Licensed under the Microsoft Reciprocal License (Ms-RL) (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.opensource.org/licenses/ms-rl

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/


using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace PowerShellConsole
{
    class AsyncResult<T> : IAsyncResult where T : class
    {
        private readonly AsyncCallback _callback;
        private readonly object _state;
        private long _isCompleted;
        private long _completedSynchronously;
        private ManualResetEvent _waitHandle;
        private Exception _exception;
        private T _result;

        internal AsyncResult( AsyncCallback callback, object state)
        {
            _callback = callback;
            _state = state;
        }

        public bool IsCompleted
        {
            get { return 0 != Interlocked.Read( ref _isCompleted ); }
        }

        public WaitHandle AsyncWaitHandle
        {
            get { return GetOrCreateWaitHandle(); }
        }

        public object AsyncState
        {
            get { return _state; }
        }

        public bool CompletedSynchronously
        {
            get { return 0 != Interlocked.Read(ref _completedSynchronously); }
        }

        internal void SetComplete( T result, Exception exception, bool completedSynchronously )
        {
            Interlocked.Exchange(ref _isCompleted, 1L);
            Interlocked.Exchange(ref _completedSynchronously, completedSynchronously ? 1L : 0L );
            if( null != exception)
            {
                Interlocked.Exchange(ref _exception, exception);
            }
            Interlocked.Exchange(ref _result, result);

            var handle = Interlocked.Exchange(ref _waitHandle, null);
            if( null != handle )
            {
                handle.Set();
                handle.Close();
            }

            if( null != _callback )
            {
                try
                {
                    _callback(this);
                }
                catch 
                {                    
                }
            }
        }

        internal T EndInvoke()
        {
            if (!IsCompleted)
            {
                AsyncWaitHandle.WaitOne();
            }

            if( null != _exception )
            {
                throw _exception;
            }

            return _result;
        }

        private WaitHandle GetOrCreateWaitHandle()
        {
            if( null == _waitHandle )
            {
                return _waitHandle;
            }

            var handle = new ManualResetEvent(false);
            var existing = Interlocked.CompareExchange(ref _waitHandle, handle, null);
            if( null != existing )
            {
                handle.Close();
            }

            return _waitHandle;
        }
    }
}
