using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IpManager
{
    public partial class MainWindowForm : Form
    {
        private List<NetworkInterface> mIfList;
        private DataTable IPTable;

        public MainWindowForm()
        {
            InitializeComponent();
            InitIPDataGrid();
            RefreshInterfaces();
            ClearInterfaceDetails();
        }

        private void InitIPDataGrid()
        {
            IPTable = new DataTable("IPTable");
            DataColumn column;

            column = new DataColumn();
            column.ColumnName = "IP";
            IPTable.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "Mask";
            IPTable.Columns.Add(column);
            IPGridView.DataSource = IPTable;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshInterfaces();
            NetworkManagement.PrintAllInterfaces();
        }

        private void RefreshInterfaces()
        {
            mIfList = NetworkManagement.GetAllNetworkInterfaces();
            int selectedIdx = -1;
            if (InterfaceListView.SelectedIndices.Count == 1)
            {
                selectedIdx = InterfaceListView.SelectedIndices[0];
            }
            InterfaceListView.Clear();
            foreach (NetworkInterface netIf in mIfList)
            {
                ListViewItem ifItem = new ListViewItem(netIf.Name);
                InterfaceListView.Items.Add(ifItem);
            }
            if (selectedIdx != -1)
            {
                InterfaceListView.Items[selectedIdx].Selected = true;
                UpdateInterfaceDetails();
            }
        }

        private void InterfaceListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateInterfaceDetails();
        }

        private void ClearInterfaceDetails()
        {
            InterfaceTextBox.Text = "";
            InterfaceTextBox.Enabled = false;
            InterfaceCaptionTextBox.Text = "";
            IPGridView.Enabled = false;
            IPTable.Rows.Clear();
            DhcpCheckBox.Enabled = false;
            DhcpCheckBox.Checked = false;
            GatewayTextBox.Text = "";
            GatewayTextBox.Enabled = false;
        }

        private void UpdateInterfaceDetails()
        {
            if (InterfaceListView.SelectedIndices.Count == 1)
            {
                int selectedIdx = InterfaceListView.SelectedIndices[0];
                NetworkInterface netIf = mIfList[selectedIdx];
                InterfaceTextBox.Text = netIf.Name;
                InterfaceCaptionTextBox.Text = netIf.Caption;
                DataRow row;

                List<IPEntry> ipList = netIf.GetIPEntries();
                IPTable.Rows.Clear();
                foreach (IPEntry ipEntry in ipList)
                {
                    row = IPTable.NewRow();
                    row["IP"] = ipEntry.IP;
                    row["Mask"] = ipEntry.Mask;
                    IPTable.Rows.Add(row);
                }
                GatewayTextBox.Text = netIf.GetGateway();

                DhcpCheckBox.Enabled = true;
                if (netIf.DHCPEnabled())
                {
                    IPGridView.Enabled = false;
                    DhcpCheckBox.Checked = true;
                    GatewayTextBox.Enabled = false;
                }
                else
                {
                    IPGridView.Enabled = true;
                    DhcpCheckBox.Checked = false;
                    GatewayTextBox.Enabled = true;
                }
                InterfaceTextBox.Enabled = true;
            }
            else
            {
                ClearInterfaceDetails();
            }
        }

        private void InterfaceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' && InterfaceTextBox.Text.Length > 0)
            {
                if (InterfaceListView.SelectedIndices.Count == 1)
                {
                    int selectedIdx = InterfaceListView.SelectedIndices[0];
                    NetworkInterface netIf = mIfList[selectedIdx];
                    netIf.Rename(InterfaceTextBox.Text);
                    RefreshInterfaces();
                }
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (InterfaceListView.SelectedIndices.Count == 1)
            {
                int selectedIdx = InterfaceListView.SelectedIndices[0];
                NetworkInterface netIf = mIfList[selectedIdx];

                if (DhcpCheckBox.Checked)
                {
                    netIf.EnableDHCP();
                }
                else
                {
                    List<IPEntry> ipList = new List<IPEntry>();
                    foreach (DataRow row in IPTable.Rows)
                    {
                        IPEntry ip = new IPEntry(row["IP"].ToString(), row["Mask"].ToString());
                        ipList.Add(ip);
                        Console.WriteLine("IPList : " + ip.ToString());
                    }
                    string gateway = GatewayTextBox.Text;
                    netIf.SetIPEntries(ipList);
                    netIf.SetGateway(gateway);
                }
                RefreshInterfaces();
            }
        }
    }
}
