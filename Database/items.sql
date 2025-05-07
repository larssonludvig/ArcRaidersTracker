-- Default table for general information
CREATE TABLE Items (
    id BIGINT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    description TEXT,
    recyclable BOOLEAN NOT NULL DEFAULT FALSE,
    sellable BOOLEAN NOT NULL DEFAULT FALSE,
    sell_price INT UNSIGNED NOT NULL DEFAULT 0,
    repairable BOOLEAN NOT NULL DEFAULT FALSE,
    repair_cost INT UNSIGNED NOT NULL DEFAULT 0,
    stack_size INT UNSIGNED NOT NULL DEFAULT 1,
    CHECK (stack_size > 0)
);

-- Recycle relation
CREATE TABLE Recyclables (
    consume_id BIGINT UNSIGNED NOT NULL,
    receive_id BIGINT UNSIGNED NOT NULL,
    count INT UNSIGNED NOT NULL,
    PRIMARY KEY (consume_id, receive_id),
    FOREIGN KEY (consume_id) REFERENCES Items(id),
    FOREIGN KEY (receive_id) REFERENCES Items(id),
    CHECK (count > 0)
);

-- Equipment table
CREATE TABLE Equipment (
    item_id BIGINT UNSIGNED NOT NULL PRIMARY KEY,
    shield INT UNSIGNED NOT NULL DEFAULT 0,
    FOREIGN KEY (item_id) REFERENCES Items(id),
);

-- Weapons table
CREATE TABLE Weapons (
    item_id BIGINT UNSIGNED NOT NULL PRIMARY KEY,
    damage INT UNSIGNED NOT NULL DEFAULT 0,
    fire_rate INT UNSIGNED NOT NULL DEFAULT 0,
    magazine_size INT UNSIGNED NOT NULL DEFAULT 1,
    hs_multiplier FLOAT NOT NULL DEFAULT 1,
    FOREIGN KEY (item_id) REFERENCES Items(id),
    CHECK (magazine_size > 0),
    CHECK (hs_multiplier >= 1)
);

-- Gadgets table
CREATE TABLE Gadgets (
    item_id BIGINT UNSIGNED NOT NULL PRIMARY KEY,
    FOREIGN KEY (item_id) REFERENCES Items(id)
);
