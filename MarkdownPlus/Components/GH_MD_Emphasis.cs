using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace MarkdownPlus.Components
{
    public class GH_MD_Emphasis : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GH_MD_Emphasis class.
        /// </summary>
        public GH_MD_Emphasis()
          : base("Markdown Emphasis", "MD Emphasis",
              "Apply Markdown Emphasis decorators.",
             Constants.SubSets, Constants.SubText)
        {
        }
        public override GH_Exposure Exposure => GH_Exposure.primary;

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter(Constants.Text.Name, Constants.Text.NickName, Constants.Text.Input, GH_ParamAccess.item, "");
            pManager[0].Optional = true;
            pManager.AddBooleanParameter("Bold", "B", "Is Bold", GH_ParamAccess.item, false);
            pManager[1].Optional = true;
            pManager.AddBooleanParameter("Italic", "I", "Is Italic", GH_ParamAccess.item, false);
            pManager[2].Optional = true;

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
            string content = "";
            DA.GetData(0, ref content);

            bool isBold = false;
            DA.GetData(1, ref isBold);

            bool isItalic = false;
            DA.GetData(2, ref isItalic);

            if(isBold & isItalic)
            {
                DA.SetData(0, "***"+content+"***");
                return;
            }
            
            if (isBold)
            {
                DA.SetData(0, "**" + content + "**");
                return;
            }

            if (isItalic)
            {
                DA.SetData(0, "*" + content + "*");
                return;
            }

            DA.SetData(0, content);
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
                return Properties.Resources.MdPlus_Emphasis;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("D606FCAE-79F5-4EB0-9420-A35FBA35C623"); }
        }
    }
}