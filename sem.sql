CREATE TYPE TAG AS ENUM ('США', 'Китай', 'Россия', 'Украина', 'Северная Корея', 'Япония', 'Беларусь', 'ООН', 'ЕС', 'Сирия', 'Турция', 'Тайвань');--TODO add more

CREATE TABLE users(
    id SERIAL PRIMARY KEY,
    username VARCHAR(20) NOT NULL UNIQUE,--store hash instead of actual value?
    password VARCHAR(44) NOT NULL, --length???
    salt VARCHAR(24) NOT NULL --length???
--     email TEXT NOT NULL UNIQUE,
--     photo TEXT --path to photo
);

CREATE TABLE articles(
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    date TIMESTAMP NOT NULL,
    --description VARCHAR(35),
    text TEXT NOT NULL
);
-- CREATE INDEX articles_time_index ON articles(date DESC); --Apparently indexes will make queries slower, since our tables will be small
--TODO create index for name

CREATE TABLE tags_article(
    article_id INTEGER NOT NULL,
    tag TAG NOT NULL,
    FOREIGN KEY (article_id) REFERENCES articles(id) ON DELETE CASCADE
);
--We will search in both directions
-- CREATE INDEX tags_articles_index ON tags_article(article_id);
-- CREATE INDEX tags_tag_index ON tags_article(tag);

CREATE TABLE debates( --debates header can be treated as a comment
    id SERIAL PRIMARY KEY,
    name VARCHAR(30) NOT NULL,
    text TEXT,
    date TIMESTAMP NOT NULL
);

CREATE TABLE debates_users(
    user_id INTEGER,
    debate_id INTEGER,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (debate_id) REFERENCES debates(id) ON DELETE CASCADE
);
-- CREATE INDEX debates_users_user_index ON debates_users(debate_id);

CREATE TABLE comments(
    user_id INTEGER,
    debate_id INTEGER,
    date TIMESTAMP NOT NULL,
    opinion BOOLEAN NOT NULL,--comment for or against
    text TEXT,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (debate_id) REFERENCES debates(id) ON DELETE CASCADE
);
-- CREATE INDEX comments_debate_id_index ON comments(debate_id);

CREATE TABLE favorite_articles(
    user_id INTEGER,
    article_id INTEGER,
    FOREIGN KEY (user_id) REFERENCES users(id) ON DELETE CASCADE,
    FOREIGN KEY (article_id) REFERENCES articles(id) ON DELETE CASCADE
);
-- CREATE INDEX favourite_articles_user_index ON favourite_articles(user_id);

CREATE TABLE people(
    id SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    post VARCHAR(30) NOT NULL,
    age SMALLINT NOT NULL,
    country VARCHAR(30) NOT NULL,
    text TEXT
--     photo TEXT --path to photo
);
CREATE TABLE tags_people(
    people_id INTEGER,
    tag TAG NOT NULL,
    FOREIGN KEY (people_id) REFERENCES people(id) ON DELETE CASCADE
);

CREATE TABLE tags_debates(
    debate_id INTEGER,
    tag TAG NOT NULL,
    FOREIGN KEY (debate_id) REFERENCES debates(id) ON DELETE CASCADE
);

-- CREATE INDEX tags_people_index ON tags_people(people_id);
-- CREATE INDEX tags_people_tag_index ON tags_people(tag);

CREATE /*MATERIALIZED*/ VIEW articles_with_tags AS
    WITH a AS(
        SELECT id, name, date, text, array_agg(tags_article.tag) AS tags
        FROM tags_article
        JOIN articles ON articles.id = tags_article.article_id
        GROUP BY id
    )
    SELECT * FROM a
    ORDER BY date DESC;

CREATE /*MATERIALIZED*/ VIEW people_with_tags AS
    WITH a AS(
        SELECT id, name, post, age, country, text, array_agg(tags_people.tag) AS tags
        FROM tags_people
        JOIN people ON people.id = tags_people.people_id
        GROUP BY id
    )
    SELECT * FROM a
    ORDER BY name;

CREATE /*MATERIALIZED*/ VIEW debates_with_tags AS
    WITH a AS(
        SELECT id, name, text, date, array_agg(tags_debates.tag) AS tags
        FROM tags_debates
        JOIN debates ON debates.id = tags_debates.debate_id
        GROUP BY id
    )
    SELECT * FROM a
    ORDER BY name;

CREATE FUNCTION select_articles_by_name_and_tag(a VARCHAR(30), b TAG)
RETURNS TABLE (id INTEGER, name TEXT, date TIMESTAMP, text TEXT, tags TAG[]) AS $$
    SELECT id, name, date, text, tags FROM articles_with_tags
    JOIN tags_article ON article_id = id AND tag = b AND name LIKE a;
$$ LANGUAGE sql;

CREATE FUNCTION select_people_by_name_and_tag(a VARCHAR(30), b TAG)
RETURNS TABLE (id INTEGER, name VARCHAR(30), post VARCHAR(30), age SMALLINT, country VARCHAR(30), text TEXT, tags TAG[]) AS $$
    SELECT id, name, post, age, country, text, tags FROM people_with_tags
    JOIN tags_people ON people_id = id AND tag = b AND name LIKE a;
$$ LANGUAGE sql;

CREATE FUNCTION select_debates_by_name_and_tag(a VARCHAR(30), b TAG)
RETURNS TABLE (id INTEGER, name VARCHAR(30), text TEXT, date TIMESTAMP, tags TAG[]) AS $$
    SELECT id, name, text, date, tags FROM debates_with_tags
    JOIN tags_debates ON debate_id = id AND tag = b AND name LIKE a;
$$ LANGUAGE sql;



CREATE TABLE remembered_guids(
    guid UUID,
    user_id INTEGER,
    FOREIGN KEY (user_id) REFERENCES users(id)
);