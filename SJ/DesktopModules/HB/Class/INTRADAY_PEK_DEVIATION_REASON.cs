namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.IO;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class INTRADAY_PEK_DEVIATION_REASON : ICacheableClass, IAutoFieldAble
    {
        public long CreateTime;
        public int Creator;
        public string DBI_ID;
        public int Deleter;
        public long DeleteTime;
        public float END_POINT;
        public int Id;
        public int IsDelete;
        public int Modifier;
        public long ModifyTime;
        public int OrderId;
        public string PLANT_NAME;
        public string Reason;
        public int RecordStatus;
        public DateTime RESULT_DATE;
        public float START_POINT;
        public int Submiter;
        public long SubmitTime;
        public int UINTERVAL;
        public string UREASON;

        public INTRADAY_PEK_DEVIATION_REASON()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            INTRADAY_PEK_DEVIATION_REASON intraday_pek_deviation_reason;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            intraday_pek_deviation_reason = Get(__nID);
            intraday_pek_deviation_reason.IsDelete = 1;
            intraday_pek_deviation_reason.Deleter = FunUtil.GetCurrentUserID();
            intraday_pek_deviation_reason.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(intraday_pek_deviation_reason).set(intraday_pek_deviation_reason);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            INTRADAY_PEK_DEVIATION_REASON intraday_pek_deviation_reason;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            intraday_pek_deviation_reason = new INTRADAY_PEK_DEVIATION_REASON();
            intraday_pek_deviation_reason.Id = __nID;
            CommonClassDB.Instance(intraday_pek_deviation_reason).delte(intraday_pek_deviation_reason);
        Label_0028:
            return;
        }

        public static INTRADAY_PEK_DEVIATION_REASON Get(int __nID)
        {
            INTRADAY_PEK_DEVIATION_REASON intraday_pek_deviation_reason;
            INTRADAY_PEK_DEVIATION_REASON intraday_pek_deviation_reason2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            intraday_pek_deviation_reason2 = null;
            goto Label_0037;
        Label_0010:
            intraday_pek_deviation_reason = new INTRADAY_PEK_DEVIATION_REASON();
            intraday_pek_deviation_reason.Id = __nID;
            intraday_pek_deviation_reason2 = (INTRADAY_PEK_DEVIATION_REASON) CommonClassDB.Instance(intraday_pek_deviation_reason).get(intraday_pek_deviation_reason, intraday_pek_deviation_reason.Id);
        Label_0037:
            return intraday_pek_deviation_reason2;
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
            str = "INTRADAY_PEK_DEVIATION_REASON";
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
            if ((File.Exists(string.Format("{0}INTRADAY_PEK_DEVIATION_REASON.AutoField", strArray[1])) == 0) != null)
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
            hashtable["RESULT_DATE"] = "对应日期";
            hashtable["UINTERVAL"] = "交易时段";
            hashtable["START_POINT"] = "起始时段";
            hashtable["END_POINT"] = "结束时段";
            hashtable["UREASON"] = "原因";
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
            INTRADAY_PEK_DEVIATION_REASON[] intraday_pek_deviation_reasonArray;
            int num;
            bool flag;
            intraday_pek_deviation_reasonArray = List();
            if (((intraday_pek_deviation_reasonArray == null) ? 0 : ((((int) intraday_pek_deviation_reasonArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = intraday_pek_deviation_reasonArray[((int) intraday_pek_deviation_reasonArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static INTRADAY_PEK_DEVIATION_REASON[] List()
        {
            INTRADAY_PEK_DEVIATION_REASON intraday_pek_deviation_reason;
            INTRADAY_PEK_DEVIATION_REASON[] intraday_pek_deviation_reasonArray;
            intraday_pek_deviation_reason = new INTRADAY_PEK_DEVIATION_REASON();
            intraday_pek_deviation_reasonArray = (INTRADAY_PEK_DEVIATION_REASON[]) CommonClassDB.Instance(intraday_pek_deviation_reason).load(intraday_pek_deviation_reason, "OrderId");
        Label_0020:
            return intraday_pek_deviation_reasonArray;
        }

        public static INTRADAY_PEK_DEVIATION_REASON[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            INTRADAY_PEK_DEVIATION_REASON intraday_pek_deviation_reason;
            INTRADAY_PEK_DEVIATION_REASON[] intraday_pek_deviation_reasonArray;
            INTRADAY_PEK_DEVIATION_REASON[] intraday_pek_deviation_reasonArray2;
            intraday_pek_deviation_reason = new INTRADAY_PEK_DEVIATION_REASON();
            intraday_pek_deviation_reasonArray = (INTRADAY_PEK_DEVIATION_REASON[]) CommonClassDB.Instance(intraday_pek_deviation_reason).load(intraday_pek_deviation_reason, __nPageIndex, __nPageSize, __strFilter, __strSort);
            intraday_pek_deviation_reasonArray2 = intraday_pek_deviation_reasonArray;
        Label_0021:
            return intraday_pek_deviation_reasonArray2;
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

