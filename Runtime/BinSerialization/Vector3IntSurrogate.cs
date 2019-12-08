using System.Runtime.Serialization;
using UnityEngine;

namespace AtaUnityTools.UnitySerializer {
    public class Vector3IntSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var v3 = (Vector3Int)obj;
            info.AddValue(nameof(v3.x), v3.x);
            info.AddValue(nameof(v3.y), v3.y);
            info.AddValue(nameof(v3.z), v3.z);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var v3 = (Vector3Int)obj;

            v3.x = (int)info.GetValue(nameof(v3.x), typeof(int));
            v3.y = (int)info.GetValue(nameof(v3.y), typeof(int));
            v3.z = (int)info.GetValue(nameof(v3.z), typeof(int));

            return obj;
        }
    }
}