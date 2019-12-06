namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.IO;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class PEK_RESULT : ICacheableClass, IAutoFieldAble
    {
        public double COST;
        public long CreateTime;
        public int Creator;
        public string DBI_ID;
        public int Deleter;
        public long DeleteTime;
        public double ELECTRICITY;
        public int Id;
        public int IsDelete;
        public int Modifier;
        public long ModifyTime;
        public string MONTH;
        public int OrderId;
        public string PLANT_NAME;
        public double PRICE;
        public string PROV_NAME;
        public string Reason;
        public int RecordStatus;
        public int Submiter;
        public long SubmitTime;
        public string UID;
        public string YEAR;

        public PEK_RESULT()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            PEK_RESULT pek_result;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            pek_result = Get(__nID);
            pek_result.IsDelete = 1;
            pek_result.Deleter = FunUtil.GetCurrentUserID();
            pek_result.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(pek_result).set(pek_result);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            PEK_RESULT pek_result;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            pek_result = new PEK_RESULT();
            pek_result.Id = __nID;
            CommonClassDB.Instance(pek_result).delte(pek_result);
        Label_0028:
            return;
        }

        public static PEK_RESULT Get(int __nID)
        {
            PEK_RESULT pek_result;
            PEK_RESULT pek_result2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            pek_result2 = null;
            goto Label_0037;
        Label_0010:
            pek_result = new PEK_RESULT();
            pek_result.Id = __nID;
            pek_result2 = (PEK_RESULT) CommonClassDB.Instance(pek_result).get(pek_result, pek_result.Id);
        Label_0037:
            return pek_result2;
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
            str = "PEK_RESULT";
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
            if ((File.Exists(string.Format("{0}PEK_RESULT.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_0031;
            }
            goto Label_01A9;
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
            hashtable["PROV_NAME"] = "省份名称";
            hashtable["YEAR"] = "结算年份";
            hashtable["MONTH"] = "结算月度";
            hashtable["UID"] = "结算单元id";
            hashtable["ELECTRICITY"] = "电量";
            hashtable["PRICE"] = "电价";
            hashtable["COST"] = "电费";
        Label_01A9:
            hashtable2 = hashtable;
        Label_01AD:
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
            PEK_RESULT[] pek_resultArray;
            int num;
            bool flag;
            pek_resultArray = List();
            if (((pek_resultArray == null) ? 0 : ((((int) pek_resultArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = pek_resultArray[((int) pek_resultArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static PEK_RESULT[] List()
        {
            PEK_RESULT pek_result;
            PEK_RESULT[] pek_resultArray;
            pek_result = new PEK_RESULT();
            pek_resultArray = (PEK_RESULT[]) CommonClassDB.Instance(pek_result).load(pek_result, "OrderId");
        Label_0020:
            return pek_resultArray;
        }

        public static PEK_RESULT[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            PEK_RESULT pek_result;
            PEK_RESULT[] pek_resultArray;
            PEK_RESULT[] pek_resultArray2;
            pek_result = new PEK_RESULT();
            pek_resultArray = (PEK_RESULT[]) CommonClassDB.Instance(pek_result).load(pek_result, __nPageIndex, __nPageSize, __strFilter, __strSort);
            pek_resultArray2 = pek_resultArray;
        Label_0021:
            return pek_resultArray2;
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

