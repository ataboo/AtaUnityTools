using System.Runtime.Serialization;
using UnityEngine;

namespace AtaUnityTools.UnitySerializer
{
    public class Vector2IntSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var v2 = (Vector2Int)obj;

            info.AddValue(nameof(v2.x), v2.x);
            info.AddValue(nameof(v2.y), v2.y);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var v2 = (Vector2Int)obj;

            v2.x = (int)info.GetValue(nameof(v2.x), typeof(int));
            v2.y = (int)info.GetValue(nameof(v2.y), typeof(int));
            
            return obj;
        }
    }
}
