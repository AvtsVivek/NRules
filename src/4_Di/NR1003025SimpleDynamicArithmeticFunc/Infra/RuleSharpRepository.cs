using NRules.RuleModel;
using NRules.RuleSharp;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace NR1003025SimpleDynamicArithmeticFunc.Infra
{
    public interface IRuleSharpRepository : IRuleRepository {

        //
        // Summary:
        //     Adds a namespace that applies to all rules loaded to the repository.
        //
        // Parameters:
        //   namespace:
        //     Namespace to add to the default set of namespaces.
        public void AddNamespace(string @namespace);
        //
        // Summary:
        //     Adds a reference assembly for types used in the rules.
        //
        // Parameters:
        //   assembly:
        //     Reference assembly.
        public void AddReference(Assembly assembly);
        //
        // Summary:
        //     Adds reference assemblies for types used in the rules.
        //
        // Parameters:
        //   assemblies:
        //     Reference assemblies.
        public void AddReferences(IEnumerable<Assembly> assemblies);
        //
        // Summary:
        //     Loads rules into the repository from the specified files.
        //
        // Parameters:
        //   fileNames:
        //     Names of the rule files to load into the repository.
        //
        // Exceptions:
        //   T:NRules.RuleSharp.RulesParseException:
        //     Error while parsing the rules.
        public void Load(IEnumerable<string> fileNames);
        //
        // Summary:
        //     Loads rules into the repository from the specified file.
        //
        // Parameters:
        //   fileName:
        //     Name of the rule file to load into the repository.
        //
        // Exceptions:
        //   T:NRules.RuleSharp.RulesParseException:
        //     Error while parsing the rules.
        public void Load(string fileName);
        //
        // Summary:
        //     Loads rules into the repository from a stream.
        //
        // Parameters:
        //   stream:
        //     Stream to load the rules from.
        //
        // Exceptions:
        //   T:NRules.RuleSharp.RulesParseException:
        //     Error while parsing the rules.
        public void Load(Stream stream);
        //
        // Summary:
        //     Loads rules into the repository from a string.
        //
        // Parameters:
        //   text:
        //     String containing the rules.
        //
        // Exceptions:
        //   T:NRules.RuleSharp.RulesParseException:
        //     Error while parsing the rules.
        public void LoadText(string text);
        //
        // Summary:
        //     Loads rules into the repository from a text reader.
        //
        // Parameters:
        //   reader:
        //     Text reader with the rules contents.
        //
        // Exceptions:
        //   T:NRules.RuleSharp.RulesParseException:
        //     Error while parsing the rules.
        public void LoadText(TextReader reader);

    }
    public class RuleSharpRepository : RuleRepository, IRuleSharpRepository
    { }
}
