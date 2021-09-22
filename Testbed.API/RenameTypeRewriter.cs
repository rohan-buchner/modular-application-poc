using System.Linq;
using HotChocolate.Language;
using HotChocolate.Stitching.Merge;
using HotChocolate.Stitching.Merge.Rewriters;

namespace Testbed.API
{
    public class RenameTypeRewriter : ITypeRewriter
    {
        public ITypeDefinitionNode Rewrite(ISchemaInfo schema, ITypeDefinitionNode typeDefinition)
        {
            var renameDirective = typeDefinition.Directives.SingleOrDefault(d => d.Name.Value == RenameDirectiveType.DirectiveName);

            if (renameDirective != null) {
                var newNameArgumment = renameDirective.Arguments.Single(a => a.Name.Value == RenameDirectiveType.ArgumentName );

                if (newNameArgumment.Value is StringValueNode stringValue) {
                    return typeDefinition.Rename(stringValue.Value, schema.Name);
                }
            }

            return typeDefinition;
        }
    }
}