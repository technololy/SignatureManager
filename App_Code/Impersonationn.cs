using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Web;
using System.DirectoryServices;

/// <summary>
/// Summary description for Impersonationn
/// </summary>
public class Impersonationn
{
    public Impersonationn()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    [DllImport("advapi32.DLL", SetLastError = true)]
    public static extern int LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);



















    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
        IntPtr admin_token = default(IntPtr);
        WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
        WindowsIdentity wid_admin = null;
        WindowsImpersonationContext wic = null;
        try
        {
            //MessageBox.Show("Copying file...");
            if (LogonUser("Local Admin name", "Local computer name", "pwd", 9, 0, ref admin_token) != 0)
            {
                wid_admin = new WindowsIdentity(admin_token);
                wic = wid_admin.Impersonate();
                System.IO.File.Copy("C:\\right.bmp", "\\\\157.60.113.28\\testnew\\right.bmp", true);
                //MessageBox.Show("Copy succeeded");
            }
            else
            {
                //MessageBox.Show("Copy Failed");
            }
        }
        catch (System.Exception se)
        {
            int ret = Marshal.GetLastWin32Error();
            // MessageBox.Show(ret.ToString(), "Error code: " + ret.ToString());
            //MessageBox.Show(se.Message);
        }
        finally
        {
            if (wic != null)
            {
                wic.Undo();
            }
        }
    }


    











}