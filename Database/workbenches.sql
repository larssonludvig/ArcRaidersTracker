CREATE TABLE Workbenches (
    Id BIGINT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Tier INT UNSIGNED NOT NULL DEFAULT 1
);

CREATE TABLE WorkbenchCosts (
    WorkbenchId BIGINT UNSIGNED NOT NULL,
    ItemId BIGINT UNSIGNED NOT NULL,
    Count INT UNSIGNED NOT NULL DEFAULT 1,
    PRIMARY KEY (WorkbenchId, ItemId),
    FOREIGN KEY (WorkbenchId) REFERENCES Workbenches(Id),
    FOREIGN KEY (ItemId) REFERENCES Items(Id)
);

-- Add source of recipe? Could be quest, lootable or any other source
CREATE TABLE WorkbenchRecipes (
    Id BIGINT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    ItemId BIGINT UNSIGNED NOT NULL,
    Count INT UNSIGNED NOT NULL DEFAULT 1,
    FOREIGN KEY (ItemId) REFERENCES Items(Id)
);

CREATE TABLE WorkbenchRecipeCosts (
    WorkbenchRecipeId BIGINT UNSIGNED NOT NULL,
    ItemId BIGINT UNSIGNED NOT NULL,
    Count INT UNSIGNED NOT NULL DEFAULT 1,
    PRIMARY KEY (WorkbenchRecipeId, ItemId),
    FOREIGN KEY (WorkbenchRecipeId) REFERENCES WorkbenchRecipes(Id),
    FOREIGN KEY (ItemId) REFERENCES Items(Id)
);
