
namespace Client
{
    using DAL;
    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
              
                List<string> list = new ClientDAL().InstalledsPrograms();
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
               
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
