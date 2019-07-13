

namespace Repository
{
    using DTO;
    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class to access Client information for bussiness
    /// </summary>
    public class ClientRepository : IClientRepository
    {
        public ClientDTO dto { get; set; }

        public ClientRepository()
        {
            this.dto = new ClientDTO();
            InstalledsPrograms();
            MachineName();
            TimerInformations();

        }


        /// <summary>
        /// Get list of installed programs in machine
        /// Method for you running in windows Service
        /// </summary>
        public void InstalledsPrograms()
        {
            List<string> list = new List<string>();
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
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

                this.dto.ProgramsList = list;
            }
        }


        /// <summary>
        /// Get machine Name 
        /// Method for you running in windows service
        /// </summary>
        public void MachineName()
        {
            this.dto.MachineName = Environment.MachineName;
        }

        /// <summary>
        /// Get Date Time Currently
        /// Method for you running in windows Service
        /// </summary>
        public void TimerInformations()
        {
            this.dto.DateHours = DateTime.UtcNow;
        }

    }
}
