using System.Text.RegularExpressions;

namespace DesafioPOO.Models
{
    public abstract class Smartphone(string sim1, string modelo, string imei, int memoria)
    {
        private static string? ParaChip(string? num)
        {
            if (num is null)
                return null;

            num = num.Replace(" ", "");
            return Regex.Replace(num, @"^\+?(\d{2,3})(\d{2})9(\d{4})-?(\d{4})$", "+$1 ($2)9$3-$4");
        }

        public string SIM1
        {
            get => ParaChip(sim1) ?? "";
            set => sim1 = value;
        }

        private string? _sim2;
        public string? SIM2
        {
            get => ParaChip(_sim2);
            set => _sim2 = value;
        }

        protected string Modelo { get; } = modelo;
        protected string IMEI { get; } = Regex.Replace(imei, @"^(\d{6})-?(\d{2})-?(\d{5})-?(\d)$", "$1-$2-$3-$4");
        protected int Memoria { get; } = memoria;

        private string[] DescricaoSmartphoneString() => [
            $"Modelo: {Modelo}",
            $"IMEI: {IMEI}",
            $"Memória: {Memoria}GB",
            $"SIM1: {SIM1}{(SIM2 is null ? "" : $"\n  SIM2: {SIM2}")}"
        ];

        public void DescricaoSmartphone() => Console.WriteLine(string.Join('\n', DescricaoSmartphoneString()));

        public void DescricaoSmartphone(string marca)
        {
            Console.WriteLine(marca);
            Console.WriteLine(string.Join('\n', DescricaoSmartphoneString().Select(e => $"  {e}")));
        }

        public void Ligar() => Console.WriteLine("Ligando...");
        public void Ligar(string deChip) => Console.WriteLine($"Ligando do número {deChip}...");
        public void Ligar(string deChip, string paraChip) => Console.WriteLine($"Ligando do número {deChip} para {paraChip}...");

        public void ReceberLigacao() => Console.WriteLine("Recebendo ligação...");

        public abstract void InstalarAplicativo(string nomeApp);
    }
}
