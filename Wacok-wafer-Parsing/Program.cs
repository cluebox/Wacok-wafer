using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpssLib.SpssDataset;
using SpssLib.DataReader;
using System.IO;

namespace Wacok_wafer_Parsing
{
    class Program
    {
        static void Main(string[] args)
        {
            int SurveyID = 600595;
            //string SurveyPeriod = "2014-09-30";//survey period
            string AttendedOn = "2018-11-30";
            //string year = getYear(SurveyPeriod); 
            string country = "Indonesia";//survey country
            DB_insertion_wacok iobj = new DB_insertion_wacok();
            string questions = "id,weight,S9,S8,S2,S7,S10,S11,S12,WA9,WA1,WA2_1,WA2_2,WA2_3,WA2_4,WA2_5,WA2_6,WA2_7,WA2_8,WA2_9,WA2_10,WA2_11,WA2_12,WA2_13,WA2_14,WA2_15,WA2_16,WA2_17,WA2_18,WA7,WA11_1,WA11_2,WA11_3,WA11_4,WA11_5,WA11_6,WA11_7,WA11_8,WA11_9,WA11_10,WA11_11,WA11_12,WA11_13,WA11_14,WA11_15,WA11_16,WA11_17,WA11_18,WA16,WA3,WA18,WA6,WA13_1,WA13_2,WA13_3,WA13_4,WA13_5,WA13_6,WA13_7,WA13_8,WA13_9,WA13_10,WA13_11,WA13_12,WA13_13,WA13_14,WA13_15,WA13_16,WA13_17,WA13_18,WA12_1,WA12_2,WA12_3,WA12_4,WA12_5,WA12_6,WA12_7,WA12_8,WA12_9,WA12_10,WA12_11,WA12_12,WA12_13,WA12_14,WA12_15,WA12_16,WA12_17,WA12_18,WA14_1,WA14_2,WA14_3,WA14_4,WA14_5,WA14_6,WA14_7,WA14_8,WA14_9,WA14_10,WA14_11,WA14_12,WA14_13,WA14_14,WA14_15,WA14_16,WA14_17,WA14_18,WA15_1,WA15_2,WA15_3,WA15_4,WA15_5,WA15_6,WA15_7,WA15_8,WA15_9,WA15_10,WA15_11,WA15_12,WA15_13,WA15_14,WA15_15,WA15_16,WA15_17,WA15_18,WA20,WA21,WA22,W23,WA24,WA25,WA26,WA27,WA28,WA29,WA30,WA31,WA32,WA33,WA34,WA35,WA36,WA37,WA40,WA41,S13_1,S13_2,S13_3,S13_4,S13_5,S13_6,S13_7,S13_8,S14_1,S14_2,S14_3,S14_4,S14_5,S14_6,S14_7,S14_8,WA4,WA5_13,WA5_14,WA5_15,WA5_16,WA5_17,WA5_18,WA1_Net1,WA1_Net2,WA1_Net3,WA1_Net4,WA1_Net5,WA2_Net1,WA2_Net2,WA2_Net3,WA2_Net4,WA2_Net5,WA7_Net1,WA7_Net2,WA7_Net3,WA7_Net4,WA7_Net5,WA11_Net1,WA11_Net2,WA11_Net3,WA11_Net4,WA11_Net5,WA16_Net1,WA16_Net2,WA16_Net3,WA16_Net4,WA16_Net5,WA3_Net1,WA3_Net2,WA3_Net3,WA3_Net4,WA3_Net5,WA13_Net1,WA13_Net2,WA13_Net3,WA13_Net4,WA13_Net5,WA12_Net1,WA12_Net2,WA12_Net3,WA12_Net4,WA12_Net5,WA14_Net1,WA14_Net2,WA14_Net3,WA14_Net4,WA14_Net5,WA15_Net1,WA15_Net2,WA15_Net3,WA15_Net4,WA15_Net5,WAAP43_1,WAAP43_2,WAAP43_3,WA2_19,WA2_20,WA11_19,WA11_20,WA13_19,WA13_20,WA12_19,WA12_20,WA14_19,WA14_20,WA15_19,WA15_20";// dashboard variable value          
            //string questions = "WA2_19,WA2_20,WA11_19,WA11_20,WA13_19,WA13_20,WA12_19,WA12_20,WA14_19,WA14_20,WA15_19,WA15_20";// dashboard variable value          
            //string questions = "WA12_19,WA12_20";// dashboard variable value          
            string[] spss_variable_name = questions.Split(',');
            SpssReader spssDataset;
            using (FileStream fileStream = new FileStream(@"D:\spssparsing\wacok\wacokWafer_Dec2018.sav", FileMode.Open, FileAccess.Read, FileShare.Read, 2048 * 10, FileOptions.SequentialScan))
            {
                spssDataset = new SpssReader(fileStream); // Create the reader, this will read the file header
                foreach (string spss_v in spss_variable_name)
                {
                    foreach (var variable in spssDataset.Variables)  // Iterate through all the varaibles
                    {
                        if (variable.Name.Equals(spss_v))
                        {
                            foreach (KeyValuePair<double, string> label in variable.ValueLabels)
                            {
                                string VARIABLE_NAME = spss_v;
                                string VARIABLE_NAME_SUB_NAME = variable.Name;
                                string VARIABLE_ID = label.Key.ToString();
                                string VARIABLE_VALUE = label.Value;
                                string VARIABLE_NAME_QUESTION = variable.Label;
                                string BASE_VARIABLE_NAME = variable.Name;
                               // iobj.insert_Dashboard_variable_values(VARIABLE_NAME, VARIABLE_NAME_SUB_NAME, VARIABLE_ID, VARIABLE_VALUE, VARIABLE_NAME_QUESTION, SurveyID, country, BASE_VARIABLE_NAME, AttendedOn);
                            }
                        }

                    }
                }
                foreach (var record in spssDataset.Records)
                {
                    string userID = null;
                    string u_id = null;
                    string variable_name;
                    decimal Weight = 0;
                    string Country = "-- Not Available --";
                    string Education = "-- Not Available --";
                    string Location = "-- Not Available --";
                    string Gender = "-- Not Available --";
                    string MaritalStatus = "-- Not Available --";
                    string AgeGroup = "-- Not Available --";
                    string SES = "-- Not Available --";
                    string Occupation = "-- Not Available --";
                    string WA9= "-- Not Available --";
                    string BrTom= "-- Not Available --";
                    string BrSpont_Astor= "-- Not Available --";
                    string BrSpont_Fullo= "-- Not Available --";
                    string BrSpont_Gery_Chocolatos= "-- Not Available --";
                    string BrSpont_Gery_Chocolatos_Dark= "-- Not Available --";
                    string BrSpont_Gery_Saluut= "-- Not Available --";
                    string BrSpont_Nabati_Hansel= "-- Not Available --";
                    string BrSpont_Nissin_Wafer= "-- Not Available --";
                    string BrSpont_Richoco= "-- Not Available --";
                    string BrSpont_Richoco_Rolls= "-- Not Available --";
                    string BrSpont_Roma_Wafer= "-- Not Available --";
                    string BrSpont_Superstar= "-- Not Available --";
                    string BrSpont_Tango_Chocolate_Wafer= "-- Not Available --";
                    string BrSpont_Nissin_wafer_keju= "-- Not Available --";
                    string BrSpont_Oops_Wafer_Keju= "-- Not Available --";
                    string BrSpont_Richeese_Nabati_Keju= "-- Not Available --";
                    string BrSpont_Richeese_Rolls= "-- Not Available --";
                    string BrSpont_Tango_Long_Cheese= "-- Not Available --";
                    string BrSpont_Zuperrr_Keju_Wafer_Keju= "-- Not Available --";
                    string AdTom= "-- Not Available --";
                    string AdSpont_Astor= "-- Not Available --";
                    string AdSpont_Fullo= "-- Not Available --";
                    string AdSpont_Gery_Chocolatos= "-- Not Available --";
                    string AdSpont_Gery_Chocolatos_Dark= "-- Not Available --";
                    string AdSpont_Gery_Saluut= "-- Not Available --";
                    string AdSpont_Nabati_Hansel= "-- Not Available --";
                    string AdSpont_Nissin_Wafer= "-- Not Available --";
                    string AdSpont_Richoco= "-- Not Available --";
                    string AdSpont_Richoco_Rolls= "-- Not Available --";
                    string AdSpont_Roma_Wafer= "-- Not Available --";
                    string AdSpont_Superstar= "-- Not Available --";
                    string AdSpont_Tango_Chocolate_Wafer= "-- Not Available --";
                    string AdSpont_Nissin_wafer_keju= "-- Not Available --";
                    string AdSpont_Oops_Wafer_Keju= "-- Not Available --";
                    string AdSpont_Richeese_Nabati_Keju= "-- Not Available --";
                    string AdSpont_Richeese_Rolls= "-- Not Available --";
                    string AdSpont_Tango_Long_Cheese= "-- Not Available --";
                    string AdSpont_Zuperrr_Keju_Wafer_Keju= "-- Not Available --";
                    string Bumo= "-- Not Available --";
                    string Favourite_Brand= "-- Not Available --";
                    string BUMO_Cheese_wafer= "-- Not Available --";
                    string Favourite_Cheese_wafer= "-- Not Available --";
                    string ConL1M_Astor= "-- Not Available --";
                    string ConL1M_Fullo= "-- Not Available --";
                    string ConL1M_Gery_Chocolatos= "-- Not Available --";
                    string ConL1M_Gery_Chocolatos_Dark= "-- Not Available --";
                    string ConL1M_Gery_Saluut= "-- Not Available --";
                    string ConL1M_Nabati_Hansel= "-- Not Available --";
                    string ConL1M_Nissin_Wafer= "-- Not Available --";
                    string ConL1M_Richoco= "-- Not Available --";
                    string ConL1M_Richoco_Rolls= "-- Not Available --";
                    string ConL1M_Roma_Wafer= "-- Not Available --";
                    string ConL1M_Superstar= "-- Not Available --";
                    string ConL1M_Tango_Chocolate_Wafer= "-- Not Available --";
                    string ConL1M_Nissin_wafer_keju= "-- Not Available --";
                    string ConL1M_Oops_Wafer_Keju= "-- Not Available --";
                    string ConL1M_Richeese_Nabati_Keju= "-- Not Available --";
                    string ConL1M_Richeese_Rolls= "-- Not Available --";
                    string ConL1M_Tango_Long_Cheese= "-- Not Available --";
                    string ConL1M_Zuperrr_Keju_Wafer_Keju= "-- Not Available --";
                    string ConL3M_Astor= "-- Not Available --";
                    string ConL3M_Fullo= "-- Not Available --";
                    string ConL3M_Gery_Chocolatos= "-- Not Available --";
                    string ConL3M_Gery_Chocolatos_Dark= "-- Not Available --";
                    string ConL3M_Gery_Saluut= "-- Not Available --";
                    string ConL3M_Nabati_Hansel= "-- Not Available --";
                    string ConL3M_Nissin_Wafer= "-- Not Available --";
                    string ConL3M_Richoco= "-- Not Available --";
                    string ConL3M_Richoco_Rolls= "-- Not Available --";
                    string ConL3M_Roma_Wafer= "-- Not Available --";
                    string ConL3M_Superstar= "-- Not Available --";
                    string ConL3M_Tango_Chocolate_Wafer= "-- Not Available --";
                    string ConL3M_Nissin_wafer_keju= "-- Not Available --";
                    string ConL3M_Oops_Wafer_Keju= "-- Not Available --";
                    string ConL3M_Richeese_Nabati_Keju= "-- Not Available --";
                    string ConL3M_Richeese_Rolls= "-- Not Available --";
                    string ConL3M_Tango_Long_Cheese= "-- Not Available --";
                    string ConL3M_Zuperrr_Keju_Wafer_Keju= "-- Not Available --";
                    string ConL1W_Astor= "-- Not Available --";
                    string ConL1W_Fullo= "-- Not Available --";
                    string ConL1W_Gery_Chocolatos= "-- Not Available --";
                    string ConL1W_Gery_Chocolatos_Dark= "-- Not Available --";
                    string ConL1W_Gery_Saluut= "-- Not Available --";
                    string ConL1W_Nabati_Hansel= "-- Not Available --";
                    string ConL1W_Nissin_Wafer= "-- Not Available --";
                    string ConL1W_Richoco= "-- Not Available --";
                    string ConL1W_Richoco_Rolls= "-- Not Available --";
                    string ConL1W_Roma_Wafer= "-- Not Available --";
                    string ConL1W_Superstar= "-- Not Available --";
                    string ConL1W_Tango_Chocolate_Wafer= "-- Not Available --";
                    string ConL1W_Nissin_wafer_keju= "-- Not Available --";
                    string ConL1W_Oops_Wafer_Keju= "-- Not Available --";
                    string ConL1W_Richeese_Nabati_Keju= "-- Not Available --";
                    string ConL1W_Richeese_Rolls= "-- Not Available --";
                    string ConL1W_Tango_Long_Cheese= "-- Not Available --";
                    string ConL1W_Zuperrr_Keju_Wafer_Keju= "-- Not Available --";
                    string ConYestOrToday_Astor= "-- Not Available --";
                    string ConYestOrToday_Fullo= "-- Not Available --";
                    string ConYestOrToday_Gery_Chocolatos= "-- Not Available --";
                    string ConYestOrToday_Gery_Chocolatos_Dark= "-- Not Available --";
                    string ConYestOrToday_Gery_Saluut= "-- Not Available --";
                    string ConYestOrToday_Nabati_Hansel= "-- Not Available --";
                    string ConYestOrToday_Nissin_Wafer= "-- Not Available --";
                    string ConYestOrToday_Richoco= "-- Not Available --";
                    string ConYestOrToday_Richoco_Rolls= "-- Not Available --";
                    string ConYestOrToday_Roma_Wafer= "-- Not Available --";
                    string ConYestOrToday_Superstar= "-- Not Available --";
                    string ConYestOrToday_Tango_Chocolate_Wafer= "-- Not Available --";
                    string ConYestOrToday_Nissin_wafer_keju= "-- Not Available --";
                    string ConYestOrToday_Oops_Wafer_Keju= "-- Not Available --";
                    string ConYestOrToday_Richeese_Nabati_Keju= "-- Not Available --";
                    string ConYestOrToday_Richeese_Rolls= "-- Not Available --";
                    string ConYestOrToday_Tango_Long_Cheese= "-- Not Available --";
                    string ConYestOrToday_Zuperrr_Keju_Wafer_Keju= "-- Not Available --";
                    string WA20= "-- Not Available --";
                    string WA21= "-- Not Available --";
                    string WA22= "-- Not Available --";
                    string WA23= "-- Not Available --";
                    string WA24= "-- Not Available --";
                    string WA25= "-- Not Available --";
                    string WA26= "-- Not Available --";
                    string WA27= "-- Not Available --";
                    string WA28= "-- Not Available --";
                    string WA29= "-- Not Available --";
                    string WA30= "-- Not Available --";
                    string WA31= "-- Not Available --";
                    string WA32= "-- Not Available --";
                    string WA33= "-- Not Available --";
                    string WA34= "-- Not Available --";
                    string WA35= "-- Not Available --";
                    string Ad_visibility= "-- Not Available --";
                    string WA37= "-- Not Available --";
                    string WA40= "-- Not Available --";
                    string WA41= "-- Not Available --";
                    string S13_1= "-- Not Available --";
                    string S13_2= "-- Not Available --";
                    string S13_3= "-- Not Available --";
                    string S13_4= "-- Not Available --";
                    string P1M_Chocolate= "-- Not Available --";
                    string S13_6= "-- Not Available --";
                    string S13_7= "-- Not Available --";
                    string S13_8= "-- Not Available --";
                    string S14_1= "-- Not Available --";
                    string S14_2= "-- Not Available --";
                    string S14_3= "-- Not Available --";
                    string S14_4= "-- Not Available --";
                    string P1W_Chocolate= "-- Not Available --";
                    string S14_6= "-- Not Available --";
                    string S14_7= "-- Not Available --";
                    string S14_8= "-- Not Available --";
                    string WA4 = "-- Not Available --";
                    string WA5_13 = "-- Not Available --";
                    string WA5_14 = "-- Not Available --";
                    string WA5_15 = "-- Not Available --";
                    string WA5_16 = "-- Not Available --";
                    string WA5_17 = "-- Not Available --";
                    string WA5_18 = "-- Not Available --";
                    string WA1_Net2 = "-- Not Available --";
                    string WA1_Net1 = "-- Not Available --";
                    string WA1_Net3 = "-- Not Available --";
                    string WA1_Net4 = "-- Not Available --";
                    string WA1_Net5 = "-- Not Available --";
                    string WA2_Net1 = "-- Not Available --";
                    string WA2_Net2 = "-- Not Available --";
                    string WA2_Net3 = "-- Not Available --";
                    string WA2_Net4 = "-- Not Available --";
                    string WA2_Net5 = "-- Not Available --";
                    string WA7_Net1 = "-- Not Available --";
                    string WA7_Net2 = "-- Not Available --";
                    string WA7_Net3 = "-- Not Available --";
                    string WA7_Net4 = "-- Not Available --";
                    string WA7_Net5 = "-- Not Available --";
                    string WA11_Net1 = "-- Not Available --";
                    string WA11_Net2 = "-- Not Available --";
                    string WA11_Net3 = "-- Not Available --";
                    string WA11_Net4 = "-- Not Available --";
                    string WA11_Net5 = "-- Not Available --";
                    string WA16_Net1 = "-- Not Available --";
                    string WA16_Net2 = "-- Not Available --";
                    string WA16_Net3 = "-- Not Available --";
                    string WA16_Net4 = "-- Not Available --";
                    string WA16_Net5 = "-- Not Available --";
                    string WA3_Net1 = "-- Not Available --";
                    string WA3_Net2 = "-- Not Available --";
                    string WA3_Net3 = "-- Not Available --";
                    string WA3_Net4 = "-- Not Available --";
                    string WA3_Net5 = "-- Not Available --";
                    string WA13_Net1 = "-- Not Available --";
                    string WA13_Net2 = "-- Not Available --";
                    string WA13_Net3 = "-- Not Available --";
                    string WA13_Net4 = "-- Not Available --";
                    string WA13_Net5 = "-- Not Available --";
                    string WA12_Net1 = "-- Not Available --";
                    string WA12_Net2 = "-- Not Available --";
                    string WA12_Net3 = "-- Not Available --";
                    string WA12_Net4 = "-- Not Available --";
                    string WA12_Net5 = "-- Not Available --";
                    string WA14_Net1 = "-- Not Available --";
                    string WA14_Net2 = "-- Not Available --";
                    string WA14_Net3 = "-- Not Available --";
                    string WA14_Net4 = "-- Not Available --";
                    string WA14_Net5 = "-- Not Available --";
                    string WA15_Net1 = "-- Not Available --";
                    string WA15_Net2 = "-- Not Available --";
                    string WA15_Net3 = "-- Not Available --";
                    string WA15_Net4 = "-- Not Available --";
                    string WA15_Net5 = "-- Not Available --";
                    string WAAP43_1 = "-- Not Available --";
                    string WAAP43_2 = "-- Not Available --";
                    string WAAP43_3 = "-- Not Available --";
                    string BrSpont_Richoco_Nabati_White = "-- Not Available --";
                    string BrSpont_Richoco_Pink_Lava = "-- Not Available --";
                    string AdSpont_Richoco_Nabati_White = "-- Not Available --";
                    string AdSpont_Richoco_Pink_Lava = "-- Not Available --";
                    string ConL1M_Richoco_Nabati_White = "-- Not Available --";
                    string ConL1M_Richoco_Pink_Lava = "-- Not Available --";
                    string ConL3M_Richoco_Nabati_White = "-- Not Available --";
                    string ConL3M_Richoco_Pink_Lava = "-- Not Available --";
                    string ConL1W_Richoco_Nabati_White = "-- Not Available --";
                    string ConL1W_Richoco_Pink_Lava = "-- Not Available --";
                    string ConYestOrToday_Richoco_Nabati_White = "-- Not Available --";
                    string ConYestOrToday_Richoco_Pink_Lava = "-- Not Available --";

                    foreach (var variable in spssDataset.Variables)
                    {
                        foreach (string spss_v in spss_variable_name)
                        {
                            if (variable.Name.Equals(spss_v))
                            {
                                variable_name = variable.Name;

                                switch (variable_name)
                                {
                                case "id":
                                        {
                                            u_id = Convert.ToString(record.GetValue(variable));
                                            userID = find_UserId(SurveyID, AttendedOn, u_id);
                                            break;
                                        }
                                case "weight":
                                        {
                                Weight = Convert.ToDecimal(record.GetValue(variable));
                                break;
                                }
                                case "S9": { SES = Convert.ToString(record.GetValue(variable)); break; }
                                case "S8": { Location = Convert.ToString(record.GetValue(variable)); break; }
                                case "S2": { AgeGroup = Convert.ToString(record.GetValue(variable)); break; }
                                case "S7": { Gender = Convert.ToString(record.GetValue(variable)); break; }
                                case "S10": { MaritalStatus = Convert.ToString(record.GetValue(variable)); break; }
                                case "S11": { Occupation = Convert.ToString(record.GetValue(variable)); break; }
                                case "S12": { Education = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA9": { WA9 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA1": { BrTom = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_1": { BrSpont_Astor = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_2": { BrSpont_Fullo = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_3": { BrSpont_Gery_Chocolatos = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_4": { BrSpont_Gery_Chocolatos_Dark = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_5": { BrSpont_Gery_Saluut = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_6": { BrSpont_Nabati_Hansel = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_7": { BrSpont_Nissin_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_8": { BrSpont_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_9": { BrSpont_Richoco_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_10": { BrSpont_Roma_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_11": { BrSpont_Superstar = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_12": { BrSpont_Tango_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_13": { BrSpont_Nissin_wafer_keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_14": { BrSpont_Oops_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_15": { BrSpont_Richeese_Nabati_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_16": { BrSpont_Richeese_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_17": { BrSpont_Tango_Long_Cheese = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_18": { BrSpont_Zuperrr_Keju_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA7": { AdTom = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_1": { AdSpont_Astor = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_2": { AdSpont_Fullo = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_3": { AdSpont_Gery_Chocolatos = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_4": { AdSpont_Gery_Chocolatos_Dark = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_5": { AdSpont_Gery_Saluut = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_6": { AdSpont_Nabati_Hansel = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_7": { AdSpont_Nissin_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_8": { AdSpont_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_9": { AdSpont_Richoco_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_10": { AdSpont_Roma_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_11": { AdSpont_Superstar = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_12": { AdSpont_Tango_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_13": { AdSpont_Nissin_wafer_keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_14": { AdSpont_Oops_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_15": { AdSpont_Richeese_Nabati_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_16": { AdSpont_Richeese_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_17": { AdSpont_Tango_Long_Cheese = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_18": { AdSpont_Zuperrr_Keju_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA16": { Bumo = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA3": { Favourite_Brand = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA18": { BUMO_Cheese_wafer = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA6": { Favourite_Cheese_wafer = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_1": { ConL1M_Astor = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_2": { ConL1M_Fullo = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_3": { ConL1M_Gery_Chocolatos = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_4": { ConL1M_Gery_Chocolatos_Dark = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_5": { ConL1M_Gery_Saluut = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_6": { ConL1M_Nabati_Hansel = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_7": { ConL1M_Nissin_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_8": { ConL1M_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_9": { ConL1M_Richoco_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_10": { ConL1M_Roma_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_11": { ConL1M_Superstar = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_12": { ConL1M_Tango_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_13": { ConL1M_Nissin_wafer_keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_14": { ConL1M_Oops_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_15": { ConL1M_Richeese_Nabati_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_16": { ConL1M_Richeese_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_17": { ConL1M_Tango_Long_Cheese = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_18": { ConL1M_Zuperrr_Keju_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_1": { ConL3M_Astor = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_2": { ConL3M_Fullo = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_3": { ConL3M_Gery_Chocolatos = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_4": { ConL3M_Gery_Chocolatos_Dark = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_5": { ConL3M_Gery_Saluut = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_6": { ConL3M_Nabati_Hansel = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_7": { ConL3M_Nissin_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_8": { ConL3M_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_9": { ConL3M_Richoco_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_10": { ConL3M_Roma_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_11": { ConL3M_Superstar = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_12": { ConL3M_Tango_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_13": { ConL3M_Nissin_wafer_keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_14": { ConL3M_Oops_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_15": { ConL3M_Richeese_Nabati_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_16": { ConL3M_Richeese_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_17": { ConL3M_Tango_Long_Cheese = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_18": { ConL3M_Zuperrr_Keju_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_1": { ConL1W_Astor = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_2": { ConL1W_Fullo = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_3": { ConL1W_Gery_Chocolatos = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_4": { ConL1W_Gery_Chocolatos_Dark = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_5": { ConL1W_Gery_Saluut = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_6": { ConL1W_Nabati_Hansel = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_7": { ConL1W_Nissin_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_8": { ConL1W_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_9": { ConL1W_Richoco_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_10": { ConL1W_Roma_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_11": { ConL1W_Superstar = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_12": { ConL1W_Tango_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_13": { ConL1W_Nissin_wafer_keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_14": { ConL1W_Oops_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_15": { ConL1W_Richeese_Nabati_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_16": { ConL1W_Richeese_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_17": { ConL1W_Tango_Long_Cheese = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_18": { ConL1W_Zuperrr_Keju_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_1": { ConYestOrToday_Astor = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_2": { ConYestOrToday_Fullo = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_3": { ConYestOrToday_Gery_Chocolatos = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_4": { ConYestOrToday_Gery_Chocolatos_Dark = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_5": { ConYestOrToday_Gery_Saluut = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_6": { ConYestOrToday_Nabati_Hansel = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_7": { ConYestOrToday_Nissin_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_8": { ConYestOrToday_Richoco = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_9": { ConYestOrToday_Richoco_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_10": { ConYestOrToday_Roma_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_11": { ConYestOrToday_Superstar = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_12": { ConYestOrToday_Tango_Chocolate_Wafer = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_13": { ConYestOrToday_Nissin_wafer_keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_14": { ConYestOrToday_Oops_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_15": { ConYestOrToday_Richeese_Nabati_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_16": { ConYestOrToday_Richeese_Rolls = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_17": { ConYestOrToday_Tango_Long_Cheese = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_18": { ConYestOrToday_Zuperrr_Keju_Wafer_Keju = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA20": { WA20 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA21": { WA21 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA22": { WA22 = Convert.ToString(record.GetValue(variable)); break; }
                                case "W23": { WA23 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA24": { WA24 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA25": { WA25 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA26": { WA26 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA27": { WA27 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA28": { WA28 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA29": { WA29 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA30": { WA30 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA31": { WA31 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA32": { WA32 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA33": { WA33 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA34": { WA34 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA35": { WA35 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA36": { Ad_visibility = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA37": { WA37 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA40": { WA40 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA41": { WA41 = Convert.ToString(record.GetValue(variable)); break; }
                                case "S13_1": { S13_1 = Convert.ToString(record.GetValue(variable)); break; }
                                case "S13_2": { S13_2 = Convert.ToString(record.GetValue(variable)); break; }
                                case "S13_3": { S13_3 = Convert.ToString(record.GetValue(variable)); break; }
                                case "S13_4": { S13_4 = Convert.ToString(record.GetValue(variable)); break; }
                                case "S13_5": { P1M_Chocolate = Convert.ToString(record.GetValue(variable)); break; }
                                case "S13_6": { S13_6 = Convert.ToString(record.GetValue(variable)); break; }
                                case "S13_7": { S13_7 = Convert.ToString(record.GetValue(variable)); break; }
                                case "S13_8": { S13_8 = Convert.ToString(record.GetValue(variable)); break; }
                                case "S14_1": { S14_1 = Convert.ToString(record.GetValue(variable)); break; }
                                case "S14_2": { S14_2 = Convert.ToString(record.GetValue(variable)); break; }
                                case "S14_3": { S14_3 = Convert.ToString(record.GetValue(variable)); break; }
                                case "S14_4": { S14_4 = Convert.ToString(record.GetValue(variable)); break; }
                                case "S14_5": { P1W_Chocolate = Convert.ToString(record.GetValue(variable)); break; }
                                case "S14_6": { S14_6 = Convert.ToString(record.GetValue(variable)); break; }
                                case "S14_7": { S14_7 = Convert.ToString(record.GetValue(variable)); break; }
                                case "S14_8": { S14_8 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA4": { WA4 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA5_13": { WA5_13 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA5_14": { WA5_14 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA5_15": { WA5_15 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA5_16": { WA5_16 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA5_17": { WA5_17 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA5_18": { WA5_18 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA1_Net2": { WA1_Net2 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA1_Net1": { WA1_Net1 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA1_Net3": { WA1_Net3 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA1_Net4": { WA1_Net4 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA1_Net5": { WA1_Net5 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_Net1": { WA2_Net1 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_Net2": { WA2_Net2 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_Net3": { WA2_Net3 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_Net4": { WA2_Net4 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_Net5": { WA2_Net5 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA7_Net1": { WA7_Net1 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA7_Net2": { WA7_Net2 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA7_Net3": { WA7_Net3 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA7_Net4": { WA7_Net4 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA7_Net5": { WA7_Net5 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_Net1": { WA11_Net1 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_Net2": { WA11_Net2 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_Net3": { WA11_Net3 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_Net4": { WA11_Net4 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_Net5": { WA11_Net5 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA16_Net1": { WA16_Net1 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA16_Net2": { WA16_Net2 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA16_Net3": { WA16_Net3 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA16_Net4": { WA16_Net4 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA16_Net5": { WA16_Net5 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA3_Net1": { WA3_Net1 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA3_Net2": { WA3_Net2 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA3_Net3": { WA3_Net3 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA3_Net4": { WA3_Net4 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA3_Net5": { WA3_Net5 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_Net1": { WA13_Net1 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_Net2": { WA13_Net2 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_Net3": { WA13_Net3 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_Net4": { WA13_Net4 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_Net5": { WA13_Net5 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_Net1": { WA12_Net1 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_Net2": { WA12_Net2 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_Net3": { WA12_Net3 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_Net4": { WA12_Net4 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_Net5": { WA12_Net5 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_Net1": { WA14_Net1 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_Net2": { WA14_Net2 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_Net3": { WA14_Net3 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_Net4": { WA14_Net4 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_Net5": { WA14_Net5 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_Net1": { WA15_Net1 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_Net2": { WA15_Net2 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_Net3": { WA15_Net3 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_Net4": { WA15_Net4 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_Net5": { WA15_Net5 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WAAP43_1": { WAAP43_1 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WAAP43_2": { WAAP43_2 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WAAP43_3": { WAAP43_3 = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_19": { BrSpont_Richoco_Nabati_White = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA2_20": { BrSpont_Richoco_Pink_Lava = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_19": { AdSpont_Richoco_Nabati_White = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA11_20": { AdSpont_Richoco_Pink_Lava = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_19": { ConL1M_Richoco_Nabati_White = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA13_20": { ConL1M_Richoco_Pink_Lava = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_19": { ConL3M_Richoco_Nabati_White = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA12_20": { ConL3M_Richoco_Pink_Lava = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_19": { ConL1W_Richoco_Nabati_White = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA14_20": { ConL1W_Richoco_Pink_Lava = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_19": { ConYestOrToday_Richoco_Nabati_White = Convert.ToString(record.GetValue(variable)); break; }
                                case "WA15_20": { ConYestOrToday_Richoco_Pink_Lava = Convert.ToString(record.GetValue(variable)); break; }
                                }

                            }
                        }
                    }

                    if (userID != null && Weight != 0 && AgeGroup.Equals("2") || AgeGroup.Equals("3"))
                    {
                        iobj.insert_Dashboard_values(userID, SurveyID, AttendedOn, Weight, country, Location, Gender, MaritalStatus, Occupation, Education, AgeGroup, SES, WA9, BrTom, BrSpont_Astor, BrSpont_Fullo, BrSpont_Gery_Chocolatos, BrSpont_Gery_Chocolatos_Dark, BrSpont_Gery_Saluut, BrSpont_Nabati_Hansel, BrSpont_Nissin_Wafer, BrSpont_Richoco, BrSpont_Richoco_Rolls, BrSpont_Roma_Wafer, BrSpont_Superstar, BrSpont_Tango_Chocolate_Wafer, BrSpont_Nissin_wafer_keju, BrSpont_Oops_Wafer_Keju, BrSpont_Richeese_Nabati_Keju, BrSpont_Richeese_Rolls, BrSpont_Tango_Long_Cheese, BrSpont_Zuperrr_Keju_Wafer_Keju, AdTom, AdSpont_Astor, AdSpont_Fullo, AdSpont_Gery_Chocolatos, AdSpont_Gery_Chocolatos_Dark, AdSpont_Gery_Saluut, AdSpont_Nabati_Hansel, AdSpont_Nissin_Wafer, AdSpont_Richoco, AdSpont_Richoco_Rolls, AdSpont_Roma_Wafer, AdSpont_Superstar, AdSpont_Tango_Chocolate_Wafer, AdSpont_Nissin_wafer_keju, AdSpont_Oops_Wafer_Keju, AdSpont_Richeese_Nabati_Keju, AdSpont_Richeese_Rolls, AdSpont_Tango_Long_Cheese, AdSpont_Zuperrr_Keju_Wafer_Keju, Bumo, Favourite_Brand, BUMO_Cheese_wafer, Favourite_Cheese_wafer, ConL1M_Astor, ConL1M_Fullo, ConL1M_Gery_Chocolatos, ConL1M_Gery_Chocolatos_Dark, ConL1M_Gery_Saluut, ConL1M_Nabati_Hansel, ConL1M_Nissin_Wafer, ConL1M_Richoco, ConL1M_Richoco_Rolls, ConL1M_Roma_Wafer, ConL1M_Superstar, ConL1M_Tango_Chocolate_Wafer, ConL1M_Nissin_wafer_keju, ConL1M_Oops_Wafer_Keju, ConL1M_Richeese_Nabati_Keju, ConL1M_Richeese_Rolls, ConL1M_Tango_Long_Cheese, ConL1M_Zuperrr_Keju_Wafer_Keju, ConL3M_Astor, ConL3M_Fullo, ConL3M_Gery_Chocolatos, ConL3M_Gery_Chocolatos_Dark, ConL3M_Gery_Saluut, ConL3M_Nabati_Hansel, ConL3M_Nissin_Wafer, ConL3M_Richoco, ConL3M_Richoco_Rolls, ConL3M_Roma_Wafer, ConL3M_Superstar, ConL3M_Tango_Chocolate_Wafer, ConL3M_Nissin_wafer_keju, ConL3M_Oops_Wafer_Keju, ConL3M_Richeese_Nabati_Keju, ConL3M_Richeese_Rolls, ConL3M_Tango_Long_Cheese, ConL3M_Zuperrr_Keju_Wafer_Keju, ConL1W_Astor, ConL1W_Fullo, ConL1W_Gery_Chocolatos, ConL1W_Gery_Chocolatos_Dark, ConL1W_Gery_Saluut, ConL1W_Nabati_Hansel, ConL1W_Nissin_Wafer, ConL1W_Richoco, ConL1W_Richoco_Rolls, ConL1W_Roma_Wafer, ConL1W_Superstar, ConL1W_Tango_Chocolate_Wafer, ConL1W_Nissin_wafer_keju, ConL1W_Oops_Wafer_Keju, ConL1W_Richeese_Nabati_Keju, ConL1W_Richeese_Rolls, ConL1W_Tango_Long_Cheese, ConL1W_Zuperrr_Keju_Wafer_Keju, ConYestOrToday_Astor, ConYestOrToday_Fullo, ConYestOrToday_Gery_Chocolatos, ConYestOrToday_Gery_Chocolatos_Dark, ConYestOrToday_Gery_Saluut, ConYestOrToday_Nabati_Hansel, ConYestOrToday_Nissin_Wafer, ConYestOrToday_Richoco, ConYestOrToday_Richoco_Rolls, ConYestOrToday_Roma_Wafer, ConYestOrToday_Superstar, ConYestOrToday_Tango_Chocolate_Wafer, ConYestOrToday_Nissin_wafer_keju, ConYestOrToday_Oops_Wafer_Keju, ConYestOrToday_Richeese_Nabati_Keju, ConYestOrToday_Richeese_Rolls, ConYestOrToday_Tango_Long_Cheese, ConYestOrToday_Zuperrr_Keju_Wafer_Keju, WA20, WA21, WA22, WA23, WA24, WA25, WA26, WA27, WA28, WA29, WA30, WA31, WA32, WA33, WA34, WA35, Ad_visibility, WA37, WA40, WA41, S13_1, S13_2, S13_3, S13_4, P1M_Chocolate, S13_6, S13_7, S13_8, S14_1, S14_2, S14_3, S14_4, P1W_Chocolate, S14_6, S14_7, S14_8, WA4, WA5_13, WA5_14, WA5_15, WA5_16, WA5_17, WA5_18, WA1_Net1, WA1_Net2, WA1_Net3, WA1_Net4, WA1_Net5, WA2_Net1, WA2_Net2, WA2_Net3, WA2_Net4, WA2_Net5, WA7_Net1, WA7_Net2, WA7_Net3, WA7_Net4, WA7_Net5, WA11_Net1, WA11_Net2, WA11_Net3, WA11_Net4, WA11_Net5, WA16_Net1, WA16_Net2, WA16_Net3, WA16_Net4, WA16_Net5, WA3_Net1, WA3_Net2, WA3_Net3, WA3_Net4, WA3_Net5, WA13_Net1, WA13_Net2, WA13_Net3, WA13_Net4, WA13_Net5, WA12_Net1, WA12_Net2, WA12_Net3, WA12_Net4, WA12_Net5, WA14_Net1, WA14_Net2, WA14_Net3, WA14_Net4, WA14_Net5, WA15_Net1, WA15_Net2, WA15_Net3, WA15_Net4, WA15_Net5, WAAP43_1, WAAP43_2, WAAP43_3, BrSpont_Richoco_Nabati_White, BrSpont_Richoco_Pink_Lava, AdSpont_Richoco_Nabati_White, AdSpont_Richoco_Pink_Lava, ConL1M_Richoco_Nabati_White, ConL1M_Richoco_Pink_Lava, ConL3M_Richoco_Nabati_White, ConL3M_Richoco_Pink_Lava, ConL1W_Richoco_Nabati_White, ConL1W_Richoco_Pink_Lava, ConYestOrToday_Richoco_Nabati_White, ConYestOrToday_Richoco_Pink_Lava);
                    }
                }
            }
        }
        private static string find_UserId(int SurveyID, string SurveyPeriod, string u_id)
        {
            string sum = "";
            string[] date = SurveyPeriod.Split('-');
            foreach (string d in date)
            {
                sum = sum + d;

            }
            return u_id + SurveyID + sum;
        }
        }
    }

