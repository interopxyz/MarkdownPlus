using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;

namespace MarkdownPlus.Components
{
    public class GH_MD_ListOrdered : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GH_MD_OrderedList class.
        /// </summary>
        public GH_MD_ListOrdered()
          : base("Markdown Ordered List", "MD List",
              "Apply Markdown Ordered List decorators.",
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
            pManager[0].Optional = false;
            pManager.AddIntegerParameter("Level", "L", "Quote Level", GH_ParamAccess.list);
            pManager[1].Optional = true;
            pManager.AddIntegerParameter("Start Number", "S", "The starting number of the sequence", GH_ParamAccess.item, 1);
            pManager[2].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter(Constants.MarkdownText.Name, Constants.MarkdownText.NickName, Constants.MarkdownText.Output, GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<string> content = new List<string>();
            DA.GetDataList(0, content);

            List<int> levels = new List<int>();
            DA.GetDataList(1, levels);
            if (levels.Count == 0) levels.Add(0);

            int countA = levels.Count;
            int countB = content.Count;
            for (int i = countA; i < countB; i++) levels.Add(levels[countA - 1]);

            int start = 1;
            DA.GetData(2, ref start);

            List<string> output = new List<string>();
            for(int i = 0; i < content.Count; i++)
            {
                string prefix = new string(' ', levels[i] * 4);
                output.Add(prefix + (i + start) + ". " + content[i]);
            }

            DA.SetDataList(0, output);
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
                return Properties.Resources.MdPlus_ListOrdered;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("10ACDA6D-8C69-41A2-B70C-4D63D6BB2BC9"); }
        }
    }
}