using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;
using System.Collections;
using System.Configuration;
using System.DirectoryServices.AccountManagement;

namespace CofcoInd.Areas.BackOffice.Extensions
{
    public class ActiveDirectoryHelper
    {
        private string ldap = "";
    # region private constants
        
        private const string Cn = "cn";
        private const string Sn = "sn";
        private const string PhysicalDeliveryOfficeName = "physicalDeliveryOfficeName";
        private const string GivenName = "givenName";
        private const string DisplayName = "displayName";
        private const string Co = "co";
        private const string Department = "department";
        private const string Company = "company";
        private const string Name = "name";
        private const string SAMAccountName = "sAMAccountName";
        private const string UserPrincipalName = "userPrincipalName";
        private const string Mail = "mail";
        
     #endregion


     #region --- Constructors ---

       

        /// <summary>
        ///    ActiveDirectoryHelper Constructor
        /// </summary>
        /// <param name="_ldap">LDAP parameter.
        ///    Example:  LDAP://CNV.com.ar
        /// </param>
        public ActiveDirectoryHelper() {

            if (IsEmpty(ConfigurationManager.AppSettings["ActiveDirectory"]))
                throw new Exception("LDAP no puede ser null");

            if (ConfigurationManager.AppSettings["ActiveDirectory"].ToLower().IndexOf("ldap://") == -1)
                throw new Exception("La dirección LPDA debe comenzar con \"ldap://\" ");

           // ldap = _ldap;
        }

     #endregion --- Constructors ---


     #region --- Public Methods ---

        public IList SearchADString(string search)
        {
            ArrayList activeDirectorylist = new ArrayList();
            if (search == null)
            {
                activeDirectorylist.Add(null);
                return activeDirectorylist;
            }
            foreach (SearchResult result in SearchADGeneral(search))
            {
                DirectoryEntry dirEntry = result.GetDirectoryEntry();

                Ilist adDTO = ToUserAD(dirEntry);
                activeDirectorylist.Add(adDTO);
            }
            return activeDirectorylist;
        }


        public Ilist SearchADUser(string userName)
        {
            ArrayList activeDirectorylist = new ArrayList();
            if (IsEmpty(userName))
                return null;
            foreach (SearchResult result in SearchUser(userName))
            {
                DirectoryEntry dirEntry = result.GetDirectoryEntry();

                Ilist adDTO = ToUserAD(dirEntry);
                activeDirectorylist.Add(adDTO);

            }
            return (activeDirectorylist.Count == 0) ? null : (Ilist)activeDirectorylist[0];
        }

        public bool SearchADGroupUser(string GroupName, string userName)
        {
            

            DirectoryEntry de = GetDirectoryEntry();
            DirectorySearcher deSearch = new DirectorySearcher(de);


            var princContext = new PrincipalContext(ContextType.Domain);

            // Get User
            UserPrincipal user = UserPrincipal.FindByIdentity(princContext, IdentityType.SamAccountName, userName);

            // Browse user's groups
            foreach (GroupPrincipal group in user.GetGroups())
            {
                if (group.Name == GroupName)
                    return true;
           
            }
            return false;
        }

        public bool AuthenticateAD(string username, string password)
        {
            using (var context = new PrincipalContext(ContextType.Domain,
            ConfigurationManager.AppSettings["ActiveDirectory"]))
            {
                return context.ValidateCredentials(username, password);
            }
        }


        #endregion --- Public Methods ---


        #region --- Private Methods ---

        private SearchResultCollection SearchUser(string userName)
        {
            DirectoryEntry de = GetDirectoryEntry();
            DirectorySearcher deSearch = new DirectorySearcher(de);
            if (userName == null)
                return null;
            //deSearch.Filter = "(&(objectCategory=user)(SAMAccountName=" + userName.Trim() + "))";
            deSearch.Filter = "(&(objectCategory=user)(samaccountname=" + userName.Trim() + "))";
            SearchResultCollection sr = deSearch.FindAll();

            deSearch.Dispose();
            de.Dispose();

            return sr;
        }

    

        private SearchResultCollection SearchString(string search)
        {
            DirectoryEntry de = GetDirectoryEntry();
            DirectorySearcher deSearch = new DirectorySearcher(de);
            deSearch.Filter = "(&(objectCategory=user)(sn=*" + search.Trim() + "*))";
            SearchResultCollection sr = deSearch.FindAll();

            deSearch.Dispose();
            de.Dispose();

            return sr;
        }


        private SearchResultCollection SearchADGeneral(string search)
        {
            DirectoryEntry de = GetDirectoryEntry();
            DirectorySearcher deSearch = new DirectorySearcher(de);
            deSearch.Filter = "(&(objectCategory=user)( |(|(sn=*" + search.Trim() + "*)(SAMAccountName=*" + search.Trim() + "*))(givenName=*" + search.Trim() + "*) ))";
            SearchResultCollection sr = deSearch.FindAll();

            deSearch.Dispose();
            de.Dispose();

            return sr;
        }

        private DirectoryEntry GetDirectoryEntry()
        {
            DirectoryEntry de = new DirectoryEntry(ldap);
            de.AuthenticationType = AuthenticationTypes.Secure;
            return de;
        }

        private static bool IsEmpty(string s)
        {
            return (s == null) ? true : (s.Trim() == "");
        }

        private Ilist ToUserAD(DirectoryEntry dirEntry)
        {
            Ilist userAD = new Ilist();

            #region Active Directory properties

            userAD.Cn = (dirEntry.Properties[Cn].Value != null) ? dirEntry.Properties[Cn].Value.ToString() : "";
            userAD.Sn = (dirEntry.Properties[Sn].Value != null) ? dirEntry.Properties[Sn].Value.ToString() : "";
            userAD.PhysicalDeliveryOfficeName = (dirEntry.Properties[PhysicalDeliveryOfficeName].Value != null) ? dirEntry.Properties[PhysicalDeliveryOfficeName].Value.ToString() : "";
            userAD.GivenName = (dirEntry.Properties[GivenName].Value != null) ? dirEntry.Properties[GivenName].Value.ToString() : "";
            userAD.DisplayName = (dirEntry.Properties[DisplayName].Value != null) ? dirEntry.Properties[DisplayName].Value.ToString() : "";
            userAD.Co = (dirEntry.Properties[Co].Value != null) ? dirEntry.Properties[Co].Value.ToString() : "";
            userAD.Department = (dirEntry.Properties[Department].Value != null) ? dirEntry.Properties[Department].Value.ToString() : "";
            userAD.Company = (dirEntry.Properties[Company].Value != null) ? dirEntry.Properties[Company].Value.ToString() : "";
            userAD.Name = (dirEntry.Properties[Name].Value != null) ? dirEntry.Properties[Name].Value.ToString() : "";
            userAD.SAMAccountName = (dirEntry.Properties[SAMAccountName].Value != null) ? dirEntry.Properties[SAMAccountName].Value.ToString() : "";
            userAD.UserPrincipalName = (dirEntry.Properties[UserPrincipalName].Value != null) ? dirEntry.Properties[UserPrincipalName].Value.ToString() : "";
            userAD.Mail = (dirEntry.Properties[Mail].Value != null) ? dirEntry.Properties[Mail].Value.ToString() : "";

            #endregion

            return userAD;
        }

    #endregion --- Private Methods ---

    }

    public class Ilist
    {
        #region Active Directory

        #region Member Variables

        private string _cn;
        private string _sn;
        private string _physicalDeliveryOfficeName;
        private string _givenName;
        private string _displayName;
        private string _co;
        private string _department;
        private string _company;
        private string _name;
        private string _sAMAccountName;
        private string _userPrincipalName;
        private string _mail;

        #endregion

        #region Public Properties

        public string Cn
        {
            get { return _cn; }
            set { _cn = value; }
        }

        public string Sn
        {
            get { return _sn; }
            set { _sn = value; }
        }

        public string PhysicalDeliveryOfficeName
        {
            get { return _physicalDeliveryOfficeName; }
            set { _physicalDeliveryOfficeName = value; }
        }

        public string GivenName
        {
            get { return _givenName; }
            set { _givenName = value; }
        }

        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        public string Co
        {
            get { return _co; }
            set { _co = value; }
        }

        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string SAMAccountName
        {
            get { return _sAMAccountName; }
            set { _sAMAccountName = value; }
        }
        public string UserPrincipalName
        {
            get { return _userPrincipalName; }
            set { _userPrincipalName = value; }
        }

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        #endregion

        #endregion
    }
}
