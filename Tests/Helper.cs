using System;
using System.IO;

namespace DNS.Tests {
    public static class Helper {
        private static readonly string BASE_DIRECTORY = 
            Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName;

        public static byte[] ReadFixture(params string[] paths) {
            string path = Path.Combine(paths);
            path = Path.Combine(BASE_DIRECTORY, "Fixtures", path);

            return File.ReadAllBytes(path);
        }

        public static T[] GetArray<T>(params T[] parameters) {
            return parameters;
        }
    }
}
