using System;

namespace Helpers {
    public static class Singleton<T> where T : class, IDisposable, new() {

        private static object lockingObject = new object();
        private static T singleTonObject;

        public static T Instance => InstanceCreation();

        public static T InstanceCreation() {
            if (singleTonObject == null) {
                lock (lockingObject) {
                    if (singleTonObject == null) {
                        singleTonObject = new T();
                    }
                }
            }
            return singleTonObject;
        }

        public static void Dispose() {
            Instance.Dispose();
            singleTonObject = null;
        }
    }
}
