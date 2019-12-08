using System.Runtime.Serialization;
using UnityEngine;

namespace AtaUnityTools.UnitySerializer
{
    public class Vector4Surrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            Vector4 v4 = (Vector4)obj;
            info.AddValue(nameof(v4.w), v4.w);
            info.AddValue(nameof(v4.x), v4.x);
            info.AddValue(nameof(v4.y), v4.y);
            info.AddValue(nameof(v4.z), v4.z);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            Vector4 v4 = (Vector4)obj;

            v4.w = (float)info.GetValue(nameof(v4.w), typeof(float));
            v4.x = (float)info.GetValue(nameof(v4.x), typeof(float));
            v4.y = (float)info.GetValue(nameof(v4.y), typeof(float));
            v4.z = (float)info.GetValue(nameof(v4.z), typeof(float));

            return obj;
        }
    }
}
