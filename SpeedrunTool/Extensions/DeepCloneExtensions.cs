using System;
using GroBuf;
using GroBuf.DataMembersExtracters;

namespace Celeste.Mod.SpeedrunTool.Extensions {
    public static class DeepCloneExtensions {
        private static readonly Serializer serializer = new Serializer(new AllFieldsExtractor(), options : GroBufOptions.WriteEmptyObjects);
        public static T DeepClone<T>(this T obj) {
            byte[] data = serializer.Serialize(obj);
            return serializer.Deserialize<T>(data);
        }

        // deep clone an object using YAML (de)serialization.
        public static T DeepCloneYaml<T>(this T obj, Type type) {
            string yaml = YamlHelper.Serializer.Serialize(obj);
            return (T) YamlHelper.Deserializer.Deserialize(yaml, type);
        }
    }
}