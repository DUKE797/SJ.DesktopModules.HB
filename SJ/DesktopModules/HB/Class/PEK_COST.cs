namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.IO;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class PEK_COST : ICacheableClass, IAutoFieldAble
    {
        public float COST;
        public long CreateTime;
        public int Creator;
        public string DBI_ID;
        public int Deleter;
        public long DeleteTime;
        public float ELECTRICITY;
        public int Id;
        public int IsDelete;
        public int Modifier;
        public long ModifyTime;
        public string MONTH;
        public int OrderId;
        public string PLANT_NAME;
        public float PRICE;
        public string Reason;
        public int RecordStatus;
        public int Submiter;
        public long SubmitTime;
        public string YEAR;

        public PEK_COST()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            PEK_COST pek_cost;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            pek_cost = Get(__nID);
            pek_cost.IsDelete = 1;
            pek_cost.Deleter = FunUtil.GetCurrentUserID();
            pek_cost.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(pek_cost).set(pek_cost);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            PEK_COST pek_cost;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            pek_cost = new PEK_COST();
            pek_cost.Id = __nID;
            CommonClassDB.Instance(pek_cost).delte(pek_cost);
        Label_0028:
            return;
        }

        public static PEK_COST Get(int __nID)
        {
            PEK_COST pek_cost;
            PEK_COST pek_cost2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            pek_cost2 = null;
            goto Label_0037;
        Label_0010:
            pek_cost = new PEK_COST();
            pek_cost.Id = __nID;
            pek_cost2 = (PEK_COST) CommonClassDB.Instance(pek_cost).get(pek_cost, pek_cost.Id);
        Label_0037:
            return pek_cost2;
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
            str = "PEK_COST";
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
            if ((File.Exists(string.Format("{0}PEK_COST.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_0031;
            }
            goto Label_0187;
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
            hashtable["PLANT_NAME"] = "电厂名称";
            hashtable["DBI_ID"] = "D5000的ID";
            hashtable["YEAR"] = "年份";
            hashtable["MONTH"] = "月度";
            hashtable["ELECTRICITY"] = "电量";
            hashtable["PRICE"] = "平均电价";
            hashtable["COST"] = "电费";
        Label_0187:
            hashtable2 = hashtable;
        Label_018B:
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
            PEK_COST[] pek_costArray;
            int num;
            bool flag;
            pek_costArray = List();
            if (((pek_costArray == null) ? 0 : ((((int) pek_costArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = pek_costArray[((int) pek_costArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static PEK_COST[] List()
        {
            PEK_COST pek_cost;
            PEK_COST[] pek_costArray;
            pek_cost = new PEK_COST();
            pek_costArray = (PEK_COST[]) CommonClassDB.Instance(pek_cost).load(pek_cost, "OrderId");
        Label_0020:
            return pek_costArray;
        }

        public static PEK_COST[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            PEK_COST pek_cost;
            PEK_COST[] pek_costArray;
            PEK_COST[] pek_costArray2;
            pek_cost = new PEK_COST();
            pek_costArray = (PEK_COST[]) CommonClassDB.Instance(pek_cost).load(pek_cost, __nPageIndex, __nPageSize, __strFilter, __strSort);
            pek_costArray2 = pek_costArray;
        Label_0021:
            return pek_costArray2;
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
    }
}

