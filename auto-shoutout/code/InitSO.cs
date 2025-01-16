using System;
using System.Collections.Generic;
using System.Linq;

public class CPHInline {
    public bool Execute() {
        string broadcastUserId = args["broadcastUserId"].ToString(),
               broadcastUserName = args["broadcastUserName"].ToString();

        CPH.SetGlobalVar("autoShoutoutUsersGroupName", "Shoutout", true);
        CPH.SetGlobalVar("lastAutoShoutoutFieldName", "lastAutoShoutout", true);
        CPH.SetGlobalVar("autoShoutoutCooldownFieldName", "autoShoutoutCooldown", true);
        CPH.SetGlobalVar("autoShoutoutSuccessArgFieldName", "autoShoutoutSuccess", true);
        CPH.SetGlobalVar("welcomeMessageUsersList", broadcastUserId, true);
        CPH.SetGlobalVar("broadcastUserName", broadcastUserName, true);
        CPH.SetGlobalVar("autoShoutoutThreshold", 43200, true);

        string autoShoutoutUsersGroupName = CPH.GetGlobalVar<string>("autoShoutoutUsersGroupName", true);
        CPH.AddGroup(autoShoutoutUsersGroupName);

        List<ActionData> actionList = CPH.GetActions();
        foreach (ActionData action in actionList) {
            string actionId = action.Id.ToString(), actionName = action.Name.ToString();

            if (actionName == "[SO] !so") {
                CPH.SetGlobalVar("shoutoutActionId", actionId, true);
                break;
            }
        }

        return true;
    }
}
