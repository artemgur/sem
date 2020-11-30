--Articles
INSERT INTO articles (id, name, date) VALUES (1, 'Test 1', '2011-11-11');
INSERT INTO articles (id, name, date) VALUES (2, 'Qwerty', '2012-12-12');
INSERT INTO articles (id, name, date) VALUES (3, 'Abc', '2001-11-11');
INSERT INTO articles (id, name, date) VALUES (4, 'Ghjklz', '1011-10-01');
INSERT INTO articles (id, name, date) VALUES (5, 'Cat', '2020-11-20');
INSERT INTO articles (id, name, date) VALUES (6, 'Test 2', '2000-01-01');

--People
INSERT INTO people (id, name, post, age, country) VALUES (1, 'Путин, Владимир Владимирович', 'Президент', 68, 'Россия');
INSERT INTO people (id, name, post, age, country) VALUES (2, 'Байден, Джо', 'Президент', 77, 'США');

INSERT INTO tags_article VALUES (1, 'США');
INSERT INTO tags_article VALUES (1, 'Россия');
INSERT INTO tags_article VALUES (2, 'Китай');
INSERT INTO tags_article VALUES (2, 'Северная Корея');
INSERT INTO tags_article VALUES (3, 'Украина');
INSERT INTO tags_article VALUES (4, 'США');
INSERT INTO tags_article VALUES (5, 'Китай');
INSERT INTO tags_article VALUES (6, 'Украина');

INSERT INTO favorite_articles VALUES (1, 1);
INSERT INTO favorite_articles VALUES (1, 5);

INSERT INTO tags_people VALUES (1, 'Россия');
INSERT INTO tags_people VALUES (2, 'США');

INSERT INTO debates (id, name, text, date) VALUES (1, 'Test Debate', 'Lorem Ipsum', '2012-10-12');
INSERT INTO debates_users (user_id, debate_id) VALUES (1,1);

INSERT INTO tags_debates VALUES (1, 'Россия');

INSERT INTO comments (user_id, debate_id, date, opinion, text) VALUES (1, 1, '2012-10-11', true, 'qwe');
INSERT INTO comments (user_id, debate_id, date, opinion, text) VALUES (1, 1, '2012-10-12', true, '13');
INSERT INTO comments (user_id, debate_id, date, opinion, text) VALUES (2, 1, '2012-10-13', true, 'old comment');
INSERT INTO comments (user_id, debate_id, date, opinion, text) VALUES (2, 1, '2012-10-14', true, 'new comment');

INSERT INTO comments (user_id, debate_id, date, opinion, text) VALUES (2, 1, '2011-10-10', false, 'new comment against');
INSERT INTO comments (user_id, debate_id, date, opinion, text) VALUES (1, 1, '2011-10-13', false, 'rty');
INSERT INTO comments (user_id, debate_id, date, opinion, text) VALUES (1, 1, '2011-10-09', false, '53');
INSERT INTO comments (user_id, debate_id, date, opinion, text) VALUES (2, 1, '2011-10-12', false, 'old comment against');



-- REFRESH MATERIALIZED VIEW articles_with_tags;
-- REFRESH MATERIALIZED VIEW people_with_tags;

