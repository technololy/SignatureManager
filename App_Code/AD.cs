using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Reflection;
using CentralBilling;
using System.Collections;

/// <summary>
/// Summary description for AD
/// </summary>
public class AD
{
    public AD()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public class ADDetails
    {
        public string groupname;
        public string regionCity;
        public string state;
        public string fullname;
        public string mailadd;
        public string mobile;
        public string unit;
        public string streetaddress;
        public string branchnamereal;

        public string mail { get; set; }
        public string staffName { get; set; }
        public string branch_name { get; set; }
        public string role { get; set; }
        public string department { get; set; }
        public string grade { get; set; }
        public string region { get; set; }
        public string sex { get; set; }
        public string status { get; set; }
        public string division { get; set; }
        public string manager { get; set; }
        public string branch_code { get; set; }
        public string directreport { get; set; }
        public string logoncount { get; set; }
        public string accountexpires { get; set; }
        public string staffid { get; set; }
        public string group { get; set; }
        public string officeExtension { get; internal set; }
        public string officeLandLine { get; internal set; }
        public string title { get; internal set; }
    }
    public static ADDetails AuthenticateUser(string strDomain, string strLoginName, string strPassword)
    {
        ADDetails ad = new ADDetails();

        bool blnAuthenticated = false;
        try
        {
            //ADDetails ad = new ADDetails();
            DirectoryEntry dsDirectoryEntry = new DirectoryEntry("LDAP://" + strDomain, strLoginName, strPassword);
            DirectorySearcher dsSearch = new DirectorySearcher(dsDirectoryEntry);
            dsSearch.Filter = "(&(objectCategory=person)(sAMAccountName=" + strLoginName + "))";
            SearchResult dsResults = dsSearch.FindOne();


            #region use this To loop through active directory object
            //var enumm = dsResults.Properties.PropertyNames.GetEnumerator();
            //while (enumm.MoveNext())
            //{
            //    var asso = enumm.Current;
          
            //    string kvp = enumm.Current.ToString();
            //    string value = getProperty(dsResults, kvp);
            //    new ErrorLog("key|" + kvp + "|value|" + value);
        

        
            //} 
            #endregion
          


            ad.title = getProperty(dsResults, "title");
            ad.mail = getProperty(dsResults, "mail");
            ad.mailadd = getProperty(dsResults, "userprincipalname");
            ad.staffName = getProperty(dsResults, "name");
            ad.mobile = getProperty(dsResults, "mobile");
            ad.fullname = getProperty(dsResults, "cn");
            ad.branch_name = getProperty(dsResults, "physicalDeliveryOfficeName");
            ad.groupname = getProperty(dsResults, "physicalDeliveryOfficeName");
            ad.staffid = getProperty(dsResults, "employeeID");
            ad.role = getProperty(dsResults, "title");
            ad.department = getProperty(dsResults, "department");
            ad.grade = getProperty(dsResults, "extensionAttribute1");
            ad.region = getProperty(dsResults, "extensionAttribute2");
            ad.branchnamereal = getProperty(dsResults, "extensionAttribute2");
            ad.state = getProperty(dsResults, "st");
            ad.regionCity = getProperty(dsResults, "l");
            ad.streetaddress = getProperty(dsResults, "streetaddress");
            ad.sex = getProperty(dsResults, "extensionAttribute3");
            ad.status = getProperty(dsResults, "employeeType");
            ad.division = getProperty(dsResults, "division");
            ad.unit = getProperty(dsResults, "division");
            ad.manager = getProperty(dsResults, "manager");
            ad.branch_code = getProperty(dsResults, "extensionattribute7");
            ad.officeLandLine = getProperty(dsResults, "facsimiletelephonenumber");
            ad.officeExtension  = getProperty(dsResults, "otherpager");
            //_mail = "ololade.oyebanji@sterlingbankng.com"


            blnAuthenticated = true;
        }
        catch (Exception ex)
        {
            blnAuthenticated = false;
        }

        return ad;
    }


    public static string FindKey(string Value, Hashtable HT)
    {
        string Key = "";
        IDictionaryEnumerator e = HT.GetEnumerator();
        while (e.MoveNext())
        {
            if (e.Value.ToString().Equals(Value))
            {
                Key = e.Key.ToString();
            }
        }
        return Key;
    }
    public static string getProperty(SearchResult search, string propertyName)
    {
        string result = "";
        try
        {
            if (search.Properties.Contains(propertyName))
            {
                result = search.Properties[propertyName][0].ToString();
            }
        }
        catch (Exception ex)
        {
            result = "";
            //Throw New Exception("Error: No result was return for the staff ID.")
        }
        return result;
    }

    public static Dictionary<string, string> GetPropertyV2<T>(T objectClass)
    {
        Dictionary<string, string> propertyDictionary = new Dictionary<string, string>();

        var classType = typeof(T);
        PropertyInfo[] propertyinfo = classType.GetProperties();
        foreach (PropertyInfo prop in propertyinfo)
        {
            var propertyname = prop.Name;
            var propertyvalue = prop.GetValue(classType);
            propertyDictionary.Add(propertyname, propertyvalue.ToString());
        }
        return propertyDictionary;
    }
}