INSERT INTO Muzyk
VALUES ('Jan', 'Kowalski', 'Janko muzykant');

SELECT *
FROM Muzyk

INSERT INTO Wytwornia
VALUES ('Universal Polska')

SELECT *
FROM Wytwornia

INSERT INTO Album
VALUES ('Friz i ekipa', '2022-12-12', 1)

SELECT *
FROM Album

INSERT INTO Utwor
VALUES ('Przejmujemy Jutuby', 1, 1);

INSERT INTO Utwor (NazwaUtworu, CzasTrwania)
VALUES ('Przejmujemy Jutuby 2', 5.34);

SELECT *
FROM Utwor

INSERT INTO WykonawcaUtworu
VALUES (1, 1)

SELECT *
FROM WykonawcaUtworu