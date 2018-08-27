using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using System.Text;
using ApolloBot.Modules;

namespace ApolloBot.Modules
{
    class XML
    {
        List<XMLInstance> xmlList = new List<XMLInstance>();

        public void InitXML()
        {
            AddXMLEntry("101", "Apollo", "Admin", 0, 100, false, "Not Banned", "None");
            AddXMLEntry("102", "Dom", "User", 0, 100, false, "Not Banned", "None");
            AddXMLEntry("103", "Cawky", "Moderator", 0, 100, false, "Not Banned", "None");
        }

        public void LoadXML()
        {

        }

        public void CreateXMLFile()
        {
            XmlTextWriter writer = new XmlTextWriter("Users.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Users");
            foreach(XMLInstance instance in xmlList)
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
                writer.WriteValue($"{instance.GetBanned()}");
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
            XMLInstance instance = new XMLInstance();
            instance.Init(uid, uname, urank, uxp, ulevel, uisbanned, ubanreason, unotes);
            xmlList.Add(instance);
        }

        public void DeleteXMLEntry(string username)
        {

        }

        public void ReturnXMLEntryByUN(string username, XMLInstance instance)
        {

        }

        public void ReturnXMLEntryByUID(string userID, XMLInstance instance)
        {

        }

    }
}
