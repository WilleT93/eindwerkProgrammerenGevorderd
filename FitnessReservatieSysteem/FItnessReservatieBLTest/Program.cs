// See https://aka.ms/new-console-template for more information
using FitnessReservatie.BL.Domein;

Console.WriteLine("Hello, World!");


Klant klant = new Klant(1,"test@hotmail.com","tobias","wille");
Toestel toestel = new Toestel(2,"loopband");
Reservatie reservatie = new Reservatie(3,new DateTime(2009,1,1), klant);
Tijdslot tijdslot = new Tijdslot(4);

reservatie.VoegSessieToe(tijdslot.Id,toestel.Id);
Console.WriteLine(klant.Achternaam);
Console.WriteLine(toestel.Id);
Console.WriteLine(reservatie.ReservatieDatum);
Console.WriteLine(tijdslot.Id);