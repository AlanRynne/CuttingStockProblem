using System;
using System.Collections.Generic;

using Grasshopper;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace CuttingStockComponent
{
    public class CuttingStockComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public CuttingStockComponent()
          : base("Cutting Stock", "CStock",
            "Calculate best 1 Dimensional nesting for cutting Rods/Planks",
            "Alan", "Gridshells")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddNumberParameter("Desired Cuts", "Cuts", "Lengths of desired cuts", GH_ParamAccess.list);
            pManager.AddNumberParameter("Available Stock Lengths", "Stock", "Lengths of available material in stock", GH_ParamAccess.list);
            pManager.AddTextParameter("Labels for the cuts", "Labels", "Labels of the cut rods", GH_ParamAccess.list);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddTextParameter("T", "t", "text", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<double> desiredCuts = new List<double>();
            List<double> availableStock = new List<double>();
            List<String> desiredCutsLabels = new List<string>();

            if(!DA.GetDataList(0, desiredCuts)) return;
            if(!DA.GetDataList(1, availableStock)) return;
            if(!DA.GetDataList(2, desiredCutsLabels)) return;

            CuttingStockClass ctc = new CuttingStockClass(desiredCuts,availableStock,desiredCutsLabels);
            List<String> st = ctc.CutStock();

            DA.SetDataList(0, st);
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("37c545da-a281-42ba-af41-bd6d0e0be476"); }
        }
    }
}
