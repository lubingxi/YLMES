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
    
    public partial class Install_check_Result
    {
        public int 序号 { get; set; }
        public int 合同编号 { get; set; }
        public string 产品名称 { get; set; }
        public string 客户产品名称 { get; set; }
        public string 产品规格 { get; set; }
        public string 单位 { get; set; }
        public Nullable<decimal> 合同数量 { get; set; }
        public Nullable<decimal> 发货数量 { get; set; }
        public Nullable<decimal> 已安装数量 { get; set; }
        public int 今安装数量 { get; set; }
        public string 完成时间 { get; set; }
        public string 是否验收 { get; set; }
        public string 验收时间 { get; set; }
    }
}
