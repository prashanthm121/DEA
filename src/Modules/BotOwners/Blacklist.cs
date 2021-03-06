﻿using DEA.Database.Models;
using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace DEA.Modules.BotOwners
{
    public partial class BotOwners
    {
        [Command("Blacklist")]
        [Remarks("290759415362224139")]
        [Summary("Blacklist a user from DEA entirely to the fullest extent.")]
        public async Task Blacklist(ulong userId)
        {
            var username = string.Empty;
            var avatarUrl = string.Empty;

            try
            {
                var user = await (Context.Client as IDiscordClient).GetUserAsync(userId);

                username = user.Username;
                avatarUrl = user.GetAvatarUrl(ImageFormat.Png, 2048);
            }
            catch
            {
                // Ignored.
            }

            var blacklist = new Blacklist(userId, username, avatarUrl);
            await _blacklistRepo.InsertAsync(blacklist);

            foreach (var guild in await (Context.Client as IDiscordClient).GetGuildsAsync())
            {
                var user = guild.GetUserAsync(userId);

                if (user != null)
                {
                    try
                    {
                        await guild.AddBanAsync(user as IUser);
                    }
                    catch
                    {
                        // Ignored.
                    }
                }

                if (guild.OwnerId == userId)
                {
                    await _blacklistRepo.AddGuildAsync(userId, guild.Id);
                    await guild.LeaveAsync();
                }
            }

            await ReplyAsync($"You have successfully blacklisted the following ID: {userId}.");
        }
    }
}
