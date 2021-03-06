﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using System.Text;
using ApolloBot.Modules;
using ApolloBot.Modules.XP;
using ApolloBot.Modules.Settings;

namespace ApolloBot.Modules
{
    class XML
    {
        List<User> xmlList = new List<User>();

        public void InitXML()
        {
            AddXMLEntry("101", "Apollo", "Admin", 0, 100, false, "Not Banned", "None");
            AddXMLEntry("102", "Dom", "User", 0, 100, false, "Not Banned", "None");
            AddXMLEntry("103", "Cawky", "Moderator", 0, 100, false, "Not Banned", "None");
        }

        public void LoadXML(BotSettings settings)
        {
            //Run on Startup or Load when Called.
            //Load Settings.XML
            //Load Users.XML

        }

        public void CreateXMLFileUsers()
        {
            XmlTextWriter writer = new XmlTextWriter("Users.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Users");
            foreach(User instance in xmlList)
            {
                writer.WriteStartElement("User");
                writer.WriteStartElement("UserID");
                writer.WriteValue($"{instance.GetID()}");
                writer.WriteEndElement();
                writer.WriteStartElement("Username");
                writer.WriteValue($"{instance.GetUsername()}");
                writer.WriteEndElement();
                writer.WriteStartElement("Rank");
                writer.WriteValue($"{instance.GetRank()}");
                writer.WriteEndElement();
                writer.WriteStartElement("Level");
                writer.WriteValue($"{instance.GetLevel()}");
                writer.WriteEndElement();
                writer.WriteStartElement("XP");
                writer.WriteValue($"{instance.GetXP()}");
                writer.WriteEndElement();
                writer.WriteStartElement("IsBanned");
                writer.WriteValue($"{instance.GetBanStatus()}");
                writer.WriteEndElement();
                writer.WriteStartElement("BanReason");
                writer.WriteValue($"{instance.GetBanReason()}");
                writer.WriteEndElement();
                writer.WriteStartElement("Notes");
                writer.WriteValue($"{instance.GetNotes()}");
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            Console.WriteLine("XML File created !");

        }

        public void AddXMLEntry(string uid, string uname, string urank, int uxp, int ulevel, bool uisbanned, string ubanreason, string unotes)
        {
            User instance = new User();
            instance.Init(uid, uname, urank, uxp, ulevel, uisbanned, ubanreason, unotes);
            xmlList.Add(instance);
        }

        public void DeleteXMLEntry(string username)
        {

        }

        public void ReturnXMLEntryByUN(string username, User instance)
        {

        }

        public void ReturnXMLEntryByUID(string userID, User instance)
        {

        }

    }
}
