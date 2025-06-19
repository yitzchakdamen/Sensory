using System;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

namespace Sensory
{
    class TokenSystem
    {
        Dal dal;
        public TokenSystem(Dal DbManagement)
        {
            dal = DbManagement;
        }


        public void InsertingTokenIntoDb(string userName)
        {
            Console.WriteLine("Generating token based on your hardware...");
            string Token = HardwareIdentifier.GetToken();
            User? user = dal.GetUserByUserToken(Token);
            if (user != null)
            {
                dal.DeletionToken(Token);
            }
            Console.WriteLine("Token generated: " + Token);

            dal.InsertToken(Token, userName);
            Console.WriteLine("Token saved successfully");
        }

        public void TokenMenu(UserSystem userSystem)
        {
            Console.WriteLine("Checking for existing token...");
            string Token = HardwareIdentifier.GetToken();
            User? user = dal.GetUserByUserToken(Token);

            if (user != null)
            {
                Console.WriteLine("Token found for user: " + user.UserName);
                Console.WriteLine("Do you want to log in as this user? (y/n)");
                string choice = Console.ReadLine()!;
                if (choice == "y")
                {
                    userSystem.user = user;
                    Console.WriteLine("User logged in successfully");
                }
                else
                {
                    Console.WriteLine("Login cancelled");
                }
            }
            else
            {
                Console.WriteLine("No user found for this token");
            }
        }

    }


    class HardwareIdentifier
    {
        public static string GetToken()
        {
            string cpuId = GetCpuId();
            string diskSerial = GetDiskSerial();
            string mac = GetMacAddress();

            return $"{cpuId}-{diskSerial}-{mac}";
        }

        private static string GetCpuId()
        {
            try
            {
                var mbs = new ManagementObjectSearcher("Select ProcessorId from Win32_Processor");
                foreach (ManagementObject mo in mbs.Get())
                {
                    return mo["ProcessorId"]?.ToString() ?? "UNKNOWN_CPU";
                }
            }
            catch { }
            return "UNKNOWN_CPU";
        }

        private static string GetDiskSerial()
        {
            try
            {
                var searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_PhysicalMedia");
                foreach (ManagementObject wmi_HD in searcher.Get())
                {
                    string serial = wmi_HD["SerialNumber"]?.ToString()?.Trim();
                    if (!string.IsNullOrEmpty(serial))
                        return serial;
                }
            }
            catch { }
            return "UNKNOWN_DISK";
        }

        private static string GetMacAddress()
        {
            try
            {
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (nic.OperationalStatus == OperationalStatus.Up &&
                        nic.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                        !nic.Description.ToLower().Contains("virtual") &&
                        !nic.Description.ToLower().Contains("pseudo"))
                    {
                        return nic.GetPhysicalAddress().ToString();
                    }
                }
            }
            catch { }
            return "UNKNOWN_MAC";
        }


    }



}

