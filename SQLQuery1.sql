INSERT INTO [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
VALUES
(NEWID(), 'Admin', 'ADMIN', NEWID()),
(NEWID(), 'Organizer', 'ORGANIZER', NEWID()),
(NEWID(), 'User', 'USER', NEWID());

-- 3. Fut Përdoruesit
DECLARE @adminId NVARCHAR(450) = NEWID();
DECLARE @organizerId NVARCHAR(450) = NEWID();
DECLARE @userId NVARCHAR(450) = NEWID();

INSERT INTO [AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], 
[PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], 
[LockoutEnd], [LockoutEnabled], [AccessFailedCount])
VALUES
(@adminId, 'admin@example.com', 'ADMIN@EXAMPLE.COM', 'admin@example.com', 'ADMIN@EXAMPLE.COM', 1,
'AQAAAAIAAYagAAAAEEz0Z4hZ8F0F0B2JY5J7K6Y9Z8X7V2W3U4V5B6N7M8O9P0Q1R2S3T4U5V6W7X8', 
NEWID(), NEWID(), '+355691234567', 1, 0, NULL, 1, 0),

(@organizerId, 'organizer@example.com', 'ORGANIZER@EXAMPLE.COM', 'organizer@example.com', 'ORGANIZER@EXAMPLE.COM', 1,
'AQAAAAIAAYagAAAAEEz0Z4hZ8F0F0B2JY5J7K6Y9Z8X7V2W3U4V5B6N7M8O9P0Q1R2S3T4U5V6W7X8', 
NEWID(), NEWID(), '+355692345678', 1, 0, NULL, 1, 0),

(@userId, 'user@example.com', 'USER@EXAMPLE.COM', 'user@example.com', 'USER@EXAMPLE.COM', 1,
'AQAAAAIAAYagAAAAEEz0Z4hZ8F0F0B2JY5J7K6Y9Z8X7V2W3U4V5B6N7M8O9P0Q1R2S3T4U5V6W7X8', 
NEWID(), NEWID(), '+355693456789', 1, 0, NULL, 1, 0);

-- 4. Cakto Rolet për Përdoruesit
INSERT INTO [AspNetUserRoles] ([UserId], [RoleId])
SELECT u.Id, r.Id 
FROM [AspNetUsers] u
CROSS JOIN [AspNetRoles] r
WHERE (u.UserName = 'admin@example.com' AND r.Name = 'Admin')
   OR (u.UserName = 'organizer@example.com' AND r.Name = 'Organizer')
   OR (u.UserName = 'user@example.com' AND r.Name = 'User');

-- 5. Fut Lokacionet
INSERT INTO [Locations] ([City], [Address], [Country])
VALUES
('Tirana', 'Bulevardi Dëshmorët e Kombit', 'Albania'),
('Durrës', 'Sheshi Liria', 'Albania'),
('Vlorë', 'Sheshi Flamurit', 'Albania');

-- 6. Fut Kategoritë e Eventeve
INSERT INTO [EventCategories] ([Name], [Description])
VALUES
('Konferenca', 'Evente profesionale dhe edukative'),
('Koncert', 'Performanca muzikore live'),
('Sport', 'Evente sportive dhe garash'),
('Kulturë', 'Evente kulturore dhe artistike'),
('Festival', 'Festivale të ndryshme');

-- 7. Fut Eventet
DECLARE @tiranaId INT = (SELECT TOP 1 Id FROM [Locations] WHERE City = 'Tirana');
DECLARE @durresId INT = (SELECT TOP 1 Id FROM [Locations] WHERE City = 'Durrës');
DECLARE @konferencaId INT = (SELECT TOP 1 Id FROM [EventCategories] WHERE Name = 'Konferenca');
DECLARE @koncertId INT = (SELECT TOP 1 Id FROM [EventCategories] WHERE Name = 'Koncert');

INSERT INTO [Events] ([Name], [Description], [StartDate], [EndDate], [LocationId], [CategoryId], [Capacity], [IsActive])
VALUES
('Konferenca e Teknologjisë', 'Konferencë mbi teknologjitë e fundit', 
 DATEADD(DAY, 10, GETDATE()), DATEADD(DAY, 11, GETDATE()), @tiranaId, @konferencaId, 200, 1),

('Koncert i Muzikës Popullore', 'Koncert me artistë të njohur të muzikës popullore', 
 DATEADD(DAY, 15, GETDATE()), DATEADD(DAY, 15, GETDATE()), @durresId, @koncertId, 5000, 1);

-- 8. Fut Etiketat e Eventeve
INSERT INTO [EventTags] ([Name])
VALUES
('Teknologji'),
('Muzikë'),
('Sport'),
('Art'),
('Edukim');

-- 9. Fut FAQ
INSERT INTO [FAQs] ([Question], [Answer])
VALUES
('Si mund të blej një biletë?', 'Mund të blini biletë direkt në faqen e eventit ose në pikën e shitjes.'),
('A mund të anuloj një blerje?', 'Politika e anulimit varet nga organizatori i eventit.');

-- 10. Fut Profile Organizatori
INSERT INTO [OrganizerProfiles] ([UserId], [OrganizationName], [Bio], [Website])
VALUES
(@organizerId, 'Organizata Jonë', 'Organizator i eventeve me eksperiencë', 'https://organizatajone.com');