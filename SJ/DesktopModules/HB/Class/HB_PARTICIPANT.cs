namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.IO;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class HB_PARTICIPANT : ICacheableClass, IAutoFieldAble
    {
        public string ADDRESS;
        public string ALIASNAME;
        public float COMPANY_ACCOUNTS_VOLUME;
        public float COMPANY_DISPATCH_VOLUME;
        public int COMPANY_TYPE;
        public string CONTROL_AREA;
        public string CORPORATION;
        public long CreateTime;
        public int Creator;
        public int Deleter;
        public long DeleteTime;
        public int DFDC;
        public string EMAIL;
        public DateTime END_EFFECTIVE_DATE;
        public string FAXPHONE;
        public string GENGROUP;
        public string GEOG_RREGION;
        public int Id;
        public int IS_DELETE;
        public int IsDelete;
        public string LINKMAN;
        public int Modifier;
        public long ModifyTime;
        public string OFFICEPHONE;
        public string OLD_NAME;
        public int OrderId;
        public string PARTICIPANT_ID;
        public string PARTICIPANT_NAME;
        public string PARTICIPANT_TYPE;
        public string PLANT_ID;
        public string PLANT_NAME;
        public string POSTAL_CODE;
        public string Reason;
        public int RecordStatus;
        public DateTime REGISTER_DATE;
        public DateTime START_EFFECTIVE_DATE;
        public int STATE;
        public int Submiter;
        public long SubmitTime;
        public string TELEPHONE;
        public string UPDATE_PERSON_ID;
        public DateTime UPDATE_TIME;

        public HB_PARTICIPANT()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            HB_PARTICIPANT hb_participant;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            hb_participant = Get(__nID);
            hb_participant.IsDelete = 1;
            hb_participant.Deleter = FunUtil.GetCurrentUserID();
            hb_participant.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(hb_participant).set(hb_participant);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            HB_PARTICIPANT hb_participant;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            hb_participant = new HB_PARTICIPANT();
            hb_participant.Id = __nID;
            CommonClassDB.Instance(hb_participant).delte(hb_participant);
        Label_0028:
            return;
        }

        public static HB_PARTICIPANT Get(int __nID)
        {
            HB_PARTICIPANT hb_participant;
            HB_PARTICIPANT hb_participant2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            hb_participant2 = null;
            goto Label_0037;
        Label_0010:
            hb_participant = new HB_PARTICIPANT();
            hb_participant.Id = __nID;
            hb_participant2 = (HB_PARTICIPANT) CommonClassDB.Instance(hb_participant).get(hb_participant, hb_participant.Id);
        Label_0037:
            return hb_participant2;
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
            str = "HB_PARTICIPANT";
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
            if ((File.Exists(string.Format("{0}HB_PARTICIPANT.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_0031;
            }
            goto Label_02FD;
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
            hashtable["PARTICIPANT_NAME"] = "名称";
            hashtable["ALIASNAME"] = "别名(简称)";
            hashtable["PLANT_NAME"] = "对应D5000模型名称";
            hashtable["PLANT_ID"] = "对应D5000模型ID";
            hashtable["PARTICIPANT_TYPE"] = "市场成员类型";
            hashtable["ADDRESS"] = "通信地址";
            hashtable["POSTAL_CODE"] = "邮政编码";
            hashtable["CORPORATION"] = "法定代表人信息";
            hashtable["LINKMAN"] = "常用联系人";
            hashtable["OFFICEPHONE"] = "办公电话";
            hashtable["TELEPHONE"] = "手机号码";
            hashtable["FAXPHONE"] = "传真号码";
            hashtable["EMAIL"] = "电子邮箱";
            hashtable["REGISTER_DATE"] = "注册时间";
            hashtable["START_EFFECTIVE_DATE"] = "生效时间";
            hashtable["END_EFFECTIVE_DATE"] = "失效时间";
            hashtable["GEOG_RREGION"] = "地理区域";
            hashtable["CONTROL_AREA"] = "控制区域";
            hashtable["UPDATE_TIME"] = "信息更新时间";
            hashtable["UPDATE_PERSON_ID"] = "信息更新人编号";
            hashtable["COMPANY_DISPATCH_VOLUME"] = "企业可调度容量";
            hashtable["COMPANY_ACCOUNTS_VOLUME"] = "企业可结算容量";
            hashtable["COMPANY_TYPE"] = "商业性质";
            hashtable["STATE"] = "状态";
            hashtable["DFDC"] = "是否地方电厂";
            hashtable["OLD_NAME"] = "曾用名";
            hashtable["GENGROUP"] = "所属发电集团";
            hashtable["IS_DELETE"] = "删除标志";
        Label_02FD:
            hashtable2 = hashtable;
        Label_0301:
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
            HB_PARTICIPANT[] hb_participantArray;
            int num;
            bool flag;
            hb_participantArray = List();
            if (((hb_participantArray == null) ? 0 : ((((int) hb_participantArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = hb_participantArray[((int) hb_participantArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static HB_PARTICIPANT[] List()
        {
            HB_PARTICIPANT hb_participant;
            HB_PARTICIPANT[] hb_participantArray;
            hb_participant = new HB_PARTICIPANT();
            hb_participantArray = (HB_PARTICIPANT[]) CommonClassDB.Instance(hb_participant).load(hb_participant, "OrderId");
        Label_0020:
            return hb_participantArray;
        }

        public static HB_PARTICIPANT[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            HB_PARTICIPANT hb_participant;
            HB_PARTICIPANT[] hb_participantArray;
            HB_PARTICIPANT[] hb_participantArray2;
            hb_participant = new HB_PARTICIPANT();
            hb_participantArray = (HB_PARTICIPANT[]) CommonClassDB.Instance(hb_participant).load(hb_participant, __nPageIndex, __nPageSize, __strFilter, __strSort);
            hb_participantArray2 = hb_participantArray;
        Label_0021:
            return hb_participantArray2;
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

