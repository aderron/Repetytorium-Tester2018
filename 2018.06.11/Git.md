Git
===
## Klienci
  * Git (https://git-scm.com/) - na zajęciach przerabialiśmy jego podstawy, łącznie z importem kluczy. Najbardziej 'prymitywny', ale o największych możliwościach. 
      * Tutorial tworzenia i instalacji klucza ssh: https://help.github.com/articles/generating-a-new-ssh-key-and-adding-it-to-the-ssh-agent/
      * Tutorial dodania klucza do konta na GitHubie: https://help.github.com/articles/adding-a-new-ssh-key-to-your-github-account/
  * TortoiseGit (https://tortoisegit.org/) - Nakładka na 'zwykłego' Git'a. Dostępne praktycznie wszystkie polecenia w formie okienek windowsa.
  * SourceTree (https://www.sourcetreeapp.com/) - Wymaga założenia konta, potrafi być powolny przy dużych repozytoriach
  * GitHub Desktop (https://desktop.github.com/) - Warto wypróbować
  * GitKraken (https://www.gitkraken.com/) - Mój faworyt, jednakże płatny do zastosowań komercyjnych (czyli w pracy). $49/user/yr - taniej przy większych zespołach

## Podstawowe komendy

 * git clone \<url> - tworzenie lokalnej kopii (klona) repozytorum dostępnego pod adresem w aktualnym folderze (.)
 * git add \<plik/folder> - dodanie pliku/folderu do commita (w TortoiseGit zaznacza się te pliki checkboxami, w pozostałych trzeba je 'stage'nąć)
 * git commit - Otwiera naszego fantastycznego Vima w celu napisania wiadomości do commita. We wszystkich innych klientach jest to dużo bardziej intuicyjne
 * git pull - ściągnięcie zmian obecnego brancha z serwera (zdalnego repozytorium)
 * git push - 'wypchnięcie' zmian z lokalnego repozytorium na zdalne
 * git status - pokazuje na jakim branchu jesteśmy, ile plików jest zmodyfikowanych, ile plików jest dodanych

 ## Jak wyjść z Vim'a

[Esc]:wq[Enter] - Wyjście i zapisanie zmian
[Esc]:q![Enter] - Wyjście bez zapisywania zmian

