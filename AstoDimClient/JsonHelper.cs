﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AstoDimClient
{
    public static class JsonHelper
    {
        public static void WriteKeyToFile(LicenseKey licenseKey)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(licenseKey, Formatting.Indented);
                File.WriteAllText(Application.StartupPath + "licensing.json", jsonString);
            }
            catch (Exception e)
            {
                MessageBox.Show("Maalesef bir hata oluştu:\n" + e.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static LicenseKey ReadKeyFromFile()
        {
            try
            {
                if (File.Exists(Application.StartupPath + "licensing.json"))
                {
                    string jsonString = File.ReadAllText(Application.StartupPath + "licensing.json");
                    return JsonConvert.DeserializeObject<LicenseKey>(jsonString) ?? new LicenseKey();
                }
                else
                {
                    MessageBox.Show("Lisans dosyası bulunamadı. Lütfen lisansınızı etkinleştirin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new LicenseKey();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Maalesef bir hata oluştu:\n" + e.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new LicenseKey();
            }
        }

        public static void RemoveLicenseFile()
        {
            try
            {
                if (File.Exists(Application.StartupPath + "licensing.json"))
                    File.Delete(Application.StartupPath + "licensing.json");
            }
            catch (Exception e)
            {
                MessageBox.Show("Dosya okuma yazma işlemlerinde bir sorun çıktı!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
