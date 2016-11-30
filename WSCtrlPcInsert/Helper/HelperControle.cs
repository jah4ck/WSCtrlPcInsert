using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSCtrlPcInsert.Model;

namespace WSCtrlPcInsert.Helper
{
    public class HelperControle
    {
        public bool OnlyHexInString(string test)
        {
            if (test.Contains("-"))
            {
                test = test.Replace("-", "");
            }
            return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
        }

        public string ControleString(string test)
        {
            if (test.Contains("'"))
            {
                test = test.Replace("'", "''");
            }
            if (test.Contains("drop"))
            {
                test = test.Replace("drop", "d.r.o.p");
            }
            if (test.Contains("update"))
            {
                test = test.Replace("update", "u.p.d.a.t.e");
            }
            if (test.Contains("delete"))
            {
                test = test.Replace("delete", "d.e.l.e.t.e");
            }
            if (test.Contains("insert"))
            {
                test = test.Replace("insert", "i.n.s.e.r.t");
            }
            if (test.Contains("truncat"))
            {
                test = test.Replace("truncat", "t.r.u.n.c.a.t");
            }
            return test;
        }
        public bool VerifNbLigne(string guid)
        {

            return false;
        }
        public string VerifPresenceDate(string guid)
        {
            ExecReqSqlReader MyExecReqSqlReader = new ExecReqSqlReader();
            MyExecReqSqlReader.ExecuteReq(@"EXEC CtrlPc.dbo.PS_ControleInsert '"+guid+"'");
            string temp = MyExecReqSqlReader.result;
            if (temp.Contains("KO"))
            {
                return "KO";
            }
            else if(temp.Contains("OK"))
            {
                return "OK";
            }
            else
            {
                return "RELICA";
            }
        }

    }
}
