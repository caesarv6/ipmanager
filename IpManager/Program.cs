using System;
using System.Management;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IpManager
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*List<NetworkInterface> netList = NetworkManagement.GetAllNetworkInterfaces();
            foreach (NetworkInterface net in netList)
            {
                if (net.Index.Equals("2"))
                {
                    net.AddIPEntry(new IPEntry("192.168.5.120", "255.255.255.0"));
                    //net.EnableDHCP();
                }
                Console.WriteLine(net.ToString());
            }*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindowForm());
        }
    }

    class NetworkManagement
    {
        public static void PrintAllInterfaces()
        {
            ManagementClass netMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection netMOC = netMC.GetInstances();

            foreach(ManagementObject netMO in netMOC)
            {
                Console.WriteLine(netMO["Caption"]);
                string[] ipList = (string[]) netMO["IPAddress"];
                string[] netMaskList = (string[])netMO["IPSubnet"];

                if (ipList != null && ipList.Length > 0)
                {
                    for (int i=0; i<ipList.Length; i++)
                    {
                        Console.WriteLine("\t" + ipList[i] + " " + netMaskList[i]);
                    }
                }

                string[] gwList = (string[])netMO["DefaultIPGateway"];
                if (gwList != null)
                {
                    foreach (string gw in gwList)
                    {
                        Console.WriteLine("\tGateway : " + gw);
                    }
                }
            }
        }

        public static List<NetworkInterface> GetAllNetworkInterfaces()
        {
            List<NetworkInterface> netList = new List<NetworkInterface>();
            ManagementClass netMC = new ManagementClass("Win32_NetworkAdapter");
            ManagementObjectCollection netMOC = netMC.GetInstances();

            foreach (ManagementObject netMO in netMOC)
            {
                if (netMO["NetConnectionID"] != null && netMO["DeviceID"] != null)
                {
                    string netName = netMO["NetConnectionID"].ToString();
                    string netIndex = netMO["DeviceID"].ToString();
                    string netCaption = netMO["Caption"].ToString();
                    netList.Add(new NetworkInterface(netName, netIndex, netCaption, netMO));
                }
            }
            return netList;
        }
    }

    class NetworkInterface
    {
        private string mName;
        private string mIndex;
        private string mCaption;
        private ManagementObject mNetMO;

        public string Name { get => mName; }
        public string Index { get => mIndex; }
        public string Caption { get => mCaption; }

        public NetworkInterface(string aName, string aIndex, string aCaption, ManagementObject aNetMO)
        {
            mName = aName;
            mIndex = aIndex;
            mCaption = aCaption;
            mNetMO = aNetMO;
        }

        override
        public string ToString()
        {
            string desc = "Interface " + mName + " Index " + mIndex;
            if (DHCPEnabled())
            {
                desc += "\tDHCP Enabled";
            }
            foreach (IPEntry ip in GetIPEntries())
            {
                desc += "\n\t" + ip.ToString();
            }
            return desc;
        }

        public void Rename(string aName)
        {
            mNetMO["NetConnectionID"] = aName;
            mNetMO.Put();
            mName = aName;
        }

        public List<IPEntry> GetIPEntries()
        {
            List<IPEntry> ipEntryList = new List<IPEntry>();
            ManagementClass netMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection netMOC = netMC.GetInstances();

            foreach (ManagementObject netMO in netMOC)
            {
                if (netMO["Index"].ToString().Equals(mIndex))
                {
                    string[] ipList = (string[])netMO["IPAddress"];
                    string[] netMaskList = (string[])netMO["IPSubnet"];

                    if (ipList != null && ipList.Length > 0)
                    {
                        for (int i = 0; i < ipList.Length; i++)
                        {
                            if (!ipList[i].Contains(":"))
                            {
                                ipEntryList.Add(new IPEntry(ipList[i], netMaskList[i]));
                            }
                        }
                    }
                    break;
                }
            }

            return ipEntryList;
        }

        public void SetIPEntries(List<IPEntry> aIpEntries)
        {
            ManagementClass netMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection netMOC = netMC.GetInstances();

            foreach (ManagementObject netMO in netMOC)
            {
                if (netMO["Index"].ToString().Equals(mIndex) && (bool)netMO["IPEnabled"])
                {
                    List<string> ipList = new List<string>();
                    List<string> netMaskList = new List<string>();

                    foreach (IPEntry ipEntry in aIpEntries)
                    {
                        if (!ipEntry.IP.Contains(":"))
                        {
                            ipList.Add(ipEntry.IP);
                            netMaskList.Add(ipEntry.Mask);
                        }
                    }

                    ManagementBaseObject newIP = netMO.GetMethodParameters("EnableStatic");
                    newIP["IPAddress"] = ipList.ToArray();
                    newIP["SubnetMask"] = netMaskList.ToArray();
                    netMO.InvokeMethod("EnableStatic", newIP, null);
                    break;
                }
            }
        }

        public void AddIPEntry(IPEntry aIpEntry)
        {
            Console.WriteLine("AddIPEntry " + aIpEntry.ToString());
            List<IPEntry> ipList = GetIPEntries();
            ipList.Add(aIpEntry);
            SetIPEntries(ipList);
        }

        public bool DHCPEnabled()
        {
            bool bRes = false;
            ManagementClass netMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection netMOC = netMC.GetInstances();

            foreach (ManagementObject netMO in netMOC)
            {
                if (netMO["Index"].ToString().Equals(mIndex))
                {
                    bRes = (bool)netMO["DHCPEnabled"];
                    break;
                }
            }
            return bRes;
        }

        public void EnableDHCP()
        {
            Console.WriteLine("EnableDHCP");
            ManagementClass netMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection netMOC = netMC.GetInstances();

            foreach (ManagementObject netMO in netMOC)
            {
                if (netMO["Index"].ToString().Equals(mIndex))
                {
                    netMO.InvokeMethod("EnableDHCP", null);
                    break;
                }
            }
        }

        public string GetGateway()
        {
            string gateway = "";
            ManagementClass netMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection netMOC = netMC.GetInstances();

            foreach (ManagementObject netMO in netMOC)
            {
                if (netMO["Index"].ToString().Equals(mIndex))
                {
                    string[] gwList = (string[])netMO["DefaultIPGateway"];
                    if (gwList != null && gwList.Length > 0)
                    {
                        gateway = gwList[0];
                    }
                    break;
                }
            }
            return gateway;
        }

        public void SetGateway(string aGateway)
        {
            Console.WriteLine("SetGateway " + aGateway);
            ManagementClass netMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection netMOC = netMC.GetInstances();

            foreach (ManagementObject netMO in netMOC)
            {
                if (netMO["Index"].ToString().Equals(mIndex))
                {
                    ManagementBaseObject newGw = netMO.GetMethodParameters("SetGateways");
                    newGw["DefaultIPGateway"] = new string[] { aGateway };
                    newGw["GatewayCostMetric"] = new int[] { 1 };
                    netMO.InvokeMethod("SetGateways", newGw, null);
                    break;
                }
            }
        }
    }

    class IPEntry
    {
        private string mIP;
        private string mMask;

        public string IP { get => mIP; }
        public string Mask { get => mMask; }

        public IPEntry(string aIP, string aMask)
        {
            mIP = aIP;
            mMask = aMask;
        }

        override
        public string ToString()
        {
            return "IP " + mIP + " Mask " + mMask;
        }
    }
}
