using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using System.IO;

namespace Project7.CodeDomBasics
{
    static class GeneratingCodeBasics
    {
        /*
         
        This example will generate the following code dynamically:

         namespace Personnel 
         {
            using System;

            public class Person 
            {
                private String name;
            }
        }

        */

        public static void Run()
        {
            Console.WriteLine("Code in different languages:\n\n");
            Console.WriteLine("\nC#\n");
            DemoCodeForCSharp();
            Console.WriteLine("\nVisual Basic\n");
            DemoCodeForVB();
            Console.WriteLine("\nC++\n");
            DemoCodeForCpp();
            Console.WriteLine("\nJavaScript\n");
            DemoCodeForJS();
        }

        static void DemoCodeForCSharp()
        {
            GenerateCodeForLanguage("CSharp");
        }

        static void DemoCodeForVB()
        {
            GenerateCodeForLanguage("VB");
        }

        static void DemoCodeForCpp()
        {
            GenerateCodeForLanguage("Cpp");
        }

        static void DemoCodeForJS()
        {
            GenerateCodeForLanguage("JS");
        }

        static void GenerateCodeForLanguage(string language)
        {
            var assembly = GenerateCode();
            string code;
            using (var provider = CodeDomProvider.CreateProvider(language))
            {
                code = GetCodeString(provider, assembly);
            }
            Console.WriteLine(code);
        }

        static string GetCodeString(CodeDomProvider provider, CodeCompileUnit assembly)
        {
            using (var writer = new StringWriter())
            {
                provider.GenerateCodeFromCompileUnit(assembly, writer, new CodeGeneratorOptions()); // Generate the code from compile unit and write to the writer using default options
                writer.Flush();
                return writer.ToString();
            }
        }

        static CodeCompileUnit GenerateCode()
        {
            CodeCompileUnit unit = new CodeCompileUnit();   // A compilable unit that hold most prevalently the namespaces; It mimics an assembly

            CodeNamespace ns = new CodeNamespace("Personnel");  // created a namespace named Personnel

            CodeTypeDeclaration @class = new CodeTypeDeclaration("Person") // // created a Person type (The type of this type is not declared yet)
            {
                IsClass = true,  // specified that the type is a class
                Attributes = MemberAttributes.Public    // set the visibility of the class
            };

            CodeMemberField field = new CodeMemberField(new CodeTypeReference(typeof(string)), "name") // // created a field named name having type string
            {
                Attributes = MemberAttributes.Private    // indicate that the access modifier of the field is private
            };

            @class.Members.Add(field); // added the field to class
            ns.Types.Add(@class);   // added the class to the namespace
            unit.Namespaces.Add(ns); // finally added the namespace to the assembly

            return unit;
        }
    }
}
