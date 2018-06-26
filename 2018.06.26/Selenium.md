## Selenium

Zostaliście starzystami w prestiżowej firmie Ceglarek Corporation. Waszym pierwwszym zadaniem będzie przetestowanie, czy strona internetowa firmy działa poprawnie na różnych przeglądarkach. Marcin (CTO) słyszał, że można to zrobić przy pomocy Selenium, ale nikt w firmie tego jeszcze nie używał. Jeden ze stażystów (Marcin) znalazł kiedyś posta w internecie, który opisywał jak to zrobić, ale nie wykonał żadnego testu.

http://scraping.pro/example-of-scraping-with-selenium-webdriver-in-csharp/

Inny stażysta (Marcin) przygotował listę rzeczy, które trzeba zrobić, żeby testy selenium się udały:

1. Zaintalować pakiet Selenium
2. Ściągnąć odpowiedni driver do przeglądarki i wrzucić do katalogu wykonywalnego programu
3. Można pisać testy!

Waszym zadaniem jest:
1. Zainstalować pakiet selenium i odpalić framework, tak aby wybrana przez was przeglądarka się włączyła i test miał nad nią kontrolę
2. Otworzyć stronę http://testing-ground.scraping.pro/login i z powodzeniem się na nią zalogować przy pomocy testowych danych: (admin/12345)
3. Krok 2 powtórzyć dla 3 różnych przeglądarek (Chrome, FIrefox, IE), następnie wykonać screenshota i porównać różnicę w renderowaniu
    * Do porównania można wykorzystać ImageTools z solucji Selenium lub napisać to sobie samemu
4. Napisać test który: 
    * wejdzie na wp.pl
    * Zamknie popup o RODO
    * Przewinie stronę i otworzy 3ci artykół w zakładce Wiadomości (2gi bez obrazka)
    * Przejdzie do komentarzy i wpisze w treść komentarza "To okropne co PIS robi z tym krajem"
    * Przejdzie do pola "Twoje imię" i wpisze "Zbulwersowany obywatel"
    * NIE KLIKNIE "Dodaj komentarz" ;)