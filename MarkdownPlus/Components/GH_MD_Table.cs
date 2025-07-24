using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Grasshopper.Kernel.Data;
using Grasshopper.Kernel.Types;
using Rhino.Geometry;

namespace MarkdownPlus.Components
{
    public class GH_MD_Table : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the GH_MD_Table class.
        /// </summary>
        public GH_MD_Table()
          : base("Markdown* Table", "MD* Table",
              "Create a Markdown Table from a tree of data and list of headers. Only for Extended Markdown.",
             Constants.SubSets, Constants.SubText)
        {
        }

        public override GH_Exposure Exposure => GH_Exposure.septenary;

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("Headers", "H", "The table headers", GH_ParamAccess.list);
            pManager[0].Optional = false;
            pManager.AddIntegerParameter("Alignment", "A", "Optional alignments (0=Left, 1=Center, 2=Right", GH_ParamAccess.list);
            pManager[1].Optional = true;
            pManager.AddTextParameter(Constants.Text.Name, Constants.Text.NickName, Constants.Text.Input, GH_ParamAccess.tree);
            pManager[2].Optional = false;
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

            DA.GetDataTree(2, out GH_Structure<GH_String> gooSet);

            List<string> headers = new List<string>();
            DA.GetDataList(0, headers)
                ;
            List<int> align = new List<int>();
            DA.GetDataList(1, align);
            if (align.Count < 1) align.Add(-1);

            int countA = headers.Count;
            int countB = align.Count;
            int countC = gooSet.Branches.Count;
            for (int i = countA; i < countC; i++) headers.Add("Item " + i + 1);
            for (int i = countB; i < countC; i++) align.Add(align[countB - 1]);

            string output = "|";
            foreach (string header in headers) output += " " + header + " |";
            output += Environment.NewLine + "|";

            foreach (int a in align)
            {
                switch (a)
                {
                    default:
                        output += " --- |";
                        break;
                    case 0:
                        output += " :--- |";
                        break;
                    case 1:
                        output += " :---: |";
                        break;
                    case 2:
                        output += " ---: |";
                        break;
                }
            }

            List<List<string>> flipped = new List<List<string>>();
            int c = 0;
            foreach (List<GH_String> goos in gooSet.Branches)
            {
                c = Math.Max(c, goos.Count);
                List<string> temp = new List<string>();
                foreach (GH_String goo in goos)
                {
                    temp.Add(goo.Value);
                }
                flipped.Add(temp);
            }



            for (int i = 0; i < flipped.Count; i++)
            {
                int c2 = flipped[i].Count;
                for (int j = c2; j < c; j++)
                {
                    flipped[i].Add("");
                }
            }

            for (int i = 0; i < c; i++)
            {
                output += Environment.NewLine + "|";
                for (int j = 0; j < flipped.Count; j++)
                {
                    output += " " + flipped[j][i] + " |";
                }
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
                return Properties.Resources.MdPlus_Table;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("5919C9EE-59A7-4CB9-8F85-CA78ED61FACD"); }
        }
    }
}