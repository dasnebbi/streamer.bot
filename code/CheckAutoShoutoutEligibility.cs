using System;

public class CPHInline {
    public bool Execute() {
        string userId = args["userId"].ToString(), userName = args["userName"].ToString(),
               autoShoutoutUsersGroupName = CPH.GetGlobalVar<string>("autoShoutoutUsersGroupName"),         // "Shoutout"
               lastAutoShoutoutFieldName = CPH.GetGlobalVar<string>("lastAutoShoutoutFieldName"),              // "lastAutoShoutout"
               autoShoutoutCooldownFieldName = CPH.GetGlobalVar<string>("autoShoutoutCooldownFieldName"),      // "autoShoutoutCooldown"
               autoShoutoutSuccessArgFieldName = CPH.GetGlobalVar<string>("autoShoutoutSuccessArgFieldName");  // "autoShoutoutSuccess"

        Int32 now = (Int32)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
              lastAutoShoutout = Convert.ToInt32(CPH.GetTwitchUserVarById<int>(userId, lastAutoShoutoutFieldName)),
              autoShoutoutThreshold = CPH.GetGlobalVar<int>("autoShoutoutThreshold");  // "autoShoutoutThreshold"

        string shoutoutErrorCooldown = $"AutoShoutout for {userName} ({userId}) failed. Reason: Cooldown.",
               shoutoutErrorNotEligible = $"AutoShoutout for {userName} ({userId}) failed. Reason: Not eligible.";

        bool autoShoutoutCooldown = CPH.GetTwitchUserVarById<bool>(userId, autoShoutoutCooldownFieldName);

        if (autoShoutoutCooldown == true && ((now - lastAutoShoutout) > autoShoutoutThreshold)) {
            CPH.SetTwitchUserVarById(userId, autoShoutoutCooldownFieldName, false);
            autoShoutoutCooldown = false;
        }

        if (autoShoutoutCooldown == true) {
            CPH.SetArgument(autoShoutoutSuccessArgFieldName, "false");
            CPH.LogWarn(shoutoutErrorCooldown);
            
            return true;
        }

        if (CPH.UserIdInGroup(userId, Platform.Twitch, autoShoutoutUsersGroupName) && autoShoutoutCooldown == false) {
            CPH.SetArgument(autoShoutoutSuccessArgFieldName, "true");
            CPH.SetTwitchUserVarById(userId, lastAutoShoutoutFieldName, now);
            CPH.SetTwitchUserVarById(userId, autoShoutoutCooldownFieldName, true);
            
            return true;
        }

        CPH.SetArgument(autoShoutoutSuccessArgFieldName, "false");
        
        return true;
    }
}
