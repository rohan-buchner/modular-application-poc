using HotChocolate.Types;

namespace Testbed.API
{
    public class RenameDirectiveType : DirectiveType
    {
        public const string DirectiveName = "rename";
        public const string ArgumentName = "name";

        protected override void Configure(IDirectiveTypeDescriptor descriptor)
        {
            descriptor.Name(DirectiveName);
            descriptor.Location(HotChocolate.Types.DirectiveLocation.Object);
            descriptor.Argument(ArgumentName)
                .Type<NonNullType<NameType>>();
        }
    }
}