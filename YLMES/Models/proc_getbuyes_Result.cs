//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YLMES.Models
{
    using System;
    
    public partial class proc_getbuyes_Result
    {
        public string Status { get; set; }
        public string PartNumber { get; set; }
        public string PartSpec { get; set; }
        public string figureNumber { get; set; }
        public string PartMaterial { get; set; }
        public Nullable<int> ActPurchasePCS { get; set; }
        public Nullable<int> ActPurchaseQTY { get; set; }
        public Nullable<int> ApplyPurchasePCS { get; set; }
        public Nullable<int> ApplyPurchaseQTY { get; set; }
        public Nullable<int> MaterialID { get; set; }
        public int ID { get; set; }
        public string PONO { get; set; }
    }
}
