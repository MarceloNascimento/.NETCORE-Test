

namespace DAL
{
    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// Class to access Me
    /// </summary>
    public class ClientDAL
    {


        public ClientDAL()
        {

        }

        public List<string> InstalledsPrograms()
        {


            List<string> list = new List<string>();
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        if (subkey.GetValue("DisplayName") != null)
                            list.Add(subkey.GetValue("DisplayName").ToString());
                        //Console.WriteLine();
                    }
                }

                return list;
            }
        }

    }
}
