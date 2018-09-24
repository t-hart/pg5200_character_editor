using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CharacterEditor.Model
{
    public static class IO
    {
        private static Result<T> Operate<T>(Func<T> f) where T : class
        {
            try
            {
                return Result<T>.Success(f());
            }
            catch (Exception e)
            {
                return Result<T>.Failure(e);
            }
        }

        public static Result<string> Save<T>(T o, string path) =>
            Operate(() =>
                {
                    using (var writer = new StreamWriter(path))
                    {
                        writer.Write(JsonConvert.SerializeObject(o, Formatting.Indented,
                         new JsonSerializerSettings
                         {
                             DateFormatString = "yyyy-MM-ddTHH:mm:sszzz",
                             NullValueHandling = NullValueHandling.Ignore,
                         }));
                    }

                    return path;
                }
            );

        public static Result<T> Load<T>(T target, string path) where T : class =>
            Operate(() =>
            {
                using (var reader = new StreamReader(path))
                {
                    JsonConvert.PopulateObject(reader.ReadToEnd(), target);
                }

                return target;
            });
    }
}
