--Articles
INSERT INTO articles (name, date, text) VALUES ('Test 1', '2011-11-11', '1 Lorem ipsum dolor sit amet consectetur adipisicing elit. A, blanditiis fugiat doloremque. Nulla vel ipsum cum veniam esse ipsam similique eius nesciunt non eos explicabo, modi nam iste error aspernatur?');
INSERT INTO articles (name, date, text) VALUES ('Qwerty', '2012-12-12', '2 Ipsum dolor sit amet consectetur adipisicing elit. A, blanditiis fugiat doloremque. Nulla vel ipsum cum veniam esse ipsam similique eius nesciunt non eos explicabo, modi nam iste error aspernatur?');
INSERT INTO articles (name, date, text) VALUES ('Abc', '2001-11-11', '3 Dolor sit amet consectetur adipisicing elit. A, blanditiis fugiat doloremque. Nulla vel ipsum cum veniam esse ipsam similique eius nesciunt non eos explicabo, modi nam iste error aspernatur?');
INSERT INTO articles (name, date, text) VALUES ('Ghjklz', '1011-10-01', '4 Sit amet consectetur adipisicing elit. A, blanditiis fugiat doloremque. Nulla vel ipsum cum veniam esse ipsam similique eius nesciunt non eos explicabo, modi nam iste error aspernatur?');
INSERT INTO articles (name, date, text) VALUES ('Cat', '2020-11-20', '5 Amet consectetur adipisicing elit. A, blanditiis fugiat doloremque. Nulla vel ipsum cum veniam esse ipsam similique eius nesciunt non eos explicabo, modi nam iste error aspernatur?');
INSERT INTO articles (name, date, text) VALUES ('Test 2', '2000-01-01', '6 Consectetur adipisicing elit. A, blanditiis fugiat doloremque. Nulla vel ipsum cum veniam esse ipsam similique eius nesciunt non eos explicabo, modi nam iste error aspernatur?');

--REFRESH MATERIALIZED VIEW articles_with_tags;

--People
INSERT INTO people (name, position, age, country, photo) VALUES ('Путин, Владимир Владимирович', 'Президент', 68, 'Россия', 'putin');
INSERT INTO people (name, position, age, country, photo) VALUES ('Байден, Джо', 'Президент', 77, 'США', 'biden')