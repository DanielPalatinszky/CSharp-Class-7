using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CSharp_Class_7
{
    // Az enum egy olyan típus, amely egyedi és megváltoztathatatlan értékeket tud tárolni
    enum Difficulty
    {
        Easy, Medium, Hard
    }

    // Alapértelmezetten az első érték 0, majd 1, 2 stb. (mindig 1-el nő)
    // De saját magunk is adhatunk értékeket:
    enum Months
    {
        January = 1, February = 2, //...
    }

    // Nem vagyunk kötelesek minden elemnek értéket adni (minden elem értéke az előző elem +1):
    enum CustomValues
    {
        A = 2, B /*3*/, C /*4*/, D = 10, E /*11*/
    }

    //--------------------------------------------------

    // Speciális adatszerkezet, amely tetszőleges típusú változókat (adattagokat) képes egyben tárolni
    struct Person
    {
        // A public kulcsszó azt jelenti, hogy az adattagot a struct-on kívül is el tudjuk érni
        public string name;

        // Ha nem írjuk oda az ugyanaz, mintha azt írnánk oda, hogy private (mindig írjuk ki!)
        // Ez azt jelenti, hogy az adattag, csak a struct-on belül érhető el
        //string birthPlace;
        private string birthPlace;

        public int age;
    }

    struct Test
    {
        public List<int> list;

        public int i;

        public float f;
    }

    // Structban lehet struct:
    struct Student
    {
        public Grades grades;
    }

    struct Grades
    {
        public string subject;

        public List<int> grades;

        // Saját magát nem tartalmazhatja:
        //public Grades grades;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Saját enum típusú változó létrehozása
            var difficulty = Difficulty.Easy;

            // Érték megváltoztatása a szokványos módon
            difficulty = Difficulty.Hard;

            // Ki is írhatjuk
            Console.WriteLine(difficulty);

            // Ellenőrzés
            if (difficulty == Difficulty.Easy)
            {
                Console.WriteLine();
            }

            // Mivel meghatározott számú egyedi és megváltoztathatatlan értékeket tárol, ezért általában switch-el ellenőrizzük if helyett
            switch (difficulty)
            {
                case Difficulty.Easy:
                    break;
                case Difficulty.Medium:
                    break;
                case Difficulty.Hard:
                    break;
            }

            // Valójában a háttérben minden egyes érték egy int
            // Bizonyíték:
            Console.WriteLine((int) difficulty); // 0

            // Fordítva is megy:
            difficulty = (Difficulty)0; // Easy

            // Mikor használjuk?
            // Ha az értéktartományunk néhány értékből áll és kényelmesebb/egyszerűbb/átláthatóbb lenne az elemeket a nevükkel azonosítani (string, int vagy valamilyen kollekció helyett)

            //--------------------------------------------------

            // Új személy létrehozása
            var person1 = new Person();

            // Az adattagok elérése (írás, olvasás)
            // Mivel public, ezért a struct-on kívül is látjuk
            person1.name = "Dani";
            Console.WriteLine(person1.name);

            // a birthPlace private, ezért nem érjük el a struct-on kívül
            //person1.birthPlace = "";

            // Metódusnak átadva nem tudjuk módosítani
            // Érték szerint adódik át, azaz a benne tárolt adattagok értékei átmásolódnak egy új Person structba, amit a metódus megkap
            Console.WriteLine(person1.name); // Dani
            RenameByValue(person1);
            Console.WriteLine(person1.name); // Dani

            // Referencia szerint átadva viszont működik:
            Console.WriteLine(person1.name); // Dani
            RenameByRef(ref person1);
            Console.WriteLine(person1.name); // Bálint

            // struct nem lehet null:
            //person1 = null;

            // Ha a struct-ban szerepel egy összetett típus (pl. list, dictionary, tuple stb. ~ ami lehet null [string is]) (nem int, float, double stb. ~ nem lehet null) (később megbeszéljük honnan tudjuk melyik milyen típusú)
            // akkor azt külön létre kell hozni, mert az alapértelmezett értéke null lesz
            var test = new Test();

            // Hiba, mert null:
            //test.list[0] = 1;

            // Hozzuk előbb létre:
            test.list = new List<int>();

            // Mostmár működik:
            test.list[0] = 1;

            // Az egyszerű típusok esetén a típus alapértelmezett értékét kapja meg:
            Console.WriteLine(test.i); // 0
            Console.WriteLine(test.f); // 0.0

            // Mivel a struct nem lehet null, ezért struct-oknak a tömbje esetén, nem kell az egyes struct-tokat külön létrehozni
            // Figyeljünk arra, hogy ha a struct tartalmaz összetett típust, akkor azokat viszont külön létre kell hozni a tömb minden struct-ja esetén
            var persons = new Person[10];

            // Működik:
            persons[0].name = "András";

            // Mivel a struct nem lehet nulll, ezért struct-on belüli struct-ot nem kell létrehozni:
            var student = new Student();
            student.grades.subject = "Math";

            // Két struct között nem tudsz alapértelmezetten egyenlőséget vonni
            // Ha össze akarod hasonlítani őket, akkor adattagonként kell
            var personA = new Person();
            var personB = new Person();

            // Nem megy:
            /*if (personA == personB)
            {

            }*/
        }

        static void RenameByValue(Person p)
        {
            p.name = "Bálint";
        }

        static void RenameByRef(ref Person p)
        {
            p.name = "Bálint";
        }
    }
}
