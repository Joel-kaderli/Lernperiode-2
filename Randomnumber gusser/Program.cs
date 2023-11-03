using System.Security.Cryptography.X509Certificates;

Random numberguesser = new Random();
int roll = numberguesser.Next(1, 100); // Zufällige Zahl zwischen 1 und 100


int versuche = 0;
bool richtigGeraten = false; // Wurde die richtige Zahl erraten?

Console.WriteLine("Hier kannst du eine Zahlen Rate Spiel spielen");
Console.WriteLine("Ich habe mir eine Zahl zwischen 1 und 99 aus gedacht");

while (!richtigGeraten)
{
    Console.WriteLine("Geben sie eine Zahl zwischem 1 und 100 ein: ");
    string DiegerateZahl = Console.ReadLine();
   
    if (int.TryParse(DiegerateZahl, out int benutzerGeratteneZahl)) // Überprüfung der Benutzereingabe auf Gültigkeit
    {

        if (benutzerGeratteneZahl < 1 || benutzerGeratteneZahl > 100)
        {
            Console.WriteLine("Bitte geben Sie eine Zahl zwischen 1 und 100 ein.");
        }
        else
        {
            versuche++;// Erhöhen der Versuchsanzahl

                        if (benutzerGeratteneZahl == roll)
            {
                richtigGeraten = true;
                Console.WriteLine($"Glüchwunsch! Sie haben die Zahl {roll} in {versuche} Versuchen erraten ");
            }
            else if (benutzerGeratteneZahl < roll)
            {
                Console.WriteLine("Die gesuchte Zahl ist grösser.");
            }
            else
            {
                Console.WriteLine("Die gesuchte Zahl ist kleiner. ");
            }
        }
    }
    else
    {
        Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine ganze Zahl ein.");
    }
}

Console.WriteLine("Danke viel mal fürs Spielen!!");
