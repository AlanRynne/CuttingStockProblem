using System;
using System.Drawing;
using Grasshopper;
using Grasshopper.Kernel;

namespace CuttingStockComponent
{
    public class CuttingStockComponentInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "CuttingStockComponent Info";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("ae99ee61-85ed-4f28-83a7-dcf3ac8d7ca1");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
