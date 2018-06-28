1. Napisać Regex, który matchuje datę w formacie D.MM.YYYY (użyć 2x \b, dzień, miesiąc i rok wrucić w grupy)
    * 1.01.2011
    * 30.12.2018
    * 9.05.1854

    (\d{1,2})\.(\d{2})\.(\d{4})
2. Napisać regex, któy zmatchuje imiona żeńskie (zaczynają się dużą literą i kończą na a)

    [A-ZŁŻ][a-z]+a$

3. Napisaać RegEx i replace w wybranym przez was edytorze tekstu, który zamieni:
[ 2, 3, 4, 7, 4, 9, 5.2, 2, 6, 5, 5, 7, 12, 3, 123] 
na tablicę stringów:
[ "2", "3", "4", "7", "4", "9", "5.2", "2", "6", "5", "5", "7", "12", "3", "123"]

    ([\d]+)(\.\d+)? => "$0"

4. SYLABUS BĘDZIE NA EGZAMINIE (boski głos)

5. Egzamin będzie na 10 (cz. teoretyczna i praktyczna)
ERRATA: 9:30, 
    egzamin administracyjny, 
    spotkanie z BPE,
    koniec obecności obowiązkowej ;) 
    egzamin drugi :) + część praktyczna (będą regexpy i mocki)