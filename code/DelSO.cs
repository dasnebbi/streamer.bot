using System;

public class CPHInline {
    public bool Execute() {
        string userId = args["targetUserId"].ToString(), userName = args["targetUserName"].ToString(),
               autoShoutoutUsersGroupName = CPH.GetGlobalVar<string>("autoShoutoutUsersGroupName", true);

        if (CPH.UserIdInGroup(userId, Platform.Twitch, autoShoutoutUsersGroupName)) {
            CPH.RemoveUserIdFromGroup(userId, Platform.Twitch, autoShoutoutUsersGroupName);
            CPH.LogInfo($"AutoShoutout: {userName} has been removed.");
        }

        return true;
    }
}
