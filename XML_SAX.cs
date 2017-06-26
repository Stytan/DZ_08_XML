using System;
using System.Xml;
using System.Xml.XPath;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_SAX
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            #region SAX - reader
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader("./Cars.xml");
                reader.WhitespaceHandling = WhitespaceHandling.None;
                while (reader.Read())
                {
                    Console.WriteLine(reader.NodeType + " " +
                        reader.Name + " " +
                        reader.Value);
                    if (reader.AttributeCount > 0)
                    {
                        while (reader.MoveToNextAttribute())
                        {
                            Console.WriteLine(reader.NodeType + " " +
                                reader.Name + " " +
                                reader.Value);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                reader.Close();
            }
            #endregion
            */
            /*
            #region SAX - writer
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter("Cars3.xml",
                                            System.Text.Encoding.Unicode);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("Cars");
                writer.WriteStartElement("Car");
                writer.WriteAttributeString("img", "./imd1.jpg");
                writer.WriteElementString("Manufacturer", "Audi");
                writer.WriteElementString("Model", "A1");
                writer.WriteElementString("Year", "2015");
                writer.WriteStartElement("Color", "White");
                writer.WriteAttributeString("type","","Glance");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
            catch (Exception)
            {
            }
            finally
            {
                writer.Close();
            }
            #endregion
            */
            /*
            //XPATH 
            XPathDocument doc = new XPathDocument("Cars.xml");
            XPathNavigator nav = doc.CreateNavigator();
            XPathNodeIterator iterator = nav.Select("/Cars/Car");
            while (iterator.MoveNext())
            {
                XPathNodeIterator it = iterator.Current.Select("Manufacturer");
                it.MoveNext();
                string man = it.Current.Value;
                it = iterator.Current.Select("Model");
                it.MoveNext();
                string model = it.Current.Value;
                Console.WriteLine(man + " " + model);
            }
             * */
            /*SAX - создать 
             * DOM - прочитать
             * описание студентов id, name, 
             */

            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter("Students.xml",
                                            System.Text.Encoding.Unicode);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("Students");
                writer.WriteStartElement("Student");
                writer.WriteAttributeString("photo", "./imd1.jpg");
                writer.WriteElementString("id", "1");
                writer.WriteElementString("Name", "Ivan Vasilev");
                writer.WriteElementString("BirthDay", "11.04.1992");
                writer.WriteElementString("Group", "IT-2707");
                writer.WriteEndElement();
                writer.WriteStartElement("Student");
                writer.WriteAttributeString("photo", "./imd2.jpg");
                writer.WriteElementString("id", "2");
                writer.WriteElementString("Name", "Petro Kuznetsov");
                writer.WriteElementString("BirthDay", "25.02.1993");
                writer.WriteElementString("Group", "IT-2707");
                writer.WriteEndElement();
                writer.WriteEndElement();
            }
            catch (Exception) { }
            finally
            {
                if (writer != null)
                {
                    writer.Flush();
                    writer.Close();
                }
            }

            XmlDocument doc = new XmlDocument();
            doc.Load("./Students.xml");
            XmlNodeList nodes = doc.GetElementsByTagName("Student");
            foreach (XmlNode node in nodes)
            {
                Console.WriteLine(node["id"].InnerText +
                    " - " + node["Name"].InnerText +
                    ", Birthday: " + node["BirthDay"].InnerText +
                    ", Group: " + node["Group"].InnerText +
                    ", Photo: " + node.Attributes["photo"].InnerText);
            }
        }
    }
}
