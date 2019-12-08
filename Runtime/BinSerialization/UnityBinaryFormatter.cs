using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace AtaUnityTools.UnitySerializer
{
    /// <summary>
    /// Wraps System.IO.BinaryFormatter and adds surrogates for some Unity data objects.
    /// </summary>
    public class UnityBinaryFormatter : IFormatter
    {
        private BinaryFormatter _binaryFormatter;
        private SurrogateSelector _surrogateSelector;

        public SerializationBinder Binder { get => _binaryFormatter.Binder; set => _binaryFormatter.Binder = value; }
        public StreamingContext Context { get => _binaryFormatter.Context; set => _binaryFormatter.Context = value; }
        public ISurrogateSelector SurrogateSelector { get => _binaryFormatter.SurrogateSelector; set => _binaryFormatter.SurrogateSelector = value; }

        public UnityBinaryFormatter()
        {
            _binaryFormatter = new BinaryFormatter();
            _surrogateSelector = new SurrogateSelector();

            AddSurrogates();
        }

        private void AddSurrogates()
        {
            _surrogateSelector = new SurrogateSelector();

            AddSurrogate<Vector2>(new Vector2Surrogate());
            AddSurrogate<Vector2Int>(new Vector2IntSurrogate());
            AddSurrogate<Vector3>(new Vector3Surrogate());
            AddSurrogate<Vector3Int>(new Vector3IntSurrogate());
            AddSurrogate<Vector4>(new Vector4Surrogate());
            AddSurrogate<Quaternion>(new QuaternionSurrogate());
        }

        public void AddSurrogate<TObj>(ISerializationSurrogate surrogate) {
            _surrogateSelector.AddSurrogate(typeof(TObj), new StreamingContext(StreamingContextStates.All), surrogate);

            SurrogateSelector = _surrogateSelector;
        }


        public object Deserialize(Stream serializationStream)
        {
            return _binaryFormatter.Deserialize(serializationStream);
        }

        public void Serialize(Stream serializationStream, object graph)
        {
            _binaryFormatter.Serialize(serializationStream, graph);
        }
    }
}
