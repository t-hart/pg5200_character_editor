using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterEditor.Model
{
    public class Result<T> where T : class
    {
        public Exception Err { get; }
        public T Ok { get; }

        private Result(Exception err, T ok)
        {
            Err = err;
            Ok = ok;
        }

        public static Result<T> Failure(Exception e) => new Result<T>(e, null);

        public static Result<T> Success(T t) => new Result<T>(null, t);

        public bool IsOk => Err == null;
        public bool IsError => !IsOk;
    }
}
