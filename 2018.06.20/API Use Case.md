1. Czy GetList działa
    a) get http://192.168.1.137/people/GetList
    b) check if content is a list of people

2. Przypadek użycia dla dodawania nowej osoby  (pozytywny)
   a) pobieramy listę osób (GetList)
   b) generujemy nową osobę, której nie ma na liście
   c) wysyłamy obiekt nowej osoby na /people/Post  (metoda POST, application/json)
   d) pobieramy listę osób ponownie i weryfikujemy czy nasz osoba jest na liście

3. Przypadek użycia (negatywny)
    a) generujemy nową osobę, która nie ma wieku (0)
    b) wysyłamy obiekt nowej osoby na /people/Post  (metoda POST, application/json)
    c) oczekujemy 400 bad request

4. Dodanie osoby która już istnieje (negatywny)
   a) pobieram listę osób
   b) dodajemy nową osobę wybierając losową z listy
   c) oczekujemy błędu (400)
