﻿using System;
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
                string result="RAS";
                result = VerifPresenceDate(guid);
                if (result == "OK")
                {
                    codeappli = ControleString(codeappli);
                    description = ControleString(description);
                    TraceLogModel myTraceLogModel = new TraceLogModel(guid, dateTraitement, codeappli, codeerreur, description);
                    return "OK";                    
                }
                else if(result == "RELICA")
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
