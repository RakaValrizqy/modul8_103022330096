using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace modul8_103022330096
{
    class Transfer
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }

    }

    class Confirmation
    {
        public string en { get; set; }
        public string id { get; set; }
    }
    internal class BankTransferConfig
    {
        public string lang { get; set; }
        public Transfer transfer { get; set; }
        public List<string> methods { get; set; }
        public Confirmation confirmation { get; set; }
        public BankTransferConfig() { }

        public BankTransferConfig(string lang, Transfer transfer, List<string> methods, Confirmation confirmation) 
        {
            this.lang = lang;
            this.transfer = transfer;
            this.methods = methods;
            this.confirmation = confirmation;
        }

    }

    class UIConfig
    {
        public BankTransferConfig bankTransferConfig;

        public const string filePath = "bank_transfer_config.json";

        public UIConfig() 
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception ex)
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }
        
        public BankTransferConfig ReadConfigFile()
        {
            string configJsonData = File.ReadAllText(filePath);
            bankTransferConfig = JsonSerializer.Deserialize<BankTransferConfig>(configJsonData);
            return bankTransferConfig;
        }

        public void SetDefault()
        {
            bankTransferConfig.lang = "en";
            bankTransferConfig.transfer.threshold = 25000000;
            bankTransferConfig.transfer.low_fee = 6500;
            bankTransferConfig.transfer.high_fee = 15000;
            bankTransferConfig.methods = ["RTO (real-time)", "SKN", "RTGS", "BI FAST"];
            bankTransferConfig.confirmation.en = "yes";
            bankTransferConfig.confirmation.id = "ya";
        }

        public void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };    

            string jsonString = JsonSerializer.Serialize(bankTransferConfig, options);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
