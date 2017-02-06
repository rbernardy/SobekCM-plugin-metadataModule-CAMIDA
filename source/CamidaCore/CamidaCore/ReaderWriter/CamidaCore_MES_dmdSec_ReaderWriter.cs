using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using SobekCM.Resource_Object;
using SobekCM.Resource_Object.METS_Sec_ReaderWriters;
using System.Diagnostics;

namespace CamidaCore.ReaderWriter
{
    class CamidaCore_MES_dmdSec_ReaderWriter : XML_Writing_Base_Type, iPackage_dmdSec_ReaderWriter
    {
        public bool Include_dmdSec(SobekCM_Item METS_Item, Dictionary<string, object> Options)
        {
            //pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Include_dmdSec...");

            CamidaCore_Info camidaInfo = METS_Item.Get_Metadata_Module("CamidaCore") as CamidaCore_Info;

            if (camidaInfo == null)
            {
                //pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Include_dmdSec: postcardInfo is null.");

                return false;
            }
            else
            {
                if (!camidaInfo.hasData)
                {
                    //pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Include_dmdSec: Not null, but no data, not including.");

                    return false;
                }
                else
                {
                    //pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Include_dmdSec: Not null, has data, including.");

                    return true;
                }
            }
        }

        public bool Read_dmdSec(XmlReader Input_XmlReader, SobekCM_Item Return_Package, Dictionary<string, object> Options)
        {
           //pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Read_dmdSec: " + Return_Package.BibID + "_" + Return_Package.VID + "...");

            CamidaCore_Info camidaInfo = Return_Package.Get_Metadata_Module("CamidaCore") as CamidaCore_Info;

            if (camidaInfo == null)
            {
                //pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Read_dmdSec: postcardInfo was null, creating and adding...");

                camidaInfo = new CamidaCore_Info();

                Return_Package.Add_Metadata_Module("CamidaCore", camidaInfo);
            }

            //pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Read_dmdSec: Beginning read loop.");
            
            do
            {
                if ((Input_XmlReader.NodeType == XmlNodeType.EndElement) && ((Input_XmlReader.Name == "METS:mdWrap") || (Input_XmlReader.Name == "mdWrap")))
                {
                   // pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Read_dmdSec: first node was endelement type and mdWrap, returning.");

                    return true;
                }

                // get the right division information based on node type

                if (Input_XmlReader.NodeType == XmlNodeType.Element)
                {
                    string termname = Input_XmlReader.Name.ToLower();

                    //pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Read_dmdSec: original termname=[" + termname + "].");

                    if (termname.IndexOf("camida:") == 0)
                    {
                        termname = termname.Substring(7);
                    }

                    //pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Read_dmdSec: trimmed termname=[" + termname + "].\r\n");

                    switch (termname)
                    {
                        case "mineralname":

                            Input_XmlReader.Read();

                            if (Input_XmlReader.NodeType == XmlNodeType.Text)
                            {
                                if (Input_XmlReader.Value.Length > 0)
                                {
                                    camidaInfo.Mineral_Name = Input_XmlReader.Value;

                                    //pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Read_dmdSec: read imagecapation=[" + postcardInfo.Image_Caption + "].");
                                }
                            }

                            break;
                    }
                }
            } while (Input_XmlReader.Read());

            //pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Read_dmdSec: loop done.");

            return true;
        }

        public string[] Schema_Location(SobekCM_Item METS_Item)
        {
            //pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Schema_Location...");

            return new String[] { };
        }

        public string[] Schema_Namespace(SobekCM_Item METS_Item)
        {
            //pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Schema_Namespace...");

            return new string[] { "postcard=\"http://dis.lib.usf.edu/standards/camida/camida.xsd\"" };
        }

        public bool Schema_Reference_Required_Package(SobekCM_Item METS_Item)
        {
            //pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Schema_Reference_Required_Package.");

            CamidaCore_Info camidaInfo = METS_Item.Get_Metadata_Module("CamidaCore") as CamidaCore_Info;
            
            if (camidaInfo == null)
            {
                //pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Schema_Reference_Required_Package: postcardInfo was null.");

                return false;
            }
            else
            {
               // pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Schema_Reference_Required_Package: postcardInfo was NOT null.");

                if (camidaInfo.hasData)
                {
                   // pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Schema_Reference_Required_Package: has data.");
                }
                else
                {
                    //pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Schema_Reference_Required_Package: does NOT have data.");
                }

                return camidaInfo.hasData;
            }
        }

        public bool Write_dmdSec(TextWriter Output_Stream, SobekCM_Item METS_Item, Dictionary<string, object> Options)
        {
            //pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Write_dmdSec: ...");

            CamidaCore_Info camidaInfo = METS_Item.Get_Metadata_Module("CamidaCore") as CamidaCore_Info;
            
            if (camidaInfo == null)
            {
                //pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Write_dmdSec: postcardInfo is null.");

                return false;
            }
            else
            {
                if (!camidaInfo.hasData)
                {
                    //pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Write_dmdSec: Not null, but no data.");

                    return false;
                }
                else
                {
                    //pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Write_dmdSec: Not null, has data.");
                }
            }

            Output_Stream.WriteLine("<camida:camida>");

            Output_Stream.WriteLine("<camida:general>");

            if (!String.IsNullOrEmpty(camidaInfo.Mineral_Name))
            {
               // pclogme.logme("PostcardCore_METS_dmdSec_ReaderWriter: Write_dmdSec: writing image caption=[" + postcardInfo.Image_Caption + "].");

                Output_Stream.WriteLine("<camida:mineralName>" + Convert_String_To_XML_Safe(camidaInfo.Mineral_Name) + "</camida:mineralName>");
            }

            Output_Stream.WriteLine("</camida:general>");

            Output_Stream.WriteLine("</camida:camida>");
            
            return true;
        }
    }
}