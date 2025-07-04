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

                                lblLicenseKey.Text = licenseKey;
                                label1.Visible = false;
                                mskLicenseKey.Visible = false;
                                btnActivateLicense.Visible = false;
                                btnInjectBot.Visible = true;

                                if (activateResult.apiKey is not null)
                                {
                                    lblRemaining.Visible = true;
                                    lblRemaining.Text = $"Lisansin kalan s�resi: {activateResult.apiKey.DaysLeft} g�n";
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
                        if (checkResult.apiKey.DaysLeft < 0)
                        {
                            MessageBox.Show("Maalesef ki bu lisans anahtar�n�n s�resi dolmu�. L�tfen yeni bir lisans anahtar� sat�n al�n�z.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (checkResult.apiKey.HWID == HWID)
                            {
                                MessageBox.Show("Lisans anahtar� ba�ar�yla etkinle�tirildi. �yi oyunlar dileriz!", "Etkinle�tirme Ba�ar�l�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnHideKey.Visible = true;

                                lblLicenseKey.Text = licenseKey;
                                label1.Visible = false;
                                mskLicenseKey.Visible = false;
                                btnActivateLicense.Visible = false;
                                btnInjectBot.Visible = true;
                                lblRemaining.Visible = true;
                                lblRemaining.Text = $"Lisansin kalan s�resi: {checkResult.apiKey.DaysLeft} g�n";
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
    }
}
