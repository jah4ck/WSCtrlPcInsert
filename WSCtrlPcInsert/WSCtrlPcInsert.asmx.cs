using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WSCtrlPcInsert.Command;

namespace WSCtrlPcInsert
{
    /// <summary>
    /// Description résumée de WSCtrlPcInsert
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class WSCtrlPcInsert : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string TraceLog(string guid, DateTime dateTraitement, string codeappli, int codeerreur, string description)
        {
            TraceLogCommand MyTraceLogCommand = new TraceLogCommand();
            return MyTraceLogCommand.TraceLogCommandAction(guid, dateTraitement, codeappli, codeerreur, description);
        }
    }
}
