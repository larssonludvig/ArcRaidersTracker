CREATE TABLE Quests (
    Id BIGINT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Description TEXT
);

CREATE TABLE QuestItemObjectives (
    QuestId BIGINT UNSIGNED NOT NULL,
    ItemId BIGINT UNSIGNED NOT NULL,
    Count INT UNSIGNED NOT NULL DEFAULT 1,
    PRIMARY KEY (QuestId, ItemId),
    FOREIGN KEY (QuestId) REFERENCES Quests(Id),
    FOREIGN KEY (ItemId) REFERENCES Items(Id)
);

CREATE TABLE QuestObjectives (
    Id BIGINT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    QuestId BIGINT UNSIGNED NOT NULL,
    MapId BIGINT UNSIGNED,
    Description TEXT,
    FOREIGN KEY (QuestId) REFERENCES Quests(Id),
    FOREIGN KEY (MapId) REFERENCES Maps(Id)
);
