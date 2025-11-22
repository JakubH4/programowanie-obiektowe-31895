// zadanie 1
const int requiredAge = 18;
const string accessDenied = "Musisz mieć 18 lat.";
const string accessAllowed = "Witamy w naszym sklepie";
const string accessPartial = "Możesz przeglądać, ale nie możesz kupować.";

int age = 14;

do
{
    Console.WriteLine("Podaj swój wiek: ");
    string input = Console.ReadLine();

    bool success = int.TryParse(input, out age);

    if (!success)
    {
        Console.WriteLine("Podaj poprawną wartość!");
    }
    else
    {
        if (age == 14)
        {
            Console.WriteLine(accessPartial);
        }
        else if (age < requiredAge)
        {
            Console.WriteLine(accessDenied);
        }
        else
        {
            Console.WriteLine(accessAllowed);
        }
    }

} while (age < requiredAge);


