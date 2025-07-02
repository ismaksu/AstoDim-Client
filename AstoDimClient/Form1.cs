using AstoDimClient.ApiLibrary;
using AstoDimClient.Properties;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace AstoDimClient
{
    public partial class frmClientMain : Form
    {
        public frmClientMain()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }
        string licenseKey;
        string HWID;

        static string GetMotherboardID()
        {
            string cpuId = GetWmiValue("Win32_Processor", "ProcessorId");
            string boardId = GetWmiValue("Win32_BaseBoard", "SerialNumber");
            string biosId = GetWmiValue("Win32_BIOS", "SerialNumber");

            string combined = cpuId + boardId + biosId;

            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(combined);
                byte[] hash = sha.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }

        private static string GetWmiValue(string className, string property)
        {
            try
            {
                var searcher = new ManagementObjectSearcher($"SELECT {property} FROM {className}");
                foreach (var obj in searcher.Get())
                {
                    return obj[property]?.ToString()?.Trim();
                }
            }
            catch { }
            return "null";
        }

        private async void btnActivateLicense_Click_1(object sender, EventArgs e)
        {
            if (mskLicenseKey.MaskFull)
            {
                DialogResult dialog = MessageBox.Show("Lisansý aktifleþtirmek istediðinize emin misiniz?\nLisansý aktifleþtirmek abonelik süresini baþlatacaktýr.", "Uyarý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    licenseKey = mskLicenseKey.Text;
                    HWID = GetMotherboardID();

                    //TODO: API Request
                    (bool status, string message) result = await ApiProcessor.ActivateLicense(licenseKey, HWID);

                    if (result.status)
                    {
                        MessageBox.Show(result.message, "Aktifleþtirme Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnHideKey.Visible = true;

                        lblLicenseKey.Text = licenseKey;
                        label1.Visible = false;
                        mskLicenseKey.Visible = false;
                        btnActivateLicense.Visible = false;
                        btnInjectBot.Visible = true;
                        lblRemaining.Visible = true;
                    }
                    else
                    {
                        mskLicenseKey.Clear();
                        MessageBox.Show(result.message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        private void frmClientMain_Load(object sender, EventArgs e)
        {

        }
    }
}
