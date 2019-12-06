namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.IO;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class RESERVE_BID : ICacheableClass, IAutoFieldAble
    {
        public long CreateTime;
        public int Creator;
        public string DBI_ID;
        public int Deleter;
        public long DeleteTime;
        public int Id;
        public int IsDelete;
        public float MIN_P;
        public int Modifier;
        public long ModifyTime;
        public int OrderId;
        public string PLANT_NAME;
        public DateTime PRESCHED_DATE;
        public string Reason;
        public int RecordStatus;
        public int SF_BID;
        public int Submiter;
        public long SubmitTime;
        public float T1;

        public RESERVE_BID()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            RESERVE_BID reserve_bid;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            reserve_bid = Get(__nID);
            reserve_bid.IsDelete = 1;
            reserve_bid.Deleter = FunUtil.GetCurrentUserID();
            reserve_bid.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(reserve_bid).set(reserve_bid);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            RESERVE_BID reserve_bid;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            reserve_bid = new RESERVE_BID();
            reserve_bid.Id = __nID;
            CommonClassDB.Instance(reserve_bid).delte(reserve_bid);
        Label_0028:
            return;
        }

        public static RESERVE_BID Get(int __nID)
        {
            RESERVE_BID reserve_bid;
            RESERVE_BID reserve_bid2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            reserve_bid2 = null;
            goto Label_0037;
        Label_0010:
            reserve_bid = new RESERVE_BID();
            reserve_bid.Id = __nID;
            reserve_bid2 = (RESERVE_BID) CommonClassDB.Instance(reserve_bid).get(reserve_bid, reserve_bid.Id);
        Label_0037:
            return reserve_bid2;
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
            str = "RESERVE_BID";
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
            if ((File.Exists(string.Format("{0}RESERVE_BID.AutoField", strArray[1])) == 0) != null)
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
            hashtable["PRESCHED_DATE"] = "报价日期";
            hashtable["T1"] = "备用报价（元/兆瓦时）";
            hashtable["MIN_P"] = "最小可调出力";
            hashtable["SF_BID"] = "是否集中竞价";
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
            RESERVE_BID[] reserve_bidArray;
            int num;
            bool flag;
            reserve_bidArray = List();
            if (((reserve_bidArray == null) ? 0 : ((((int) reserve_bidArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = reserve_bidArray[((int) reserve_bidArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static RESERVE_BID[] List()
        {
            RESERVE_BID reserve_bid;
            RESERVE_BID[] reserve_bidArray;
            reserve_bid = new RESERVE_BID();
            reserve_bidArray = (RESERVE_BID[]) CommonClassDB.Instance(reserve_bid).load(reserve_bid, "OrderId");
        Label_0020:
            return reserve_bidArray;
        }

        public static RESERVE_BID[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            RESERVE_BID reserve_bid;
            RESERVE_BID[] reserve_bidArray;
            RESERVE_BID[] reserve_bidArray2;
            reserve_bid = new RESERVE_BID();
            reserve_bidArray = (RESERVE_BID[]) CommonClassDB.Instance(reserve_bid).load(reserve_bid, __nPageIndex, __nPageSize, __strFilter, __strSort);
            reserve_bidArray2 = reserve_bidArray;
        Label_0021:
            return reserve_bidArray2;
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

