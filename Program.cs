using DesafioPOO.Models;

static void separador() => Console.WriteLine(new string('-', 42));

var nokia = new Nokia("+55 88 9 5623251", "N95", "73847982349811", 64);
nokia.DescricaoSmartphone(marca: "Nokia");
nokia.InstalarAplicativo("Whatsapp");

separador();

nokia.SIM1 = "5521955632121";
Console.WriteLine("- SIM1 alterado!");

nokia.DescricaoSmartphone();
nokia.Ligar();

separador();

var iphone = new Iphone("+5511956247123", "9S", "15262225632100", 128);
iphone.SIM2 = "+5589966223311";
iphone.DescricaoSmartphone("Iphone");
iphone.InstalarAplicativo("Telegram");
iphone.ReceberLigacao();

separador();

nokia.Ligar(deChip: nokia.SIM1, paraChip: iphone.SIM2);
