using System;
using System.Collections.Generic;
using System.Text;

namespace LinqExample
{
    public class Test
    {
        static void Main(string[] args)
        {
            Object obj = new Object();
            Student student = new Student();
            GenericWithTwoDataType<Object, Student> genericWithTwoDataType = new GenericWithTwoDataType<object, Student>();
            var result = genericWithTwoDataType.GetDataType(obj, student);
            Console.WriteLine(result);
        }
    }
    public class GenericWithTwoDataType<T, K>
    {
        public string GetDataType(T t, K k)
        {
            dynamic var1 = t.GetType().ToString();
            dynamic var2 = k.GetType().ToString();
            return var1 + " " +  var2;
        }
    }
}
