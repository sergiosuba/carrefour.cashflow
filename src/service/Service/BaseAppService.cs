using System;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace cashflow.applicationservice
{
    public class BaseAppService : IDisposable
    {
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                return;

            if (disposing)
                handle.Dispose();
        }
    }
}
