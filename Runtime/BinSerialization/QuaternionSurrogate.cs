using System.Runtime.Serialization;
using UnityEngine;

namespace AtaUnityTools.UnitySerializer
{
    public class QuaternionSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            var quat = (Quaternion)obj;
            info.AddValue(nameof(quat.w), quat.w);
            info.AddValue(nameof(quat.x), quat.x);
            info.AddValue(nameof(quat.y), quat.y);
            info.AddValue(nameof(quat.z), quat.z);
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            var quat = (Quaternion)obj;

            quat.w = (float)info.GetValue(nameof(quat.w), typeof(float));
            quat.x = (float)info.GetValue(nameof(quat.x), typeof(float));
            quat.y = (float)info.GetValue(nameof(quat.y), typeof(float));
            quat.z = (float)info.GetValue(nameof(quat.z), typeof(float));

            return obj;
        }
    }
}
