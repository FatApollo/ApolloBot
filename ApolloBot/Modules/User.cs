﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloBot.Modules
{
    public class User
    {
        private string userid;
        private string username;
        private string rank;

        private int xp;
        private int level;

        private int karma;

        private bool banned;
        private string banreason;

        private string notes;

        public void Init(string uid, string uname, string urank, int uxp, int ulevel, bool uisbanned, string ubanreason, string unotes)
        {
            userid = uid;
            username = uname;
            rank = urank;
            xp = uxp;
            level = ulevel;
            banned = uisbanned;
            banreason = ubanreason;
            notes = unotes;
        }

        public string GetID()
        {
            return userid;
        }

        public void SetID(string id)
        {
            userid = id;
        }

        public string GetUsername()
        {
            return username;
        }

        public void SetUsername(string name)
        {

            username = name;
        }

        public int GetXP()
        {
            return xp;
        }

        public void SetXP(int new_xp)
        {
            xp = new_xp;
        }

        public int GetKarma()
        {
            return karma;
        }

        public void SetKarma(int new_karma)
        {
            karma = new_karma;
        }
        
        public string GetRank()
        {
            return rank;
        }

        public void SetRank(string newrank)
        {
            rank = newrank;
        }

        public int GetLevel()

        {
            return level;
        }

        public void SetLevel(int newLevel)
        {
            level = newLevel;
        }

        public bool GetBanStatus()
        {
            return banned;
        }

        public void SetBanStatus(bool isbanned)
        {
            banned = isbanned;
        }

        public string GetBanReason()
        {
            return banreason;
        }

        public void SetBanReason(string newbanreason)
        {
            banreason = newbanreason;
        }

        public string GetNotes()
        {
            return notes;
        }

        public void SetNotes(string newnotes)
        {
            notes = newnotes;
        }
    }
}
