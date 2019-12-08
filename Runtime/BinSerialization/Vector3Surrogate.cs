using System.Runtime.Serialization;
using UnityEngine;

namespace AtaUnityTools.UnitySerializer
{
    public class Vector3Surrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            Vector3 v3 = (Vector3)obj;
            info.AddValue(nameof(v3.x), v3.x);
            info.AddValue(nameof(v3.y), v3.y);
            info.AddValue(nameof(v3.z), v3.z);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            Vector3 v3 = (Vector3)obj;

            v3.x = (float)info.GetValue(nameof(v3.x), typeof(float));
            v3.y = (float)info.GetValue(nameof(v3.y), typeof(float));
            v3.z = (float)info.GetValue(nameof(v3.z), typeof(float));

            return obj;
        }
    }
}
