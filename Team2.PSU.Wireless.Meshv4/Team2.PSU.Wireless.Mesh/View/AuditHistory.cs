using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Team2.PSU.Wireless.Mesh.Presenter;
using System.IO;
using Team2.PSU.Wireless.Mesh.Properties;
using Team2.PSU.Wireless.Mesh.Model;

namespace Team2.PSU.Wireless.Mesh.View
{
    public partial class AuditHistory : Form
    {
        TerminalPresenter terminalPresenter = new TerminalPresenter();
        TerminalModel terminalModel = new TerminalModel();
        public AuditHistory()
        {
            InitializeComponent();
            cmbComPort.Items.Clear();
            cmbComPort.Items.AddRange(terminalModel.OrderedPortNames());
            GetAuditHistory( true );
        }

        private void dgAuditHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == this.dgAuditHistory.Columns["DataDirectionImageColumn"].Index)
            {
                System.Globalization.CultureInfo resourceCulture = null;
                System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Team2.PSU.Wireless.Mesh.Properties.Resources", typeof(Resources).Assembly);
                object objInComming = temp.GetObject("ARRDOWNA", resourceCulture);
                object objOutComming = temp.GetObject("ARRUPA", resourceCulture);
                //System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                ///Stream myStreamUp = myAssembly.GetManifestResourceStream("Team2.PSU.Wireless.Mesh.Properties.Resources.ARRUPA.GIF");
                if (this.dgAuditHistory["DataDirection", e.RowIndex].Value.ToString() == "Incoming")
                {
                    e.Value = (System.Drawing.Bitmap)(objInComming);
                    this.dgAuditHistory["DataDirectionImageColumn", e.RowIndex].ToolTipText = "Incoming";
                }
                else
                {
                    {
                        e.Value = (System.Drawing.Bitmap)(objOutComming);
                        this.dgAuditHistory["DataDirectionImageColumn", e.RowIndex].ToolTipText = "Outgoing";
                    }
                }
            }            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetAuditHistory( false );
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbComPort.SelectedIndex = -1;
            cmbDataDirection.SelectedIndex = -1;
        }    
   
        private void GetAuditHistory( bool firstLoad ){
            AuditEntry auditEntry = new AuditEntry();
            auditEntry.ComPort = string.IsNullOrEmpty(Convert.ToString(cmbComPort.SelectedItem)) ? null : Convert.ToString(cmbComPort.SelectedItem);
            auditEntry.DataDirection = string.IsNullOrEmpty(Convert.ToString(cmbDataDirection.SelectedItem))? null :Convert.ToString(cmbDataDirection.SelectedItem);
            DataTable auditedItems = terminalPresenter.GetAuditRecords(auditEntry).Tables[0];
            if (auditedItems != null)
            {
                dgAuditHistory.DataSource = terminalPresenter.GetAuditRecords(auditEntry).Tables[0];
            }

            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "DataDirectionImageColumn";
            imageColumn.HeaderText = "Data Direction";
            dgAuditHistory.Columns.Add(imageColumn);
            dgAuditHistory.Columns["DataDirection"].Visible = false;
            dgAuditHistory.Columns["BaudRate"].Width = 75;
            dgAuditHistory.Columns["ComPort"].Width = 75;
            dgAuditHistory.Columns["DataBits"].Width = 75;
            dgAuditHistory.Columns["Parity"].Width = 75;
            dgAuditHistory.Columns["StopBits"].Width = 75;
            dgAuditHistory.Columns["TextMessage"].Width = 300;
            dgAuditHistory.Columns["TextMessage"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void AuditHistory_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
