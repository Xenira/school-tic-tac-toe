## THIS IS THE WEB VERSION! PLEASE DOWNLOAD THE FULL VERSION [HERE](https://xenira.github.io/school-tic-tac-toe/Array_Programmierung.docx)

# 1. Inhalt

| Number | Title |
| --- | --- |
| 2. | Bedeutung von Arrays in der Programmierung |
| 2.1. | Was sind Arrays |
| 2.2. | Arrays in C# |
| 2.2.1. | Deklarierung von Arrays |
| 2.2.2. | Inline Deklarierung |
| 2.2.3. | Jagged und Zweidimensionale Arrays |
| 2.3. | Arrays in moderner Programmierung |
| 3. | Quellcode Dokumentation |
| 3.1. | Klassenübersicht |
| 3.1.1. | Main |
| 3.1.2. | Game |
| 3.2. | Spiellogik (Game Klasse) |
| 3.2.1. | Properties |
| 3.2.2. | Methoden |
| 3.2.3. | Anzeige / User Interface (Main Klasse) |
| 4. | Fazit |
| 5. | Weitere Dokumentation und Quellcode |
| 6. | Lizenz |
| 7. | Literaturverzeichnis |

# 2. Bedeutung von Arrays in der Programmierung
## 2.1. Was sind Arrays

Einfach ausgedrückt sind Arrays listen. Komplizierter ausgedrückt sind Arrays Datenstrukturen, welche mehrere Variablen eines Datentyps gespeichert werden können[CITATION Lou15 \l 2057].

Ein Array ist dabei eine der einfachsten Listen, hat aber auch einige Einschränkungen. So müssen bei einem Array nicht nur der Typ, sondern auch die Anzahl der Elemente angegeben werden. Die Länge und der Typ müssen dabei bereits beim Erstellen des Arrays feststehen und können später in der Regel nicht geändert werden. Dies hat den Hintergrund, dass der entsprechende Speicher dem Array zugewiesen werden muss.

Um auf ein Element des Arrays zuzugreifen muss der Index, also die Position, des Elements angegeben werden. Da durch den Variablentyp die Länge eines Wertes bekannt ist, kann durch Multiplikation die Position des Wertes oder der Referenz errechnet werden, was den Zugriff auf diesen Wert erlaubt. Aus diesem Grund ist das erste Element des Arrays auch an Position 0 zu finden.

> ```C#
> intArray = new int[4];
> intArray[0] = 300;
> intArray[1] = 301;
> intArray[2] = 302;
> intArray[3] = 303;
> ```
>
> | Byte | Data | Accessor |
> | --- | --- | --- |
> | 0 - 4 | 4 | length of array |
> | 4 - 8 | 300 | `intArray[0]` |
> | 8 - 12 | 301 | `intArray[1]` |
> | 12 - 16 | 302 | `intArray[2]` |
> | 16 - 20 | 303 | `intArray[3]` |

## 2.2. Arrays in C#
### 2.2.1. Deklarierung von Arrays

Arrays in C# funktionieren ähnlich wie in den meisten Programmiersprachen. Der Variable wird mit dem Datentyp gefolgt von zwei eckigen Klammern und dem Variablennamen  deklariert. Die Wertzuweisung erfolgt mit dem ‚new&#39; Keyword gefolgt von dem Datentyp und der Länge in eckigen Klammern. Um Werte Zuzuweisen oder Auszulesen wird der Variablenname mit dem Index in eckigen Klammern benutzt.

```C#
int[] variablenName;
variablenName = newint[5];
variablenName[0] = 42;
```

### 2.2.2. Inline Deklarierung

Da dieser manuelle Weg der Wertzuweisung sehr Unhandlich sein kann gibt es eine Alternative Schreibweise, welche die Erstellung von Arrays mit statischen Werten vereinfacht. Dafür gibt man bei der Initialisierung die Werte einfach in geschweiften Klammern  und mit Komma getrennt an.

### 2.2.3. Jagged und Zweidimensionale Arrays

Um mehrere Dimensionen / Spalten darzustellen gibt es in C# zwei verschiedene Konzepte. Sollte in jeder Zeile gleich viele Spalten geben, so spricht man von zweidimensionalen Arrays. Zweidimensionale Arrays werden mit einem Komma in den eckigen Klammern gekennzeichnet und auf die Werte kann mit durch ein Komma getrennte Indizes in den Klammern zugegriffen werden.

Jagged Arrays haben unterschiedliche viele Spalten in den Zeilen. Das Bedeutet in jedem Element des Arrays ist ein weiteres Array, welches eine andere Länge als das „Haupt&quot;-Array hat. Bei einem Jagged Array Kann bei der Initialisierung nur die Länge des Hauptarrays festgelegt werden. Alle Arrays in diesem Array müssen extra deklariert werden. Um ein Jagged Array zu definieren werden die geöffneten und geschlossenen eckigen Klammern zwei Mal hintereinandergeschrieben. Für den Zugriff muss in jede der Klammern der Index geschrieben werden.

```C#
int[,] multidimensionalArray = newint[10, 5];
multidimensionalArray[0, 1] = 3;

int[][] jaggedArray = newint[10][];
jaggedArray[0] = newint[5];
jaggedArray[0][1] = 3;
```

## 2.3. Arrays in moderner Programmierung

Wie bereits Angesprochen kann die Länge eines Arrays in der Regel nicht geändert werden. Wenn man nun also einen Wert hinzufügen oder entfernen möchte müsste man ein neues Array erstellen und alle übrigen Werte in dieses Kopieren. Ein ähnliches Problem hat man beim Sortieren von Arrays, da beim Einfügen / nach vorne Sortieren alle hinteren Elemente einzeln Aufgerückt werden müssen. Dies verursacht, besonders bei langen Arrays, enorme Performanceprobleme. Aus diesem Grund werden Heutzutage in vielen Anwendungsfällen eher Listen als Arrays verwendet. Eine Liste kann ohne Probleme erweitert und Sortiert werden, da weder die Anzahl der Elemente noch deren Reinfolge fix definiert werden.

# 3. Quellcode Dokumentation

Im Folgenden wird der Quellcode und die Funktionsweise des Beispielprogramms ‚Tic Tac Toe&#39; dokumentiert. Die Spielregeln des Spiels werden dabei als bekannt vorausgesetzt. Tastenkombinationen werden: Pfeiltasten / WASD für Cursor Navigation, Enter / Leertaste für bestätigen, F5 für ein neues Spiel und Escape zum Beenden.

## 3.1. Klassenübersicht
![](./2017-02-26%2021_20_17-TickTackToe%20-%20Microsoft%20Visual%20Studio.png)

*Abbildung 2: Übersicht über die Ressourcen. (Für genauere Details siehe Docs auf github)*
### 3.1.1. Main

Die Main Klasse stellt den Einstiegspunkt der Anwendung da. Sie beinhaltet die _Main( __string__ [] args)_ Methode, welche die Hauptroutine des Programmes ist. Zusätzlich wird in dieser Klasse das Userinterface ausgegeben und der Input an die Spiellogik weitergegeben.

### 3.1.2. Game

Die Game Klasse beinhaltet alle Logik, welche für das Spiel relevant ist. Es findet keine Ausgabe an den User stat. Dies ist Aufgabe der Main Klasse. Dadurch ist Trennung von Interface und Logik gegeben.

## 3.2. Spiellogik (Game Klasse)
### 3.2.1. Properties

Als Grundlage für die Logik des Spiels sind mehrere Eigenschaften deklariert. Das Spielfeld ist durch ein Zweidimensionales Array abgebildet, da sowohl jede Spalte als auch jede Zeile drei Felder hat. Als Datentyp ist ein Nullable&lt;bool&gt; gesetzt. Dies erlaubt sowohl false (Player 1), true (Player 2) als auch null was einem noch nicht Besetzten Spielfeld entspricht. Da der Standardwert null ist wird das Spielfeld automatisch leer erstellt.

Zusätzlich wird ein Array mit den Symbolen für die verschiedenen Spieler angelegt. Dieses Array hat an Position 0 und 1 die Symbole für den ersten und zweiten Spieler und an Position 2 das Symbol für ein freies Feld. Diese Belegung erlaubt es das Spielersymbol durch einen Booleschen Wert, wie er auch im Spielfeld abgelegt wird, und Position 2 als extra Element abzufragen.

Der Cursor beschreibt die Position im Spielfeld, welche momentan ausgewählt ist. Da es die X und Y Koordinaten angibt, kann dies in einem Array der Länge 2 Abgebildet werden und Standardmäßig auf die Position 0/0 gesetzt werden.

Für die Ermittlung des Gewinners wird zum einen der Gewinner (soweit es einen gibt), ob das Spiel noch läuft und mit welchen Kombinationen gewonnen werden kann, gespeichert.

Zum Abschluss wird noch der momentan Aktive Spieler gespeichert und Standardmäßig auf den Spieler 1 gesetzt.

```C#
publicchar[] playerSymbols { get; } = { 'X', 'O', ' ' };

publicbool?[,] field { get; privateset; } = newbool?[3, 3];
publicint[] cursor { get; privateset; } = { 0, 0 };

publicbool currentPlayer = false;
publicbool? winner { get; privateset; } = null;
publicbool isGameRunning { get; privateset; } = true;

publicint[][] winnables =
{
    /\* SPOILER: Possible combinations \*/
};
```

### 3.2.2. Methoden

Da Alle Properties nicht von außen gesetzt werden können um Logik von Interface zu trennen müssen alle Änderungen durch die öffentlichen () Methoden vorgenommen werden. Jede Eigenschaft hat jedoch einen öffentlichen Getter1 welcher das Betrachten des momentanen Spielstandes erlaubt.

#### 3.2.2.1. Platzieren von Spielsteinen

Zum Platzieren eines Spielsteines muss der Spieler den Cursor auf das gewünschte Feld navigieren und dann das Setzen seines Spielsteins bestätigen. Dafür gibt es zwei Methoden, die genau diese Funktionen abbilden.

Zum Navigieren mit dem Cursor (WASD oder Pfeiltasten) wird die Methode _MoveCursor(__int_ _x,_ _int_ _y)_ mit der Änderung in X und Y Position aufgerufen. In der Methode wird zuerst überprüft, ob die neue Position noch im Spielfeld liegt. Nur wenn dies Zutrifft wird die Position auch geändert.

Da durch die Methode zum Navigieren bereits sichergestellt wurde, dass die Cursor Position gültig ist braucht nun in der Methode zum Setzen des Spielsteins nur noch überprüft werden, ob an der gegebenen Position schon ein Spielstein ist. Nur wenn dort noch kein Stein platziert wurde wird der Wert im Spielfeld geändert.

```C#
// Check if values are in bound
if (x &lt; -1 || x &gt; 1 || y &lt; -1 || y &gt; 1) return;
if (cursor[0] + x &lt; 0 || cursor[0] + x &gt; 2) return;
if (cursor[1] + y &lt; 0 || cursor[1] + y &gt; 2) return;

// Set cursor position
cursor[0] += x;
cursor[1] += y;
```

#### 3.2.2.2. Gewinnprüfung

Bei der Überprüfung ob ein Spieler gewonnen hat gibt es mehrere mögliche Ansätze. Da sich die Anzahl der möglichen Kombinationen, die zu einem Gewinn führen jedoch in Grenzen halten (3 Vertikal, 3 Horizontal und 2 Diagonal) werden diese Kombinationen einfach in einem Jagged Array abgelegt. Zum Überprüfen ob ein Gewinner vorliegt muss jetzt einfach für jede dieser Gewinnkombinationen überprüft werden, ob alle drei Felder in der Kombination von demselben Spieler besetzt wurden. Ist dies der Fall, so hat dieser Spieler gewonnen.

##### 3.2.2.2.1. Edgecases2

Bei der Überprüfung auf das Gewinnen kommt es zu einem Edgecase. Denn es gibt nicht nur die Möglichkeit, dass Spieler 1 oder Spieler 2 gewinnen, sondern auch das des zu einem Unentschieden kommt.

Da allerdings der null Wert für den Zustand das noch keiner der Spieler gewonnen hat definiert wurde kann dies nicht der Rückgabewert für ein Unentschieden sein. Nach unserer Logik würde dieses Spiel also nie enden, da es keinen Gewinner geben kann.

Die Lösung für dieses Problem ist die Einführung eines weiteren Booleschen wertes, welcher angibt, ob das Spiel bereits beendet wurde. Wenn nun also auf die Gewinnbedingungen überprüft wird, wird als Gewinner immer noch null zurückgegeben, aber zusätzlich der Flag3 für das Spielende, wenn das Spielfeld voll ist.

```C#
// Finish game when all fields are occupied
if (!field.Cast&lt;bool?&gt;().Any(v =&gt; !v.HasValue)) { this.isGameRunning = false; }
```

### 3.2.3. Anzeige / User Interface (Main Klasse)

Die Hauptaufgabe der Main Klasse ist die Anzeige der Benutzeroberfläche und das Verarbeiten von Benutzereingaben. Dafür existiert ein Updateloop4, welcher sowohl für das neu zeichnen des Interfaces als auch das Erkennen von Eingaben zuständig ist. Um ein flackern oder mehrfacheingaben zu Verhindern wird zusätzlich eine kurze Zeitverzögerung eingebaut.

#### 3.2.3.1. Benutzeroberfläche

Die Benutzeroberfläche liegt in zwei zuständen vor. Dem Spielfeld und wenn das Spiel beendet ist dem End-Bildschirm.

 ![](./2017-02-26%2021_05_53-Tic.png)
 
 *Abbildung 3: Spielfeld mit einigen Spielsteinen schon gesetzt.*

Im Spielfeld Modus wird in der ersten Zeile der momentan aktive Spieler angezeigt. Darunter ist das Spielfeld zu finden. Um das Spielfeld zu zeichnen wird zuerst über die Erste Dimension des Spielfeld Arrays iteriert5. Dabei wird jeweils eine neue Zeile in der Konsole erstellt und dann für jedes dieser Elemente über die zweite Dimension iteriert. So kann für jedes Feld ein Kästchen (Dargestellt durch eckige Klammern) mit dem Spielstein, soweit einer platziert ist, ausgegeben werden.

Wenn die Position des Kästchens der Position des Cursors entspricht, so wird das Kästchen und der Spielstein farbig dargestellt.

 ![](./2017-02-26%2021_04_25-Toe.png)

Abbildung 5: Fehlermeldung, wenn schon ein Stein platziert ist.

- RICHTUNGSTASTEN oder WASD oder NUMBLOCK (2486): Die Cursor-beweg Funktion der Game Klasse wird aufgerufen.
- F5: Startet ein neues Spiel indem eine neue Instanz6 der Game Klasse erzeugt wird.
- ESCAPE: Schließt die Anwendung

![](./2017-02-26%2021_05_28-.png)

*Abbildung 5: Fehlermeldung, wenn schon ein Stein platziert ist.*

Das Spiel an sich gib also keine „befehle&quot; an die Oberfläche. Alle Änderungen an der Oberfläche werden durch Änderungen am Status des Spiels hervorgerufen.

# 4. Fazit

Zusammenfassend lässt sich sagen, dass für Listen mit statischer Größe ein Array eine einfache und effiziente Möglichkeit der Abbildung im Programm ist.

Sobald das Programm jedoch in Komplexität steigt und weitere Anforderungen an die Liste hinzukommen sollte zu einem Dynamischeren Datentyp gegriffen werden, der das Hinzufügen von Elementen an beliebigen Indizes erlaubt. Nur so kann man eine Performante Umgebung schaffen, welche sich gut skalieren lässt. Selbst bei großen Datenmengen wird die Liste somit nicht zum „Schwachpunkt des Programmes&quot;. In dem Verwendeten Beispiel hat das noch ganz gut funktioniert, wäre aber mit einer List deutlich einfacher umzusetzen gewesen.

# 5. Weitere Dokumentation und Quellcode

Der verwendete Quellcode und eine Dokumentation können auf meiner GitHub Seite unter folgender URL eingesehen werden:

GitHub: [https://github.com/Xenira/school-tic-tac-toe](https://github.com/Xenira/school-tic-tac-toe)
Dokumentation: [https://xenira.github.io/school-tic-tac-toe/Docu/html/annotated.html](https://xenira.github.io/school-tic-tac-toe/Docu/html/annotated.html)

# 6. Lizenz

Sowohl diese Ausarbeitung als auch der Sourcecode stehen unter der MIT Lizenz. Der volle Lizenztext befindet sich im GitHub unter folgender Adresse: [https://github.com/Xenira/school-tic-tac-toe/blob/master/LICENSE](https://github.com/Xenira/school-tic-tac-toe/blob/master/LICENSE)

# 7. Literaturverzeichnis

chakrit. (11. April 2009). _c# - Checking for winner in TicTacToe? - Stack Overflow_. Von Stack Overflow: http://stackoverflow.com/questions/740467/checking-for-winner-in-tictactoe#740473 abgerufen

Daddy, P. (11. July 2009). _c# - Arrays, heap and stack and value types - Stack Overflow_. Von Stack Overflow: http://stackoverflow.com/questions/1113819/arrays-heap-and-stack-and-value-types abgerufen

Doxygen. (29. Dezember 2016). _Doxygen: Main Page_. Von Doxygen: http://www.stack.nl/~dimitri/doxygen/ abgerufen

Louis, D. (2015). Easy C++. In D. Louis, _Easy C++_ (S. 216). 219: Markt + Technik Verlag.

patorjk.com. (kein Datum). _Text to ASCII Art Generator (TAAG)_. Von Text to ASCII Art Generator: http://www.patorjk.com/software/taag/ abgerufen

**Anmerkung:** Durch jahrelange Arbeit mit und im Internet kann es dazu gekommen sein, dass meine Meinungen und Ansichten durch den dort zu findenden Inhalt beeinflusst sein worden könnten, was zu ähnlichen Formulierungen (Zumeist aus dem Englischen übernommen) oder Ausdrucksweisen geführt haben kann. Jegliche Referenzen außerhalb dieses Literaturverzeichnisses wurden nicht während der Erarbeitung dieser Ausarbeitung in Betracht gezogen und können unmöglich hier wiedergegeben werden, da dieser Teil meiner Bildung waren und nicht dokumentiert wurde und nicht ohne weiteres dokumentiert werden kann.
