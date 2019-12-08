using System.Runtime.Serialization;
using UnityEngine;

namespace AtaUnityTools.UnitySerializer
{
    public class Vector2Surrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var v2 = (Vector2)obj;

            info.AddValue(nameof(v2.x), v2.x);
            info.AddValue(nameof(v2.y), v2.y);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var v2 = (Vector2)obj;

            v2.x = (float)info.GetValue(nameof(v2.x), typeof(float));
            v2.y = (float)info.GetValue(nameof(v2.y), typeof(float));
            
            return obj;
        }
    }
}
