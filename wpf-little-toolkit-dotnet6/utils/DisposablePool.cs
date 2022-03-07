using System;
using System.Collections.Generic;

namespace io.github.toyota32k.dotnet6.toolkit.utils {
    public class DisposablePool : List<IDisposable>, IDisposable {
        public void Dispose() {
            foreach (var e in this) {
                e.Dispose();
            }
            Clear();
        }
    }
}
