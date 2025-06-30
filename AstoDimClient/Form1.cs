using AstoDimClient.Properties;

namespace AstoDimClient
{
    public partial class frmClientMain : Form
    {
        public frmClientMain()
        {
            InitializeComponent();
        }
        string licenseKey;
        private void btnActivateLicense_Click_1(object sender, EventArgs e)
        {
            if (mskLicenseKey.MaskFull)
            {
                DialogResult dialog = MessageBox.Show("Lisansý aktifleþtirmek istediðinize emin misiniz?\nLisansý aktifleþtirmek abonelik süresini baþlatacaktýr.", "Uyarý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    licenseKey = mskLicenseKey.Text;
                    lblLicenseKey.Text = licenseKey;
                    label1.Visible = false;
                    mskLicenseKey.Visible = false;
                    btnActivateLicense.Visible = false;
                    btnInjectBot.Visible = true;
                    lblRemaining.Visible = true;
                    //TODO: API Request
                    MessageBox.Show("Lisans baþarýyla aktifleþtirildi!!", "Aktifleþtirme Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnHideKey.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Lütfen doðru bir lisans anahtarý girdiðinizden emin olunuz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mskLicenseKey_Enter(object sender, EventArgs e)
        {
            mskLicenseKey.Select(0, 0);
        }

        bool isTextHidden;
        private void btnHideKey_Click(object sender, EventArgs e)
        {
            isTextHidden = !isTextHidden;
            if (isTextHidden)
            {
                lblLicenseKey.Text = "XXXXX-XXXXX-XXXXX-XXXXX-XXXXX";
                btnHideKey.BackgroundImage = Resources.see_eye_visible_icon_1878261;
            }
            else
            {
                lblLicenseKey.Text = licenseKey;
                btnHideKey.BackgroundImage = Resources.no_see_visible_hidde_icon_187886;
            }
        }
    }
}
