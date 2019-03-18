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
    static class CloningMethodUsingCDOM
    {
        const string NamespaceName = "Project7.CodeDomBaiscs.Dynamics";
        const string TypeName = "Person";

        public static void Run()
        {
            DemoGenerateAndCreate();
        }

        static void DemoGenerateAndCreate()
        {
            var unit = GenerateCode();
            var provider = CodeDomProvider.CreateProvider("CSharp");
            var sw = new StringWriter();
            provider.GenerateCodeFromCompileUnit(unit, sw, new CodeGeneratorOptions());
            sw.Flush();
            var code = sw.ToString();
            sw.Dispose();
            File.WriteAllText("Person.cs", code);
            
            Console.WriteLine("Code:\n\n");
            Console.WriteLine(code);

            var assembly = GetAssembly(unit, provider);
            Console.WriteLine("\n\nCompiled assembly name: " + assembly.FullName);
            Console.WriteLine();
            CreateAndCloneObjects(assembly);
        }

        static void CreateAndCloneObjects(Assembly assembly)
        {
            var type = assembly.GetType($"{NamespaceName}.{TypeName}");
            var instance1 = Activator.CreateInstance(type, new object[] { "Arslan", 23 });
            var method = type.GetMethod("Clone");
            var instance2 = method.Invoke(instance1, null);

            var nameProp = type.GetProperty("Name");
            var ageProp = type.GetProperty("Age");

            Console.WriteLine($"Instance1 and Instance2 are same: {ReferenceEquals(instance1, instance1)}");
            Console.WriteLine("Instance1:");
            Console.WriteLine($"Name: {nameProp.GetValue(instance1)}");
            Console.WriteLine($"Age: {ageProp.GetValue(instance1)}");
            Console.WriteLine("Instance2:");
            Console.WriteLine($"Name: {nameProp.GetValue(instance2)}");
            Console.WriteLine($"Age: {ageProp.GetValue(instance2)}");
        }

        static Assembly GetAssembly(CodeCompileUnit unit, CodeDomProvider provider)
        {
            var compilationOptions = new CompilerParameters
            {
                GenerateExecutable = false,
                GenerateInMemory = true,
                IncludeDebugInformation = false
            };
            compilationOptions.ReferencedAssemblies.Add("mscorlib.dll");

            var compilationResult = provider.CompileAssemblyFromDom(compilationOptions, unit);
            var assembly = compilationResult.CompiledAssembly;

            return assembly;
        }

        static CodeCompileUnit GenerateCode()
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace ns = new CodeNamespace(NamespaceName);
            ns.Imports.Add(new CodeNamespaceImport("System"));

            CodeTypeDeclaration type = new CodeTypeDeclaration
            {
                Attributes = MemberAttributes.Public,
                IsClass = true,
                Name = TypeName
            };

            CodeMemberField nameBackingField = new CodeMemberField
            {
                Attributes = MemberAttributes.Private,
                Type = new CodeTypeReference(typeof(string)),
                Name = "name"
            };

            CodeMemberField ageBackingField = new CodeMemberField
            {
                Attributes = MemberAttributes.Private,
                Type = new CodeTypeReference(typeof(int)),
                Name = "age"
            };

            type.Members.Add(nameBackingField);
            type.Members.Add(ageBackingField);

            CodeMemberProperty nameProperty = new CodeMemberProperty
            {
                Attributes = MemberAttributes.Public,
                Type = new CodeTypeReference(typeof(string)),
                HasGet = true,
                HasSet = true,
                Name = "Name"
            };
            nameProperty.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "name")));
            nameProperty.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "name"), new CodePropertySetValueReferenceExpression()));

            CodeMemberProperty ageProperty = new CodeMemberProperty
            {
                Attributes = MemberAttributes.Public,
                Type = new CodeTypeReference(typeof(int)),
                HasGet = true,
                HasSet = true,
                Name = "Age"
            };
            ageProperty.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "age")));
            ageProperty.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "age"), new CodePropertySetValueReferenceExpression()));
            

            type.Members.Add(nameProperty);
            type.Members.Add(ageProperty);

            CodeConstructor ctor = new CodeConstructor
            {
                Attributes = MemberAttributes.Public
            };
            ctor.Parameters.Add(new CodeParameterDeclarationExpression(typeof(string), "name"));
            ctor.Parameters.Add(new CodeParameterDeclarationExpression(typeof(int), "age"));
            ctor.Statements.Add(new CodeAssignStatement(new CodePropertyReferenceExpression(new CodeThisReferenceExpression(), "Name"), new CodeArgumentReferenceExpression("name")));
            ctor.Statements.Add(new CodeAssignStatement(new CodePropertyReferenceExpression(new CodeThisReferenceExpression(), "Age"), new CodeArgumentReferenceExpression("age")));

            type.Members.Add(ctor);

            var cloneMethod = new CodeMemberMethod
            {
                Attributes = MemberAttributes.Public,
                ReturnType = new CodeTypeReference($"{NamespaceName}.{TypeName}"),
                Name = "Clone"
            };
            cloneMethod.Statements.Add(new CodeVariableDeclarationStatement(typeof(object), "obj"));
            cloneMethod.Statements.Add(new CodeVariableDeclarationStatement($"{NamespaceName}.{TypeName}", "downtyped"));

            cloneMethod.Statements.Add(new CodeAssignStatement(new CodeVariableReferenceExpression("obj"), new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "MemberwiseClone")));
            cloneMethod.Statements.Add(new CodeAssignStatement(new CodeVariableReferenceExpression("downtyped"), new CodeCastExpression($"{NamespaceName}.{TypeName}", new CodeVariableReferenceExpression("obj"))));
            cloneMethod.Statements.Add(new CodeMethodReturnStatement(new CodeVariableReferenceExpression("downtyped")));

            type.Members.Add(cloneMethod);

            ns.Types.Add(type);
            unit.Namespaces.Add(ns);

            return unit;
        }
    }
}
