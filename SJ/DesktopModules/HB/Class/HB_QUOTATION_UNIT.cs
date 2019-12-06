namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class HB_QUOTATION_UNIT : ICacheableClass, IAutoFieldAble
    {
        public string CONNECTION_POINT;
        public long CreateTime;
        public int Creator;
        public int Deleter;
        public long DeleteTime;
        public string GENERATOR_ID;
        public string GENERATOR_NAME;
        public int Id;
        public int IsDelete;
        public int Modifier;
        public long ModifyTime;
        public int OrderId;
        public string PARTICIPANT_ID;
        public string QUOTATION_UNIT;
        public string Reason;
        public int RecordStatus;
        public int Submiter;
        public long SubmitTime;

        public HB_QUOTATION_UNIT()
        {
            base..ctor();
            return;
        }

        public static BasicMess[] BMPARTICIPANT_ID(bool __bNeedAll)
        {
            List<BasicMess> list;
            string str;
            ArrayList list2;
            Hashtable hashtable;
            int num;
            HB_PARTICIPANT hb_participant;
            string str2;
            BasicMess[] messArray;
            bool flag;
            IEnumerator enumerator;
            IDisposable disposable;
            list = new List<BasicMess>();
            list.Clear();
            if ((__bNeedAll == 0) != null)
            {
                goto Label_002E;
            }
            list.Add(new BasicMess("--全部--", ""));
        Label_002E:
            str = "select distinct Id as id from " + DBFactory.reptablename("HB_PARTICIPANT") + " where IsDelete=2";
            list2 = new PersistenceManager().GetFromSql(str);
            enumerator = list2.GetEnumerator();
        Label_005D:
            try
            {
                goto Label_00E5;
            Label_0062:
                hashtable = (Hashtable) enumerator.Current;
                num = int.Parse(hashtable["id"].ToString());
                if (((num < 1) == 0) == null)
                {
                    goto Label_00E5;
                }
                hb_participant = HB_PARTICIPANT.Get(num);
                if (((hb_participant == null) == 0) == null)
                {
                    goto Label_00E5;
                }
                str2 = string.Format("{0}({1})", hb_participant.PARTICIPANT_NAME, (int) hb_participant.Id);
                list.Add(new BasicMess(str2, hb_participant.PARTICIPANT_ID));
            Label_00E5:
                if (enumerator.MoveNext() != null)
                {
                    goto Label_0062;
                }
                goto Label_0114;
            }
            finally
            {
            Label_00F7:
                disposable = enumerator as IDisposable;
                if ((disposable == null) != null)
                {
                    goto Label_0113;
                }
                disposable.Dispose();
            Label_0113:;
            }
        Label_0114:
            messArray = list.ToArray();
        Label_011F:
            return messArray;
        }

        public static unsafe void Del(int __nID)
        {
            HB_QUOTATION_UNIT hb_quotation_unit;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            hb_quotation_unit = Get(__nID);
            hb_quotation_unit.IsDelete = 1;
            hb_quotation_unit.Deleter = FunUtil.GetCurrentUserID();
            hb_quotation_unit.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(hb_quotation_unit).set(hb_quotation_unit);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            HB_QUOTATION_UNIT hb_quotation_unit;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            hb_quotation_unit = new HB_QUOTATION_UNIT();
            hb_quotation_unit.Id = __nID;
            CommonClassDB.Instance(hb_quotation_unit).delte(hb_quotation_unit);
        Label_0028:
            return;
        }

        public static HB_QUOTATION_UNIT Get(int __nID)
        {
            HB_QUOTATION_UNIT hb_quotation_unit;
            HB_QUOTATION_UNIT hb_quotation_unit2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            hb_quotation_unit2 = null;
            goto Label_0037;
        Label_0010:
            hb_quotation_unit = new HB_QUOTATION_UNIT();
            hb_quotation_unit.Id = __nID;
            hb_quotation_unit2 = (HB_QUOTATION_UNIT) CommonClassDB.Instance(hb_quotation_unit).get(hb_quotation_unit, hb_quotation_unit.Id);
        Label_0037:
            return hb_quotation_unit2;
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
            str = "HB_QUOTATION_UNIT";
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
            if ((File.Exists(string.Format("{0}HB_QUOTATION_UNIT.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_0031;
            }
            goto Label_0165;
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
            hashtable["PARTICIPANT_ID"] = "市场成员ID";
            hashtable["QUOTATION_UNIT"] = "报价单元";
            hashtable["CONNECTION_POINT"] = "并网点（D5000母线名称）";
            hashtable["GENERATOR_NAME"] = "机组D5000名称";
            hashtable["GENERATOR_ID"] = "机组D5000ID";
        Label_0165:
            hashtable2 = hashtable;
        Label_0169:
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
            HB_QUOTATION_UNIT[] hb_quotation_unitArray;
            int num;
            bool flag;
            hb_quotation_unitArray = List();
            if (((hb_quotation_unitArray == null) ? 0 : ((((int) hb_quotation_unitArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = hb_quotation_unitArray[((int) hb_quotation_unitArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static HB_QUOTATION_UNIT[] List()
        {
            HB_QUOTATION_UNIT hb_quotation_unit;
            HB_QUOTATION_UNIT[] hb_quotation_unitArray;
            hb_quotation_unit = new HB_QUOTATION_UNIT();
            hb_quotation_unitArray = (HB_QUOTATION_UNIT[]) CommonClassDB.Instance(hb_quotation_unit).load(hb_quotation_unit, "OrderId");
        Label_0020:
            return hb_quotation_unitArray;
        }

        public static HB_QUOTATION_UNIT[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            HB_QUOTATION_UNIT hb_quotation_unit;
            HB_QUOTATION_UNIT[] hb_quotation_unitArray;
            HB_QUOTATION_UNIT[] hb_quotation_unitArray2;
            hb_quotation_unit = new HB_QUOTATION_UNIT();
            hb_quotation_unitArray = (HB_QUOTATION_UNIT[]) CommonClassDB.Instance(hb_quotation_unit).load(hb_quotation_unit, __nPageIndex, __nPageSize, __strFilter, __strSort);
            hb_quotation_unitArray2 = hb_quotation_unitArray;
        Label_0021:
            return hb_quotation_unitArray2;
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

