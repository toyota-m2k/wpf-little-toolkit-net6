using System;
using System.Windows;
using System.Windows.Input;
using io.github.toyota32k.dotnet6.toolkit.utils;

namespace io.github.toyota32k.dotnet6.toolkit.view {
    public class WaitCursor : IDisposable {
        private readonly WeakReference<FrameworkElement?> mCursorOwner;

        public Cursor? Cursor {
            get => mCursorOwner.GetValue()?.Cursor;
            set {
                var co = mCursorOwner.GetValue();
                if(null!=co) {
                    co.Cursor = value;
                }
            }
        }

        private readonly Cursor? mOrgCursor;

        public WaitCursor(FrameworkElement cursorOwner, Cursor? waitCursor=null) {
            mCursorOwner = new WeakReference<FrameworkElement?>(cursorOwner);
            mOrgCursor = cursorOwner.Cursor;
            cursorOwner.Cursor = waitCursor ?? Cursors.Wait;
        }

        public void Dispose() {
            Cursor = mOrgCursor;
        }

        public static WaitCursor Start(FrameworkElement cursorOwner, Cursor? waitCursor=null) {
            return new WaitCursor(cursorOwner, waitCursor);
        }
    }
}
