using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML
{
    /*XML:
     * -хранение данных для персонального использования на накопителе
     * -серриализация
     * -web-services-сетевые приложения используя HTTP обмениваются XML-документами
     */
    /* DOM-documet object model         SAX-Simple API for XML
     * читает весь документ целиком     читает как текстовый документ
     * и формирует в памяти дерево      +можно читать построчно (быстрее)
     * -нужно прочитать всё             -нет возможности легкого поиска
     * +поиск по построенному           -контроль структуры полностью на разработчике
     *  дереву очень быстрый
     * +можно достраивать дерево
     */
    class Program
    {
        static void OutputNode(XmlNode node)
        {
            Console.WriteLine(node.NodeType + " " +
                                node.Name + " " +
                                node.Value);
            if(node.Attributes != null)
                foreach (XmlAttribute attr in node.Attributes)
                {
                    Console.WriteLine(attr.NodeType + " " +
                        attr.Name + " " +
                        attr.Value);
                }
            if (node.HasChildNodes)
            {
                XmlNodeList children = node.ChildNodes;
                foreach (XmlNode child in children)
                {
                    OutputNode(child);
                }
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //Чтение документов в DOM-модели
            /*XmlDocument doc = new XmlDocument();
            doc.Load("./Cars.xml");
            XmlNodeList nodes = doc.GetElementsByTagName("Car");
            foreach(XmlNode node in nodes)
            {
                Console.WriteLine(node["Manufacturer"].InnerText +
                    " - " + node["Model"].InnerText);
            }
            foreach (XmlNode node in nodes)
            {
                OutputNode(node);
            }*/

#region Запись документов в DOM-модели
            XmlDocument doc = new XmlDocument();
            doc.Load("./Cars.xml");
            XmlNode root = doc.DocumentElement;
            root.RemoveChild(root.FirstChild);
            XmlNode bike = doc.CreateElement("Moto");
            XmlNode e1 = doc.CreateElement("Manufacturer");
            XmlNode e2 = doc.CreateElement("Model");
            XmlNode e3 = doc.CreateElement("Year");
            XmlNode e4 = doc.CreateElement("Color");

            XmlNode text1 = doc.CreateTextNode("Harley");
            XmlNode text2 = doc.CreateTextNode("B1");
            XmlNode text3 = doc.CreateTextNode("1991");
            XmlNode text4 = doc.CreateTextNode("Silver");

            e1.AppendChild(text1);
            e2.AppendChild(text2);
            e3.AppendChild(text3);
            e4.AppendChild(text4);

            XmlAttribute attr = doc.CreateAttribute("type");
            attr.Value = "Metallic";
            e4.Attributes.Append(attr);

            bike.AppendChild(e1);
            bike.AppendChild(e2);
            bike.AppendChild(e3);
            bike.AppendChild(e4);

            root.AppendChild(bike);
            
            doc.Save("./Cars2.xml");
#endregion 
        }
    }
}
