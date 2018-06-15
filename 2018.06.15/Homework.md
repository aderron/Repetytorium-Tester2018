This is homework that you're supposed to do over the weekend!! :(((

1. Finish reading chapter 1 and chapter 2 (in polish) of ISTQB Foundation Syllabus (Link in ISTQB section)
2. Bugi, will prepare Glossary entries for it (with polish descriptions)
3. YOU WILL show me your solutions (might not be working) for ProjectEuler problems Largest prime factor (https://projecteuler.net/problem=3) and Largest palindrome product (https://projecteuler.net/problem=4)
4. Think about Defects that you can find for PasswordValidator
5. Programing courses. Please... Write tests that check how each of those operatotrs work!

    Data structures: bool, int, byte, short, long, string, enum, int[], char[], IEnumerable<...>, ICollection<...>, IList<...>

    Operators: =, ==, !=, <=, <, >, >=, *, ^, &, &&, |, +=, -=, *=, /=, &=, |=, ++i, i++

    Commnads/Keywords: if..else if..else, for, foreach, while.., switch..case, do..while

    LINQ: 
        .Where(a => isOdd(a)) - filtruje kolkcje przy p omocy predykatu  (czy nieprzyste)
        .Select(a => b) - konwertuje koleckję z a na b
        .Sum(a => isOdd(a)) - sumuje te któe spełniają predykat (nieparzyste), 
        .Count()- liczy te któe spełniają predykat (nieparzyste)
        First() - zwraca pierwszy, który spełnina predykat, 
        Last() - zwraca ostatni który z wraca predykat 
        Single()- zwraca jedyny element który spełnia predykat albo rzuca exception
        GroupBy(p => p.Age) - grupuje elementy po predykacie 
        OrderBy(p => p.Age) - sortuje kolekcje po Age, (OrderByDescending)
        ToList() - twory listę z wyrażenia, które wpisaliśmy wcześniej (.ToArray())


var Names = new List<string>() { "Ania", "Kamil", "Jezus" };
Names.Add("Tolek");
Names.Remove("Kamil"); 
foreach (var name in Names.Where(name => name != "Ania")) 
{

}

i=3;
console.writeline(++i);  // 4
console.writeLine(i++);  // 3
i == 4;

public enum Sizes {
    S = 0,
    M = 1,
    L = 2,
    XL = 3 
}

// TO JEST ZŁO
if (a = b)
{

}
