namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.IO;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class RESERVE_RESULT : ICacheableClass, IAutoFieldAble
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

        public RESERVE_RESULT()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            RESERVE_RESULT reserve_result;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            reserve_result = Get(__nID);
            reserve_result.IsDelete = 1;
            reserve_result.Deleter = FunUtil.GetCurrentUserID();
            reserve_result.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(reserve_result).set(reserve_result);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            RESERVE_RESULT reserve_result;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            reserve_result = new RESERVE_RESULT();
            reserve_result.Id = __nID;
            CommonClassDB.Instance(reserve_result).delte(reserve_result);
        Label_0028:
            return;
        }

        public static RESERVE_RESULT Get(int __nID)
        {
            RESERVE_RESULT reserve_result;
            RESERVE_RESULT reserve_result2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            reserve_result2 = null;
            goto Label_0037;
        Label_0010:
            reserve_result = new RESERVE_RESULT();
            reserve_result.Id = __nID;
            reserve_result2 = (RESERVE_RESULT) CommonClassDB.Instance(reserve_result).get(reserve_result, reserve_result.Id);
        Label_0037:
            return reserve_result2;
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
            str = "RESERVE_RESULT";
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
            if ((File.Exists(string.Format("{0}RESERVE_RESULT.AutoField", strArray[1])) == 0) != null)
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
            RESERVE_RESULT[] reserve_resultArray;
            int num;
            bool flag;
            reserve_resultArray = List();
            if (((reserve_resultArray == null) ? 0 : ((((int) reserve_resultArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = reserve_resultArray[((int) reserve_resultArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static RESERVE_RESULT[] List()
        {
            RESERVE_RESULT reserve_result;
            RESERVE_RESULT[] reserve_resultArray;
            reserve_result = new RESERVE_RESULT();
            reserve_resultArray = (RESERVE_RESULT[]) CommonClassDB.Instance(reserve_result).load(reserve_result, "OrderId");
        Label_0020:
            return reserve_resultArray;
        }

        public static RESERVE_RESULT[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            RESERVE_RESULT reserve_result;
            RESERVE_RESULT[] reserve_resultArray;
            RESERVE_RESULT[] reserve_resultArray2;
            reserve_result = new RESERVE_RESULT();
            reserve_resultArray = (RESERVE_RESULT[]) CommonClassDB.Instance(reserve_result).load(reserve_result, __nPageIndex, __nPageSize, __strFilter, __strSort);
            reserve_resultArray2 = reserve_resultArray;
        Label_0021:
            return reserve_resultArray2;
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

