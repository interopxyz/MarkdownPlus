using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace MarkdownPlus.Components
{
    public class GH_MD_CodeBlock : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GH_MD_CodeBlock class.
        /// </summary>
        public GH_MD_CodeBlock()
          : base("Markdown Code Block", "MD Code Block",
              "Create a Markdown Code block from a list of text.",
             Constants.SubSets, Constants.SubText)
        {
        }
        public override GH_Exposure Exposure => GH_Exposure.primary | GH_Exposure.obscure;

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter(Constants.Text.Name, Constants.Text.NickName, Constants.Text.Input, GH_ParamAccess.list);
            pManager[0].Optional = true;
            pManager.AddBooleanParameter("Fenced", "F", "If true, Extended Syntax fenced code will be used.", GH_ParamAccess.item);
            pManager[1].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter(Constants.MarkdownText.Name, Constants.MarkdownText.NickName, Constants.MarkdownText.Output, GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<string> content = new List<string>();
            DA.GetDataList(0, content);

            bool isFenced = false;
            DA.GetData(1, ref isFenced);

            string output = "";
            if (isFenced)
            {
                output += "```" + Environment.NewLine;
                foreach (string txt in content) output += txt + Environment.NewLine;
                output += "```";
            }
            else
            {
                output += Environment.NewLine;
                foreach (string txt in content) output += "    " + txt + Environment.NewLine;
            }
            DA.SetData(0, output);

        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return Properties.Resources.MdPlus_CodeBlock;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("1E7ED9C1-11FC-4BD5-9A3F-38D251413E72"); }
        }
    }
}