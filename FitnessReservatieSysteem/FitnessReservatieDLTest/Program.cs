// See https://aka.ms/new-console-template for more information
using FitnessReservatie.BL.Managers;
using FItnessReservatieDL;

Console.WriteLine("Hello, World!");

string connectionstring = @"Data Source=DESKTOP-91NOPN3\SQLEXPRESS;Initial Catalog=FitnessReservatieSysteem;Integrated Security=True
";

KlantManager km = new KlantManager(new KlantRepoADO(connectionstring));
Console.WriteLine(km.GetKlantVoornaam(1,null));
Console.WriteLine(km.GetKlantVoornaam(null,"ibrahim@khlosi.com"));
Console.WriteLine((km.ZoekKlantDetails(1,null)).Achternaam);