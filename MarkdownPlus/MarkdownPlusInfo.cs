using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace MarkdownPlus
{
    public class MarkdownPlusInfo : GH_AssemblyInfo
    {
        public override string Name => "MarkdownPlus";

        //Return a 24x24 pixel bitmap to represent this GHA library.
        public override Bitmap Icon => Properties.Resources.MarkdownPlus_Logo_24;

        //Return a short string describing the purpose of this GHA library.
        public override string Description => "Add markdown language string modifiers";

        public override Guid Id => new Guid("0BCA3D19-C858-4518-B8D3-1E066DFFCE8E");

        //Return a string identifying you or your company.
        public override string AuthorName => "David Mans";

        //Return a string representing your preferred contact details.
        public override string AuthorContact => "interopxyz@gmail.com";

        public override string AssemblyVersion => "1.0.1.0";
    }
}