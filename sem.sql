--plans: add indexes
CREATE TYPE TAG AS ENUM ('США', 'Китай', 'Россия', 'Украина', 'Северная Корея');--TODO add more

CREATE TABLE users(
    id SERIAL PRIMARY KEY,
    login VARCHAR(20) NOT NULL UNIQUE,--store hash instead of actual value?
    password VARCHAR(40) NOT NULL, --store hash instead of actual value?
    email TEXT NOT NULL UNIQUE
);

CREATE TABLE article(
    id SERIAL PRIMARY KEY,
    name VARCHAR(30) NOT NULL, --TODO should be unique?
    date TIMESTAMP,
    text TEXT NOT NULL--path to markdown file, not text itself
);

CREATE TABLE tags(
    article_id INTEGER NOT NULL,
    tag TAG NOT NULL,
    FOREIGN KEY (article_id) REFERENCES article(id) ON DELETE CASCADE
);

CREATE TABLE debates( --debates header can be treated as a comment
    id SERIAL PRIMARY KEY,
    name VARCHAR(30) NOT NULL,
    date TIMESTAMP
);

CREATE TABLE debates_users(
    user_id INTEGER,
    debate_id INTEGER,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (debate_id) REFERENCES debates(id) ON DELETE CASCADE
);

CREATE TABLE comments(
    user_id INTEGER,
    debate_id INTEGER,
    date TIMESTAMP,
    opinion BOOLEAN,--comment for or against
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (debate_id) REFERENCES debates(id) ON DELETE CASCADE
)
