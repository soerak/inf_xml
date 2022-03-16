using System;
using System.Xml;
using System.Threading;
using System.IO;
using System.Linq;

namespace MyNamespace
{
    public class Program
    {
        


        public static void Main(string[] args)
        {
            Console.Write("MODE >>\t");
            string input = Console.ReadLine();

            if(input == "1"){
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load("file.xml");

                XmlNodeList nodelist = xmldoc.GetElementsByTagName("row");
                foreach(XmlNode node in nodelist){
                
                    Console.WriteLine("NAME:\t\t" + node["name"].InnerText);
                    Console.WriteLine("EMAIL:\t\t" + node["email"].InnerText);
                
                    if(node["about"].InnerText != string.Empty){
                        Console.WriteLine("ABOUT:\t\t" + node["about"].InnerText);
                    }

                    Console.WriteLine(" ");
                }
            } else if (input == "2")
            {
                
                // EINSTELLUNGEN FÜR DEN WRITER
                var sts = new XmlWriterSettings()
                {
                    Indent = true,
                };
                
                // MUSS USING BEINHALTEN IDK WHY          datei   einstellungen
                using XmlWriter writer = XmlWriter.Create("data.xml", sts);
                Random _rng = new Random();

                // STARTE DEN WRITER
                writer.WriteStartDocument();

                writer.WriteStartElement("root"); // STARTE EIN ELEMENT <element>
                    writer.WriteStartElement("user");
                        writer.WriteStartElement("id");
                            writer.WriteValue(_rng.Next(1, 100)); // MUSS KEIN STR SEIN
                        writer.WriteEndElement();
                    writer.WriteEndElement(); // BEENDE DAS ELEMENT </element>

                    writer.WriteStartElement("user");
                        writer.WriteStartElement("id");
                            writer.WriteValue(_rng.Next(1, 100)); 
                        writer.WriteEndElement();
                    writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteEndDocument(); // ENDE DEN WRITER

                Console.WriteLine("XML document created"); // DEBUG


            }
            else if(input == "3")
            {

                List<User> usrlist = new List<User>();

                usrlist.Add(new User("kevin1", "megakevin"));
                usrlist.Add(new User("chantal1", "passwort"));
                usrlist.Add(new User("jacob1", "80085"));

                var sts = new XmlWriterSettings()
                {
                    Indent = true,
                };

                using XmlWriter writer = XmlWriter.Create("dynamic.xml", sts);
                writer.WriteStartDocument();

                writer.WriteStartElement("root");


                foreach(User user in usrlist){

                    writer.WriteStartElement("user");
                        writer.WriteStartElement("username");
                            writer.WriteValue(user.username);
                        writer.WriteEndElement();

                        writer.WriteStartElement("password");
                            writer.WriteValue(user.password);
                        writer.WriteEndElement();
                    writer.WriteEndElement();

                }

                writer.WriteEndElement();
                writer.WriteEndDocument();

                /*
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load("dynamic.xml");

                XmlNodeList nodelist = xmldoc.GetElementsByTagName("user");
                foreach(XmlNode node in nodelist){
                
                    Console.WriteLine("USERNAME:\t\t" + node["username"].InnerText);
                    Console.WriteLine("PASSWORT:\t\t" + node["password"].InnerText);
                    Console.WriteLine(" ");
                }
                */


            }
            
            
            // invalid mode
            else {Console.WriteLine("invalid mode");}
            
        }
    }

    public class User{

        public string username;
        public string password;

        public User(string _username, string _password){
            this.username = _username;
            this.password = _password;
        }


    }

}