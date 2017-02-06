using System;
using SobekCM.Core.BriefItem;
using SobekCM.Resource_Object;

namespace CamidaCore.BriefItemMapper
{
    public class CamidaCore_BriefItemMapper : IBriefItemMapper
    {
        public bool MapToBriefItem(SobekCM_Item Original, BriefItemInfo New)
        {
            //PostcardCore_Logme pclogme = new PostcardCore_Logme();

            //pclogme.logme("PostcardCore_BriefItemMapper...");

            CamidaCore_Info camidaInfo = Original.Get_Metadata_Module("CamidaCore") as CamidaCore_Info;

            if ((camidaInfo != null) && (camidaInfo.hasData))
            {
                // pclogme.logme("PostcardCore_BriefItemMapper: postcardInfo was not null and has data...");

                if (!String.IsNullOrEmpty(camidaInfo.Mineral_Name))
                {
                    New.Add_Description("Mineral Name", camidaInfo.Mineral_Name);
                }
            }

            return true;
        }
    }
}