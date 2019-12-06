namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.IO;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class HB_RiQJHItem : ICacheableClass, IAutoFieldAble
    {
        public long CreateTime;
        public int Creator;
        public double Data1;
        public double Data10;
        public double Data11;
        public double Data12;
        public double Data13;
        public double Data14;
        public double Data15;
        public double Data16;
        public double Data17;
        public double Data18;
        public double Data19;
        public double Data2;
        public double Data20;
        public double Data21;
        public double Data22;
        public double Data23;
        public double Data24;
        public double Data25;
        public double Data26;
        public double Data27;
        public double Data28;
        public double Data29;
        public double Data3;
        public double Data30;
        public double Data31;
        public double Data32;
        public double Data33;
        public double Data34;
        public double Data35;
        public double Data36;
        public double Data37;
        public double Data38;
        public double Data39;
        public double Data4;
        public double Data40;
        public double Data41;
        public double Data42;
        public double Data43;
        public double Data44;
        public double Data45;
        public double Data46;
        public double Data47;
        public double Data48;
        public double Data49;
        public double Data5;
        public double Data50;
        public double Data51;
        public double Data52;
        public double Data53;
        public double Data54;
        public double Data55;
        public double Data56;
        public double Data57;
        public double Data58;
        public double Data59;
        public double Data6;
        public double Data60;
        public double Data61;
        public double Data62;
        public double Data63;
        public double Data64;
        public double Data65;
        public double Data66;
        public double Data67;
        public double Data68;
        public double Data69;
        public double Data7;
        public double Data70;
        public double Data71;
        public double Data72;
        public double Data73;
        public double Data74;
        public double Data75;
        public double Data76;
        public double Data77;
        public double Data78;
        public double Data79;
        public double Data8;
        public double Data80;
        public double Data81;
        public double Data82;
        public double Data83;
        public double Data84;
        public double Data85;
        public double Data86;
        public double Data87;
        public double Data88;
        public double Data89;
        public double Data9;
        public double Data90;
        public double Data91;
        public double Data92;
        public double Data93;
        public double Data94;
        public double Data95;
        public double Data96;
        public int Day;
        public int Deleter;
        public long DeleteTime;
        public long DTime;
        public int Id;
        public int IsDelete;
        public int Modifier;
        public long ModifyTime;
        public int Month;
        public int OrderId;
        public string PlanId;
        public string PlanName;
        public string Reason;
        public int RecordStatus;
        public int Submiter;
        public long SubmitTime;
        public string Type;
        public int Year;

        public HB_RiQJHItem()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            HB_RiQJHItem item;
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
            HB_RiQJHItem item;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            item = new HB_RiQJHItem();
            item.Id = __nID;
            CommonClassDB.Instance(item).delte(item);
        Label_0028:
            return;
        }

        public bool FromString(string __strOne)
        {
            string str;
            string[] strArray;
            int num;
            int num2;
            string str2;
            double num3;
            bool flag;
            char[] chArray;
            bool flag2;
        Label_000B:
            str = __strOne ?? "";
            strArray = str.Split(new char[] { 9 });
            if (((((int) strArray.Length) < 0x62) == 0) != null)
            {
                goto Label_0038;
            }
            flag = 0;
            goto Label_00A1;
        Label_0038:
            this.Type = strArray[0];
            this.PlanName = strArray[1];
            num = 1;
            num2 = 0;
            goto Label_0091;
        Label_0050:
            str2 = string.Format("Data{0}", (int) (num2 + 1));
            num3 = Util.pasteDouble(strArray[num += 1], 0.0);
            CommonClassDB.SetObjectFieldValue(this, str2, (double) num3);
            num2 += 1;
        Label_0091:
            if ((num2 < 0x60) != null)
            {
                goto Label_0050;
            }
            flag = 1;
        Label_00A1:
            return flag;
        }

        public static HB_RiQJHItem Get(int __nID)
        {
            HB_RiQJHItem item;
            HB_RiQJHItem item2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            item2 = null;
            goto Label_0037;
        Label_0010:
            item = new HB_RiQJHItem();
            item.Id = __nID;
            item2 = (HB_RiQJHItem) CommonClassDB.Instance(item).get(item, item.Id);
        Label_0037:
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
            str = "HB_RiQJHItem";
        Label_0009:
            return str;
        }

        public string GetDeleteSql(string __strWhere)
        {
            string str;
            string str2;
            bool flag;
            str = string.Format("delete from {0}", this.GetCacheTableName());
            if (string.IsNullOrEmpty(__strWhere) != null)
            {
                goto Label_002E;
            }
            str = str + string.Format(" where {0}", __strWhere);
        Label_002E:
            str2 = str;
        Label_0032:
            return str2;
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
            if ((File.Exists(string.Format("{0}RiQJHItem.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_0031;
            }
            goto Label_07E7;
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
            hashtable["PlanId"] = "计划ID";
            hashtable["PlanName"] = "计划名称";
            hashtable["Type"] = "类型";
            hashtable["Year"] = "年";
            hashtable["Month"] = "月";
            hashtable["Day"] = "日";
            hashtable["DTime"] = "日期";
            hashtable["Data1"] = "数据1";
            hashtable["Data2"] = "数据2";
            hashtable["Data3"] = "数据3";
            hashtable["Data4"] = "数据4";
            hashtable["Data5"] = "数据5";
            hashtable["Data6"] = "数据6";
            hashtable["Data7"] = "数据7";
            hashtable["Data8"] = "数据8";
            hashtable["Data9"] = "数据9";
            hashtable["Data10"] = "数据10";
            hashtable["Data11"] = "数据11";
            hashtable["Data12"] = "数据12";
            hashtable["Data13"] = "数据13";
            hashtable["Data14"] = "数据14";
            hashtable["Data15"] = "数据15";
            hashtable["Data16"] = "数据16";
            hashtable["Data17"] = "数据17";
            hashtable["Data18"] = "数据18";
            hashtable["Data19"] = "数据19";
            hashtable["Data20"] = "数据20";
            hashtable["Data21"] = "数据21";
            hashtable["Data22"] = "数据22";
            hashtable["Data23"] = "数据23";
            hashtable["Data24"] = "数据24";
            hashtable["Data25"] = "数据25";
            hashtable["Data26"] = "数据26";
            hashtable["Data27"] = "数据27";
            hashtable["Data28"] = "数据28";
            hashtable["Data29"] = "数据29";
            hashtable["Data30"] = "数据30";
            hashtable["Data31"] = "数据31";
            hashtable["Data32"] = "数据32";
            hashtable["Data33"] = "数据33";
            hashtable["Data34"] = "数据34";
            hashtable["Data35"] = "数据35";
            hashtable["Data36"] = "数据36";
            hashtable["Data37"] = "数据37";
            hashtable["Data38"] = "数据38";
            hashtable["Data39"] = "数据39";
            hashtable["Data40"] = "数据40";
            hashtable["Data41"] = "数据41";
            hashtable["Data42"] = "数据42";
            hashtable["Data43"] = "数据43";
            hashtable["Data44"] = "数据44";
            hashtable["Data45"] = "数据45";
            hashtable["Data46"] = "数据46";
            hashtable["Data47"] = "数据47";
            hashtable["Data48"] = "数据48";
            hashtable["Data49"] = "数据49";
            hashtable["Data50"] = "数据50";
            hashtable["Data51"] = "数据51";
            hashtable["Data52"] = "数据52";
            hashtable["Data53"] = "数据53";
            hashtable["Data54"] = "数据54";
            hashtable["Data55"] = "数据55";
            hashtable["Data56"] = "数据56";
            hashtable["Data57"] = "数据57";
            hashtable["Data58"] = "数据58";
            hashtable["Data59"] = "数据59";
            hashtable["Data60"] = "数据60";
            hashtable["Data61"] = "数据61";
            hashtable["Data62"] = "数据62";
            hashtable["Data63"] = "数据63";
            hashtable["Data64"] = "数据64";
            hashtable["Data65"] = "数据65";
            hashtable["Data66"] = "数据66";
            hashtable["Data67"] = "数据67";
            hashtable["Data68"] = "数据68";
            hashtable["Data69"] = "数据69";
            hashtable["Data70"] = "数据70";
            hashtable["Data71"] = "数据71";
            hashtable["Data72"] = "数据72";
            hashtable["Data73"] = "数据73";
            hashtable["Data74"] = "数据74";
            hashtable["Data75"] = "数据75";
            hashtable["Data76"] = "数据76";
            hashtable["Data77"] = "数据77";
            hashtable["Data78"] = "数据78";
            hashtable["Data79"] = "数据79";
            hashtable["Data80"] = "数据80";
            hashtable["Data81"] = "数据81";
            hashtable["Data82"] = "数据82";
            hashtable["Data83"] = "数据83";
            hashtable["Data84"] = "数据84";
            hashtable["Data85"] = "数据85";
            hashtable["Data86"] = "数据86";
            hashtable["Data87"] = "数据87";
            hashtable["Data88"] = "数据88";
            hashtable["Data89"] = "数据89";
            hashtable["Data90"] = "数据90";
            hashtable["Data91"] = "数据91";
            hashtable["Data92"] = "数据92";
            hashtable["Data93"] = "数据93";
            hashtable["Data94"] = "数据94";
            hashtable["Data95"] = "数据95";
            hashtable["Data96"] = "数据96";
        Label_07E7:
            hashtable2 = hashtable;
        Label_07EB:
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
            HB_RiQJHItem[] itemArray;
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

        public static HB_RiQJHItem[] List()
        {
            HB_RiQJHItem item;
            HB_RiQJHItem[] itemArray;
            item = new HB_RiQJHItem();
            itemArray = (HB_RiQJHItem[]) CommonClassDB.Instance(item).load(item, "OrderId");
        Label_0020:
            return itemArray;
        }

        public static HB_RiQJHItem[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            HB_RiQJHItem item;
            HB_RiQJHItem[] itemArray;
            HB_RiQJHItem[] itemArray2;
            item = new HB_RiQJHItem();
            itemArray = (HB_RiQJHItem[]) CommonClassDB.Instance(item).load(item, __nPageIndex, __nPageSize, __strFilter, __strSort);
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
    }
}

