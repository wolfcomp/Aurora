using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.Utils
{
    public static class TypeExtensions
    {
        public static object TryClone(this object self, bool deep = false)
        {
            if (self is ICloneable)
                return ((ICloneable)self).Clone();
            else if (deep) {
                var settings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace, TypeNameHandling = TypeNameHandling.All, SerializationBinder = Aurora.Utils.JSONUtils.SerializationBinder };
                var json = JsonConvert.SerializeObject(self, Formatting.None, settings);
                return JsonConvert.DeserializeObject(json, self.GetType(), settings);
            } else
                return self;
        }

        public static IEnumerable<T> SkipTake<T>(this IEnumerable<T> enumerable, int skip, int take)
        {
            return enumerable.Skip(skip).Take(take);
        }

        public static IEnumerable<IEnumerable<T>> SplitRow<T>(this IEnumerable<T> enumerable, int rowSize)
        {
            var arr = new IEnumerable<T>[enumerable.Count() / rowSize];
            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = enumerable.SkipTake(rowSize * i, rowSize);
            }
            return arr;
        }
    }
}
