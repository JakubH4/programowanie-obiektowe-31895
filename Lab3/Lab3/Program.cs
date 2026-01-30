// zadanie 4

// var o1 = new Osoba("Arek", 32);
// var o2 = new Osoba("Peter", 24);
// var o3 = new Osoba("Maria", 28);
//
// o1.PrzedstawSie();
// o2.PrzedstawSie();
// o3.PrzedstawSie();
//
// class Osoba
// {
//     private string imie;
//     private int wiek;
//     
//     public Osoba(string imie, int wiek)
//     {
//         this.imie = imie;
//         this.wiek = wiek;
//     }
//
//     public void PrzedstawSie()
//     {
//         Console.WriteLine($"Mam na imię {imie}. Mam {wiek} lat!");
//     }
// }


// zadanie 5

/*
 var acc1 = new BankAccount();

acc1.deposit(1000);
acc1.getBalance();
acc1.withdraw(900);
acc1.getBalance();
acc1.withdraw(200);

class BankAccount
{
    private double balance;
    public void deposit(double cash)
    {
        Console.WriteLine($"Deposit {cash}");
        balance += cash;
    }

    public void getBalance()
    {
        Console.WriteLine($"Balance: {balance}");
    }

    public void withdraw(double cash)
    {
        if (balance - cash >= 0)
        {
            balance -= cash;
            Console.WriteLine($"Wypłaciłeś: {cash}");
        }
        else
        {
            Console.WriteLine("Brak środków na koncie!");
        }
    }
}
*/

// zadanie 6

// var myCat = new Cat();
// myCat.Meow();
// myCat.Jedz();
//
// class Zwierze
// {
//     public void Jedz() => Console.WriteLine("Zwierzę je");
// }
// class Pies : Zwierze
// {
//     public void Szczekaj() => Console.WriteLine("Hau hau!");
// }
//
// class Cat : Zwierze
// {
//     public void Meow() =>  Console.WriteLine("Meow!");
// }