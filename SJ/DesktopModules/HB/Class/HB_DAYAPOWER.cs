namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.IO;
    using System.Runtime.InteropServices;
    using WebSiteBase.Utilities;

    public class HB_DAYAPOWER
    {
        public long CreateTime;
        public int Creator;
        public int Deleter;
        public long DeleteTime;
        public int Id;
        public int IsDelete;
        public int Modifier;
        public long ModifyTime;
        public int OrderId;
        public string Reason;
        public int RecordStatus;
        public int Submiter;
        public long SubmitTime;
        public double T1;
        public double T10;
        public double T11;
        public double T12;
        public double T13;
        public double T14;
        public double T15;
        public double T16;
        public double T17;
        public double T18;
        public double T19;
        public double T2;
        public double T20;
        public double T21;
        public double T22;
        public double T23;
        public double T24;
        public double T25;
        public double T26;
        public double T27;
        public double T28;
        public double T29;
        public double T3;
        public double T30;
        public double T31;
        public double T32;
        public double T33;
        public double T34;
        public double T35;
        public double T36;
        public double T37;
        public double T38;
        public double T39;
        public double T4;
        public double T40;
        public double T41;
        public double T42;
        public double T43;
        public double T44;
        public double T45;
        public double T46;
        public double T47;
        public double T48;
        public double T49;
        public double T5;
        public double T50;
        public double T51;
        public double T52;
        public double T53;
        public double T54;
        public double T55;
        public double T56;
        public double T57;
        public double T58;
        public double T59;
        public double T6;
        public double T60;
        public double T61;
        public double T62;
        public double T63;
        public double T64;
        public double T65;
        public double T66;
        public double T67;
        public double T68;
        public double T69;
        public double T7;
        public double T70;
        public double T71;
        public double T72;
        public double T73;
        public double T74;
        public double T75;
        public double T76;
        public double T77;
        public double T78;
        public double T79;
        public double T8;
        public double T80;
        public double T81;
        public double T82;
        public double T83;
        public double T84;
        public double T85;
        public double T86;
        public double T87;
        public double T88;
        public double T89;
        public double T9;
        public double T90;
        public double T91;
        public double T92;
        public double T93;
        public double T94;
        public double T95;
        public double T96;

        public HB_DAYAPOWER()
        {
            base..ctor();
            return;
        }

        public unsafe ArrayList GetChartData(out ArrayList __alFields, DateTime __dDate, string __strValueLabel)
        {
            ArrayList list;
            int num;
            DateTime time;
            string str;
            object obj2;
            Hashtable hashtable;
            ArrayList list2;
            double num2;
            bool flag;
            *(__alFields) = new ArrayList();
            *(__alFields).Add("时间");
            *(__alFields).Add(__strValueLabel);
            list = new ArrayList();
            num = 1;
            goto Label_00A7;
        Label_0028:
            time = &__dDate.AddMinutes((double) (num * 15));
            str = string.Format("T{0}", (int) num);
            obj2 = CommonClassDB.GetObjectFieldValue(this, str);
            hashtable = new Hashtable();
            hashtable["时间"] = string.Format("{0}({1})", str, &time.ToString("HH:mm"));
            num2 = (double) obj2;
            hashtable[__strValueLabel] = &num2.ToString("0.####");
            list.Add(hashtable);
            num += 1;
        Label_00A7:
            if ((num < 0x61) != null)
            {
                goto Label_0028;
            }
            list2 = list;
        Label_00BA:
            return list2;
        }

        public static Hashtable GetFieldNameHash()
        {
            Hashtable hashtable;
            string[] strArray;
            string str;
            Hashtable hashtable2;
            bool flag;
            hashtable = new Hashtable();
            strArray = CustomerUtil.GetTemplateRootPath();
            if ((File.Exists(string.Format("{0}HB_DAYAPOWER.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_0031;
            }
            goto Label_0770;
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
            hashtable["T1"] = "时段1";
            hashtable["T2"] = "时段2";
            hashtable["T3"] = "时段3";
            hashtable["T4"] = "时段4";
            hashtable["T5"] = "时段5";
            hashtable["T6"] = "时段6";
            hashtable["T7"] = "时段7";
            hashtable["T8"] = "时段8";
            hashtable["T9"] = "时段9";
            hashtable["T10"] = "时段10";
            hashtable["T11"] = "时段11";
            hashtable["T12"] = "时段12";
            hashtable["T13"] = "时段13";
            hashtable["T14"] = "时段14";
            hashtable["T15"] = "时段15";
            hashtable["T16"] = "时段16";
            hashtable["T17"] = "时段17";
            hashtable["T18"] = "时段18";
            hashtable["T19"] = "时段19";
            hashtable["T20"] = "时段20";
            hashtable["T21"] = "时段21";
            hashtable["T22"] = "时段22";
            hashtable["T23"] = "时段23";
            hashtable["T24"] = "时段24";
            hashtable["T25"] = "时段25";
            hashtable["T26"] = "时段26";
            hashtable["T27"] = "时段27";
            hashtable["T28"] = "时段28";
            hashtable["T29"] = "时段29";
            hashtable["T30"] = "时段30";
            hashtable["T31"] = "时段31";
            hashtable["T32"] = "时段32";
            hashtable["T33"] = "时段33";
            hashtable["T34"] = "时段34";
            hashtable["T35"] = "时段35";
            hashtable["T36"] = "时段36";
            hashtable["T37"] = "时段37";
            hashtable["T38"] = "时段38";
            hashtable["T39"] = "时段39";
            hashtable["T40"] = "时段40";
            hashtable["T41"] = "时段41";
            hashtable["T42"] = "时段42";
            hashtable["T43"] = "时段43";
            hashtable["T44"] = "时段44";
            hashtable["T45"] = "时段45";
            hashtable["T46"] = "时段46";
            hashtable["T47"] = "时段47";
            hashtable["T48"] = "时段48";
            hashtable["T49"] = "时段49";
            hashtable["T50"] = "时段50";
            hashtable["T51"] = "时段51";
            hashtable["T52"] = "时段52";
            hashtable["T53"] = "时段53";
            hashtable["T54"] = "时段54";
            hashtable["T55"] = "时段55";
            hashtable["T56"] = "时段56";
            hashtable["T57"] = "时段57";
            hashtable["T58"] = "时段58";
            hashtable["T59"] = "时段59";
            hashtable["T60"] = "时段60";
            hashtable["T61"] = "时段61";
            hashtable["T62"] = "时段62";
            hashtable["T63"] = "时段63";
            hashtable["T64"] = "时段64";
            hashtable["T65"] = "时段65";
            hashtable["T66"] = "时段66";
            hashtable["T67"] = "时段67";
            hashtable["T68"] = "时段68";
            hashtable["T69"] = "时段69";
            hashtable["T70"] = "时段70";
            hashtable["T71"] = "时段71";
            hashtable["T72"] = "时段72";
            hashtable["T73"] = "时段73";
            hashtable["T74"] = "时段74";
            hashtable["T75"] = "时段75";
            hashtable["T76"] = "时段76";
            hashtable["T77"] = "时段77";
            hashtable["T78"] = "时段78";
            hashtable["T79"] = "时段79";
            hashtable["T80"] = "时段80";
            hashtable["T81"] = "时段81";
            hashtable["T82"] = "时段82";
            hashtable["T83"] = "时段83";
            hashtable["T84"] = "时段84";
            hashtable["T85"] = "时段85";
            hashtable["T86"] = "时段86";
            hashtable["T87"] = "时段87";
            hashtable["T88"] = "时段88";
            hashtable["T89"] = "时段89";
            hashtable["T90"] = "时段90";
            hashtable["T91"] = "时段91";
            hashtable["T92"] = "时段92";
            hashtable["T93"] = "时段93";
            hashtable["T94"] = "时段94";
            hashtable["T95"] = "时段95";
            hashtable["T96"] = "时段96";
        Label_0770:
            hashtable2 = hashtable;
        Label_0774:
            return hashtable2;
        }

        public static Hashtable GetListFieldNameHash()
        {
            Hashtable hashtable;
            hashtable = null;
        Label_0005:
            return hashtable;
        }
    }
}

