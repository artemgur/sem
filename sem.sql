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
--We will search in both directions
CREATE INDEX tags_article_index ON tags(article_id);
CREATE INDEX tags_tag_index ON tags(tag);

CREATE TABLE debates( --debates header can be treated as a comment
    id SERIAL PRIMARY KEY,
    name VARCHAR(30) NOT NULL,
    text TEXT,
    date TIMESTAMP
);

CREATE TABLE debates_users(
    user_id INTEGER,
    debate_id INTEGER,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (debate_id) REFERENCES debates(id) ON DELETE CASCADE
);
CREATE INDEX debates_users_user_index ON debates_users(debate_id);

CREATE TABLE comments(
    user_id INTEGER,
    debate_id INTEGER,
    date TIMESTAMP,
    opinion BOOLEAN,--comment for or against
    text TEXT,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (debate_id) REFERENCES debates(id) ON DELETE CASCADE
);
CREATE INDEX comments_debate_id_index ON comments(debate_id);

CREATE TABLE favourite_articles(
    user_id INTEGER,
    article_id INTEGER,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (article_id) REFERENCES article(id) ON DELETE CASCADE
);
CREATE INDEX favourite_articles_user_index ON favourite_articles(user_id);
