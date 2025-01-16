using System;

public class CPHInline {
    public bool Execute() {
        string userId = args["targetUserId"].ToString(), userName = args["targetUserName"].ToString(),
               autoShoutoutUsersGroupName = CPH.GetGlobalVar<string>("autoShoutoutUsersGroupName", true),
               shoutoutActionId = CPH.GetGlobalVar<string>("shoutoutActionId", true);

        if (!CPH.UserIdInGroup(userId, Platform.Twitch, autoShoutoutUsersGroupName)) {
            CPH.AddUserIdToGroup(userId, Platform.Twitch, autoShoutoutUsersGroupName);
            CPH.LogInfo($"AutoShoutout: {userName} has been added.");
            CPH.SetArgument("targetUserName", userName);
            CPH.RunActionById(shoutoutActionId);
        }

        return true;
    }
}
