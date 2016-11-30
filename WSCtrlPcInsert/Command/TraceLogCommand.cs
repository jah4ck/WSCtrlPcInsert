using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSCtrlPcInsert.Helper;
using WSCtrlPcInsert.Model;

namespace WSCtrlPcInsert.Command
{
    public class TraceLogCommand : HelperControle
    {
        public string TraceLogCommandAction(string guid, DateTime dateTraitement, string codeappli, int codeerreur, string description)
        {
            if (OnlyHexInString(guid))
            {
                //test droit ecriture + ajout ligne si non présente + incrémente compteur
                if (VerifPresenceDate(guid) == "OK")
                {
                    int codeappliInt;
                    bool testCodeappli = Int32.TryParse(codeappli, out codeappliInt);
                    if (testCodeappli)
                    {
                        description = ControleString(description);
                        TraceLogModel myTraceLogModel = new TraceLogModel(guid,dateTraitement,codeappli,codeerreur,description);
                        return "OK";
                    }
                    else
                    {
                        return "KO";
                    }
                }
                else if(VerifPresenceDate(guid)=="RELICA")
                {
                    return "RELICA";
                }
                else
                {
                    return "KO";
                }
            }
            else
            {
                return "KO";
            }
        }
    }
}
