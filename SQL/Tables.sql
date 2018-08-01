
CREATE TABLE Album(
	AlbumID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Title nvarchar(128),
	Artist nvarchar(128)
);

CREATE TABLE Genres(
	ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Genre nvarchar(128)
);
ALTER TABLE Genres
Add AlbumID int;

ALTER TABLE Genres
ADD CONSTRAINT FK_Genres_Album FOREIGN KEY (AlbumID)
REFERENCES Album (AlbumID)
ON UPDATE CASCADE
ON DELETE CASCADE;

CREATE TABLE Styles(
	ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Style varchar(128)
);
ALTER TABLE Styles
Add AlbumID int;

ALTER TABLE Styles
ADD CONSTRAINT FK_Styles_Album FOREIGN KEY (AlbumID)
REFERENCES Album (AlbumID)
ON UPDATE CASCADE
ON DELETE CASCADE;

CREATE TABLE TrackList(
	ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Position nvarchar(32),
	Duration nvarchar(32),
	Title nvarchar(128)
);
ALTER TABLE TrackList
Add AlbumID int;

ALTER TABLE TrackList
ADD CONSTRAINT FK_TrackList_Album FOREIGN KEY (AlbumID)
REFERENCES Album (AlbumID)
ON UPDATE CASCADE
ON DELETE CASCADE;

CREATE TABLE Videos(
	ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Video nvarchar(1024)
);
ALTER TABLE Videos
Add AlbumID int;

ALTER TABLE Videos
ADD CONSTRAINT FK_Videos_Album FOREIGN KEY (AlbumID)
REFERENCES Album (AlbumID)
ON UPDATE CASCADE
ON DELETE CASCADE;

CREATE TABLE Images(
	ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Image nvarchar(1024)
);
ALTER TABLE Images
Add AlbumID int;

ALTER TABLE Images
ADD CONSTRAINT FK_Images_Album FOREIGN KEY (AlbumID)
REFERENCES Album (AlbumID)
ON UPDATE CASCADE
ON DELETE CASCADE;

CREATE TABLE ExtraArtists(
	ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name nvarchar(128),
	Role nvarchar(128),
	Title nvarchar(128)
);
ALTER TABLE ExtraArtists
Add AlbumID int;

ALTER TABLE ExtraArtists
ADD CONSTRAINT FK_ExtraArtists_Album FOREIGN KEY (AlbumID)
REFERENCES Album (AlbumID)
ON UPDATE CASCADE
ON DELETE CASCADE;