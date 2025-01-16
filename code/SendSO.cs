using System;

public class CPHInline {
    public bool Execute() {
        string user = args["targetUser"].ToString(), game = args["game"].ToString(),
               custom = CPH.GetTwitchUserVar<string>(user, "shoutout"),
               broadcastUserName = CPH.GetGlobalVar<string>("broadcastUserName", true);

        if (user == broadcastUserName) {
            CPH.SendMessage($"/me Advertising for my own channel? Embarrassing, dude.");
        } else if (custom == null) {
            CPH.SendMessage(
                $"/me Go watch {user} over at https://twitch.tv/{user} where they were last streaming {game}. They're pretty fun to watch as well!");
        } else {
            custom = custom.ToString();
            CPH.SendMessage($"/me {custom} https://twitch.tv/{user}");
        }

        return true;
    }
}
