using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Cwiczenie_3_Oczyszczanie_pamieci
{
    class DisposeObject : IDisposable
    {
        private bool disposed = false;                // zabezpieczenie aby nie wywoływać wielokrotnie
        private IntPtr handle;                          // niezarządzane zasoby
        private Component component = new Component();  // zarządzane zasoby

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        public extern static bool CloseHandle(IntPtr handle);

        public DisposeObject(IntPtr _handle)
        {
            this.handle = _handle;
        }

        ~DisposeObject()          // niedeterministyczny
        {
            Dispose(false);
        }

        public void Dispose()   // deterministyczny
        {

            Dispose(true);
            GC.SuppressFinalize(this); // zabezpieczenie prezd powtórnym wywołaniem finalizatora
        }

        protected virtual void Dispose(bool disposing)
        {

            if (!disposed)      // tylko jeden raz
            {
                if (disposing)
                {
                    component.Dispose(); // zarządzane (kod urzytkownika)
                }

                Marshal.FreeHGlobal(handle);    // niezarządzane
                handle = IntPtr.Zero;
            }
            disposed = true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cwiczenie 3\n");

            int n = 3;
            IntPtr p = Marshal.AllocHGlobal(sizeof(int));

            Marshal.WriteInt32(p, n);

            int n1 = Marshal.ReadInt32(p);

            Console.WriteLine("n = {0}\nn1 = {1}", n, n1);

            DisposeObject dispose = new DisposeObject(p);

            dispose.Dispose();
        }
    }
}
