namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.IO;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class PEK_INTRADAY_REASON : ICacheableClass, IAutoFieldAble
    {
        public long CreateTime;
        public int Creator;
        public string DBI_ID;
        public int Deleter;
        public long DeleteTime;
        public double END_POINT;
        public int Id;
        public int IsDelete;
        public int Modifier;
        public long ModifyTime;
        public int OrderId;
        public string PLANT_NAME;
        public string Reason;
        public int RecordStatus;
        public DateTime RESULT_DATE;
        public double START_POINT;
        public int Submiter;
        public long SubmitTime;
        public string UREASON;

        public PEK_INTRADAY_REASON()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            PEK_INTRADAY_REASON pek_intraday_reason;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            pek_intraday_reason = Get(__nID);
            pek_intraday_reason.IsDelete = 1;
            pek_intraday_reason.Deleter = FunUtil.GetCurrentUserID();
            pek_intraday_reason.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(pek_intraday_reason).set(pek_intraday_reason);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            PEK_INTRADAY_REASON pek_intraday_reason;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            pek_intraday_reason = new PEK_INTRADAY_REASON();
            pek_intraday_reason.Id = __nID;
            CommonClassDB.Instance(pek_intraday_reason).delte(pek_intraday_reason);
        Label_0028:
            return;
        }

        public static PEK_INTRADAY_REASON Get(int __nID)
        {
            PEK_INTRADAY_REASON pek_intraday_reason;
            PEK_INTRADAY_REASON pek_intraday_reason2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            pek_intraday_reason2 = null;
            goto Label_0037;
        Label_0010:
            pek_intraday_reason = new PEK_INTRADAY_REASON();
            pek_intraday_reason.Id = __nID;
            pek_intraday_reason2 = (PEK_INTRADAY_REASON) CommonClassDB.Instance(pek_intraday_reason).get(pek_intraday_reason, pek_intraday_reason.Id);
        Label_0037:
            return pek_intraday_reason2;
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
            str = "PEK_INTRADAY_REASON";
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
            if ((File.Exists(string.Format("{0}PEK_INTRADAY_REASON.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_0031;
            }
            goto Label_0176;
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
            hashtable["RESULT_DATE"] = "对应日期";
            hashtable["START_POINT"] = "起始时段";
            hashtable["END_POINT"] = "结束时段";
            hashtable["UREASON"] = "原因";
        Label_0176:
            hashtable2 = hashtable;
        Label_017A:
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
            PEK_INTRADAY_REASON[] pek_intraday_reasonArray;
            int num;
            bool flag;
            pek_intraday_reasonArray = List();
            if (((pek_intraday_reasonArray == null) ? 0 : ((((int) pek_intraday_reasonArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = pek_intraday_reasonArray[((int) pek_intraday_reasonArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static PEK_INTRADAY_REASON[] List()
        {
            PEK_INTRADAY_REASON pek_intraday_reason;
            PEK_INTRADAY_REASON[] pek_intraday_reasonArray;
            pek_intraday_reason = new PEK_INTRADAY_REASON();
            pek_intraday_reasonArray = (PEK_INTRADAY_REASON[]) CommonClassDB.Instance(pek_intraday_reason).load(pek_intraday_reason, "OrderId");
        Label_0020:
            return pek_intraday_reasonArray;
        }

        public static PEK_INTRADAY_REASON[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            PEK_INTRADAY_REASON pek_intraday_reason;
            PEK_INTRADAY_REASON[] pek_intraday_reasonArray;
            PEK_INTRADAY_REASON[] pek_intraday_reasonArray2;
            pek_intraday_reason = new PEK_INTRADAY_REASON();
            pek_intraday_reasonArray = (PEK_INTRADAY_REASON[]) CommonClassDB.Instance(pek_intraday_reason).load(pek_intraday_reason, __nPageIndex, __nPageSize, __strFilter, __strSort);
            pek_intraday_reasonArray2 = pek_intraday_reasonArray;
        Label_0021:
            return pek_intraday_reasonArray2;
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

