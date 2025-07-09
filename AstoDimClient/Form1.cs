using AstoDimClient.ApiLibrary;
using AstoDimClient.Properties;
using System.Management;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

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
        ApiKey? globalKey;

        static DateTime GetDateTime()
        {
            DateTime dateTimeNow = ApiProcessor.GetDateTime();
            if (dateTimeNow == DateTime.MinValue)
                MessageBox.Show("Sunuculara eriþilemedi. Lütfen internet baðlantýnýzý kontrol ediniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return dateTimeNow;
        }

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
            licenseKey = mskLicenseKey.Text;
            HWID = GetMotherboardID();


            if (mskLicenseKey.MaskFull)
            {
                (ApiKey? apiKey, string message) checkResult = await ApiProcessor.CheckLicense(licenseKey);
                if (checkResult.apiKey is not null)
                {
                    if (!checkResult.apiKey.IsActivated)
                    {
                        DialogResult dialog = MessageBox.Show("Lisansý aktifleþtirmek istediðinize emin misiniz?\nLisansý aktifleþtirmek kiralama süresini baþlatacaktýr ve lisans anahtarýný bilgisayarýnýzla eþleþtirecektir.", "Uyarý!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {

                            //TODO: API Request
                            (bool status, string message) result = await ApiProcessor.ActivateLicense(licenseKey, HWID);

                            if (result.status)
                            {
                                MessageBox.Show(result.message, "Aktifleþtirme Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnHideKey.Visible = true;

                                (ApiKey? apiKey, string message) activateResult = await ApiProcessor.CheckLicense(licenseKey);
                                globalKey = activateResult.apiKey;

                                lblLicenseKey.Text = licenseKey;
                                label1.Visible = false;
                                mskLicenseKey.Visible = false;
                                btnActivateLicense.Visible = false;
                                btnInjectBot.Visible = true;

                                if (activateResult.apiKey is not null)
                                {
                                    lblRemaining.Visible = true;
                                    lblRemaining.Text = $"Lisansin kalan süresi: {activateResult.apiKey.DaysLeft} gün";
                                    timer1.Enabled = true;
                                }
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
                        bool isLicenseExpired = checkResult.apiKey.ExpireDate.CompareTo(GetDateTime()) < 0;
                        if (isLicenseExpired)
                        {
                            MessageBox.Show("Maalesef ki bu lisans anahtarýnýn süresi dolmuþ. Lütfen yeni bir lisans anahtarý satýn alýnýz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (checkResult.apiKey.HWID == HWID)
                            {
                                MessageBox.Show("Lisans anahtarý baþarýyla etkinleþtirildi. Ýyi oyunlar dileriz!", "Etkinleþtirme Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnHideKey.Visible = true;
                                globalKey = checkResult.apiKey;

                                lblLicenseKey.Text = licenseKey;
                                label1.Visible = false;
                                mskLicenseKey.Visible = false;
                                btnActivateLicense.Visible = false;
                                btnInjectBot.Visible = true;
                                lblRemaining.Visible = true;
                                lblRemaining.Text = $"Lisansin kalan süresi: {checkResult.apiKey.DaysLeft} gün";
                                timer1.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Bu lisans anahtarý zaten baþka bir bilgisayara aktifleþtirilmiþ. Eðer bunun bir hata olduðunu düþünüyorsanýz lütfen lisans anahtarýný aldýðýnýz yerle iletiþime geçiniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    mskLicenseKey.Clear();
                    MessageBox.Show(checkResult.message, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (globalKey is not null)
            {
                int daysRemaining = (globalKey.ExpireDate - GetDateTime()).Days;
                lblRemaining.Text = $"Lisansin kalan süresi: {daysRemaining} gün";
                bool isLicenseExpired = globalKey.ExpireDate.CompareTo(GetDateTime()) < 0;
                if (isLicenseExpired)
                {
                    btnHideKey.Visible = false;
                    globalKey = null;

                    lblLicenseKey.Text = "XXXXX-XXXXX-XXXXX-XXXXX-XXXXX";
                    label1.Visible = true;
                    mskLicenseKey.Visible = true;
                    btnActivateLicense.Visible = true;
                    btnInjectBot.Visible = false;
                    lblRemaining.Visible = false;
                    lblRemaining.Text = $"Aktif lisans bulunamadý.";
                    timer1.Enabled = false;

                    MessageBox.Show("Maalesef ki lisansýnýzýn süresi doldu. Lütfen yeni bir lisans anahtarý satýn alýnýz.", "Uyarý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void btnInjectBot_Click(object sender, EventArgs e)
        {

        }
    }
}
