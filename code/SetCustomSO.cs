using System;
using System.Collections.Generic;
using System.Linq;

public class CPHInline {
    public bool Execute() {
        string user = args["user"].ToString();
        string targetUser = args["targetUser"].ToString();

        string inputraw = args["rawInput"].ToString();
        char[] charSeparators = new char[] { ' ' };
        string[] inputargs = inputraw.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
        string cso = inputraw.Remove(0, inputargs[0].ToString().Length);
        CPH.SetArgument("parsedinput", cso);

        return true;
    }
}
