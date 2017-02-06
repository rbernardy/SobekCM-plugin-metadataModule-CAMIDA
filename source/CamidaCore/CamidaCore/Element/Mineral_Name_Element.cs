using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SobekCM.Core.ApplicationState;
using SobekCM.Core.Configuration.Localization;
using SobekCM.Core.Users;
using SobekCM.Resource_Object;
using System.Web;

namespace CamidaCore
{
    public class Mineral_Name_Element : SobekCM.Library.Citation.Elements.simpleTextBox_Element
    {
        public Mineral_Name_Element() : base("Mineral_Name","cc_mineral_name")
        {
            Repeatable = false;
        }

        public override void Prepare_For_Save(SobekCM_Item Bib, User_Object Current_User)
        {
            // Do nothing since there is only one value.
        }

        public override void Render_Template_HTML(TextWriter Output, SobekCM_Item Bib, string Skin_Code, bool IsMozilla, StringBuilder PopupFormBuilder, User_Object Current_User, Web_Language_Enum CurrentLanguage, Language_Support_Info Translator, string Base_URL)
        {
            if (!String.IsNullOrEmpty(Acronym))
            {
                Acronym = "Enter the Mineral Name";
            }

            string valueToDisplay = string.Empty;

            // Look for an existing value for mineral_name

            CamidaCore_Info camidaInfo = Bib.Get_Metadata_Module("CamidaCore") as CamidaCore_Info;

            if (camidaInfo != null)
            {
                valueToDisplay = camidaInfo.Mineral_Name;
            }

            render_helper(Output, valueToDisplay, Skin_Code, Current_User, CurrentLanguage, Translator, Base_URL);
        }

        public override void Save_To_Bib(SobekCM_Item Bib)
        {
            //pclogme.logme("PC_Era_Element: Save_To_Bib: [" + Bib.BibID + "_" + Bib.VID + "]...");

            string[] getKeys = HttpContext.Current.Request.Form.AllKeys;

            //pclogme.logme("PC_Era_Element: Save_To_Bib: getKeys has " + getKeys.Length + " keys.");
            //pclogme.logme("PC_Era_Element: Save_To_Bib: html_element_name=[" + html_element_name + "].");
            
            foreach (string thisKey in getKeys)
            {
                if (thisKey.IndexOf(html_element_name.Replace("_", "")) == 0)
                {
                    //pclogme.logme("PC_Era_Element: Save_To_Bib: Key matched [" + thisKey + "].");

                    // get any existing postcard module

                    CamidaCore_Info camidaInfo = Bib.Get_Metadata_Module("CamidaCore") as CamidaCore_Info;

                    // user's value

                    string value = HttpContext.Current.Request.Form[thisKey];

                    // Was there a value from user?

                    if (value.Length > 0)
                    {
                        //pclogme.logme("PC_Era_Element: Save_To_Bib: Value's length was > 0 [" + value + "].");

                        // Ensure postcard module exists and is added to the item

                        if (camidaInfo == null)
                        {
                            //pclogme.logme("PC_Era_Element: Save_To_Bib: postcardInfo was null.");

                            camidaInfo = new CamidaCore_Info();

                            Bib.Add_Metadata_Module("CamidaCore", camidaInfo);
                        }
                        else
                        {
                           // pclogme.logme("PC_Era_Element: Save_To_Bib: postcardInfo was not null.");
                        }

                        // set this value

                        camidaInfo.Mineral_Name = value;
                    }
                    else
                    {
                        // clear the era if the value from the user was blank

                        if (camidaInfo != null)
                        {
                            camidaInfo.Mineral_Name = string.Empty;
                        }
                    }

                    return;
                }
                else
                {
                    //pclogme.logme("PC_Era_Element: Save_To_Bib: Key didn't match [" + thisKey + "].");
                }
            }
        }
    }
}