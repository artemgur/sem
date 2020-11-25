--Articles
INSERT INTO articles (id, name, date, text) VALUES (1, 'Test 1', '2011-11-11', '1 Lorem ipsum dolor sit amet consectetur adipisicing elit. A, blanditiis fugiat doloremque. Nulla vel ipsum cum veniam esse ipsam similique eius nesciunt non eos explicabo, modi nam iste error aspernatur?');
INSERT INTO articles (id, name, date, text) VALUES (2, 'Qwerty', '2012-12-12', '2 Ipsum dolor sit amet consectetur adipisicing elit. A, blanditiis fugiat doloremque. Nulla vel ipsum cum veniam esse ipsam similique eius nesciunt non eos explicabo, modi nam iste error aspernatur?');
INSERT INTO articles (id, name, date, text) VALUES (3, 'Abc', '2001-11-11', '3 Dolor sit amet consectetur adipisicing elit. A, blanditiis fugiat doloremque. Nulla vel ipsum cum veniam esse ipsam similique eius nesciunt non eos explicabo, modi nam iste error aspernatur?');
INSERT INTO articles (id, name, date, text) VALUES (4, 'Ghjklz', '1011-10-01', '4 Sit amet consectetur adipisicing elit. A, blanditiis fugiat doloremque. Nulla vel ipsum cum veniam esse ipsam similique eius nesciunt non eos explicabo, modi nam iste error aspernatur?');
INSERT INTO articles (id, name, date, text) VALUES (5, 'Cat', '2020-11-20', '5 Amet consectetur adipisicing elit. A, blanditiis fugiat doloremque. Nulla vel ipsum cum veniam esse ipsam similique eius nesciunt non eos explicabo, modi nam iste error aspernatur?');
INSERT INTO articles (id, name, date, text) VALUES (6, 'Test 2', '2000-01-01', '6 Consectetur adipisicing elit. A, blanditiis fugiat doloremque. Nulla vel ipsum cum veniam esse ipsam similique eius nesciunt non eos explicabo, modi nam iste error aspernatur?');

--REFRESH MATERIALIZED VIEW articles_with_tags;

--People
INSERT INTO people (name, position, age, country) VALUES ('Путин, Владимир Владимирович', 'Президент', 68, 'Россия');
INSERT INTO people (name, position, age, country) VALUES ('Байден, Джо', 'Президент', 77, 'США');

INSERT INTO tags_article VALUES (1, 'США');
INSERT INTO tags_article VALUES (1, 'Россия');
INSERT INTO tags_article VALUES (2, 'Китай');
INSERT INTO tags_article VALUES (2, 'Северная Корея');
INSERT INTO tags_article VALUES (3, 'Украина');
INSERT INTO tags_article VALUES (4, 'США');
INSERT INTO tags_article VALUES (5, 'Китай');
INSERT INTO tags_article VALUES (6, 'Украина');
