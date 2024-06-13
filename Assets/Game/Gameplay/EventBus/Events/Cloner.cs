
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    public static class Cloner
    {
        public static T DeepCopy<T>(this T self)
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self), "The object instance cannot be null.");
            }

            using (var stream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, self);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }