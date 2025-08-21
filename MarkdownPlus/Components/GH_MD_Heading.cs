using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Parameters;
using Rhino.Geometry;

namespace MarkdownPlus.Components
{
    public class GH_MD_Heading : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GH_MD_Heading class.
        /// </summary>
        public GH_MD_Heading()
          : base("Markdown Heading", "MD Heading",
              "Apply Markdown Heading decorators.",
             Constants.SubSets , Constants.SubText)
        {
        }
        public override GH_Exposure Exposure => GH_Exposure.primary;

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter(Constants.Text.Name, Constants.Text.NickName, Constants.Text.Input, GH_ParamAccess.item,"");
            pManager[0].Optional = true;
            pManager.AddIntegerParameter("Level", "L", "Header Level", GH_ParamAccess.item, 0);
            pManager[1].Optional = true;

            Param_Integer paramA = (Param_Integer)pManager[1];
            paramA.AddNamedValue("Level 1", 0);
            paramA.AddNamedValue("Level 2", 1);
            paramA.AddNamedValue("Level 3", 2);
            paramA.AddNamedValue("Level 4", 3);
            paramA.AddNamedValue("Level 5", 4);
            paramA.AddNamedValue("Level 6", 5);

        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter(Constants.MarkdownText.Name, Constants.MarkdownText.NickName, Constants.MarkdownText.Output,GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string content = "";
            DA.GetData(0, ref content);

            int index = 0;
            DA.GetData(1, ref index);

            switch (index)
            {
                default:
                    DA.SetData(0, "# " + content);
                    break;
                case 1:
                    DA.SetData(0, "## " + content);
                    break;
                case 2:
                    DA.SetData(0, "### " + content);
                    break;
                case 3:
                    DA.SetData(0, "#### " + content);
                    break;
                case 4:
                    DA.SetData(0, "##### " + content);
                    break;
                case 5:
                    DA.SetData(0, "###### " + content);
                    break;
            }
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
                return Properties.Resources.MdPlus_Heading;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("18F0CB23-E1A9-4F0F-8D8F-7FF2AAC07E64"); }
        }
    }
}