namespace ProjectManagement.Domain.Common;

public class EnumConstants
{
    public static Country Countries { get; set; } = new();
    public sealed class Country
    {
        public string US => "US";
        public string IN => "India";
    }

    public static INStates INState { get; set; } = new();
    public sealed class INStates
    {
        public string AndamanAndNicobarIsland => "Andaman And Nicobar Island";
        public string AndhraPradesh => "Andhra Pradesh";
        public string ArunachalPradesh => "Arunachal Pradesh";
        public string Assam => "Assam";
        public string Bihar => "Bihar";
        public string Chandigarh => "Chandigarh";
        public string Chhattisgarh => "Chhattisgarh";
        public string DadraAndNagarHaveli => "Dadra and Nagar Haveli";
        public string DamanAndDiu => "Daman and Diu";
        public string Delhi => "Delhi";
        public string Goa => "Goa";
        public string Gujarat => "Gujarat";
        public string Haryana => "Haryana";
        public string HimachalPradesh => "Himachal Pradesh";
        public string JammuAndKashmir => "Jammu and Kashmir";
        public string Jharkhand => "Jharkhand";
        public string Karnataka => "Karnataka";
        public string Kerala => "Kerala";
        public string Lakshadweep => "Lakshadweep";
        public string MadhyaPradesh => "Madhya Pradesh";
        public string Maharashtra => "Maharashtra";
        public string Manipur => "Manipur";
        public string Meghalaya => "Meghalaya";
        public string Mizoram => "Mizoram";
        public string Nagaland => "Nagaland";
        public string Orissa => "Orissa";
        public string Puducherry => "Puducherry";
        public string Punjab => "Punjab";
        public string Rajasthan => "Rajasthan";
        public string Sikkim => "Sikkim";
        public string TamilNadu => "Tamil Nadu";
        public string Telangana => "Telangana";
        public string Tripura => "Tripura";
        public string Uttarakhand => "Uttarakhand";
        public string UttarPradesh => "Uttar Pradesh";
        public string WestBengal => "West Bengal";
    }

    public static USStates USState { get; set; } = new();
    public sealed class USStates
    {
        public string Alabama => "Alabama";
        public string Alaska => "Alaska";
        public string AmericanSamoa => "American Samoa";
        public string Arizona => "Arizona";
        public string Arkansas => "Arkansas";
        public string California => "California";
        public string Colorado => "Colorado";
        public string Connecticut => "Connecticut";
        public string Delaware => "Delaware";
        public string DistrictOfColumbia => "District of Columbia";
        public string Florida => "Florida";
        public string Georgia => "Georgia";
        public string Guam => "Guam";
        public string Hawaii => "Hawaii";
        public string Idaho => "Idaho";
        public string Illinois => "Illinois";
        public string Indiana => "Indiana";
        public string Iowa => "Iowa";
        public string Kansas => "Kansas";
        public string Kentucky => "Kentucky";
        public string Louisiana => "Louisiana";
        public string Maine => "Maine";
        public string Maryland => "Maryland";
        public string Massachusetts => "Massachusetts";
        public string Michigan => "Michigan";
        public string Minnesota => "Minnesota";
        public string Mississippi => "Mississippi";
        public string Missouri => "Missouri";
        public string Montana => "Montana";
        public string Nebraska => "Nebraska";
        public string Nevada => "Nevada";
        public string NewHampshire => "New Hampshire";
        public string NewJersey => "New Jersey";
        public string NewMexico => "New Mexico";
        public string NewYork => "New York";
        public string NewCarolina => "New Carolina";
        public string NorthDakota => "North Dakota";
        public string NorthernMarianaIS => "Northern Mariana IS";
        public string Ohio => "Ohio";
        public string Oklahoma => "Oklahoma";
        public string Oregon => "Oregon";
        public string Pennsylvania => "Pennsylvania";
        public string PuertoRico => "Puerto Rico";
        public string RhodeIsland => "Rhode Island";
        public string SouthCarolina => "South Carolina";
        public string SouthDakota => "South Dakota";
        public string Tennessee => "Tennessee";
        public string Texas => "Texas";
        public string Utah => "Utah";
        public string Vermont => "Vermont";
        public string Virginia => "Virginia";
        public string VirginIslands => "Virgin Islands";
        public string Washington => "Washington";
        public string WestVirginia => "West Virginia";
        public string Wisconsin => "Wisconsin";
        public string Wyoming => "Wyoming";
    }

    public static DateFormat DateFormats { get; set; } = new();
    public sealed class DateFormat
    {
        public string MM_dd_yyyy => "MM/dd/yyyy";
        public string dd_MM_yyyy => "dd/MM/yyyy";
        public string yyyy_MM_dd => "yyyy/MM/dd";
    }
}
