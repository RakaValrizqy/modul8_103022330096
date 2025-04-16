// See https://aka.ms/new-console-template for more information
using modul8_103022330096;

class Program
{
    static void Main(string[] args)
    {
        UIConfig config = new UIConfig();

        Console.WriteLine("Select Language: ");
        string bhs = Console.ReadLine();

        if (bhs == "en")
        {
            config.bankTransferConfig.lang = "en";
        } else if (bhs == "id")
        {
            config.bankTransferConfig.lang = "id";
        }

        config.WriteNewConfigFile();

        if (config.bankTransferConfig.lang == "en")
        {
            Console.Write("Please insert the amount od money to transfer: ");
        } else if (config.bankTransferConfig.lang == "id")
        {
            Console.Write("Masukkan jumlah uang yang akan di - transfer: ");
        }

        int x = Convert.ToInt32(Console.ReadLine());
        int biayaTf;
        if (x <= config.bankTransferConfig.transfer.threshold)
        {
            biayaTf = config.bankTransferConfig.transfer.low_fee;
        } else
        {
            biayaTf = config.bankTransferConfig.transfer.high_fee;
        }
        int total = x + biayaTf;

        if (config.bankTransferConfig.lang == "en")
        {
            Console.WriteLine($"Transfer fee = {biayaTf} and Total Amount = {(total)}");
        } else if (config.bankTransferConfig.lang == "id") 
        {
            Console.WriteLine($"Biaya transfer = {biayaTf} dan Total biaya = {(total)}");
        }

        if (config.bankTransferConfig.lang == "en")
        {
            Console.WriteLine("Select transfer method: ");
        }
        else if (config.bankTransferConfig.lang == "id")
        {
            Console.WriteLine("Pilih metode transfer: ");
        }
        for (int i=0; i<config.bankTransferConfig.methods.Count; i++)
        {
            Console.WriteLine($"{(i+1)}. {config.bankTransferConfig.methods[i]}");
        }

        Console.Write("Input: ");
        int mtd = Convert.ToInt32(Console.ReadLine())-1;

        string confirm;
        if (config.bankTransferConfig.lang == "en")
        {
            Console.WriteLine($"Please type {config.bankTransferConfig.confirmation.en} to confirm the transaction: ");
            confirm = Console.ReadLine();
            if (confirm == "yes")
            {
                Console.WriteLine("The transfer is completed");
            } else
            {
                Console.WriteLine("Transfer is cancelled");
            }
        } else if (config.bankTransferConfig.lang == "id")
        {
            Console.WriteLine($"Ketik {config.bankTransferConfig.confirmation.id} untuk mengkonfirmasi transaksi: ");
            confirm = Console.ReadLine();
            if (confirm == "ya")
            {
                Console.WriteLine("Proses transfer berhasil");
            }
            else
            {
                Console.WriteLine("Transfer dibatalkan");
            }
        }
    }
}
