namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using WebSiteBase.Class;

    public class HB_INTRADAY_POWER
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
        public double T4;
        public double T5;
        public double T6;
        public double T7;
        public double T8;
        public double T9;

        public HB_INTRADAY_POWER()
        {
            base..ctor();
            return;
        }

        public static BasicMess[] BMUINTERVAL(bool __bNeedAll)
        {
            List<BasicMess> list;
            string[] strArray;
            string[] strArray2;
            int num;
            string str;
            string str2;
            BasicMess[] messArray;
            bool flag;
            string[] strArray3;
            list = new List<BasicMess>();
            list.Clear();
            if ((__bNeedAll == 0) != null)
            {
                goto Label_002E;
            }
            list.Add(new BasicMess("--全部--", ""));
        Label_002E:;
            strArray = new string[] { "1:15-9:00", "9:15-13:00", "13:15-17:00", "17:15-21:00", "21:15-次日1:00" };
            strArray2 = new string[] { "1", "2", "3", "4", "5" };
            num = 0;
            goto Label_00C2;
        Label_00A2:
            str = strArray[num];
            str2 = strArray2[num];
            list.Add(new BasicMess(str, str2));
            num += 1;
        Label_00C2:
            if ((num < ((int) strArray.Length)) != null)
            {
                goto Label_00A2;
            }
            messArray = list.ToArray();
        Label_00D8:
            return messArray;
        }

        public unsafe ArrayList GetChartData(out ArrayList __alFields, DateTime __dDate, string __strValueLabel, int __nUINTERVAL)
        {
            ArrayList list;
            DateTime time;
            int num;
            DateTime time2;
            string str;
            object obj2;
            Hashtable hashtable;
            ArrayList list2;
            int num2;
            double num3;
            bool flag;
            *(__alFields) = new ArrayList();
            *(__alFields).Add("时间");
            *(__alFields).Add(__strValueLabel);
            list = new ArrayList();
            time = &__dDate.Date;
            num2 = __nUINTERVAL;
            switch ((num2 - 1))
            {
                case 0:
                    goto Label_004F;

                case 1:
                    goto Label_0062;

                case 2:
                    goto Label_0075;

                case 3:
                    goto Label_0088;

                case 4:
                    goto Label_009B;
            }
            goto Label_00AE;
        Label_004F:
            time = &time.AddMinutes(60.0);
            goto Label_00AE;
        Label_0062:
            time = &time.AddMinutes(540.0);
            goto Label_00AE;
        Label_0075:
            time = &time.AddMinutes(780.0);
            goto Label_00AE;
        Label_0088:
            time = &time.AddMinutes(1020.0);
            goto Label_00AE;
        Label_009B:
            time = &time.AddMinutes(1260.0);
        Label_00AE:
            num = 1;
            goto Label_0137;
        Label_00B5:
            time2 = &time.AddMinutes((double) (num * 15));
            str = string.Format("T{0}", (int) num);
            obj2 = CommonClassDB.GetObjectFieldValue(this, str);
            hashtable = new Hashtable();
            hashtable["时间"] = string.Format("{0}({1})", str, &time2.ToString("HH:mm"));
            num3 = (double) obj2;
            hashtable[__strValueLabel] = &num3.ToString("0.####");
            list.Add(hashtable);
            num += 1;
        Label_0137:
            if ((num < 0x21) != null)
            {
                goto Label_00B5;
            }
            list2 = list;
        Label_014A:
            return list2;
        }

        public static unsafe void GetDateAndInterval(DateTime __dTime, out DateTime __dDate, out int __nInterval)
        {
            TimeSpan span;
            bool flag;
            DateTime time;
            *(__dDate) = &__dTime.Date;
            span = __dTime - *(__dDate);
            if (((span < new TimeSpan(1, 15, 0)) == 0) != null)
            {
                goto Label_0056;
            }
            *(__dDate) = &&__dTime.Date.AddDays(-1.0);
            *((int*) __nInterval) = 5;
            goto Label_00D3;
        Label_0056:
            if (((span < new TimeSpan(9, 15, 0)) == 0) != null)
            {
                goto Label_0074;
            }
            *((int*) __nInterval) = 1;
            goto Label_00D3;
        Label_0074:
            if (((span < new TimeSpan(13, 15, 0)) == 0) != null)
            {
                goto Label_0092;
            }
            *((int*) __nInterval) = 2;
            goto Label_00D3;
        Label_0092:
            if (((span < new TimeSpan(0x11, 15, 0)) == 0) != null)
            {
                goto Label_00B0;
            }
            *((int*) __nInterval) = 3;
            goto Label_00D3;
        Label_00B0:
            if (((span < new TimeSpan(0x15, 15, 0)) == 0) != null)
            {
                goto Label_00CE;
            }
            *((int*) __nInterval) = 4;
            goto Label_00D3;
        Label_00CE:
            *((int*) __nInterval) = 5;
        Label_00D3:
            return;
        }

        public static unsafe string GetDisplayPOINTStr(int __nInterval, int __nPoint)
        {
            long num;
            TimeSpan span;
            string str;
            num = GetIntervalTicks(__nInterval);
            &span = new TimeSpan(num);
            span += new TimeSpan(0, 15 * __nPoint, 0);
            string introduced3 = &span.ToString("hh");
            str = string.Format("{0}:{1}", introduced3, &span.ToString("mm"));
        Label_0048:
            return str;
        }

        public static unsafe long GetIntervalTicks(int __nInterval)
        {
            TimeSpan span;
            long num;
            int num2;
            span = new TimeSpan();
            num2 = __nInterval;
            switch ((num2 - 1))
            {
                case 0:
                    goto Label_0029;

                case 1:
                    goto Label_0037;

                case 2:
                    goto Label_0046;

                case 3:
                    goto Label_0055;

                case 4:
                    goto Label_0064;
            }
            goto Label_0073;
        Label_0029:
            &span = new TimeSpan(1, 15, 0);
            goto Label_0073;
        Label_0037:
            &span = new TimeSpan(9, 15, 0);
            goto Label_0073;
        Label_0046:
            &span = new TimeSpan(13, 15, 0);
            goto Label_0073;
        Label_0055:
            &span = new TimeSpan(0x11, 15, 0);
            goto Label_0073;
        Label_0064:
            &span = new TimeSpan(0x15, 15, 0);
        Label_0073:
            num = &span.Ticks;
        Label_007D:
            return num;
        }
    }
}

