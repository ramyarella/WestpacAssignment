using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Scenarios
{ 
    public static class DocuPath
     { 
        public static string GetDataFromXML(string XMLPath, string path)
        { 
             string value = null; 
             try 
             { 
                 XmlDocument doc = new XmlDocument(); 
                 doc.Load(XMLPath); 
                 value = doc.SelectSingleNode(path).InnerText.ToString(); 
                  
             } 
             catch (Exception ex) 
             { 
                 throw ex; 
             }    
             return value; 
         } 
     } 
 } 
