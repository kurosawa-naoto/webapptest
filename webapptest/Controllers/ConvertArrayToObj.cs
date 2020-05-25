using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using webapptest.Models;

namespace webapptest.Controllers
{
    public class ConvertArrayToObj<T>
    {
        public T DoConvert(byte[]array)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            ms.Write(array,0,array.Length);
            ms.Seek(0,SeekOrigin.Begin);
            return (T)bf.Deserialize(ms);
        }
    }
}
