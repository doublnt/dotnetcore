using System;
using System.Reflection;

namespace ReflectionDemo {

    internal sealed class Dictionary<TKey, TValue> { }

    public static class Program {
        public static void Main (string[] args) {
            // String dataAssembly = "System.Data, version=4.0.0.0, " +
            //     "culture=neutral, PublicKeyToken=b77a5c561934e089";
            // LoadAssemblandShowPublicTypes (dataAssembly);
            Console.WriteLine ("--------->\n{0}", new Object ().GetType () == new Object ().GetType ());
            Console.WriteLine (new Object ().GetType () == typeof (Object));
            Console.WriteLine (new Object ().GetType ().GetTypeInfo ());

            Type a = new Object ().GetType ();
            var b = Activator.CreateInstance (a);
            Console.WriteLine ("-------->\n" + a.GetMethod ("ToString"));
            Console.WriteLine (a.GetTypeInfo ().GetMethod ("ToString"));
            Console.WriteLine (a.GetTypeInfo ().GetDeclaredMethod ("ToString"));

            Type openType = typeof (Dictionary<,>);
            Type closedType = openType.MakeGenericType (typeof (String), typeof (Int32));
            Object o = Activator.CreateInstance (closedType);
            Console.WriteLine ("-------->\n" + o.GetType ());

            #region  GetMemberinfo
            /* 
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies ();
            foreach (Assembly item in assemblies) {
                Show (0, "Assembly: {0}", item);

                foreach (Type t in item.ExportedTypes) {
                    Show (1, "Type: {0}", t);

                    foreach (MemberInfo mi in t.GetTypeInfo ().DeclaredMembers) {
                        String typeName = String.Empty;
                        if (mi is Type) typeName = "(Nested) Type";
                        if (mi is FieldInfo) typeName = "FieldInfo";
                        if (mi is MethodInfo) typeName = "MethodInfo";
                        if (mi is ConstructorInfo) typeName = "ConstructorInfo";
                        if (mi is PropertyInfo) typeName = "PropertyInfo";
                        if (mi is EventInfo) typeName = "EventInfo";
                        Show (2, "{0} : {1}", typeName, mi);
                    }
                }
            }*/
            #endregion

        }

        public static void Show (Int32 indent, String format, params Object[] args) {
            Console.WriteLine (new String (' ', 3 * indent) + format, args);
        }

        private static void LoadAssemblandShowPublicTypes (String assemId) {
            Assembly a = Assembly.Load (assemId);

            foreach (Type t in a.ExportedTypes) {
                Console.WriteLine (t.FullName);
            }
        }
    }
}