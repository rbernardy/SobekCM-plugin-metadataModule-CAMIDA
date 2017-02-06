using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SobekCM.Resource_Object;

namespace CamidaCore
{
    [Serializable]
    public class CamidaCore_Info : SobekCM.Resource_Object.Metadata_Modules.iMetadata_Module
    {
        #region individual private fields

        // GENERAL tab
        private String mineralName;
        private String caveName;
        private String geoLatitude;
        private String geoLongitude;
        private String geoLength;
        private String geoDepth;
        private String geoAltitude;
        private String geoWater;
        private String typeGeologicRock;
        //private String geologicAge; SELECT LIST
        private String geologicOthers;
        //private String caveClimateType; SELECT LIST
        private String caveClimateTemperature;
        private String caveClimateHumidity;
        private String occurencesSpeleothems; // TEXT AREA
        // frequencySpeleothems; SELECT LIST
        private String occurenceSpeleothemsOther;
        private String locationWithinCave; // TEXT AREA
        private String occurenceNonCave; // TEXT AREA
        private String occurenceCave; // TEXT AREA
        private String locationsCaveOtherOld;
        private String conservationProtection;
        private String depositionStability; // TEXT AREA

        // MINERALOGY tab

        // mineralImaStatus SELECT LIST
        // mineralGroup SELECT LIST
        private String chemicalFormula;
        private String varieties; // TEXT AREA
        private String habit;
        private String physicalColor;
        private String physicalLuster;
        private String physicalHardness;
        private String physicalCleavage;
        private String dianosticFeatures; // TEXT AREA
        private String analyticalDataIdentifiedBy; // TEXT AREA
        private String analyticalOtherMethods; // TEXT AREA
        private String analysisChemical; // TEXT AREA
        private String mineralAssemblage; // TEXT AREA

        // crystallography tab

        // crystalSystem SELECT LIST
        private String cellParameterA;
        private String cellParameterB;
        private String cellParameterC;
        private String cellParameterAlpha;
        private String cellParameterBeta;
        private String cellParameterGamma;
        private String crystalSize;
        private String sem; // TEXT AREA
        private String polarizing; // TEXT AREA
        private String twins;
        private String pseudomorphosis;
        private String commonCrystalForms; // TEXT AREA

        // related info

        private String relatedReferences; // TEXT AREA
        private String citedInCamida;
        private String repository;
        private String generalInfo; // TEXT AREA

        #endregion

        public String Mineral_Name
        {
            get { return mineralName ?? String.Empty; }
            set { mineralName = value; }
        }

        public String Cave_Name
        {
            get { return caveName ?? String.Empty; }
            set { caveName = value; }
        }

        public String Geo_Latitude
        {
            get { return geoLatitude ?? String.Empty; }
            set { geoLatitude = value; }
        }

        public String Geo_Longitude
        {
            get { return geoLongitude ?? String.Empty; }
            set { geoLongitude = value; }
        }

        public String Geo_Length
        {
            get { return geoLength ?? String.Empty; }
            set { geoLength = value; }
        }

        public String Geo_Depth
        {
            get { return geoDepth ?? String.Empty; }
            set { geoDepth = value; }
        }

        public String Geo_altitude
        {
            get { return geoAltitude ?? String.Empty; }
            set { geoAltitude = value; }
        }

        public String Geo_water
        {
            get { return geoWater ?? String.Empty; }
            set { geoWater = value; }
        }

        public String Type_Geologic_Rock
        {
            get { return typeGeologicRock ?? String.Empty; }
            set { typeGeologicRock = value; }
        }

        // geologic_age

        public String Geologic_Other
        {
            get { return geologicOthers ?? String.Empty; }
            set { geologicOthers = value; }
        }

        // cave_climate_type

        public String Cave_Climate_Temperature
        {
            get { return caveClimateTemperature ?? String.Empty; }
            set { caveClimateTemperature = value; }
        }

        public String Cave_Climate_Humidity
        {
            get { return caveClimateHumidity ?? String.Empty; }
            set { caveClimateHumidity = value; }
        }

        public String Occurences_Spelothems
        {
            get { return occurencesSpeleothems ?? String.Empty; }
            set { occurencesSpeleothems = value; }
        }

        // frequency_speleothems

        public String Occurence_Speleothems_Other
        {
            get { return occurenceSpeleothemsOther ?? String.Empty; }
            set { occurenceSpeleothemsOther = value; }
        }

        public String Location_Within_Cave
        {
            get { return locationWithinCave ?? String.Empty; }
            set { locationWithinCave = value; }
        }

        public String Occurence_Non_Cave
        {
            get { return occurenceNonCave ?? String.Empty; }
            set { occurenceNonCave = value; }
        }

        public String Occurence_Cave
        {
            get { return occurenceCave ?? String.Empty; }
            set { occurenceCave = value; }
        }

        public String Locations_Cave_Other_old
        {
            get { return locationsCaveOtherOld ?? String.Empty; }
            set { locationsCaveOtherOld = value; }
        }

        public String Conservation_Protection
        {
            get { return conservationProtection ?? String.Empty; }
            set { conservationProtection = value; }
        }

        public String Deposition_Stability
        {
            get { return depositionStability ?? String.Empty; }
            set { depositionStability = value; }
        }

        public Boolean hasData
        {
            get
            {
                return true;
            }
        }

        public List<KeyValuePair<string, string>> Metadata_Search_Terms
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Module_Name
        {
            get
            {
                return "CamidaCore";
            }
        }

        public bool Retrieve_Additional_Info_From_Database(int ItemID, string DB_ConnectionString, SobekCM_Item BibObject, out string Error_Message)
        {
            Error_Message = String.Empty;

            return true;
        }

        public bool Save_Additional_Info_To_Database(int ItemID, string DB_ConnectionString, SobekCM_Item BibObject, out string Error_Message)
        {
            Error_Message = String.Empty;

            return true;
        }
    }
}