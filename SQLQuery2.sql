INSERT INTO EventCategories (Name, Id)
VALUES 

(1003,	'Konferenca'),
(1004,	'Koncert'),
(1005,	'Sport'),
(1006,	'Kulturë'),
(1007,	'Festival');

-- Fut të dhëna demonstrative në tabelën Locations
INSERT INTO Locations (Id, VenueName,Address, City, Country)
VALUES 
(1004,'Pallati i Kongreseve', 'Bulevardi Dëshmorët e Kombit', 'Tirana', 'Shqipëri'),
(1005,'Fusha e Gjelbër', 'Rruga e Elbasanit', 'Durrës', 'Shqipëri'),
(1006,'Teatri Kombëtar', 'Sheshi Skënderbej', 'Tirana', 'Shqipëri'),
(1007,'Hotel Adriatik', 'Rruga e Jonit', 'Vlorë', 'Shqipëri'),
(1008,'Universiteti i Tiranës', 'Bulevardi Zogu I', 'Tirana', 'Shqipëri');

-- Fut të dhëna demonstrative në tabelën EventTags
INSERT INTO EventTags (Name)
VALUES 
('Pop'),
('Folk'),
('Futboll'),
('Workshop'),
('Konferencë'),
('Pikturë'),
('Ushqim Tradicional');

-- Fut të dhëna demonstrative në tabelën Events
INSERT INTO Events (Name, StartDate, EndDate, Time, Capacity, CategoryId, Description, LocationID, IsActive)
VALUES
('Festivali i Këngës', '2023-12-20', '2023-12-22', '20:00', 5000, 1007, 'Festivali kombëtar i këngës', 1, 1),
('Konferenca e Teknologjisë', '2023-11-15', '2023-11-16', '09:00', 300, 1003, 'Konferencë për teknologjitë e fundit', 5, 1),
('Turniri i Futbollit', '2023-10-10', '2023-10-12', '16:00', 10000, 1005, 'Turniri kombëtar i futbollit', 2, 1),
('Ekspozita e Arteve', '2023-09-01', '2023-09-30', '10:00', 200, 1006, 'Ekspozitë e artit bashkëkohor', 3, 1),
('Workshop i Gatimit', '2023-08-25', '2023-08-25', '18:00', 50, 1007, 'Workshop me kuzhinierë të famshëm', 4, 1);

-- Fut të dhëna demonstrative në tabelën FAQ
INSERT INTO FAQs(Question, Answer)
VALUES
('Si mund të blej biletë?', 'Biletat mund të blihen online në faqen tonë zyrtare.'),
('A ka parking në vendndodhje?', 'Po, të gjitha vendndodhjet tona ofrojnë parking falas.'),
('A mund të anulohet një biletë?', 'Anulimet janë të mundshme deri 7 ditë para eventit.'),
('Cili është koha e fillimit të eventit?', 'Koha e saktë e fillimit shfaqet në faqen e eventit.'),
('A ka ulje për studentë?', 'Po, studentët marrin 20% zbritje me kartën e studentit.');


