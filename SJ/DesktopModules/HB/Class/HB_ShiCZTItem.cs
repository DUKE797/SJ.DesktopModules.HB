namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.IO;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class HB_ShiCZTItem : ICacheableClass, IAutoFieldAble
    {
        public string BeiZ;
        public long CreateTime;
        public int Creator;
        public int Deleter;
        public long DeleteTime;
        public string DianLYWXKZ;
        public string DiaoDGX;
        public string DiLQY;
        public long EnterDate;
        public long ExitDate;
        public string HangYLB;
        public int Id;
        public int IsDelete;
        public int Modifier;
        public long ModifyTime;
        public string Name;
        public int OrderId;
        public string Reason;
        public int RecordStatus;
        public int Submiter;
        public long SubmitTime;
        public string Type;
        public int UserId;
        public string YingYZZ;

        public HB_ShiCZTItem()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            HB_ShiCZTItem item;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            item = Get(__nID);
            item.IsDelete = 1;
            item.Deleter = FunUtil.GetCurrentUserID();
            item.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(item).set(item);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            HB_ShiCZTItem item;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            item = new HB_ShiCZTItem();
            item.Id = __nID;
            CommonClassDB.Instance(item).delte(item);
        Label_0028:
            return;
        }

        public static HB_ShiCZTItem Get(int __nID)
        {
            HB_ShiCZTItem item;
            HB_ShiCZTItem item2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            item2 = null;
            goto Label_0037;
        Label_0010:
            item = new HB_ShiCZTItem();
            item.Id = __nID;
            item2 = (HB_ShiCZTItem) CommonClassDB.Instance(item).get(item, item.Id);
        Label_0037:
            return item2;
        }

        public static HB_ShiCZTItem GetByName(string __strName)
        {
            HB_ShiCZTItem item;
            HB_ShiCZTItem[] itemArray;
            HB_ShiCZTItem item2;
            bool flag;
            if ((string.IsNullOrEmpty(__strName) == 0) != null)
            {
                goto Label_0012;
            }
            item2 = null;
            goto Label_0074;
        Label_0012:
            item = new HB_ShiCZTItem();
            item.IsDelete = 2;
            item.Name = __strName;
            itemArray = (HB_ShiCZTItem[]) CommonClassDB.Instance(item).load(item);
            if (((itemArray == null) ? 0 : ((((int) itemArray.Length) < 1) == 0)) != null)
            {
                goto Label_0050;
            }
            item2 = null;
            goto Label_0074;
        Label_0050:
            if (((((int) itemArray.Length) > 1) == 0) != null)
            {
                goto Label_006E;
            }
            throw new Exception(string.Format("Name={0} exist multi ShiCZTItem", __strName));
        Label_006E:
            item2 = itemArray[0];
        Label_0074:
            return item2;
        }

        public static HB_ShiCZTItem GetByUserId(int __nUserId)
        {
            HB_ShiCZTItem item;
            HB_ShiCZTItem[] itemArray;
            HB_ShiCZTItem item2;
            bool flag;
            if (((__nUserId == 0) == 0) != null)
            {
                goto Label_0010;
            }
            item2 = null;
            goto Label_0077;
        Label_0010:
            item = new HB_ShiCZTItem();
            item.IsDelete = 2;
            item.UserId = __nUserId;
            itemArray = (HB_ShiCZTItem[]) CommonClassDB.Instance(item).load(item);
            if (((itemArray == null) ? 0 : ((((int) itemArray.Length) < 1) == 0)) != null)
            {
                goto Label_004E;
            }
            item2 = null;
            goto Label_0077;
        Label_004E:
            if (((((int) itemArray.Length) > 1) == 0) != null)
            {
                goto Label_0071;
            }
            throw new Exception(string.Format("UserId={0} exist multi ShiCZTItem", (int) __nUserId));
        Label_0071:
            item2 = itemArray[0];
        Label_0077:
            return item2;
        }

        public string GetCacheKey()
        {
            string str;
            string str2;
            bool flag;
            str = "";
            if (((this.Id > 0) == 0) != null)
            {
                goto Label_002E;
            }
            str = str + "id=" + ((int) this.Id);
        Label_002E:
            str2 = str;
        Label_0032:
            return str2;
        }

        public string GetCacheTableName()
        {
            string str;
            str = "HB_ShiCZTItem";
        Label_0009:
            return str;
        }

        public Hashtable GetFieldNameHash()
        {
            Hashtable hashtable;
            string[] strArray;
            string str;
            Hashtable hashtable2;
            bool flag;
            hashtable = new Hashtable();
            strArray = CustomerUtil.GetTemplateRootPath();
            if ((File.Exists(string.Format("{0}ShiCZTItem.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_0031;
            }
            goto Label_01CB;
        Label_0031:
            hashtable["Id"] = "唯一Id";
            hashtable["Creator"] = "创建人";
            hashtable["CreateTime"] = "创建时间";
            hashtable["Modifier"] = "修改人";
            hashtable["ModifyTime"] = "修改时间";
            hashtable["Deleter"] = "删除人";
            hashtable["DeleteTime"] = "删除时间";
            hashtable["IsDelete"] = "是否删除";
            hashtable["RecordStatus"] = "记录状态";
            hashtable["Submiter"] = "提交人";
            hashtable["SubmitTime"] = "提交时间";
            hashtable["Reason"] = "审核原因";
            hashtable["OrderId"] = "排序号";
            hashtable["Name"] = "成员名称";
            hashtable["Type"] = "成员类型";
            hashtable["HangYLB"] = "行业类别";
            hashtable["DiLQY"] = "地理区域";
            hashtable["DiaoDGX"] = "调度关系";
            hashtable["EnterDate"] = "入市时间";
            hashtable["ExitDate"] = "退市时间";
            hashtable["YingYZZ"] = "营业执照扫描件";
            hashtable["DianLYWXKZ"] = "电力业务许可证扫描件";
            hashtable["BeiZ"] = "备注";
            hashtable["UserId"] = "用户Id";
        Label_01CB:
            hashtable2 = hashtable;
        Label_01CF:
            return hashtable2;
        }

        public Hashtable GetListFieldNameHash()
        {
            Hashtable hashtable;
            hashtable = null;
        Label_0005:
            return hashtable;
        }

        public static int GetNextOrderID()
        {
            HB_ShiCZTItem[] itemArray;
            int num;
            bool flag;
            itemArray = List();
            if (((itemArray == null) ? 0 : ((((int) itemArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = itemArray[((int) itemArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static HB_ShiCZTItem[] List()
        {
            HB_ShiCZTItem item;
            HB_ShiCZTItem[] itemArray;
            item = new HB_ShiCZTItem();
            itemArray = (HB_ShiCZTItem[]) CommonClassDB.Instance(item).load(item, "OrderId");
        Label_0020:
            return itemArray;
        }

        public static HB_ShiCZTItem[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            HB_ShiCZTItem item;
            HB_ShiCZTItem[] itemArray;
            HB_ShiCZTItem[] itemArray2;
            item = new HB_ShiCZTItem();
            itemArray = (HB_ShiCZTItem[]) CommonClassDB.Instance(item).load(item, __nPageIndex, __nPageSize, __strFilter, __strSort);
            itemArray2 = itemArray;
        Label_0021:
            return itemArray2;
        }

        public string CreatorName
        {
            get
            {
                UserInfo info;
                string str;
                bool flag;
                info = UserInfo.Get(this.Creator);
                if (((info == null) == 0) != null)
                {
                    goto Label_0020;
                }
                str = "";
                goto Label_0029;
            Label_0020:
                str = info.RealName;
            Label_0029:
                return str;
            }
        }

        public string DisplayRecordStatus
        {
            get
            {
                string str;
                bool flag;
                if (((this.RecordStatus == 1) == 0) != null)
                {
                    goto Label_0019;
                }
                str = "录入中";
                goto Label_006A;
            Label_0019:
                if (((this.RecordStatus == 2) == 0) != null)
                {
                    goto Label_0031;
                }
                str = "已提交";
                goto Label_006A;
            Label_0031:
                if (((this.RecordStatus == 3) == 0) != null)
                {
                    goto Label_0049;
                }
                str = "审核通过";
                goto Label_006A;
            Label_0049:
                if (((this.RecordStatus == 0x1f) == 0) != null)
                {
                    goto Label_0062;
                }
                str = "退回";
                goto Label_006A;
            Label_0062:
                str = "";
            Label_006A:
                return str;
            }
        }
    }
}

