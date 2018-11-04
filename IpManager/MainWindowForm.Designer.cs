namespace IpManager
{
    partial class MainWindowForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.RefreshButton = new System.Windows.Forms.Button();
            this.InterfaceListView = new System.Windows.Forms.ListView();
            this.InterfaceLabel = new System.Windows.Forms.Label();
            this.InterfaceTextBox = new System.Windows.Forms.TextBox();
            this.InterfaceCaptionLabel = new System.Windows.Forms.Label();
            this.InterfaceCaptionTextBox = new System.Windows.Forms.TextBox();
            this.IPGridView = new System.Windows.Forms.DataGridView();
            this.DhcpCheckBox = new System.Windows.Forms.CheckBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.GatewayLabel = new System.Windows.Forms.Label();
            this.GatewayTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.IPGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(12, 12);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshButton.TabIndex = 0;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // InterfaceListView
            // 
            this.InterfaceListView.HideSelection = false;
            this.InterfaceListView.Location = new System.Drawing.Point(12, 41);
            this.InterfaceListView.MultiSelect = false;
            this.InterfaceListView.Name = "InterfaceListView";
            this.InterfaceListView.Size = new System.Drawing.Size(200, 377);
            this.InterfaceListView.TabIndex = 1;
            this.InterfaceListView.UseCompatibleStateImageBehavior = false;
            this.InterfaceListView.View = System.Windows.Forms.View.List;
            this.InterfaceListView.SelectedIndexChanged += new System.EventHandler(this.InterfaceListView_SelectedIndexChanged);
            // 
            // InterfaceLabel
            // 
            this.InterfaceLabel.AutoSize = true;
            this.InterfaceLabel.Location = new System.Drawing.Point(244, 41);
            this.InterfaceLabel.Name = "InterfaceLabel";
            this.InterfaceLabel.Size = new System.Drawing.Size(78, 13);
            this.InterfaceLabel.TabIndex = 2;
            this.InterfaceLabel.Text = "Interface name";
            // 
            // InterfaceTextBox
            // 
            this.InterfaceTextBox.Location = new System.Drawing.Point(369, 38);
            this.InterfaceTextBox.Name = "InterfaceTextBox";
            this.InterfaceTextBox.Size = new System.Drawing.Size(286, 20);
            this.InterfaceTextBox.TabIndex = 3;
            this.InterfaceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InterfaceTextBox_KeyPress);
            // 
            // InterfaceCaptionLabel
            // 
            this.InterfaceCaptionLabel.AutoSize = true;
            this.InterfaceCaptionLabel.Location = new System.Drawing.Point(244, 83);
            this.InterfaceCaptionLabel.Name = "InterfaceCaptionLabel";
            this.InterfaceCaptionLabel.Size = new System.Drawing.Size(85, 13);
            this.InterfaceCaptionLabel.TabIndex = 4;
            this.InterfaceCaptionLabel.Text = "InterfaceCaption";
            // 
            // InterfaceCaptionTextBox
            // 
            this.InterfaceCaptionTextBox.Enabled = false;
            this.InterfaceCaptionTextBox.Location = new System.Drawing.Point(369, 80);
            this.InterfaceCaptionTextBox.Name = "InterfaceCaptionTextBox";
            this.InterfaceCaptionTextBox.ReadOnly = true;
            this.InterfaceCaptionTextBox.Size = new System.Drawing.Size(286, 20);
            this.InterfaceCaptionTextBox.TabIndex = 5;
            // 
            // IPGridView
            // 
            this.IPGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IPGridView.Location = new System.Drawing.Point(247, 199);
            this.IPGridView.Name = "IPGridView";
            this.IPGridView.Size = new System.Drawing.Size(408, 219);
            this.IPGridView.TabIndex = 6;
            // 
            // DhcpCheckBox
            // 
            this.DhcpCheckBox.AutoSize = true;
            this.DhcpCheckBox.Location = new System.Drawing.Point(247, 124);
            this.DhcpCheckBox.Name = "DhcpCheckBox";
            this.DhcpCheckBox.Size = new System.Drawing.Size(56, 17);
            this.DhcpCheckBox.TabIndex = 7;
            this.DhcpCheckBox.Text = "DHCP";
            this.DhcpCheckBox.UseVisualStyleBackColor = true;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(580, 120);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 8;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // GatewayLabel
            // 
            this.GatewayLabel.AutoSize = true;
            this.GatewayLabel.Location = new System.Drawing.Point(244, 170);
            this.GatewayLabel.Name = "GatewayLabel";
            this.GatewayLabel.Size = new System.Drawing.Size(49, 13);
            this.GatewayLabel.TabIndex = 9;
            this.GatewayLabel.Text = "Gateway";
            // 
            // GatewayTextBox
            // 
            this.GatewayTextBox.Location = new System.Drawing.Point(370, 167);
            this.GatewayTextBox.Name = "GatewayTextBox";
            this.GatewayTextBox.Size = new System.Drawing.Size(285, 20);
            this.GatewayTextBox.TabIndex = 10;
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 436);
            this.Controls.Add(this.GatewayTextBox);
            this.Controls.Add(this.GatewayLabel);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.DhcpCheckBox);
            this.Controls.Add(this.IPGridView);
            this.Controls.Add(this.InterfaceCaptionTextBox);
            this.Controls.Add(this.InterfaceCaptionLabel);
            this.Controls.Add(this.InterfaceTextBox);
            this.Controls.Add(this.InterfaceLabel);
            this.Controls.Add(this.InterfaceListView);
            this.Controls.Add(this.RefreshButton);
            this.MaximumSize = new System.Drawing.Size(680, 475);
            this.MinimumSize = new System.Drawing.Size(680, 475);
            this.Name = "MainWindowForm";
            this.Text = "Ip Manager";
            ((System.ComponentModel.ISupportInitialize)(this.IPGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.ListView InterfaceListView;
        private System.Windows.Forms.Label InterfaceLabel;
        private System.Windows.Forms.TextBox InterfaceTextBox;
        private System.Windows.Forms.Label InterfaceCaptionLabel;
        private System.Windows.Forms.TextBox InterfaceCaptionTextBox;
        private System.Windows.Forms.DataGridView IPGridView;
        private System.Windows.Forms.CheckBox DhcpCheckBox;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label GatewayLabel;
        private System.Windows.Forms.TextBox GatewayTextBox;
    }
}

