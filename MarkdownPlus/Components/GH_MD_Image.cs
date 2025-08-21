using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace MarkdownPlus.Components
{
    public class GH_MD_Image : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GH_MD_Image class.
        /// </summary>
        public GH_MD_Image()
          : base("Markdown Image", "MD Image",
              "Create a Markdown Image text.",
             Constants.SubSets, Constants.SubText)
        {
        }
        public override GH_Exposure Exposure => GH_Exposure.primary | GH_Exposure.obscure;

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter(Constants.Text.Name, Constants.Text.NickName, Constants.Text.Input, GH_ParamAccess.item, "");
            pManager[0].Optional = true;
            pManager.AddTextParameter("Image Path", "I", "The Path or URL to the image", GH_ParamAccess.item);
            pManager[1].Optional = false;
            pManager.AddTextParameter("Title", "L", "The Hyperlink text", GH_ParamAccess.item);
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

            string hyperlink = "";
            DA.GetData(1, ref hyperlink);

            string title = "";
            if(DA.GetData(2, ref title)) title = " \""+title+ "\"";

            DA.SetData(0, "![" + content + "](" + hyperlink +title + ")");
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
                return Properties.Resources.MdPlus_Image;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("75D567A8-95B1-4503-B10E-988B5E65CE54"); }
        }
    }
}