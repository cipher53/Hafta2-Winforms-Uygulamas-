using FormsUI.Workspaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsUI.Examples.Workspace
{
    // FrmMain sınıfı Form sınıfından türetiliyor.
    public partial class FrmMain : Form
    {
        // TextEditorWorkspace türünden bir örnek (instance) oluşturuluyor ve readonly olarak işaretleniyor.
        private readonly TextEditorWorkspace workspace = new TextEditorWorkspace();

        public FrmMain()
        {
            // FrmMain sınıfının kurucu metodu.
            InitializeComponent();

             // TextEditorWorkspace sınıfının olaylarına abone olunuyor.
            workspace.WorkspaceCreated += Workspace_WorkspaceCreated;
            workspace.WorkspaceOpened += Workspace_WorkspaceOpened;
            workspace.WorkspaceChanged += Workspace_WorkspaceChanged;
            workspace.WorkspaceSaved += Workspace_WorkspaceSaved;
            workspace.WorkspaceClosed += Workspace_WorkspaceClosed;
            // workspace nesnesinin Close() metodu çağrılarak bir dosya kapatılıyor.
            workspace.Close();
        }

            // Yeni işlem metodu.
        private void Action_New(object sender, EventArgs e)
        {
            // Uzun sürecek bir işlem için LengthyOperation kullanarak işlem yapılıyor.
            using (new LengthyOperation(this))
            {
                workspace.New();
            }
        }
            // Aç işlem metodu.
        private void Action_Open(object sender, EventArgs e)
        {
            // Uzun sürecek bir işlem için LengthyOperation kullanarak işlem yapılıyor.
            using (new LengthyOperation(this))
            {
                workspace.Open();
            }
        }

            // Kaydet işlem metodu.
        private void Action_Save(object sender, EventArgs e)
        {
            // Uzun sürecek bir işlem için LengthyOperation kullanarak işlem yapılıyor.
            using (new LengthyOperation(this))
            {
                workspace.Save();
            }
        }

            // Farklı kaydet işlem metodu.
        private void Action_SaveAs(object sender, EventArgs e)
        {
            // Uzun sürecek bir işlem için LengthyOperation kullanarak işlem yapılıyor.
            using (new LengthyOperation(this))
            {
                workspace.Save(true);
            }
        }
            // Kapat işlem metodu.
        private void Action_Close(object sender, EventArgs e)
        {
            // Uzun sürecek bir işlem için LengthyOperation kullanarak işlem yapılıyor.
            using (new LengthyOperation(this))
            {
                workspace.Close();
            }
        }

            // Workspace kapatıldığında gerçekleşecek olay.
        private void Workspace_WorkspaceClosed(object sender, EventArgs e)
        {
            // Metin kutusu devre dışı bırakılıyor ve içeriği temizleniyor.
            txtMain.Enabled = false;
            txtMain.Text = string.Empty;

             // Menü ögeleri devre dışı bırakılıyor.
            mnuClose.Enabled = false;
            mnuSave.Enabled = false;
            mnuSaveAs.Enabled = false;
            tbtnSave.Enabled = false;
            statusLabel.Text = string.Empty;
        }

        private void Workspace_WorkspaceSaved(object sender, WorkspaceSavedEventArgs e)
        {
            mnuSave.Enabled = false;
            tbtnSave.Enabled = false;
            statusLabel.Text = e.FileName;
        }

        private void Workspace_WorkspaceChanged(object sender, EventArgs e)
        {
            mnuSave.Enabled = true;
            tbtnSave.Enabled = true;
        }

        private void Workspace_WorkspaceOpened(object sender, WorkspaceOpenedEventArgs e)
        {
            txtMain.Enabled = true;
            txtMain.Text = (e.Model as TextEditorModel).Text;

            mnuSaveAs.Enabled = true;
            mnuClose.Enabled = true;
            statusLabel.Text = e.FileName;
        }

        private void Workspace_WorkspaceCreated(object sender, WorkspaceCreatedEventArgs e)
        {
            txtMain.Enabled = true;
            txtMain.Text = string.Empty;
            txtMain.Focus();

            mnuClose.Enabled = true;
            mnuSave.Enabled = true;
            tbtnSave.Enabled = true;
            mnuSaveAs.Enabled = true;
            statusLabel.Text = string.Empty;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = !this.workspace.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Unsubscribe the workspace events.
            workspace.WorkspaceCreated -= Workspace_WorkspaceCreated;
            workspace.WorkspaceOpened -= Workspace_WorkspaceOpened;
            workspace.WorkspaceChanged -= Workspace_WorkspaceChanged;
            workspace.WorkspaceSaved -= Workspace_WorkspaceSaved;
            workspace.WorkspaceClosed -= Workspace_WorkspaceClosed;
            base.OnClosed(e);
        }

        private void txtMain_TextChanged(object sender, EventArgs e)
        {
            (workspace.Model as TextEditorModel).Text = txtMain.Text;
        }
    }
}
