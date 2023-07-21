using DevExpress.XtraEditors;
using System.Windows.Forms;
using System;
using System.Threading.Tasks;
using CashBackApi.ControlPanel.Services;
using CashBackApi.Shared.ViewModels;
using CashBackApi.ControlPanel.Utils;

namespace CashBackApi.ControlPanel
{
    public sealed partial class FrmLogin : XtraForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async Task Authorize()
        {
            var client = new UserPanelService();

            var res = await client.AuthenticateAsync(new viAuthenticateModel { Login = edLogin.Text, Password = edPassword.Text }, null);
            
            if (res is null)
            {
                MessageBox.Show("Заполните поля");
                return;
            }

            if (res.AnswerId == 0)
            {
                Vars.UserId = res.Data.Id;
                Vars.Token = res.Data.Token;
                Vars.RoleId = res.Data.TypeId;

                DialogResult = DialogResult.OK;
                return;
            }
            else
                MessageBox.Show(res.AnswerMessage);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await Authorize();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
                Authorize().GetAwaiter();
            else if (keyData == Keys.Escape)
                Close();

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public static DialogResult Execute()
        {
            FrmLogin frm = new FrmLogin();
            frm.edLogin.Focus();
            DialogResult res = frm.ShowDialog();
            frm.Dispose();

            return res;
        }

    }
}