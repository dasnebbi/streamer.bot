# Nebusters Auto-Shoutout

This snippet for Streamer.Bot contains of several actions, commands and queues in order to implement a auto-shoutout functionality.

## Installation

1. Download [Streamer.bot](https://streamer.bot/)
2. Ensure that you're connected to your Twitch broadcaster account (see [Documentation](https://docs.streamer.bot/guide/platforms/twitch#accounts))
3. Ensure that Streamer.bot is connected with OBS Studio (see [Documentation](https://docs.streamer.bot/guide/broadcasters/obs-studio)).
4. Copy or download the [export.sb](https://raw.githubusercontent.com/dasnebbi/streamer.bot/refs/heads/master/auto-shoutout/export.sb).
5. Open the "Import" dialogue in Streamer.bot (see [Documentation](https://docs.streamer.bot/guide/import-export#import)
6. Drag the downloaded [export.sb](https://raw.githubusercontent.com/dasnebbi/streamer.bot/refs/heads/master/auto-shoutout/export.sb) over the field "Import string" or paste its contents to that field.
7. Click "Import" on the lower, right bottom side of the dialogue.
8. Close the "Import" dialogue if necessary.
9. **DO NOT** activate actions, queues or commands manually.
10. Navigate to "Actions".
11. Ensure the Group "*Nebusters Auto-Shoutout - Setup*" is expanded. If it is not, expand it by right-clicking on the group and selecting "*Expand All*".
12. Click on the action "*[SO] Setup*" and navigate to the actions Tiggers.
13. Do a right-click on the Test-Trigger and click "*Test Trigger*".
14. All actions except "*[SO] Setup*" should now be activated.
15. You **COULD** delete "*[SO] Setup*" now, but I'd recommend to keep it.

## Commands

Importing the auto-shoutout adds several new commands to your Streamer.bot:

- #addso
- #delso
- !so
- !setso

### !so

The command will add a shoutout to the queue. If the shoutout-queue is empty, it'll perform this action instantly.

You can add as many shoutouts to the queue as you want. There's no necessity to wait.

##### Usage
```plain
!so @dasnebbi
```

### !setso

The command will add a possibility to customize the shoutout message per user.

##### Usage

```plain
!setso @dasnebbi You are interested in photography and like beautiful images? Then watch him!
```

Next time you trigger "*!so username*", the message sent by Streamer.bot will look like this:

```plain
Moderator: !so @dasnebbi
Chatbot: /me You are interested in photography and like beautiful images? Then watch him! https://twitch.tv/dasnebbi
```

##### Result

### #addso and #delso

While performing "*[SO] Setup*", a user-group called "*Shoutout*" was added to Streamer.bot. This group is necessary to manage users that are eligible of receiving an auto-shoutout.

Both actions will be documented in Streamer.bots logfiles.

It may take up to 30 seconds until a user appears in or disappears from the group in Streamer.bots UI.

#### #addso

The command will add a user to the group and instantly perform an auto-shoutout. Also, this 

##### Usage
```plain
#addso @dasnebbi
```

#### #delso

The command will remove a user from the group.

##### Usage

```plain
#delso @dasnebbi
```

## Customizing chat messages for Shoutouts or Raids

Chat messages that are sent by Streamer.bot in order to perform an auto-shoutout are to be found inside the following actions:

- [SO] !so
- [SO] Raid SO

Variables (see [Documentation](https://docs.streamer.bot/guide/variables)) may've been used. Be sure you know what you're doing prior editing code.

### [SO] !so

The sub-action "*Execute Code*" contains three messages:
```cs
  CPH.SendMessage($"/me Advertising for my own channel? Embarrassing, dude.");
  CPH.SendMessage($"/me Go watch {user} over at https://twitch.tv/{user} where they were last streaming {game}. They're pretty fun to watch as well!");
  CPH.SendMessage($"/me {custom} https://twitch.tv/{user}");
```

### [SO] Raid SO

The sub-action "*Twitch Message*" contains one message:
```plain
/me TombRaid %user% and %viewers% stop by and crash the stream on purpose. HenloThere 
```
