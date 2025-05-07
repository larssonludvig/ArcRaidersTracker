-- Default table for general information
CREATE TABLE Items (
    Id BIGINT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    Recyclable BOOLEAN NOT NULL DEFAULT FALSE,
    Sellable BOOLEAN NOT NULL DEFAULT FALSE,
    SellPrice INT UNSIGNED NOT NULL DEFAULT 0,
    Repairable BOOLEAN NOT NULL DEFAULT FALSE,
    RepairCost INT UNSIGNED NOT NULL DEFAULT 0,
    StackSize INT UNSIGNED NOT NULL DEFAULT 1,
    CHECK (StackSize > 0)
);

-- Recycle relation
CREATE TABLE Recyclables (
    ConsumeId BIGINT UNSIGNED NOT NULL,
    ReceiveId BIGINT UNSIGNED NOT NULL,
    Count INT UNSIGNED NOT NULL,
    PRIMARY KEY (ConsumeId, ReceiveId),
    FOREIGN KEY (ConsumeId) REFERENCES Items(Id),
    FOREIGN KEY (ReceiveId) REFERENCES Items(Id),
    CHECK (count > 0)
);

-- Equipment table
CREATE TABLE Equipment (
    ItemId BIGINT UNSIGNED NOT NULL PRIMARY KEY,
    Shield INT UNSIGNED NOT NULL DEFAULT 0,
    FOREIGN KEY (ItemId) REFERENCES Items(Id),
);

-- Weapons table
CREATE TABLE Weapons (
    IitemId BIGINT UNSIGNED NOT NULL PRIMARY KEY,
    Damage INT UNSIGNED NOT NULL DEFAULT 0,
    FireRate INT UNSIGNED NOT NULL DEFAULT 0,
    MagazineSize INT UNSIGNED NOT NULL DEFAULT 1,
    HSMultiplier FLOAT NOT NULL DEFAULT 1,
    FOREIGN KEY (ItemId) REFERENCES Items(Id),
    CHECK (MagazineSize > 0),
    CHECK (HSMultiplier >= 1)
);

-- Gadgets table
CREATE TABLE Gadgets (
    ItemId BIGINT UNSIGNED NOT NULL PRIMARY KEY,
    FOREIGN KEY (ItemId) REFERENCES Items(Id)
);
