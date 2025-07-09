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
                MessageBox.Show("Sunuculara eri�ilemedi. L�tfen internet ba�lant�n�z� kontrol ediniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        DialogResult dialog = MessageBox.Show("Lisans� aktifle�tirmek istedi�inize emin misiniz?\nLisans� aktifle�tirmek kiralama s�resini ba�latacakt�r ve lisans anahtar�n� bilgisayar�n�zla e�le�tirecektir.", "Uyar�!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {

                            //TODO: API Request
                            (bool status, string message) result = await ApiProcessor.ActivateLicense(licenseKey, HWID);

                            if (result.status)
                            {
                                MessageBox.Show(result.message, "Aktifle�tirme Ba�ar�l�", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                    lblRemaining.Text = $"Lisansin kalan s�resi: {activateResult.apiKey.DaysLeft} g�n";
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
                            MessageBox.Show("Maalesef ki bu lisans anahtar�n�n s�resi dolmu�. L�tfen yeni bir lisans anahtar� sat�n al�n�z.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (checkResult.apiKey.HWID == HWID)
                            {
                                MessageBox.Show("Lisans anahtar� ba�ar�yla etkinle�tirildi. �yi oyunlar dileriz!", "Etkinle�tirme Ba�ar�l�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnHideKey.Visible = true;
                                globalKey = checkResult.apiKey;

                                lblLicenseKey.Text = licenseKey;
                                label1.Visible = false;
                                mskLicenseKey.Visible = false;
                                btnActivateLicense.Visible = false;
                                btnInjectBot.Visible = true;
                                lblRemaining.Visible = true;
                                lblRemaining.Text = $"Lisansin kalan s�resi: {checkResult.apiKey.DaysLeft} g�n";
                                timer1.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Bu lisans anahtar� zaten ba�ka bir bilgisayara aktifle�tirilmi�. E�er bunun bir hata oldu�unu d���n�yorsan�z l�tfen lisans anahtar�n� ald���n�z yerle ileti�ime ge�iniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("L�tfen do�ru bir lisans anahtar� girdi�inizden emin olunuz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                lblRemaining.Text = $"Lisansin kalan s�resi: {daysRemaining} g�n";
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
                    lblRemaining.Text = $"Aktif lisans bulunamad�.";
                    timer1.Enabled = false;

                    MessageBox.Show("Maalesef ki lisans�n�z�n s�resi doldu. L�tfen yeni bir lisans anahtar� sat�n al�n�z.", "Uyar�!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void btnInjectBot_Click(object sender, EventArgs e)
        {

        }
    }
}
