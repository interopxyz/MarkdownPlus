using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace MarkdownPlus.Components
{
    public class GH_MD_ListTask : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GH_MD_TaskList class.
        /// </summary>
        public GH_MD_ListTask()
          : base("Markdown* Task List", "MD* Task",
              "Apply Markdown Task List decorators. Only for Extended Markdown.",
             Constants.SubSets, Constants.SubText)
        {
        }
        public override GH_Exposure Exposure => GH_Exposure.septenary;

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter(Constants.Text.Name, Constants.Text.NickName, Constants.Text.Input, GH_ParamAccess.item);
            pManager[0].Optional = false;
            pManager.AddIntegerParameter("Level", "L", "Quote Level", GH_ParamAccess.item);
            pManager[1].Optional = true;
            pManager.AddBooleanParameter("Check", "C", "Is Checked", GH_ParamAccess.item);
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

            int level = 0;
            DA.GetData(1, ref level);

            bool status = false;
            DA.GetData(2, ref status);

                string prefix = new string(' ', level * 4);
            if (status)
            {
                DA.SetData(0, prefix + "- [x] " + content);
            }
            else
            {
                DA.SetData(0, prefix + "- [ ] " + content);
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
                return Properties.Resources.MdPlus_ListTask;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("83AA8311-7F54-469C-8DC7-29DDCBF6B508"); }
        }
    }
}